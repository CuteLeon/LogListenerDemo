Public Class Form1
    Dim SystemLogListener As Logging.FileLogTraceListener = New Logging.FileLogTraceListener
    Dim SystemTime As Date = My.Computer.Clock.LocalTime

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With SystemLogListener
            .Location = Logging.LogFileLocation.ExecutableDirectory
            .Append = False
            .AutoFlush = True
            .Delimiter = vbCrLf
            .BaseFileName = "HackSystem-" & SystemTime.ToString("yy-MM-dd-hh-mm-ss")
            .DiskSpaceExhaustedBehavior = Logging.DiskSpaceExhaustedOption.DiscardMessages
            .Encoding = System.Text.Encoding.UTF8
            .IndentSize = 4
            .IndentLevel = 1

            .WriteLine(.BaseFileName & ".log")
            .WriteLine(My.Computer.Clock.LocalTime.ToString)
            .WriteLine("————————————————")
            .Fail("我不爽了，我出错")
            .Name = "HackSystemLogListener"

            .Flush()
            .Close()
        End With
    End Sub
End Class
