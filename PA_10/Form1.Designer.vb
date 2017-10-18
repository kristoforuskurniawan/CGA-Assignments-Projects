<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm 'FUck it let's just mix the clas HUAHAHAHA
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
        Me.MainCanvas = New System.Windows.Forms.PictureBox()
        Me.ButtonCopy = New System.Windows.Forms.Button()
        Me.ButtonCut = New System.Windows.Forms.Button()
        Me.ButtonPaste = New System.Windows.Forms.Button()
        Me.CoordinateLabel = New System.Windows.Forms.Label()
        Me.ButtonClear = New System.Windows.Forms.Button()
        Me.CoordinateLabel2 = New System.Windows.Forms.Label()
        CType(Me.MainCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainCanvas
        '
        Me.MainCanvas.Image = Global.Polygon_Clipping_PA_10.My.Resources.Resources.White_Background_2
        Me.MainCanvas.Location = New System.Drawing.Point(13, 13)
        Me.MainCanvas.Name = "MainCanvas"
        Me.MainCanvas.Size = New System.Drawing.Size(480, 480)
        Me.MainCanvas.TabIndex = 0
        Me.MainCanvas.TabStop = False
        '
        'ButtonCopy
        '
        Me.ButtonCopy.Location = New System.Drawing.Point(521, 78)
        Me.ButtonCopy.Name = "ButtonCopy"
        Me.ButtonCopy.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCopy.TabIndex = 1
        Me.ButtonCopy.Text = "Copy"
        Me.ButtonCopy.UseVisualStyleBackColor = True
        '
        'ButtonCut
        '
        Me.ButtonCut.Location = New System.Drawing.Point(521, 107)
        Me.ButtonCut.Name = "ButtonCut"
        Me.ButtonCut.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCut.TabIndex = 2
        Me.ButtonCut.Text = "Cut"
        Me.ButtonCut.UseVisualStyleBackColor = True
        '
        'ButtonPaste
        '
        Me.ButtonPaste.Location = New System.Drawing.Point(521, 136)
        Me.ButtonPaste.Name = "ButtonPaste"
        Me.ButtonPaste.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPaste.TabIndex = 3
        Me.ButtonPaste.Text = "Paste"
        Me.ButtonPaste.UseVisualStyleBackColor = True
        '
        'CoordinateLabel
        '
        Me.CoordinateLabel.AutoSize = True
        Me.CoordinateLabel.Location = New System.Drawing.Point(518, 24)
        Me.CoordinateLabel.Name = "CoordinateLabel"
        Me.CoordinateLabel.Size = New System.Drawing.Size(75, 13)
        Me.CoordinateLabel.TabIndex = 4
        Me.CoordinateLabel.Text = "X1 = 0, Y1 = 0"
        Me.CoordinateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonClear
        '
        Me.ButtonClear.Location = New System.Drawing.Point(521, 166)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClear.TabIndex = 5
        Me.ButtonClear.Text = "Clear"
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'CoordinateLabel2
        '
        Me.CoordinateLabel2.AutoSize = True
        Me.CoordinateLabel2.Location = New System.Drawing.Point(518, 37)
        Me.CoordinateLabel2.Name = "CoordinateLabel2"
        Me.CoordinateLabel2.Size = New System.Drawing.Size(75, 13)
        Me.CoordinateLabel2.TabIndex = 6
        Me.CoordinateLabel2.Text = "X2 = 0, Y2 = 0"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 506)
        Me.Controls.Add(Me.CoordinateLabel2)
        Me.Controls.Add(Me.ButtonClear)
        Me.Controls.Add(Me.CoordinateLabel)
        Me.Controls.Add(Me.ButtonPaste)
        Me.Controls.Add(Me.ButtonCut)
        Me.Controls.Add(Me.ButtonCopy)
        Me.Controls.Add(Me.MainCanvas)
        Me.Name = "MainForm"
        Me.Text = "Polygon Clipping - Sutherland and Hodgman"
        CType(Me.MainCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MainCanvas As PictureBox
    Friend WithEvents ButtonCopy As Button
    Friend WithEvents ButtonCut As Button
    Friend WithEvents ButtonPaste As Button
    Friend WithEvents bitmapCanvas As Bitmap = Bitmap.FromFile("C:\\Users\\Kristoforus\\Documents\\CGA-Assignments-Projects\\PA_10\\Polygon_Clipping_PA_10\\White_Background_2.jpg")
    Friend WithEvents CoordinateLabel As Label
    Friend WithEvents ButtonClear As Button
    Friend WithEvents CoordinateLabel2 As Label
End Class