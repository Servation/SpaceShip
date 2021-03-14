Public Class Star
    Public x As Double
    Public y As Double
    Public speedY As Decimal
    Public size As Integer
    Private MainRect As Rectangle

    Sub New(MainRect As Rectangle)
        Me.MainRect = MainRect
        ResetVars()
    End Sub

    Private Sub ResetVars()
        'reset variables
    End Sub

    Public Sub Show(G As Graphics)
        G.FillEllipse(New SolidBrush(Color.FromArgb(250, 250, 250)), New Rectangle(x - (size / 2), y - (size / 2), size, size)
)
    End Sub

    Public Sub Update()
        y += speedY
        If y > MainRect.Height + 90 Then
            y = -3
        End If

    End Sub
End Class

