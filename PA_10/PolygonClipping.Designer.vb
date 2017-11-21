<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PolygonClipping
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
        Me.coordinateLbl = New System.Windows.Forms.Label()
        Me.multipleBtn = New System.Windows.Forms.Button()
        Me.clippingBtn = New System.Windows.Forms.Button()
        Me.singleBtn = New System.Windows.Forms.Button()
        Me.refreshBtn = New System.Windows.Forms.Button()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.coorLbl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.modeLbl = New System.Windows.Forms.Label()
        Me.singleLbl = New System.Windows.Forms.Label()
        Me.polygonListBox = New System.Windows.Forms.ListBox()
        Me.coordinatesListBox = New System.Windows.Forms.ListBox()
        Me.multipleLbl = New System.Windows.Forms.Label()
        CType(Me.MainCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainCanvas
        '
        Me.MainCanvas.BackColor = System.Drawing.SystemColors.Window
        Me.MainCanvas.Location = New System.Drawing.Point(12, 27)
        Me.MainCanvas.Name = "MainCanvas"
        Me.MainCanvas.Size = New System.Drawing.Size(617, 348)
        Me.MainCanvas.TabIndex = 0
        Me.MainCanvas.TabStop = False
        '
        'coordinateLbl
        '
        Me.coordinateLbl.AutoSize = True
        Me.coordinateLbl.Location = New System.Drawing.Point(659, 202)
        Me.coordinateLbl.Name = "coordinateLbl"
        Me.coordinateLbl.Size = New System.Drawing.Size(88, 13)
        Me.coordinateLbl.TabIndex = 2
        Me.coordinateLbl.Text = "COORDINATES:"
        '
        'multipleBtn
        '
        Me.multipleBtn.Location = New System.Drawing.Point(94, 382)
        Me.multipleBtn.Name = "multipleBtn"
        Me.multipleBtn.Size = New System.Drawing.Size(75, 50)
        Me.multipleBtn.TabIndex = 4
        Me.multipleBtn.Text = "MULTIPLE POLYGON"
        Me.multipleBtn.UseVisualStyleBackColor = True
        '
        'clippingBtn
        '
        Me.clippingBtn.Location = New System.Drawing.Point(175, 381)
        Me.clippingBtn.Name = "clippingBtn"
        Me.clippingBtn.Size = New System.Drawing.Size(75, 52)
        Me.clippingBtn.TabIndex = 5
        Me.clippingBtn.Text = "CLIPPING"
        Me.clippingBtn.UseVisualStyleBackColor = True
        '
        'singleBtn
        '
        Me.singleBtn.Location = New System.Drawing.Point(13, 381)
        Me.singleBtn.Name = "singleBtn"
        Me.singleBtn.Size = New System.Drawing.Size(75, 52)
        Me.singleBtn.TabIndex = 8
        Me.singleBtn.Text = "SINGLE POLYGON"
        Me.singleBtn.UseVisualStyleBackColor = True
        '
        'refreshBtn
        '
        Me.refreshBtn.Location = New System.Drawing.Point(256, 381)
        Me.refreshBtn.Name = "refreshBtn"
        Me.refreshBtn.Size = New System.Drawing.Size(75, 53)
        Me.refreshBtn.TabIndex = 9
        Me.refreshBtn.Text = "REFRESH"
        Me.refreshBtn.UseVisualStyleBackColor = True
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(774, 24)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'coorLbl
        '
        Me.coorLbl.AutoSize = True
        Me.coorLbl.Location = New System.Drawing.Point(346, 401)
        Me.coorLbl.Name = "coorLbl"
        Me.coorLbl.Size = New System.Drawing.Size(0, 13)
        Me.coorLbl.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(648, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "LIST OF POLYGON:"
        '
        'modeLbl
        '
        Me.modeLbl.AutoSize = True
        Me.modeLbl.Location = New System.Drawing.Point(446, 401)
        Me.modeLbl.Name = "modeLbl"
        Me.modeLbl.Size = New System.Drawing.Size(77, 13)
        Me.modeLbl.TabIndex = 18
        Me.modeLbl.Text = "Clipping Mode:"
        '
        'singleLbl
        '
        Me.singleLbl.AutoSize = True
        Me.singleLbl.Location = New System.Drawing.Point(561, 401)
        Me.singleLbl.Name = "singleLbl"
        Me.singleLbl.Size = New System.Drawing.Size(69, 13)
        Me.singleLbl.TabIndex = 19
        Me.singleLbl.Text = "Single Mode:"
        '
        'polygonListBox
        '
        Me.polygonListBox.FormattingEnabled = True
        Me.polygonListBox.Location = New System.Drawing.Point(636, 41)
        Me.polygonListBox.Name = "polygonListBox"
        Me.polygonListBox.Size = New System.Drawing.Size(135, 160)
        Me.polygonListBox.TabIndex = 20
        '
        'coordinatesListBox
        '
        Me.coordinatesListBox.FormattingEnabled = True
        Me.coordinatesListBox.Location = New System.Drawing.Point(636, 215)
        Me.coordinatesListBox.Name = "coordinatesListBox"
        Me.coordinatesListBox.Size = New System.Drawing.Size(135, 160)
        Me.coordinatesListBox.TabIndex = 21
        '
        'multipleLbl
        '
        Me.multipleLbl.AutoSize = True
        Me.multipleLbl.Location = New System.Drawing.Point(667, 401)
        Me.multipleLbl.Name = "multipleLbl"
        Me.multipleLbl.Size = New System.Drawing.Size(76, 13)
        Me.multipleLbl.TabIndex = 22
        Me.multipleLbl.Text = "Multiple Mode:"
        '
        'PolygonClipping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 445)
        Me.Controls.Add(Me.multipleLbl)
        Me.Controls.Add(Me.coordinatesListBox)
        Me.Controls.Add(Me.polygonListBox)
        Me.Controls.Add(Me.singleLbl)
        Me.Controls.Add(Me.modeLbl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.coorLbl)
        Me.Controls.Add(Me.refreshBtn)
        Me.Controls.Add(Me.singleBtn)
        Me.Controls.Add(Me.clippingBtn)
        Me.Controls.Add(Me.multipleBtn)
        Me.Controls.Add(Me.coordinateLbl)
        Me.Controls.Add(Me.MainCanvas)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "PolygonClipping"
        Me.Text = "Sutherland-Hodgman Polygon Clipping"
        CType(Me.MainCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MainCanvas As PictureBox
    Friend WithEvents coordinateLbl As Label
    Friend WithEvents multipleBtn As Button
    Friend WithEvents clippingBtn As Button
    Friend WithEvents singleBtn As Button
    Friend WithEvents refreshBtn As Button
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents coorLbl As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents modeLbl As Label
    Friend WithEvents singleLbl As Label
    Friend WithEvents polygonListBox As ListBox
    Friend WithEvents coordinatesListBox As ListBox
    Friend WithEvents multipleLbl As Label
End Class
