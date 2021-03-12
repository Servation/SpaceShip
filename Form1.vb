
Public Class Form1
    Private MainRect As Rectangle
    Private Ship As ShipStarter
    Private Ast(10) As Asteroid
    Private Stars(200) As Star
    Private keysPressed As New HashSet(Of Keys)
    Private gen As New Random

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
    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        keysPressed.Remove(e.KeyCode)
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        StartStars()
        StartShip()
        StartAsteroid()

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

        G.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        For i As Integer = 0 To Stars.Count - 1
            Stars(i).Show(G)
            Stars(i).Update()
        Next
        For i As Integer = 0 To Ast.Count - 1
            Ast(i).Show(G)
            If pointCircle(Ship.px0, Ship.py0, Ast(i).cX, Ast(i).cY, Ast(i).Radius) Then
                Ast(i).y = -60
                Ast(i).cX = Ast(i).x + 30
                Ast(i).cY = Ast(i).y + 30
            ElseIf pointCircle(Ship.px1, Ship.py1, Ast(i).cX, Ast(i).cY, Ast(i).Radius) Then
                Ast(i).y = -60
                Ast(i).cX = Ast(i).x + 30
                Ast(i).cY = Ast(i).y + 30
            ElseIf pointCircle(Ship.px2, Ship.py2, Ast(i).cX, Ast(i).cY, Ast(i).Radius) Then
                Ast(i).y = -60
                Ast(i).cX = Ast(i).x + 30
                Ast(i).cY = Ast(i).y + 30
            End If
            Ast(i).Update(gen.Next(0, MainRect.Width), gen.Next(-8, 8) * 0.1)
            Ast(i).visible = True
        Next
        Ship.Show(G)
        Ship.Update()
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

End Class
