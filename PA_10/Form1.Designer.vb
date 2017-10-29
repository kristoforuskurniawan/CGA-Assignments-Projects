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
        Me.ButtonFinishPolygon = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveCtrlSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenCtrlOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutMeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.MainCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainCanvas
        '
        Me.MainCanvas.Image = Global.Polygon_Clipping_PA_10.My.Resources.Resources.White_Background_2
        Me.MainCanvas.Location = New System.Drawing.Point(12, 24)
        Me.MainCanvas.Name = "MainCanvas"
        Me.MainCanvas.Size = New System.Drawing.Size(480, 480)
        Me.MainCanvas.TabIndex = 0
        Me.MainCanvas.TabStop = False
        '
        'ButtonCopy
        '
        Me.ButtonCopy.Location = New System.Drawing.Point(506, 78)
        Me.ButtonCopy.Name = "ButtonCopy"
        Me.ButtonCopy.Size = New System.Drawing.Size(106, 23)
        Me.ButtonCopy.TabIndex = 1
        Me.ButtonCopy.Text = "Copy"
        Me.ButtonCopy.UseVisualStyleBackColor = True
        '
        'ButtonCut
        '
        Me.ButtonCut.Location = New System.Drawing.Point(506, 107)
        Me.ButtonCut.Name = "ButtonCut"
        Me.ButtonCut.Size = New System.Drawing.Size(106, 23)
        Me.ButtonCut.TabIndex = 2
        Me.ButtonCut.Text = "Cut"
        Me.ButtonCut.UseVisualStyleBackColor = True
        '
        'ButtonPaste
        '
        Me.ButtonPaste.Location = New System.Drawing.Point(506, 136)
        Me.ButtonPaste.Name = "ButtonPaste"
        Me.ButtonPaste.Size = New System.Drawing.Size(106, 23)
        Me.ButtonPaste.TabIndex = 3
        Me.ButtonPaste.Text = "Paste"
        Me.ButtonPaste.UseVisualStyleBackColor = True
        '
        'CoordinateLabel
        '
        Me.CoordinateLabel.AutoSize = True
        Me.CoordinateLabel.Location = New System.Drawing.Point(518, 24)
        Me.CoordinateLabel.Name = "CoordinateLabel"
        Me.CoordinateLabel.Size = New System.Drawing.Size(63, 13)
        Me.CoordinateLabel.TabIndex = 4
        Me.CoordinateLabel.Text = "X = 0, Y = 0"
        Me.CoordinateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonClear
        '
        Me.ButtonClear.Location = New System.Drawing.Point(506, 166)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(106, 23)
        Me.ButtonClear.TabIndex = 5
        Me.ButtonClear.Text = "Clear"
        Me.ButtonClear.UseVisualStyleBackColor = True
        '
        'ButtonFinishPolygon
        '
        Me.ButtonFinishPolygon.Location = New System.Drawing.Point(506, 49)
        Me.ButtonFinishPolygon.Name = "ButtonFinishPolygon"
        Me.ButtonFinishPolygon.Size = New System.Drawing.Size(106, 23)
        Me.ButtonFinishPolygon.TabIndex = 6
        Me.ButtonFinishPolygon.Text = "Finish Polygon"
        Me.ButtonFinishPolygon.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(624, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveCtrlSToolStripMenuItem, Me.OpenCtrlOToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveCtrlSToolStripMenuItem
        '
        Me.SaveCtrlSToolStripMenuItem.Name = "SaveCtrlSToolStripMenuItem"
        Me.SaveCtrlSToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SaveCtrlSToolStripMenuItem.Text = "Save (Ctrl+S)"
        '
        'OpenCtrlOToolStripMenuItem
        '
        Me.OpenCtrlOToolStripMenuItem.Name = "OpenCtrlOToolStripMenuItem"
        Me.OpenCtrlOToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OpenCtrlOToolStripMenuItem.Text = "Open (Ctrl+O)"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutMeToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'AboutMeToolStripMenuItem
        '
        Me.AboutMeToolStripMenuItem.Name = "AboutMeToolStripMenuItem"
        Me.AboutMeToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AboutMeToolStripMenuItem.Text = "About Me"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 522)
        Me.Controls.Add(Me.ButtonFinishPolygon)
        Me.Controls.Add(Me.ButtonClear)
        Me.Controls.Add(Me.CoordinateLabel)
        Me.Controls.Add(Me.ButtonPaste)
        Me.Controls.Add(Me.ButtonCut)
        Me.Controls.Add(Me.ButtonCopy)
        Me.Controls.Add(Me.MainCanvas)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.Text = "Polygon Clipping - Sutherland and Hodgman"
        CType(Me.MainCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MainCanvas As PictureBox
    Friend WithEvents ButtonCopy As Button
    Friend WithEvents ButtonCut As Button
    Friend WithEvents ButtonPaste As Button
    Friend WithEvents bitmapCanvas As Bitmap = Bitmap.FromFile("C:\\Users\\Kristoforus\\Documents\\CGA-Assignments-Projects\\PA_10\\Polygon_Clipping_PA_10\\White_Background_2.jpg")
    Friend WithEvents myGraphics As Graphics = Graphics.FromImage(bitmapCanvas) 'Graphic from bitmap canvas to be drawn with pen
    Friend WithEvents myPen As Pen = Pens.Black 'Pen for drawing on bitmap canvas
    Friend WithEvents CoordinateLabel As Label
    Friend WithEvents ButtonClear As Button
    Friend WithEvents ButtonFinishPolygon As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveCtrlSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenCtrlOToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutMeToolStripMenuItem As ToolStripMenuItem
End Class