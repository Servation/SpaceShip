Public Class ShipStarter
    Public x As Double
    Public y As Double
    Public speedX As Decimal
    Public speedY As Decimal
    Public maxSpeed = 5
    Private MainRect As Rectangle
    Public visible = True
    Public px0, py0, px1, py1, px2, py2 As Double
    Public alive As Boolean
    Public health As Integer = 100
    Private thrusters As Boolean = False

    Sub New(MainRect As Rectangle)
        Me.MainRect = MainRect
        ResetVars()
        alive = False
    End Sub

    Private Sub ResetVars()
        'reset variables
        x = MainRect.Width / 2 - 45
        y = MainRect.Height * 9 / 10 - 30
        speedX = 0
        speedY = -5
        px0 = 30 + x
        py0 = 0 + y
        px1 = 0 + x
        py1 = 65 + y
        px2 = 60 + x
        py2 = 65 + y

    End Sub

    Public Sub Show(G As Graphics)
        Dim points As Point()
        Dim point1 As Point()
        Dim point2 As Point()
        Dim point3 As Point()
        Dim healthP As Point()
        Dim healthP2 As Point()

        points = {New Point(x + 30, y + 3), New Point(x + 2, y + 40), New Point(x + 0, y + 65), New Point(x + 15, y + 50), New Point(x + 45, y + 50), New Point(x + 60, y + 65), New Point(x + 58, y + 40)}
        point1 = {New Point(x + 30, y + 0), New Point(x + 14, y + 30), New Point(x + 2, y + 60), New Point(x + 15, y + 50), New Point(x + 45, y + 50), New Point(x + 58, y + 60), New Point(x + 46, y + 30)}
        point2 = {New Point(x + 15, y + 50), New Point(x + 23, y + 54), New Point(x + 30, y + 56), New Point(x + 37, y + 54), New Point(x + 45, y + 50)}
        point3 = {New Point(x + 15, y + 50), New Point(x + 25, y + 52), New Point(x + 35, y + 52), New Point(x + 45, y + 50)}
        healthP = {New Point(949, 951), New Point(971, 951), New Point(971, 749), New Point(949, 749)}
        healthP2 = {New Point(950, 950), New Point(970, 950), New Point(970, 950 - health * 2), New Point(950, 950 - health * 2)}
        If visible Then
            G.FillPolygon(New SolidBrush(Color.GhostWhite), points)
            G.FillPolygon(New SolidBrush(Color.Crimson), point1)
        End If
        If thrusters Then
            G.FillPolygon(New SolidBrush(Color.LightBlue), point2)
        Else
            G.FillPolygon(New SolidBrush(Color.LightBlue), point3)
        End If
        G.FillPolygon(New SolidBrush(Color.White), healthP)
        If health > 45 Then
            G.FillPolygon(New SolidBrush(Color.Green), healthP2)
        ElseIf health > 25 Then
            G.FillPolygon(New SolidBrush(Color.Yellow), healthP2)
        Else
            G.FillPolygon(New SolidBrush(Color.Red), healthP2)
        End If


    End Sub

    Public Sub Update()
        If health <= 0 Then
            health = 0
            alive = False
        End If
        x += speedX
        y += speedY
        px0 += speedX
        py0 += speedY
        px1 += speedX
        py1 += speedY
        px2 += speedX
        py2 += speedY

        If x < 0 Then
            x = 0
            px0 = 30 + x
            px1 = 0 + x
            px2 = 60 + x
            speedX -= speedX
        End If
        If y < 25 Then
            y = 25
            py0 = 0 + y
            py1 = 65 + y
            py2 = 65 + y
            speedY -= speedY
        End If
        If x > MainRect.Width - 60 Then
            x = MainRect.Width - 60
            px0 = 30 + x
            px1 = 0 + x
            px2 = 60 + x
            speedX -= speedX
        End If
        If y > MainRect.Height - 65 Then
            y = MainRect.Height - 65
            py0 = 0 + y
            py1 = 65 + y
            py2 = 65 + y
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
        If speedY < -0.2 Then
            thrusters = True
        Else
            thrusters = False
        End If

    End Sub
End Class