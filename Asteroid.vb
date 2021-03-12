Public Class Asteroid
    Public x As Decimal
    Public y As Decimal
    Public speedX As Decimal
    Public speedY As Decimal
    Public type As Integer
    Public visible As Boolean = False
    Private MainRect As Rectangle

    Sub New(MainRect As Rectangle)
        Me.MainRect = MainRect
        ResetVars()
    End Sub

    Private Sub ResetVars()
        'reset variables
        y = -60
        speedX = 0
    End Sub

    Public Sub Show(G As Graphics)
        If visible Then
            Dim points As Point()
            Select Case type
                Case 0
                    points = {New Point(x + 31, y + 2), New Point(x + 8, y + 4), New Point(x + 3, y + 28), New Point(x + 11, y + 45), New Point(x + 32, y + 63), New Point(x + 49, y + 50), New Point(x + 61, y + 29), New Point(x + 45, y + 9)}
                Case 1
                    points = {New Point(x + 30, y + 0), New Point(x + 9, y + 6), New Point(x + 0, y + 30), New Point(x + 13, y + 48), New Point(x + 30, y + 60), New Point(x + 48, y + 48), New Point(x + 60, y + 30), New Point(x + 43, y + 8)}
                Case 2
                    points = {New Point(x + 29, y + 0), New Point(x + 8, y + 6), New Point(x + 2, y + 32), New Point(x + 11, y + 47), New Point(x + 32, y + 59), New Point(x + 50, y + 50), New Point(x + 62, y + 33), New Point(x + 45, y + 4)}
                Case 3
                    points = {New Point(x + 31, y + 1), New Point(x + 8, y + 5), New Point(x + 1, y + 31), New Point(x + 12, y + 49), New Point(x + 31, y + 63), New Point(x + 47, y + 47), New Point(x + 59, y + 31), New Point(x + 42, y + 8)}
            End Select

            G.DrawPolygon(New Pen(Color.White), points)
            G.FillPolygon(New SolidBrush(Color.FromArgb(39, 16, 5)), points)
        End If
    End Sub

    Public Sub Update(i As Integer)
        x += speedX
        y += speedY

        If y > MainRect.Height + 90 Then
            y = 0
            x = i
        End If
    End Sub
End Class
