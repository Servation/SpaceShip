
Public Class Form1
    Private MainRect As Rectangle
    Private Ship As ShipStarter
    Private Ast(10) As Asteroid
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
        StartShip()
        startAst()
    End Sub

    Private Sub StartShip()
        MainRect = DisplayRectangle
        Ship = New ShipStarter(MainRect)
    End Sub

    Private Sub startAst()
        For i As Integer = 0 To Ast.Count - 1
            Ast(i) = New Asteroid(MainRect)
            Ast(i).x = gen.Next(0, MainRect.Width)
            Ast(i).speedY = gen.Next(20, 80) * 0.1
            Ast(i).speedX = gen.Next(-8, 8) * 0.1
            Ast(i).type = gen.Next(0, 4)
        Next

    End Sub


    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim G As Graphics = e.Graphics

        G.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        For i As Integer = 0 To Ast.Count - 1
            Ast(i).Show(G)
            Ast(i).Update(gen.Next(0, MainRect.Width))
            Ast(i).visible = True
        Next
        Ship.Show(G)
        Ship.Update()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        StartShip()
    End Sub

    Public Shared Function DistanceBetween(p1 As Point, p2 As Point) As Single
        Return Math.Sqrt((Math.Abs(p2.X - p1.X) ^ 2) + (Math.Abs(p2.Y - p1.Y) ^ 2))
    End Function

End Class
