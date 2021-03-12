Public Class ShipStarter
    Public x As Decimal
    Public y As Decimal
    Public speedX As Decimal
    Public speedY As Decimal
    Public maxSpeed = 5
    Private MainRect As Rectangle
    Public visible = True

    Sub New(MainRect As Rectangle)
        Me.MainRect = MainRect
        ResetVars()
    End Sub

    Private Sub ResetVars()
        'reset variables
        x = MainRect.Width / 2 - 45
        y = MainRect.Height * 9 / 10 - 30
        speedX = 0
        speedY = -5
    End Sub

    Public Sub Show(G As Graphics)
        Dim points As Point()
        Dim point1 As Point()

        points = {New Point(x + 30, y + 0), New Point(x + 2, y + 40), New Point(x + 0, y + 65), New Point(x + 15, y + 50), New Point(x + 45, y + 50), New Point(x + 60, y + 65), New Point(x + 58, y + 40)}
        point1 = {New Point(x + 30, y + 0), New Point(x + 14, y + 30), New Point(x + 2, y + 60), New Point(x + 15, y + 50), New Point(x + 45, y + 50), New Point(x + 58, y + 60), New Point(x + 46, y + 30)}
        If visible Then
            G.FillPolygon(New SolidBrush(Color.FromArgb(200, 100, 100)), points)
            G.FillPolygon(New SolidBrush(Color.FromArgb(100, 100, 100)), point1)
        End If
    End Sub

    Public Sub Update()
        x += speedX
        y += speedY
        'reset variables when the circle reaches the edge

        If x < 0 Then
            x = 0
            speedX -= speedX
        End If
        If y < -30 Then
            y = -30
            speedY -= speedY
        End If
        If x > MainRect.Width - 60 Then
            x = MainRect.Width - 60
            speedX -= speedX
        End If
        If y > MainRect.Height - 90 Then
            y = MainRect.Height - 90
            speedY -= speedY
        End If
        declerate()
    End Sub
    Public Sub declerate()
        If speedX > 0 Then
            speedX -= 0.2
        ElseIf speedX < 0 Then
            speedX += 0.2
        End If
        If speedY > 0 Then
            speedY -= 0.2
        ElseIf speedY < 0 Then
            speedY += 0.2
        End If

    End Sub
End Class