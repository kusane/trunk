Imports System.IO

Module Module1

    Enum eMode As Integer
        EVEN = 0 '偶数
        ODD      '奇数
    End Enum

    Sub Main()

        Dim fileName As String = System.Configuration.ConfigurationManager.AppSettings("filename")
        Dim replaceStr As String = System.Configuration.ConfigurationManager.AppSettings("replaceStr")

        Dim fileOld As String = fileName & "_old.csv"

        ' 元ファイルはリネームして保存
        If File.Exists(fileName) Then
            File.Move(fileName, fileOld)
        Else
            Exit Sub
        End If

        Dim sReader As New StreamReader(fileOld, System.Text.Encoding.Default)
        Dim sWriter As New StreamWriter(fileName, False, System.Text.Encoding.GetEncoding("shift_jis"))

        ' 初回 = 偶数モード
        Dim mode As Integer = eMode.EVEN

        ' 1行読込
        While (sReader.Peek() >= 0)

            Dim stBuffer As String = sReader.ReadLine()

            Dim cntChar = CountChar(stBuffer, Chr(34))

            ' モードの判定
            If (mode + cntChar) Mod 2 = 0 Then
                mode = eMode.EVEN
            Else
                mode = eMode.ODD
            End If

            ' 書込処理
            If mode = eMode.EVEN Then
                ' 偶数モード時：改行込で出力 (WriteLine)
                sWriter.WriteLine(stBuffer)
            Else
                ' 奇数モード時：そのまま出力 (Write) + 置換文字を出力 (改行しない)
                sWriter.Write(stBuffer)
                sWriter.Write(replaceStr)
            End If

        End While

        sWriter.Close()
        sReader.Close()

    End Sub

    Public Function CountChar(ByVal s As String, ByVal c As Char) As Integer
        Return s.Length - s.Replace(c.ToString, "").Length
    End Function

End Module
