Public Class ShipStarter
    Public Property x As Double
    Public Property y As Double
    Public Property speedX As Decimal
    Public Property speedY As Decimal
    Public Property maxSpeed = 5
    Public Property visible = True
    Public Property px0 As Double
    Public Property py0 As Double
    Public Property px1 As Double
    Public Property py1 As Double
    Public Property px2 As Double
    Public Property py2 As Double
    Public Property alive As Boolean
    Public Property health As Integer = 100
    Private thrusters As Boolean = False
    Private MainRect As Rectangle

    Sub New(MainRect As Rectangle)
        Me.MainRect = MainRect
        ResetVars()
        _alive = False
    End Sub

    Private Sub ResetVars()
        'reset variables
        _x = MainRect.Width / 2 - 45
        _y = MainRect.Height * 9 / 10 - 30
        _speedX = 0
        _speedY = -5
        _px0 = 30 + _x
        _py0 = 0 + _y
        _px1 = 0 + _x
        _py1 = 65 + _y
        _px2 = 60 + _x
        _py2 = 65 + _y

    End Sub

    Public Sub Show(G As Graphics)
        Dim points As Point()
        Dim point1 As Point()
        Dim point2 As Point()
        Dim point3 As Point()
        Dim healthP As Point()
        Dim healthP2 As Point()

        points = {New Point(_x + 30, _y + 3), New Point(_x + 2, _y + 40), New Point(_x + 0, _y + 65), New Point(_x + 15, _y + 50), New Point(_x + 45, _y + 50), New Point(_x + 60, _y + 65), New Point(_x + 58, _y + 40)}
        point1 = {New Point(_x + 30, _y + 0), New Point(_x + 14, _y + 30), New Point(_x + 2, _y + 60), New Point(_x + 15, _y + 50), New Point(_x + 45, _y + 50), New Point(_x + 58, _y + 60), New Point(_x + 46, _y + 30)}
        point2 = {New Point(_x + 15, _y + 50), New Point(_x + 23, _y + 54), New Point(_x + 30, _y + 56), New Point(_x + 37, _y + 54), New Point(_x + 45, _y + 50)}
        point3 = {New Point(_x + 15, _y + 50), New Point(_x + 25, _y + 52), New Point(_x + 35, _y + 52), New Point(_x + 45, _y + 50)}
        healthP = {New Point(949, 951), New Point(971, 951), New Point(971, 749), New Point(949, 749)}
        healthP2 = {New Point(950, 950), New Point(970, 950), New Point(970, 950 - _health * 2), New Point(950, 950 - _health * 2)}
        If _visible Then
            G.FillPolygon(New SolidBrush(Color.GhostWhite), points)
            G.FillPolygon(New SolidBrush(Color.Crimson), point1)
        End If
        If thrusters Then
            G.FillPolygon(New SolidBrush(Color.LightBlue), point2)
        Else
            G.FillPolygon(New SolidBrush(Color.LightBlue), point3)
        End If
        G.FillPolygon(New SolidBrush(Color.White), healthP)
        If _health > 45 Then
            G.FillPolygon(New SolidBrush(Color.Green), healthP2)
        ElseIf _health > 25 Then
            G.FillPolygon(New SolidBrush(Color.Yellow), healthP2)
        Else
            G.FillPolygon(New SolidBrush(Color.Red), healthP2)
        End If


    End Sub

    Public Sub Update()
        If _health <= 0 Then
            _health = 0
            _alive = False
        End If
        _x += _speedX
        _y += _speedY
        _px0 += _speedX
        _py0 += _speedY
        _px1 += _speedX
        _py1 += _speedY
        _px2 += _speedX
        _py2 += _speedY

        If _x < 0 Then
            _x = 0
            _px0 = 30 + _x
            _px1 = 0 + _x
            _px2 = 60 + _x
            _speedX -= _speedX
        End If
        If _y < 25 Then
            _y = 25
            _py0 = 0 + _y
            _py1 = 65 + _y
            _py2 = 65 + _y
            _speedY -= _speedY
        End If
        If _x > MainRect.Width - 60 Then
            _x = MainRect.Width - 60
            _px0 = 30 + _x
            _px1 = 0 + _x
            _px2 = 60 + _x
            _speedX -= _speedX
        End If
        If _y > MainRect.Height - 65 Then
            _y = MainRect.Height - 65
            _py0 = 0 + _y
            _py1 = 65 + _y
            _py2 = 65 + _y
            _speedY -= _speedY
        End If
        declerate()
    End Sub
    Public Sub declerate()
        If _speedX > 0 Then
            _speedX -= 0.2
        ElseIf _speedX < 0 Then
            _speedX += 0.2
        End If
        If _speedY > 0 Then
            _speedY -= 0.2
        ElseIf _speedY < 0 Then
            _speedY += 0.2
        End If
        If _speedY < -0.2 Then
            thrusters = True
        Else
            thrusters = False
        End If

    End Sub

    Public Sub MoveY(i As Double)
        _y += i
        _py0 += i
        _py1 += i
        _py2 += i
    End Sub
End Class