Imports Godot

Public Class GodotVisualBasic

    Private parentnode2d As Node2D
    Private colors(9) As Color

    Public Sub New(n As Node2D)
        parentnode2d = n
    End Sub

    Public Sub _Ready()
        GD.Print("hello world from visualbasic from node ", parentnode2d.Name)

        colors(0) = Color.Color8(0, 0, 0)
        colors(1) = Color.Color8(255, 0, 255)
        colors(2) = Color.Color8(0, 0, 255)
        colors(3) = Color.Color8(0, 255, 0)
        colors(4) = Color.Color8(0, 128, 255)
        colors(5) = Color.Color8(255, 0, 0)
        colors(6) = Color.Color8(255, 128, 0)
        colors(7) = Color.Color8(255, 255, 0)
        colors(8) = Color.Color8(255, 255, 255)
    End Sub

    Public Sub _Process()

    End Sub

    Public Sub _Draw()
        Dim startmsecs As ULong = Time.GetTicksMsec
        Dim c As Color
        Dim l As Single = 100.0
        Dim u, v, x, y, n, r, q As Single

        For i As Integer = 0 To 500
            For j As Integer = 0 To 500
                u = i / 250.0 - 1.5
                v = j / 250.0F - 1.0
                x = u
                y = v
                n = 0.0
                r = x * x
                q = y * y
                While (r + q) < 4.0F And n < l
                    y = 2.0F * x * y + v
                    x = r - q + u
                    r = x * x
                    q = y * y
                    n = n + 1.0F
                End While
                If n < 10.0F Then
                    c = colors(0)
                Else
                    c = colors((Mathf.Round(8.0F * (n - 10.0F) / (l - 10.0F))))
                    c.G = 255
                End If

                parentnode2d.DrawRect(New Rect2(New Vector2(i + 500, j), New Vector2(1, 1)), c, True, -1.0, False)
            Next
        Next

        Dim stopmsecs As ULong = Time.GetTicksMsec
        GD.Print("VisualBasic result milliseconds: ")
        GD.Print(stopmsecs - startmsecs)

    End Sub


End Class