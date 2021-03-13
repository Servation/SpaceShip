<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lblHealth = New System.Windows.Forms.Label()
        Me.lblGameOver = New System.Windows.Forms.Label()
        Me.lblPressSpace = New System.Windows.Forms.Label()
        Me.lblRetry = New System.Windows.Forms.Label()
        Me.tmrScore = New System.Windows.Forms.Timer(Me.components)
        Me.lblScore = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'lblHealth
        '
        Me.lblHealth.AutoSize = True
        Me.lblHealth.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblHealth.Font = New System.Drawing.Font("Nirmala UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHealth.ForeColor = System.Drawing.Color.Lime
        Me.lblHealth.Location = New System.Drawing.Point(816, 884)
        Me.lblHealth.Name = "lblHealth"
        Me.lblHealth.Size = New System.Drawing.Size(0, 50)
        Me.lblHealth.TabIndex = 0
        '
        'lblGameOver
        '
        Me.lblGameOver.AutoSize = True
        Me.lblGameOver.BackColor = System.Drawing.Color.Black
        Me.lblGameOver.Font = New System.Drawing.Font("Nirmala UI", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGameOver.ForeColor = System.Drawing.Color.Red
        Me.lblGameOver.Location = New System.Drawing.Point(319, 379)
        Me.lblGameOver.Name = "lblGameOver"
        Me.lblGameOver.Size = New System.Drawing.Size(373, 86)
        Me.lblGameOver.TabIndex = 1
        Me.lblGameOver.Text = "Game Over"
        Me.lblGameOver.Visible = False
        '
        'lblPressSpace
        '
        Me.lblPressSpace.AutoSize = True
        Me.lblPressSpace.BackColor = System.Drawing.Color.Black
        Me.lblPressSpace.Font = New System.Drawing.Font("Nirmala UI", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPressSpace.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblPressSpace.Location = New System.Drawing.Point(181, 261)
        Me.lblPressSpace.Name = "lblPressSpace"
        Me.lblPressSpace.Size = New System.Drawing.Size(635, 86)
        Me.lblPressSpace.TabIndex = 2
        Me.lblPressSpace.Text = "Press Space To Start"
        '
        'lblRetry
        '
        Me.lblRetry.AutoSize = True
        Me.lblRetry.BackColor = System.Drawing.Color.Black
        Me.lblRetry.Font = New System.Drawing.Font("Nirmala UI", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRetry.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblRetry.Location = New System.Drawing.Point(181, 474)
        Me.lblRetry.Name = "lblRetry"
        Me.lblRetry.Size = New System.Drawing.Size(652, 86)
        Me.lblRetry.TabIndex = 3
        Me.lblRetry.Text = "Press Space To Retry"
        Me.lblRetry.Visible = False
        '
        'tmrScore
        '
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.BackColor = System.Drawing.Color.Black
        Me.lblScore.Font = New System.Drawing.Font("Nirmala UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblScore.Location = New System.Drawing.Point(465, 25)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(43, 50)
        Me.lblScore.TabIndex = 5
        Me.lblScore.Text = "0"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(993, 961)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.lblRetry)
        Me.Controls.Add(Me.lblPressSpace)
        Me.Controls.Add(Me.lblGameOver)
        Me.Controls.Add(Me.lblHealth)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblHealth As Label
    Friend WithEvents lblGameOver As Label
    Friend WithEvents lblPressSpace As Label
    Friend WithEvents lblRetry As Label
    Friend WithEvents tmrScore As Timer
    Friend WithEvents lblScore As Label
End Class
