Public Class MainForm
    'First initialize all components

    Private Point, Point1_Clip, Point2_Clip, Point3_Clip, Point4_Clip As Point
    Private PointList, ClippingWindowList, ClippedPolygon As List(Of Point)
    Private Polygon As List(Of List(Of Point)) 'List of polygon as a List Of List Of Points
    Private newBitmap As Bitmap
    Private mRect As Rectangle
    Private x, y, Clip_X1, Clip_X2, Clip_Y1, Clip_Y2, rectWidth, rectHeight, PointNum, PolyENum, SelectedPolyIndex As Integer
    Private PositionPointArr As Integer = 0
    Private pressedButton, afterClip, CopyMode, DrawMode, CutMode, PasteMode As Boolean 'Last Edited here On 27 October 2017 at 2:49 PM

    'mainCanvas resolution is 480x480

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'Executed as soon as the form is loaded, Set all local variables's default value

        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = True

        StartPosition = FormStartPosition.CenterScreen
        ' Remove the control box so the form will only display client area.
        ControlBox = True

        afterClip = False
        mRect = New Rectangle()
        Point = New Point()
        PointList = New List(Of Point)
        ClippedPolygon = New List(Of Point) 'Store the finished polygon
        Polygon = New List(Of List(Of Point)) 'List of PointList
        'ClippingWindow = New Clippingwindow
        ClippingWindowList = New List(Of Point) 'To store clipping window's coordinates
        CutMode = False
        CopyMode = False
        PasteMode = False
        DrawMode = True 'At the beginning of form's creation, you can only use draw mode
        rectHeight = 0 'Height for the clipping window rectangle
        rectWidth = 0 'Width for the clipping window width
        PointNum = 0  'Number of points that have been inserted into the list
        PolyENum = 0 'Number of polygon created
    End Sub

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click 'Clear the clipping window only
        If (ClippingWindowList IsNot Nothing And ClippingWindowList.Count > 0) Then
            Dim Point1, Point2, Point3, Point4 As Point
            Point1 = New Point()
            Point2 = New Point()
            Point3 = New Point()
            Point4 = New Point()

            Point1 = ClippingWindowList(0)
            Point2 = ClippingWindowList(1)
            Point3 = ClippingWindowList(2)
            Point4 = ClippingWindowList(3)

            myGraphics = Graphics.FromImage(bitmapCanvas)
            myGraphics.DrawLine(Pens.White, Point1.X, Point1.Y, Point2.X, Point2.Y)
            myGraphics.DrawLine(Pens.White, Point2.X, Point2.Y, Point3.X, Point3.Y)
            myGraphics.DrawLine(Pens.White, Point3.X, Point3.Y, Point4.X, Point4.Y)
            myGraphics.DrawLine(Pens.White, Point4.X, Point4.Y, Point1.X, Point1.Y) 'Make all clipping window edges to white (delete this)

            For i = 0 To Polygon.Count - 1 'Loop through polygon line and redraw all polygons
                For j = 1 To Polygon(i).Count - 1
                    Dim PointPoly1 As Point = Polygon(i)(j - 1)
                    Dim PointPoly2 As Point = Polygon(i)(j)
                    myGraphics.DrawLine(myPen, PointPoly1, PointPoly2)
                Next
            Next
            ClippingWindowList.Clear() 'Empty the list of point for clipping window after deleted
        Else
            MessageBox.Show("No clipping window detected!") 'LAST EDITED HERE On 6 November 2017 at 10:59 AM
        End If
        'PolygonList_ListBox.Items.Clear()
        'PolyCoord_ListBox.Items.Clear()
        'Polygon.Clear()
        'PointList.Clear()
        afterClip = False
        DrawMode = True
        CutMode = False
    End Sub

    Private Sub MainCanvas_MouseDown(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseDown ' Mouse down, get the x, y coordinates
        pressedButton = True
        If (CutMode) And Not afterClip Then
            Clip_X1 = e.X
            Clip_Y1 = e.Y
            Point.X = Clip_X1
            Point.Y = Clip_Y1
            x = e.X
            y = e.Y
        ElseIf (DrawMode) Then
            x = e.X
            y = e.Y
            PointList.Add(New Point(e.X, e.Y)) 'Get point coordinate each click
            PointNum = PointNum + 1
        End If
    End Sub

    Private Sub AboutMeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutMeToolStripMenuItem.Click 'When you click the about me
        MessageBox.Show(
            "Sutherland and Hodgman Clipping demo ver. 0.1a" & vbNewLine & vbNewLine &
            "User Inteface" & vbTab & "1 Jonathan Surya" & vbNewLine & vbNewLine &
            "Coding" & vbTab & vbTab & "1 Kristoforus Kurniawan" & vbNewLine & vbTab & vbTab & "2 Ardy Wijaya", "About Me", MessageBoxButtons.OK)
    End Sub

    Private Sub SaveIt()
        Dim save As New SaveFileDialog
        save.Filter = "JPG files (*.jpg)|*.jpg|Bitmaps (*.bmp)|*.bmp|Png(*.png)|*.png"
        If (save.ShowDialog = DialogResult.OK) Then
            bitmapCanvas.Save(save.FileName)
        End If
    End Sub

    Private Sub OpenIt()
        Dim open As New OpenFileDialog
        open.Filter = "JPG files (*.jpg)|*.jpg|Bitmaps (*.bmp)|*.bmp|Png(*.png)|*.png"
        If (open.ShowDialog = DialogResult.OK) Then
            bitmapCanvas = System.Drawing.Image.FromFile(open.FileName)
            MainCanvas.Image = bitmapCanvas
        End If
    End Sub

    Private Sub SaveCtrlSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveCtrlSToolStripMenuItem.Click 'When you click save
        SaveIt()
    End Sub

    Private Sub OpenCtrlOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenCtrlOToolStripMenuItem.Click 'When you click open
        OpenIt()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub InsertClipWindowCoordinate(ByRef Point1 As Point, ByRef Point2 As Point, ByRef Point3 As Point, ByRef Point4 As Point) 'Insert points for clipping window (for traversing)
        ClippingWindowList.Add(Point1)
        ClippingWindowList.Add(Point2)
        ClippingWindowList.Add(Point3)
        ClippingWindowList.Add(Point4)
    End Sub

    Private Sub ButtonCut_Click(sender As Object, e As EventArgs) Handles ButtonCut.Click
        If (Not CutMode) Then
            CutMode = True
            DrawMode = False
        ElseIf (CutMode And Polygon.Count > 0) Then 'Cut mode is activated and polygon has been drawn
            InsertClipWindowCoordinate(Point1_Clip, Point2_Clip, Point3_Clip, Point4_Clip) 'Insert all 4 points into a list of points once the clipping window has been drawn
            SutherlandHodgman(Polygon, ClippingWindowList, ClippedPolygon, SelectedPolyIndex)
            'For i = 0 To ClippingWindowList.Count - 1
            '    MessageBox.Show("Point " & i + 1.ToString() & " X = " & ClippingWindowList(i).X.ToString() & ", Y = " & ClippingWindowList(i).Y.ToString()) 'Checking if clipping windows point has been stored
            'Next
        End If
    End Sub

    Private Sub DrawClipWindow(ByRef myGraphics As Graphics, ByRef bitmapCanvas As Bitmap) 'Drawing rectangle for clipping window
        myGraphics = Graphics.FromImage(bitmapCanvas)
        myGraphics.DrawLine(myPen, Clip_X1, Clip_Y1, Clip_X2, Clip_Y1)
        myGraphics.DrawLine(myPen, Clip_X2, Clip_Y1, Clip_X2, Clip_Y2)
        myGraphics.DrawLine(myPen, Clip_X2, Clip_Y2, Clip_X1, Clip_Y2)
        myGraphics.DrawLine(myPen, Clip_X1, Clip_Y2, Clip_X1, Clip_Y1) 'LAST EDITED HERE ON 3 November 2017 at 11:52 PM

        Point1_Clip.X = Clip_X1
        Point1_Clip.Y = Clip_Y1

        Point2_Clip.X = Clip_X2
        Point2_Clip.Y = Clip_Y1

        Point3_Clip.X = Clip_X2
        Point3_Clip.Y = Clip_Y2

        Point4_Clip.X = Clip_X1
        Point4_Clip.Y = Clip_Y2
    End Sub

    Private Sub PolygonList_ListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PolygonList_ListBox.SelectedIndexChanged 'This method shows the coordinate lists for the selected polygon
        PolyCoord_ListBox.Items.Clear()
        Dim PolyCoord As String = ""
        Dim i As Integer = PolygonList_ListBox.SelectedIndex
        SelectedPolyIndex = i
        If (i >= 0) Then
            For j = 0 To Polygon(i).Count - 1
                PolyCoord = "X = " & Polygon(i)(j).X.ToString() & ", Y = " & Polygon(i)(j).Y.ToString() + vbNewLine
                PolyCoord_ListBox.Items.Add(PolyCoord)
            Next
        Else
            MessageBox.Show("Please click exactly on the polygon list!")
        End If
    End Sub

    Private Sub CheckMousePosition(e As MouseEventArgs) 'This method handles the label when we draw rectangle using mouse move
        If e.X >= 0 And e.Y >= 0 And e.X <= MainCanvas.Width And e.Y <= MainCanvas.Height Then
            CoordinateLabel.Text = "X = " & e.X.ToString() & ", y = " & e.Y.ToString()
        ElseIf e.X < 0 And e.Y < 0 Then
            CoordinateLabel.Text = "X = 0, y = 0"
        ElseIf e.X < 0 Then
            CoordinateLabel.Text = "X = 0" & ", y = " & e.Y.ToString()
        ElseIf e.Y < 0 Then
            CoordinateLabel.Text = "X = " & e.X.ToString() & ", y = 0"
        ElseIf e.X > MainCanvas.Width Then
            CoordinateLabel.Text = "X = " & MainCanvas.Width.ToString() & ", y = " & e.Y.ToString()
        ElseIf e.Y > MainCanvas.Height Then
            CoordinateLabel.Text = "X = " & e.X.ToString() & ", y = " & MainCanvas.Height.ToString()
        ElseIf e.Y > MainCanvas.Height And e.X > MainCanvas.Width Then
            CoordinateLabel.Text = "X = " & MainCanvas.Width.ToString() & ", y = " & MainCanvas.Height.ToString()
        End If ' All these if-else limits the minimum point to 0 when exceeds the MainCanvas
    End Sub

    Public Sub MainCanvas_MouseMove(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        CoordinateLabel.Text = "X = " & e.X.ToString() & ", Y = " & e.Y.ToString()
        newBitmap = bitmapCanvas.Clone()
        myGraphics = Graphics.FromImage(newBitmap)
        If (pressedButton) Then
            If (CutMode) Then
                'CheckMousePosition(e)
                mRect.X = x
                mRect.Y = y
                'If e.X <= PictureBox1.Width And e.X >= 0 - PictureBox1.Width Then
                If e.X >= 0 And e.X < mRect.X Then
                    mRect.Width = mRect.X - e.X
                    mRect.X = e.X
                ElseIf e.X < 0 And e.X < mRect.X Then
                    'mRect.Width = mRect.X
                    mRect.X = 0
                ElseIf e.X < MainCanvas.Width Then
                    mRect.Width = e.X - mRect.X
                    '     End If
                End If
                '   If e.Y <= PictureBox1.Height And e.Y >= 0 Then
                If e.Y > 0 And e.Y < mRect.Y Then
                    mRect.Height = mRect.Y - e.Y
                    mRect.Y = e.Y
                ElseIf e.Y < 0 And e.Y < mRect.Y Then
                    '  mRect.Height = mRect.Y
                    mRect.Y = 0
                ElseIf e.Y < MainCanvas.Height Then
                    mRect.Height = e.Y - mRect.Y
                End If
                myGraphics.DrawRectangle(myPen, mRect)
            ElseIf (DrawMode) Then
            End If
        End If
        MainCanvas.Image = newBitmap
    End Sub

    Private Sub MainCanvas_MouseUp(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseUp 'Get the final position from mouse, draw on bitmapCanvas
        pressedButton = False
        Dim i As Integer
        Dim FirstPoint As Point = New Point()
        Dim SecondPoint As Point = New Point()
        Dim LastPoint As Point = New Point()
        If (CutMode And Not afterClip) Then
            mRect.X = x
            mRect.Y = y
            Clip_X2 = e.X
            Clip_Y2 = e.Y
            DrawClipWindow(myGraphics, bitmapCanvas)
        ElseIf (DrawMode) Then
            If (PointList) IsNot Nothing Then
                For i = 1 To PointList.Count - 1
                    FirstPoint = PointList(i - 1)
                    SecondPoint = PointList(i)
                    myGraphics = Graphics.FromImage(bitmapCanvas)
                Next
            End If
            myGraphics.DrawLine(myPen, FirstPoint, SecondPoint) 'LAST EDITED HERE 3 November 2017 at 12:01 AM
        End If
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Sub ButtonFinishPolygon_Click(sender As Object, e As EventArgs) Handles ButtonFinishPolygon.Click 'When this button is clicked, Traverse through all polygon points and make one new polygon
        Dim PolyListLoop As Integer
        Dim PolyObjStr As String = ""
        Dim PolyCoordStr As String = ""
        If PointList IsNot Nothing Then
            Try
                Using myGraphics As Graphics = Graphics.FromImage(bitmapCanvas)
                    myGraphics.DrawLine(myPen, PointList(0), PointList(PointList.Count - 1))
                    MainCanvas.Image = bitmapCanvas
                End Using

                If (PointNum >= 3) Then 'Polygon only created when the number of points is at least 3
                    Dim tempPointList As List(Of Point) = New List(Of Point)

                    If (tempPointList IsNot Nothing) Then 'Clean the tempPoint before inserting new Point to prevent previous polygon's point to be repeated
                        tempPointList.Clear()
                    End If

                    For Each Point As Point In PointList 'Entirely copy the value of PointList into tempPointList
                        tempPointList.Add(New Point(Point))
                    Next

                    Polygon.Add(tempPointList)
                    PointList.Clear() 'After each polygon creation, clear the point list (since it has been stored in the polygon).
                    PointNum = 0 'Reset the number of points to 0 LAST EDITED HERE ON 2 November 2017 at 12:56 PM

                    For PolyListLoop = 0 To Polygon.Count - 1
                        PolyObjStr = "Polygon " & PolyListLoop + 1.ToString() & vbNewLine
                    Next
                    PolygonList_ListBox.Items.Add(PolyObjStr)
                End If
            Catch ex As Exception
                MessageBox.Show("It looks like you whether haven't drawn anything or clicked the finish polygon twice. This message prevents the program from crashing and will restart the program." &
                                vbNewLine & vbNewLine & ex.Message.ToString(), "Error!")
                Application.Restart()
            End Try
        End If
    End Sub

    'Sutherland-Hodgman algorithm method, we will be using NLeft since the DrawClipWindow method uses an anti-clockwise direction
    'Kinda stuck here on the calculation part
    Private Sub SutherlandHodgman(ByRef Polygon As List(Of List(Of Point)), ByRef ClippingWindowPointList As List(Of Point), ByRef ClippedPolygon As List(Of Point), ByVal SelectedPolyIndex As Integer)
        Dim NormalRight As New List(Of System.Windows.Vector) 'Store the normal right of clipping window edge
        Dim NormalLeft As New List(Of System.Windows.Vector) 'Store the normal left of clipping window edge
        Dim In_Or_Out As New List(Of Integer) 'Stores the result of calculation to determine whether inside or outside
        Dim ClipWinEdge As New List(Of System.Windows.Vector) 'LAST EDITED HERE On 3 November 2017 at 8:05 PM

        Dim i As Integer = 1
        Dim j As Integer = 0

        While (i <= ClippingWindowPointList.Count And j < ClippingWindowPointList.Count) 'Insert clipping window edge into a list of vector -> vector of clipping window vector
            If i = ClippingWindowPointList.Count Then
                i = 0
            End If
            ClipWinEdge.Add(New System.Windows.Vector(ClippingWindowPointList(i).X - ClippingWindowPointList(j).X, ClippingWindowPointList(i).Y - ClippingWindowPointList(j).Y))
            i = i + 1
            j = j + 1
        End While

        If ((ClippingWindowPointList(0).X < ClippingWindowPointList(2).X And ClippingWindowPointList(0).Y < ClippingWindowPointList(2).Y) Or (ClippingWindowPointList(0).X > ClippingWindowPointList(2).X And ClippingWindowPointList(0).Y > ClippingWindowPointList(2).Y)) Then 'NRight
            For edgeIndex As Integer = 0 To ClipWinEdge.Count - 1 'Insert the normal vector into a list
                NormalRight.Add(New System.Windows.Vector(ClipWinEdge(edgeIndex).Y, -ClipWinEdge(edgeIndex).X))  'NormalRight is y, -x of edge vector
                j = j + 1
            Next

            For a As Integer = 0 To ClipWinEdge.Count - 1
                MessageBox.Show("Normal Right -> X = " & NormalRight(a).X.ToString() & ", Y = " & NormalRight(a).Y.ToString())
            Next

            For forClip As Integer = 0 To ClippingWindowPointList.Count - 1 'Trying to calculate the dot product
                For forPoly As Integer = 0 To Polygon(SelectedPolyIndex).Count - 1
                    MessageBox.Show("Clip Window Point " & forClip + 1.ToString() &
                                    " X = " & ClippingWindowPointList(forClip).X.ToString() &
                                    ", Y = " & ClippingWindowPointList(forClip).Y.ToString() &
                                    " Compared with polygon point " & forPoly + 1.ToString() &
                                    " X = " & Polygon(SelectedPolyIndex)(forPoly).X.ToString() &
                                    ", Y = " & Polygon(SelectedPolyIndex)(forPoly).Y.ToString() &
                                    " dot product with X = " & NormalRight(forClip).X.ToString() &
                                    ", Y = " & NormalRight(forClip).Y.ToString() & vbNewLine & vbNewLine &
                                    "The result will be X = " &
                                    ((Polygon(SelectedPolyIndex)(forPoly).X - ClippingWindowPointList(forClip).X) * NormalRight(forClip).X) + ((Polygon(SelectedPolyIndex)(forPoly).Y - ClippingWindowPointList(forClip).Y) * NormalRight(forClip).Y).ToString())
                Next
            Next

        ElseIf ((ClippingWindowPointList(0).X < ClippingWindowPointList(2).X And ClippingWindowPointList(0).Y > ClippingWindowPointList(2).Y) Or (ClippingWindowPointList(0).X > ClippingWindowPointList(2).X And ClippingWindowPointList(0).Y < ClippingWindowPointList(2).Y)) Then 'NLeft
            For edgeIndex As Integer = 0 To ClipWinEdge.Count - 1 'Insert the normal vector into a list
                NormalLeft.Add(New System.Windows.Vector(-ClipWinEdge(edgeIndex).Y, ClipWinEdge(edgeIndex).X))  'NormalRight is y, -x of edge vector
                j = j + 1
            Next

            For a As Integer = 0 To ClipWinEdge.Count - 1
                MessageBox.Show("Normal Left -> X = " & NormalLeft(a).X.ToString() & ", Y = " & NormalLeft(a).Y.ToString())
            Next

            For forClip As Integer = 0 To ClippingWindowPointList.Count - 1 'Trying to calculate the dot product after this store it into a list
                For forPoly As Integer = 0 To Polygon(SelectedPolyIndex).Count - 1
                    MessageBox.Show("Clip Window Point " & forClip + 1.ToString() &
                                    " X = " & ClippingWindowPointList(forClip).X.ToString() &
                                    ", Y = " & ClippingWindowPointList(forClip).Y.ToString() &
                                    " Compared with polygon point " & forPoly + 1.ToString() &
                                    " X = " & Polygon(SelectedPolyIndex)(forPoly).X.ToString() &
                                    ", Y = " & Polygon(SelectedPolyIndex)(forPoly).Y.ToString() &
                                    " dot product with X = " & NormalLeft(forClip).X.ToString() &
                                    ", Y = " & NormalLeft(forClip).Y.ToString() & vbNewLine & vbNewLine &
                                    "The result will be X = " &
                                    ((Polygon(SelectedPolyIndex)(forPoly).X - ClippingWindowPointList(forClip).X) * NormalLeft(forClip).X) + ((Polygon(SelectedPolyIndex)(forPoly).Y - ClippingWindowPointList(forClip).Y) * NormalLeft(forClip).Y).ToString())
                Next
            Next
        Else
            MessageBox.Show("Please draw a proper clipping window")
        End If

        CutMode = False
        DrawMode = True
        PointList.Clear() 'LAST EDITED HERE On 4 November 2017 at 12:51 AM
    End Sub
End Class