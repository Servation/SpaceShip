Public Class Star
    Public Property x As Double
    Public Property y As Double
    Public Property speedY As Decimal
    Public Property size As Integer
    Private MainRect As Rectangle

    Sub New(MainRect As Rectangle)
        Me.MainRect = MainRect
        ResetVars()
    End Sub

    Private Sub ResetVars()
        'reset variables
    End Sub

    Public Sub Show(G As Graphics)
        G.FillEllipse(New SolidBrush(Color.FromArgb(250, 250, 250)), New Rectangle(_x - (_size / 2), _y - (_size / 2), _size, _size)
)
    End Sub

    Public Sub Update()
        _y += _speedY
        If _y > MainRect.Height + 90 Then
            _y = -3
        End If

    End Sub
End Class

