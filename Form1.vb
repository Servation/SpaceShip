
Public Class Form1
    Private MainRect As Rectangle
    Private Ship As ShipStarter
    Private Ast(30) As Asteroid
    Private Stars(200) As Star
    Private keysPressed As New HashSet(Of Keys)
    Private gen As New Random
    Dim score As Double = 0
    Private showAst As Integer = 1
    Private dead As Boolean = True
    Private start As Boolean = True


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
        If e.KeyCode = Keys.Space And dead Then
            StartShip()
            StartAsteroid()
            StartStars()
            lblGameOver.Visible = False
            lblPressSpace.Visible = False
            lblRetry.Visible = False
            lblScore.Visible = True
            score = 0
            tmrScore.Start()
            dead = False
            Ship.alive = True
            If start Then
                start = False
            End If
        End If
    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        keysPressed.Remove(e.KeyCode)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
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
            Ast(i).speedX = gen.Next(-8, 8) * 0.1
            Ast(i).type = gen.Next(0, 4)
            Ast(i).cX = Ast(i).x + 30
        Next
    End Sub
    Private Sub StartStars()
        For i As Integer = 0 To Stars.Count - 1
            Stars(i) = New Star(MainRect)
            Stars(i).x = gen.Next(0, MainRect.Width)
            Stars(i).y = gen.Next(0, MainRect.Height)
            Stars(i).size = gen.Next(1, 5)
            Stars(i).speedY = gen.Next(1, 3) * 0.1
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
                If pointCircle(Ship.px0, Ship.py0, Ast(i).cX, Ast(i).cY, Ast(i).Radius) And Ship.health > 0 Then
                    Ast(i).y = -60
                    Ast(i).cX = Ast(i).x + 30
                    Ast(i).cY = Ast(i).y + 30
                    Ship.health -= 34
                    Ship.y += 30
                    Ship.py0 += 30
                    Ship.py1 += 30
                    Ship.py2 += 30
                    Ship.speedX = Ast(i).speedX
                    Ship.speedY = Ast(i).speedY
                ElseIf (pointCircle(Ship.px1, Ship.py1, Ast(i).cX, Ast(i).cY, Ast(i).Radius) Or pointCircle(Ship.px2, Ship.py2, Ast(i).cX, Ast(i).cY, Ast(i).Radius)) And Ship.health > 0 Then
                    Ast(i).y = -60
                    Ast(i).cX = Ast(i).x + 30
                    Ast(i).cY = Ast(i).y + 30
                    Ship.health -= 24
                    Ship.y += 20
                    Ship.py0 += 20
                    Ship.py1 += 20
                    Ship.py2 += 20
                    Ship.speedX = Ast(i).speedX
                    Ship.speedY = Ast(i).speedY
                End If
                Ast(i).Update(gen.Next(0, MainRect.Width), gen.Next(-8, 8) * 0.1)
                Ast(i).visible = True
                Ast(i).Show(G)
            Next
            Ship.Show(G)
            Ship.Update()
            lblHealth.Text = Ship.health
        Else
            lblHealth.Visible = False
            If Not start Then
                lblGameOver.Visible = True
                lblRetry.Visible = True
            End If
            tmrScore.Stop()
            dead = True
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
End Class
