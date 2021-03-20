Public Class Weapon
    Public Property x As Double
    Public Property y As Double
    Public Property speedY As Decimal
    Public Property size As Integer
    Public Property visible As Boolean = False
    Private MainRect As Rectangle

    Sub New(MainRect As Rectangle)
        Me.MainRect = MainRect
        ResetVars()
    End Sub

    Private Sub ResetVars()
        'reset variables
    End Sub

    Public Sub Show(G As Graphics)
        If _visible Then
            G.FillPolygon(New SolidBrush(Color.BlueViolet), {New Point(x - 2, y), New Point(x - 2, y + 20), New Point(x + 2, y + 20), New Point(x + 2, y)})
        End If

    End Sub

    Public Sub Update()
        _y += _speedY
        If _y < -20 Then
            _visible = False
        End If
    End Sub
End Class
