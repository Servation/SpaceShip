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
    Public Property special As Integer
    Public Property worth As Integer
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
                If _special = 1 Or _special = 2 Then
                    G.DrawPolygon(New Pen(Color.Goldenrod), points)
                    G.FillPolygon(New SolidBrush(Color.Gold), points)
                    points = {New Point(_x + 33, _y + 20), New Point(_x + 47, _y + 9), New Point(_x + 52, _y + 7), New Point(_x + 53, _y + 13), New Point(_x + 44, _y + 27), New Point(_x + 36, _y + 27)}
                    G.DrawPolygon(New Pen(Color.Black), points)
                    G.FillPolygon(New SolidBrush(Color.Gold), points)
                    points = {New Point(_x + 48, _y + 31), New Point(_x + 50, _y + 26), New Point(_x + 66, _y + 30), New Point(_x + 51, _y + 35)}
                    G.DrawPolygon(New Pen(Color.Black), points)
                    G.FillPolygon(New SolidBrush(Color.Gold), points)
                    points = {New Point(_x + 14, _y + 60), New Point(_x + 15, _y + 68), New Point(_x + 29, _y + 56), New Point(_x + 30, _y + 50), New Point(_x + 23, _y + 48)}
                    G.DrawPolygon(New Pen(Color.Black), points)
                    G.FillPolygon(New SolidBrush(Color.Gold), points)
                ElseIf _special = 3 Then
                    G.DrawPolygon(New Pen(Color.LightSteelBlue), points)
                    G.FillPolygon(New SolidBrush(Color.SteelBlue), points)
                    points = {New Point(_x + 16, _y + 7), New Point(_x + 32, _y + 13), New Point(_x + 30, _y + 20), New Point(_x + 19, _y + 27), New Point(_x + 12, _y + 27), New Point(_x + 10, _y + 12)}
                    G.DrawPolygon(New Pen(Color.Black), points)
                    G.FillPolygon(New SolidBrush(Color.SteelBlue), points)
                    points = {New Point(_x + 39, _y + 45), New Point(_x + 46, _y + 43), New Point(_x + 54, _y + 59), New Point(_x + 50, _y + 64), New Point(_x + 36, _y + 52)}
                    G.DrawPolygon(New Pen(Color.Black), points)
                    G.FillPolygon(New SolidBrush(Color.SteelBlue), points)
                Else
                    G.DrawPolygon(New Pen(Color.BlueViolet), points)
                    G.FillPolygon(New SolidBrush(Color.FromArgb(100, 90, 110)), points)
                End If
            Else
                If _special = 1 Or _special = 2 Then
                    G.DrawPolygon(New Pen(Color.Gold), points)
                    G.FillPolygon(New SolidBrush(Color.FromArgb(130, 120, 90)), points)
                    points = {New Point(_x + 33, _y + 20), New Point(_x + 47, _y + 9), New Point(_x + 52, _y + 7), New Point(_x + 53, _y + 13), New Point(_x + 44, _y + 27), New Point(_x + 36, _y + 27)}
                    G.DrawPolygon(New Pen(Color.Black), points)
                    G.FillPolygon(New SolidBrush(Color.Gold), points)
                    points = {New Point(_x + 48, _y + 31), New Point(_x + 50, _y + 26), New Point(_x + 66, _y + 30), New Point(_x + 51, _y + 35)}
                    G.DrawPolygon(New Pen(Color.Black), points)
                    G.FillPolygon(New SolidBrush(Color.Gold), points)
                    points = {New Point(_x + 14, _y + 60), New Point(_x + 15, _y + 68), New Point(_x + 29, _y + 56), New Point(_x + 30, _y + 50), New Point(_x + 23, _y + 48)}
                    G.DrawPolygon(New Pen(Color.Black), points)
                    G.FillPolygon(New SolidBrush(Color.Gold), points)
                ElseIf _special = 3 Then
                    G.DrawPolygon(New Pen(Color.LightSteelBlue), points)
                    G.FillPolygon(New SolidBrush(Color.FromArgb(90, 90, 110)), points)
                    points = {New Point(_x + 16, _y + 7), New Point(_x + 32, _y + 13), New Point(_x + 30, _y + 20), New Point(_x + 19, _y + 27), New Point(_x + 12, _y + 27), New Point(_x + 10, _y + 12)}
                    G.DrawPolygon(New Pen(Color.Black), points)
                    G.FillPolygon(New SolidBrush(Color.SteelBlue), points)
                    points = {New Point(_x + 39, _y + 45), New Point(_x + 46, _y + 43), New Point(_x + 54, _y + 59), New Point(_x + 50, _y + 64), New Point(_x + 36, _y + 52)}
                    G.DrawPolygon(New Pen(Color.Black), points)
                    G.FillPolygon(New SolidBrush(Color.SteelBlue), points)
                Else
                    G.DrawPolygon(New Pen(Color.Black), points)
                    G.FillPolygon(New SolidBrush(Color.FromArgb(100, 90, 90)), points)
                End If
            End If

        End If
    End Sub

    Public Sub Update(i As Decimal, n As Decimal, a As Decimal, b As Integer, s As Integer)
        _x += _speedX
        _y += _speedY
        _cX += _speedX
        _cY += _speedY
        If health <= 0 Then
            visible = False
        End If
        If _y > MainRect.Height + 90 Then
            _special = s
            _type = b
            _speedX = n
            _speedY = a
            _y = -60
            _x = i
            _cY = -30
            _cX = i + 30
            _visible = True
            If _special = 1 Or _special = 2 Then
                _health = 150
                _worth = 500
            ElseIf _special = 3 Then
                _health = 200
                _worth = 750
            Else
                _health = 100
                _worth = 15
            End If
        End If

    End Sub

End Class
