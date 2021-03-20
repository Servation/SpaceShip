
Public Class Form1
    Private MainRect As Rectangle
    Private Ship As ShipStarter
    Private Ast(80) As Asteroid
    Private Stars(300) As Star
    Private Lasers(4) As Weapon
    Private logicalLaser As Integer
    Private keysPressed As New HashSet(Of Keys)
    Private gen As New Random
    Private score As Double = 0
    Private arrScore(9) As Double
    Private showAst As Integer = 1
    Private dead As Boolean = True
    Private start As Boolean = True
    Private updatingScore As Boolean

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
        If e.KeyCode = Keys.Enter And dead Then
            StartShip()
            StartAsteroid()
            StartStars()
            StartLaser()
            lblGameOver.Visible = False
            lblPressSpace.Visible = False
            lblRetry.Visible = False
            lblHScore.Visible = False
            lblScore.Visible = True
            score = 0
            tmrScore.Start()
            dead = False
            Ship.alive = True
            updatingScore = True
            If start Then
                start = False
            End If
        End If
        If Not dead Then
            If e.KeyCode = Keys.Space And Not Lasers(logicalLaser).visible Then
                Lasers(logicalLaser).visible = True
                Lasers(logicalLaser).x = Ship.px0
                Lasers(logicalLaser).y = Ship.py0
                Lasers(logicalLaser).speedY = -10
            End If
        End If

    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        keysPressed.Remove(e.KeyCode)
        If e.KeyCode = Keys.Space Then
            If logicalLaser < 4 Then
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
    End Sub

    Private Sub StartShip()
        MainRect = DisplayRectangle
        Ship = New ShipStarter(MainRect)
    End Sub

    Private Sub StartAsteroid()
        For i As Integer = 0 To Ast.Count - 1
            Ast(i) = New Asteroid(MainRect)
            Ast(i).x = gen.Next(0, MainRect.Width)
            Ast(i).speedY = gen.Next(20, 80) * 0.1
            Ast(i).speedX = gen.Next(-11, 11) * 0.2
            Ast(i).type = gen.Next(0, 4)
            Ast(i).cX = Ast(i).x + 30
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
                ElseIf (pointCircle(Ship.px1, Ship.py1, Ast(i).cX, Ast(i).cY, Ast(i).Radius) Or pointCircle(Ship.px2, Ship.py2, Ast(i).cX, Ast(i).cY, Ast(i).Radius)) And Ship.health > 0 And Ast(i).visible Then
                    Ast(i).health = 0
                    Ship.health -= 24
                    Ship.MoveY(20)
                    Ship.speedX = Ast(i).speedX
                    Ship.speedY = Ast(i).speedY
                End If
                Ast(i).Update(gen.Next(0, MainRect.Width), gen.Next(-8, 8) * 0.1)
                Ast(i).Show(G)
                For n As Integer = 0 To Lasers.Count - 1
                    If (pointCircle(Lasers(n).x, Lasers(n).y, Ast(i).cX, Ast(i).cY, Ast(i).Radius)) And Lasers(n).visible And Ast(i).visible Then
                        Ast(i).health -= 51
                        Lasers(n).visible = False
                        If Ast(i).health <= 0 Then
                            score += 25
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
                lblGameOver.Visible = True
                lblRetry.Visible = True
                lblHScore.Visible = True
            End If
            tmrScore.Stop()
            dead = True
            If updatingScore Then
                updateArrScore(score)
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
        score += 5
        lblScore.Text = score
        If showAst < 5 And score Mod 20 = 0 Then
            showAst += 1
        End If
        If showAst < Ast.Count - 1 And score Mod 100 = 0 Then
            showAst += 1
        End If
        If score Mod 20 = 0 Then
            If Ship.health < 100 Then
                Ship.health += 1
                If Ship.health > 100 Then
                    Ship.health = 100
                End If
            End If
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
        Else
            MessageBox.Show("File does not exist")
        End If
    End Sub
End Class
