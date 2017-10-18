Public Class TPolygon
    Public PolyIndex As Integer = 0
    Public PolyLine As TElementPolygon 'List of Points
    Public PolyHead, PolyTail As TElementPolygon 'Head and tail of Linked List
    Public nextPolygon As TPolygon 'Store multiple polygons
End Class
