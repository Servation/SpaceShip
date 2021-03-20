Public Class Asteroid
    Public Property x As Double
    Public Property y As Double
    Public Property cX As Double
    Public Property cY As Double
    Public Property Radius As Double
    Public Property speedX As Decimal
    Public Property speedY As Decimal
    Public Property type As Integer
    Public Property visible As Boolean = True
    Public Property health As Integer
    Private MainRect As Rectangle

    Sub New(MainRect As Rectangle)
        Me.MainRect = MainRect
        ResetVars()
    End Sub

    Private Sub ResetVars()
        'reset variables
        _y = -60
        _Radius = 30
        _cY = -30
    End Sub

    Public Sub Show(G As Graphics)
        If _visible Then
            Dim points As Point()
            Select Case _type
                Case 0
                    points = {New Point(_x + 31, _y + 2), New Point(_x + 8, _y + 4), New Point(_x + 3, _y + 28), New Point(_x + 11, _y + 45), New Point(_x + 32, _y + 62), New Point(_x + 49, _y + 50), New Point(_x + 61, _y + 29), New Point(_x + 45, _y + 9)}
                Case 1
                    points = {New Point(_x + 30, _y + 0), New Point(_x + 9, _y + 6), New Point(_x + 0, _y + 30), New Point(_x + 13, _y + 48), New Point(_x + 30, _y + 60), New Point(_x + 48, _y + 48), New Point(_x + 60, _y + 30), New Point(_x + 43, _y + 8)}
                Case 2
                    points = {New Point(_x + 29, _y + 0), New Point(_x + 8, _y + 6), New Point(_x + 2, _y + 32), New Point(_x + 11, _y + 47), New Point(_x + 32, _y + 59), New Point(_x + 50, _y + 50), New Point(_x + 62, _y + 33), New Point(_x + 45, _y + 4)}
                Case 3
                    points = {New Point(_x + 31, _y + 1), New Point(_x + 8, _y + 5), New Point(_x + 1, _y + 31), New Point(_x + 12, _y + 49), New Point(_x + 31, _y + 61), New Point(_x + 47, _y + 47), New Point(_x + 59, _y + 31), New Point(_x + 42, _y + 8)}
            End Select


            If health < 99 Then
                G.DrawPolygon(New Pen(Color.Red), points)
            Else
                G.DrawPolygon(New Pen(Color.Yellow), points)
            End If
            G.FillPolygon(New SolidBrush(Color.FromArgb(100, 90, 90)), points)
        End If
    End Sub

    Public Sub Update(i As Decimal, n As Decimal)
        _x += _speedX
        _y += _speedY
        _cX += _speedX
        _cY += _speedY
        If health <= 0 Then
            visible = False
        End If
        If _y > MainRect.Height + 90 Then
            _speedX = n
            _y = -60
            _x = i
            _cY = -30
            _cX = i + 30
            _visible = True
            _health = 100
        End If

    End Sub

End Class
