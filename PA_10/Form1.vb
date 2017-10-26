Public Class MainForm

    'First initialize all components
    Private points As TPoint = Nothing
    Private headPolygon As TPolygon = Nothing 'For the head of Polygon
    Private headPolyElement As TElementPolygon 'For the head of Element of Polygon
    Private polygonIndexNum As Integer = 0
    Private polyElementIndexNum As Integer = 0
    Dim pressedButton As Boolean = False

    'mainCanvas resolution is 480x480

    Private Sub ButtonClear_Click(sender As Object, e As EventArgs) Handles ButtonClear.Click
        For i = 0 To MainCanvas.Width - 1
            For j = 0 To MainCanvas.Height - 1
                If (bitmapCanvas.GetPixel(i, j) <> Color.White) Then
                    bitmapCanvas.SetPixel(i, j, Color.White)
                End If
            Next
        Next
        MainCanvas.Image = bitmapCanvas
    End Sub

    Private Function InsertPointNode(ByRef pointNode As TPoint, ByVal x As Integer, ByVal y As Integer) As TPoint
        If (pointNode Is Nothing) Then 'Newly allocated
            pointNode = New TPoint
            pointNode.setCoordinates(x, y)
        Else 'Already allocated
            pointNode.setCoordinates(x, y)
        End If
        Return pointNode
    End Function

    Private Function InsertPolyElementNode(ByRef polyElement_Param As TElementPolygon, ByRef pointElement_Param As TPoint, ByVal x As Integer, ByVal y As Integer) As TElementPolygon
        If (polyElement_Param Is Nothing) Then
            polyElement_Param = New TElementPolygon
            'polyElement_Param.nextPoint = New TElementPolygon
            polyElement_Param.numOfPoints = polyElementIndexNum + 1
            polyElement_Param.points = InsertPointNode(pointElement_Param, x, y)
            polyElement_Param.nextPoint = Nothing
        Else
            '    MessageBox.Show("It's here inside else!")
            polyElement_Param.nextPoint = InsertPolyElementNode(polyElement_Param.nextPoint, pointElement_Param, x, y)
        End If
        Return polyElement_Param
    End Function

    'Private Function CreatePolygonNode(ByRef Polygon_Param As TPolygon) As TPolygon
    '    If (Polygon_Param Is Nothing) Then
    '        Polygon_Param = New TPolygon
    '        Polygon_Param.PolyIndex = Polygon_Param.PolyIndex + 1 'Increase the index by one for each polygon creation
    '        Polygon_Param.PolyLine = Nothing
    '        Polygon_Param.nextPolygon = Nothing
    '    End If
    '    Return Polygon_Param
    'End Function

    'Private _Previous As System.Nullable(Of Point) = Nothing
    Private Sub MainCanvas_MouseDown(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseDown ' Mouse down, get the position
        pressedButton = True
        headPolyElement = Nothing
        headPolyElement = InsertPolyElementNode(headPolyElement, points, e.X, e.Y)
        'points = InsertPointNode(points, e.X, e.Y)
        ' _Previous = e.Location
        'MainCanvas_MouseMove(sender, e)
    End Sub

    Private Sub MainCanvas_MouseMove(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseMove
        CoordinateLabel.Text = "X = " & e.X.ToString() & ", Y = " & e.Y.ToString()

        'If _Previous IsNot Nothing Then
        '    If MainCanvas.Image Is Nothing Then
        '        Dim bmp As New Bitmap(MainCanvas.Width, MainCanvas.Height)
        '        Using g As Graphics = Graphics.FromImage(bmp)
        '            g.Clear(Color.White)
        '        End Using
        '        MainCanvas.Image = bmp
        '    End If
        '    Using g As Graphics = Graphics.FromImage(MainCanvas.Image)
        '        g.DrawLine(Pens.Black, _Previous.Value, e.Location)
        '    End Using
        '    MainCanvas.Invalidate()
        '    _Previous = e.Location
        'End If
    End Sub
    Dim i = 1
    Private Sub pictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles MainCanvas.MouseUp 'Get the final position from mouse, draw on bitmapCanvas
        headPolyElement = InsertPolyElementNode(headPolyElement, points, e.X, e.Y) 'Last edited here on 26 October 2017 at 10:53 PM
        While (headPolyElement IsNot Nothing)
            'Using myGraphics As Graphics = Graphics.FromImage(bitmapCanvas)
            '    Dim point As PointF
            '    point.X = headPolyElement.points.x
            '    point.Y = headPolyElement.points.y
            '    myGraphics.DrawLines(Pens.Black, point)
            'End Using
            MessageBox.Show("Point " & i.ToString() & " X = " & headPolyElement.points.x.ToString() & ", Point " & i.ToString() & " Y = " & headPolyElement.points.y.ToString())
            headPolyElement = headPolyElement.nextPoint
            i = i + 1
        End While
        pressedButton = False
        '_Previous = Nothing
    End Sub
End Class
