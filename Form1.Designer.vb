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
        Me.lblRetry = New System.Windows.Forms.Label()
        Me.tmrScore = New System.Windows.Forms.Timer(Me.components)
        Me.lblScore = New System.Windows.Forms.Label()
        Me.lblHScore = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pbGameOver = New System.Windows.Forms.PictureBox()
        Me.pbTitle = New System.Windows.Forms.PictureBox()
        CType(Me.pbGameOver, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTitle, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblGameOver.BackColor = System.Drawing.Color.Transparent
        Me.lblGameOver.Font = New System.Drawing.Font("Nirmala UI", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGameOver.ForeColor = System.Drawing.Color.Crimson
        Me.lblGameOver.Location = New System.Drawing.Point(306, 315)
        Me.lblGameOver.Name = "lblGameOver"
        Me.lblGameOver.Size = New System.Drawing.Size(363, 86)
        Me.lblGameOver.TabIndex = 1
        Me.lblGameOver.Text = "Game over"
        Me.lblGameOver.Visible = False
        '
        'lblRetry
        '
        Me.lblRetry.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblRetry.BackColor = System.Drawing.Color.Transparent
        Me.lblRetry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRetry.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRetry.Font = New System.Drawing.Font("Nirmala UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRetry.ForeColor = System.Drawing.Color.Crimson
        Me.lblRetry.Location = New System.Drawing.Point(381, 420)
        Me.lblRetry.Name = "lblRetry"
        Me.lblRetry.Size = New System.Drawing.Size(214, 72)
        Me.lblRetry.TabIndex = 0
        Me.lblRetry.Text = "Start"
        Me.lblRetry.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblRetry.UseMnemonic = False
        '
        'tmrScore
        '
        Me.tmrScore.Interval = 200
        '
        'lblScore
        '
        Me.lblScore.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.lblScore.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.lblScore.Font = New System.Drawing.Font("Nirmala UI", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblScore.Location = New System.Drawing.Point(438, 31)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(109, 50)
        Me.lblScore.TabIndex = 5
        Me.lblScore.Text = "0"
        Me.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblScore.Visible = False
        '
        'lblHScore
        '
        Me.lblHScore.AutoSize = True
        Me.lblHScore.BackColor = System.Drawing.Color.Transparent
        Me.lblHScore.Font = New System.Drawing.Font("Nirmala UI", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHScore.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.lblHScore.Location = New System.Drawing.Point(429, 532)
        Me.lblHScore.Name = "lblHScore"
        Me.lblHScore.Size = New System.Drawing.Size(127, 30)
        Me.lblHScore.TabIndex = 6
        Me.lblHScore.Text = "High Score:"
        Me.lblHScore.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Harlow Solid Italic", 72.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.BlueViolet
        Me.lblTitle.Location = New System.Drawing.Point(61, 187)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(862, 121)
        Me.lblTitle.TabIndex = 7
        Me.lblTitle.Text = "The Asteroid Miner"
        Me.lblTitle.Visible = False
        '
        'pbGameOver
        '
        Me.pbGameOver.Image = Global.SpaceShip.My.Resources.Resources.image__6_
        Me.pbGameOver.Location = New System.Drawing.Point(258, 338)
        Me.pbGameOver.Name = "pbGameOver"
        Me.pbGameOver.Size = New System.Drawing.Size(458, 50)
        Me.pbGameOver.TabIndex = 9
        Me.pbGameOver.TabStop = False
        Me.pbGameOver.Visible = False
        '
        'pbTitle
        '
        Me.pbTitle.Image = Global.SpaceShip.My.Resources.Resources.image__5_
        Me.pbTitle.Location = New System.Drawing.Point(153, 216)
        Me.pbTitle.Name = "pbTitle"
        Me.pbTitle.Size = New System.Drawing.Size(770, 70)
        Me.pbTitle.TabIndex = 8
        Me.pbTitle.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(25, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(984, 961)
        Me.Controls.Add(Me.pbGameOver)
        Me.Controls.Add(Me.pbTitle)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblHScore)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.lblRetry)
        Me.Controls.Add(Me.lblGameOver)
        Me.Controls.Add(Me.lblHealth)
        Me.Cursor = System.Windows.Forms.Cursors.Cross
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1000, 1000)
        Me.MinimumSize = New System.Drawing.Size(1000, 1000)
        Me.Name = "Form1"
        Me.Text = "The Asteroid Miner"
        CType(Me.pbGameOver, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents lblHealth As Label
    Friend WithEvents lblGameOver As Label
    Friend WithEvents lblRetry As Label
    Friend WithEvents tmrScore As Timer
    Friend WithEvents lblScore As Label
    Friend WithEvents lblHScore As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents pbTitle As PictureBox
    Friend WithEvents pbGameOver As PictureBox
End Class
