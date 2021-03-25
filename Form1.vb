
Public Class Form1
    Private MainRect As Rectangle
    Private Ship As ShipStarter
    Private Ast(50) As Asteroid
    Private Stars(300) As Star
    Private Lasers(20) As Weapon
    Private logicalLaser As Integer
    Private keysPressed As New HashSet(Of Keys)
    Private gen As New Random
    Private score As Double = 0
    Private counter As Integer = 0
    Private arrScore(9) As Double
    Private showAst As Integer = 1
    Private dead As Boolean = True
    Private start As Boolean = True
    Private updatingScore As Boolean

    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" _
    (ByVal lpstrCommand As String, ByVal lpstrReturnString As String,
    ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If keysPressed.Contains(Keys.A) And Ship.speedX > -Ship.maxSpeed Then
            Ship.speedX -= 1
        End If
        If keysPressed.Contains(Keys.D) And Ship.speedX < Ship.maxSpeed Then
            Ship.speedX += 1
        End If
        If keysPressed.Contains(Keys.W) And Ship.speedY > -Ship.maxSpeed Then
            Ship.speedY -= 1
        End If
        If keysPressed.Contains(Keys.S) And Ship.speedY < Ship.maxSpeed Then
            Ship.speedY += 1
        End If
        Invalidate()
    End Sub
    Private Sub form1_keydown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        keysPressed.Add(e.KeyCode)
        If Not dead Then
            If e.KeyCode = Keys.Space And Not Lasers(logicalLaser).visible And Ship.energy >= 15 Then
                Lasers(logicalLaser).visible = True
                Lasers(logicalLaser).x = Ship.px0
                Lasers(logicalLaser).y = Ship.py0
                Lasers(logicalLaser).speedY = -15
                Ship.energy -= 15
                PlaySound("laser.wav", 1)
            End If
        End If
    End Sub
    Private Sub lblRetry_Click(sender As Object, e As EventArgs) Handles lblRetry.Click
        StartShip()
        StartAsteroid()
        StartStars()
        StartLaser()
        pbTitle.Visible = False
        pbGameOver.Visible = False
        lblRetry.Visible = False
        lblHScore.Visible = False
        lblScore.Visible = True
        score = 0
        tmrScore.Start()
        dead = False
        Ship.alive = True
        updatingScore = True
        PlaySound("Restart.wav", 3)
        Cursor.Hide()
        If start Then
            start = False
        End If
    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        keysPressed.Remove(e.KeyCode)
        If e.KeyCode = Keys.Space Then
            If logicalLaser < 10 Then
                logicalLaser += 1
            Else
                logicalLaser = 0
            End If
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        My.Computer.Audio.Play(My.Resources.ShipNoise, AudioPlayMode.BackgroundLoop)
        ReadFile()
        updateArrScore(score)
        lblRetry.BackColor = Color.FromArgb(100, 250, 250, 250)
        CopyResourceToDisk()
    End Sub

    Private Sub CopyResourceToDisk()
        If Not IO.File.Exists("laser.wav") Then
            Dim bts(CInt(My.Resources.laser.Length - 1)) As Byte
            My.Resources.laser.Read(bts, 0, bts.Length)
            IO.File.WriteAllBytes("laser.wav", bts)
        End If
        If Not IO.File.Exists("explosion.wav") Then
            Dim bts(CInt(My.Resources.impact.Length - 1)) As Byte
            My.Resources.impact.Read(bts, 0, bts.Length)
            IO.File.WriteAllBytes("explosion.wav", bts)
        End If
        If Not IO.File.Exists("ShipHit.wav") Then
            Dim bts(CInt(My.Resources.ShipHit.Length - 1)) As Byte
            My.Resources.ShipHit.Read(bts, 0, bts.Length)
            IO.File.WriteAllBytes("ShipHit.wav", bts)
        End If
        If Not IO.File.Exists("Restart.wav") Then
            Dim bts(CInt(My.Resources.Restart.Length - 1)) As Byte
            My.Resources.Restart.Read(bts, 0, bts.Length)
            IO.File.WriteAllBytes("Restart.wav", bts)
        End If
    End Sub

    Private Sub StartShip()
        MainRect = DisplayRectangle
        Ship = New ShipStarter(MainRect)
    End Sub

    Private Sub StartAsteroid()
        For i As Integer = 0 To Ast.Count - 1
            Ast(i) = New Asteroid(MainRect)
            Ast(i).x = gen.Next(0, MainRect.Width)
            Ast(i).speedY = gen.Next(20, 60) * 0.1
            Ast(i).speedX = gen.Next(-10, 10) * 0.2
            Ast(i).type = gen.Next(0, 4)
            Ast(i).cX = Ast(i).x + 30
            Ast(i).worth = 15
        Next
    End Sub
    Private Sub StartStars()
        For i As Integer = 0 To Stars.Count - 1
            Stars(i) = New Star(MainRect)
            Stars(i).x = gen.Next(0, MainRect.Width)
            Stars(i).y = gen.Next(0, MainRect.Height)
            Stars(i).size = gen.Next(1, 4)
            Stars(i).speedY = gen.Next(1, 10) * 0.1
        Next
    End Sub

    Private Sub StartLaser()
        For i As Integer = 0 To Lasers.Count - 1
            Lasers(i) = New Weapon(MainRect)
        Next
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim G As Graphics = e.Graphics
        Dim intScore As Integer = Integer.TryParse(lblScore.Text, intScore)

        G.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        For i As Integer = 0 To Stars.Count - 1
            Stars(i).Show(G)
            Stars(i).Update()
        Next
        If Ship.alive Then
            For i As Integer = 0 To showAst
                If pointCircle(Ship.px0, Ship.py0, Ast(i).cX, Ast(i).cY, Ast(i).Radius) And Ship.health > 0 And Ast(i).visible Then
                    Ast(i).health = 0
                    Ship.health -= 34
                    Ship.MoveY(30)
                    Ship.speedX = Ast(i).speedX
                    Ship.speedY = Ast(i).speedY
                    PlaySound("ShipHit.wav", 2)
                ElseIf (pointCircle(Ship.px1, Ship.py1, Ast(i).cX, Ast(i).cY, Ast(i).Radius) Or pointCircle(Ship.px2, Ship.py2, Ast(i).cX, Ast(i).cY, Ast(i).Radius)) And Ship.health > 0 And Ast(i).visible Then
                    Ast(i).health = 0
                    Ship.health -= 24
                    Ship.MoveY(20)
                    Ship.speedX = Ast(i).speedX
                    Ship.speedY = Ast(i).speedY
                    PlaySound("ShipHit.wav", 2)
                End If
                Ast(i).Update(gen.Next(0, MainRect.Width), gen.Next(-10, 10) * 0.2, gen.Next(20, 60) * 0.1, gen.Next(0, 4), gen.Next(0, 40))
                Ast(i).Show(G)
                For n As Integer = 0 To Lasers.Count - 1
                    If (pointCircle(Lasers(n).x, Lasers(n).y, Ast(i).cX, Ast(i).cY, Ast(i).Radius)) And Lasers(n).visible And Ast(i).visible Then
                        Ast(i).health -= 51
                        Lasers(n).visible = False
                        PlaySound("explosion.wav", 0)
                        If Ast(i).health <= 0 Then
                            score += Ast(i).worth
                        End If
                    End If
                Next
            Next
            For n As Integer = 0 To Lasers.Count - 1
                Lasers(n).Show(G)
                Lasers(n).Update()
            Next
            Ship.Show(G)
            Ship.Update()
            lblHealth.Text = Ship.health
        Else
            lblHealth.Visible = False
            If Not start Then
                'lblGameOver.Visible = True
                'lblTitle.Visible = True
                pbTitle.Visible = True
                pbGameOver.Visible = True
                lblRetry.Visible = True
                lblRetry.Text = "Restart"
                lblHScore.Visible = True
            End If
            tmrScore.Stop()
            dead = True
            If updatingScore Then
                updateArrScore(score)
                Cursor.Show()
                updatingScore = False
            End If
            showAst = 1
        End If
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        StartShip()
        StartAsteroid()
        StartStars()
    End Sub

    Private Function pointCircle(px As Decimal, py As Decimal, cx As Decimal, cy As Decimal, r As Decimal) As Boolean
        Dim distX As Decimal = px - cx
        Dim distY As Decimal = py - cy
        Dim distance = Math.Sqrt((distX * distX) + (distY * distY))
        Return distance <= r
    End Function

    Private Sub tmrScore_Tick(sender As Object, e As EventArgs) Handles tmrScore.Tick
        counter += 1
        lblScore.Text = score
        If Ship.energy <= 95 Then
            Ship.energy += 5
        End If
        If showAst < 5 And counter Mod 2 = 0 Then
            showAst += 1
        End If
        If showAst < Ast.Count - 1 And counter Mod 24 = 0 Then
            showAst += 1
        End If
        If counter Mod 10 = 0 Then
            score += 1
        End If
        If Ship.health < 100 And Ship.energy = 100 Then
            Ship.health += 1
        End If
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.Closed
        My.Computer.Audio.Stop()
        SaveToFile()
    End Sub

    Private Sub updateArrScore(s As Double)
        Dim last As Integer = arrScore.Count - 1
        If s > arrScore(last) Then
            arrScore(last) = s
        End If
        Array.Sort(arrScore)
        Array.Reverse(arrScore)
        Dim HighScore As String
        HighScore = "High Score:" + Environment.NewLine
        For Each s In arrScore
            If s > 0 Then
                HighScore &= s & Environment.NewLine
            End If
        Next s
        lblHScore.Text = HighScore
    End Sub

    Private Sub SaveToFile()
        Dim outFile As IO.StreamWriter
        outFile = IO.File.CreateText("HighScores.txt")

        For intSub As Integer = 0 To 9
            Dim HScore As Double

            HScore = arrScore(intSub) & ControlChars.NewLine

            outFile.WriteLine(HScore)

        Next
        outFile.Close()
    End Sub

    Private Sub ReadFile()
        Dim inFile As IO.StreamReader

        If IO.File.Exists("HighScores.txt") Then
            inFile = IO.File.OpenText("HighScores.txt")

            Dim fileText As String

            For i As Integer = 0 To 9
                fileText = inFile.ReadLine
                arrScore(i) = fileText
            Next i
            inFile.Close()
        End If
    End Sub

    Private Sub lblRetry_MouseEnter(sender As Object, e As EventArgs) Handles lblRetry.MouseEnter
        lblRetry.BackColor = Color.FromArgb(200, 255, 255, 255)
    End Sub

    Private Sub PlaySound(s As String, i As Integer)
        Try
            mciSendString("close myWAV" & i.ToString, Nothing, 0, 0)

            Dim fileName1 As String = s
            mciSendString("open " & ChrW(34) & fileName1 & ChrW(34) & " type mpegvideo alias myWAV" & i.ToString, Nothing, 0, 0)
            mciSendString("play myWAV" & i.ToString, Nothing, 0, 0)

            Dim Volume As Integer = 400
            mciSendString("setaudio myWAV" & i.ToString & " volume to " & Volume.ToString, Nothing, 0, 0)

        Catch ex As Exception
            Me.Text = ex.Message
        End Try
    End Sub

    Private Sub lblRetry_MouseLeave(sender As Object, e As EventArgs) Handles lblRetry.MouseLeave
        lblRetry.BackColor = Color.FromArgb(100, 250, 250, 250)
    End Sub
End Class
