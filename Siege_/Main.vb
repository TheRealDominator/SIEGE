Imports System.IO
Imports System.Net
Module Main
    Private ProgramTitle As String = "SIEGE"
    Private Version As String = My.Application.Info.Version.ToString
    Private Extension As String = ".siege"
    Private Target, var0, Var1, var2, var3, var4, var5, var6, var7, var8, var9 As String
    Private ExpURI, ExpPath As String
    Private Mode As Integer = 0
    Sub Main()
        InitProgram()
        InitExploits()
        Do
            CommandWorker(True)
        Loop
    End Sub
    Sub InitProgram()
        Console.Title = ProgramTitle
    End Sub
    Sub InitExploits()
        Try
            Dim di As New DirectoryInfo("siege")
            Dim fiArr As FileInfo() = di.GetFiles()
            Dim fri As FileInfo
            For Each fri In fiArr
                ExpList.Add(fri.Name.ToString)
            Next fri
            Console.WriteLine("---------- SIEGE ----------")
            Console.WriteLine("Program Version: " & Version)
            Console.WriteLine("Exploits Loaded: " & ExpList.Count)
            Console.WriteLine("---------------------------")
            Console.WriteLine(vbNewLine)
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("SIEGE > ")
            Console.ForegroundColor = ConsoleColor.White
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("SIEGE -> Error: ")
            Console.ForegroundColor = ConsoleColor.White
            Console.Write(ex.Message)
        End Try
    End Sub
    Sub CommandWorker(ByVal isWorking As Boolean)
        Do
            Try
                Dim ComStr As String = Console.ReadLine
                If ComStr.StartsWith("use ") Then
                    Dim RawModule As String = "siege\" & ComStr.Substring(4)
                    Use(RawModule)
                    GoTo 1
                ElseIf ComStr.StartsWith("set ") Then
                    SetVar(ComStr.Substring(4))
                    Dim CArry() As String = ComStr.Split(" ")
                    Console.WriteLine(CArry(1).ToUpper & " value changed to " & CArry(2).ToUpper)
                    GoTo 1
                ElseIf ComStr.StartsWith("exploit") Or ComStr.StartsWith("run") Then
                    Exploit()
                    GoTo 1
                ElseIf ComStr.StartsWith("search ") Then
                    Search(ComStr.Substring(7))
                    GoTo 1
                ElseIf ComStr.StartsWith("search ") Then
                    Search(ComStr.Substring(7))
                    GoTo 1
                ElseIf ComStr.StartsWith("show ") Then
                    ShowInfo(ComStr.Substring(5))
                    GoTo 1
                ElseIf ComStr = "reload" Then
                    ReloadProgram()
                    GoTo 2
                ElseIf ComStr = "clear" Then
                    Console.Clear()
                    GoTo 1
                ElseIf ComStr = "?" Or ComStr = "help" Then
                    Console.WriteLine("---------- Help ----------")
                    Console.WriteLine(" ")
                    Console.WriteLine("use - use exploit from exploit directory")
                    Console.WriteLine("set - set predefined variable used by exploits")
                    Console.WriteLine("search - used for searching exploits")
                    Console.WriteLine("clear - clean's console text")
                    Console.WriteLine("show - displays info")
                    Console.WriteLine("exploit / run - runs exploit")
                    Console.WriteLine("reload - Reload exploits and program")
                    Console.WriteLine("exit - exits program")
                    Console.WriteLine("help / ? - shows this text")
                    Console.WriteLine(" ")
                    Console.WriteLine("--------------------------")
                    GoTo 1
                ElseIf ComStr = "exit" Then
                    End
                Else
                    Console.WriteLine("Invalid or Unknown command please try again or use ?")
                End If
1:
                If ExpPath = String.Empty Then
                    Console.WriteLine(" ")
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write("SIEGE > ")
                    Console.ForegroundColor = ConsoleColor.White
                Else
                    Console.WriteLine(" ")
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write("SIEGE [")
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.Write(ExpPath.ToUpper)
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write("] > ")
                    Console.ForegroundColor = ConsoleColor.White
                End If
2:
            Catch ex As Exception
                Console.ForegroundColor = ConsoleColor.Red
                Console.Write("SIEGE -> Error: ")
                Console.ForegroundColor = ConsoleColor.White
                Console.Write(ex.Message)
                If ExpPath = String.Empty Then
                    Console.WriteLine(" ")
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write("SIEGE > ")
                    Console.ForegroundColor = ConsoleColor.White
                Else
                    Console.WriteLine(" ")
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write("SIEGE [")
                    Console.ForegroundColor = ConsoleColor.Green
                    Console.Write(ExpPath.ToUpper)
                    Console.ForegroundColor = ConsoleColor.Red
                    Console.Write("] > ")
                    Console.ForegroundColor = ConsoleColor.White
                End If
            End Try
        Loop While isWorking = True
    End Sub
    Sub UnloadProgram()
        Try
            Console.Clear()
            ExpList.Clear()
            ExpURI = Nothing
            ExpPath = Nothing
            Target = Nothing
            var0 = Nothing
            Var1 = Nothing
            var2 = Nothing
            var3 = Nothing
            var4 = Nothing
            var5 = Nothing
            var6 = Nothing
            var7 = Nothing
            var8 = Nothing
            var9 = Nothing
        Catch ex As Exception
        End Try
    End Sub
    Sub ReloadProgram()
        UnloadProgram()
        InitProgram()
        InitExploits()
    End Sub
    Function StrBuilder(ByVal WorkData As String) As String
        Try
            Dim FinishedData As String = WorkData

            If FinishedData.Contains("+target") Then
                FinishedData = FinishedData.Replace("+target", Target)
            End If
            If FinishedData.Contains("+var0") Then
                FinishedData = FinishedData.Replace("+var0", var0)
            End If
            If FinishedData.Contains("+var1") Then
                FinishedData = FinishedData.Replace("+var1", Var1)
            End If
            If FinishedData.Contains("+var2") Then
                FinishedData = FinishedData.Replace("+var2", var2)
            End If
            If FinishedData.Contains("+var3") Then
                FinishedData = FinishedData.Replace("+var3", var3)
            End If
            If FinishedData.Contains("+var4") Then
                FinishedData = FinishedData.Replace("+var4", var4)
            End If
            If FinishedData.Contains("+var5") Then
                FinishedData = FinishedData.Replace("+var5", var5)
            End If
            If FinishedData.Contains("+var6") Then
                FinishedData = FinishedData.Replace("+var6", var6)
            End If
            If FinishedData.Contains("+var7") Then
                FinishedData = FinishedData.Replace("+var7", var7)
            End If
            If FinishedData.Contains("+var8") Then
                FinishedData = FinishedData.Replace("+var8", var8)
            End If
            If FinishedData.Contains("+var9") Then
                FinishedData = FinishedData.Replace("+var9", var9)
            End If
            Return FinishedData
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Function SetVar(ByVal var As String) As Boolean
        Try
            If var.StartsWith("target ") Then
                Target = var.Substring(7)
            End If
            If var.StartsWith("var0 ") Then
                var0 = var.Substring(5)
            End If
            If var.StartsWith("var1 ") Then
                Var1 = var.Substring(5)
            End If
            If var.StartsWith("var2 ") Then
                var2 = var.Substring(5)
            End If
            If var.StartsWith("var3 ") Then
                var3 = var.Substring(5)
            End If
            If var.StartsWith("var4 ") Then
                var4 = var.Substring(5)
            End If
            If var.StartsWith("var5 ") Then
                var5 = var.Substring(5)
            End If
            If var.StartsWith("var6 ") Then
                var6 = var.Substring(5)
            End If
            If var.StartsWith("var7 ") Then
                var7 = var.Substring(5)
            End If
            If var.StartsWith("var8 ") Then
                var8 = var.Substring(5)
            End If
            If var.StartsWith("var9 ") Then
                var9 = var.Substring(5)
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function Use(ByVal str As String) As Boolean
        Try
            If File.Exists(str & Extension) Then
                Dim CArry() As String
                Dim SR As New StreamReader(str & Extension)
                Dim RawRead As String = SR.ReadToEnd
                CArry = RawRead.Split(vbNewLine)
                ExpPath = str.Replace(Extension, "")
                ExpPath = ExpPath.Replace("siege\", "")
                ExpURI = CArry(0)
                Mode = CArry(1)
            Else
                Console.ForegroundColor = ConsoleColor.Yellow
                Console.Write("SIEGE -> Info: ")
                Console.ForegroundColor = ConsoleColor.White
                Console.Write(str.ToUpper.Replace("SIEGE\", "") & " Does not exist" & vbNewLine)
            End If
        Catch ex As Exception
            Console.WriteLine("Error While Loading Exploit")
            Return False
        End Try
    End Function
    Function Exploit() As Boolean
        Try
            If Not ExpURI = Nothing Then
                If Mode = "0" Then
                    Dim ExpClient As New WebClient
                    Dim s As String = StrBuilder(ExpURI)
                    Dim str As String = ExpClient.DownloadString(s)
                    Console.WriteLine(s)
                    Console.Write(vbNewLine & "Status: ")
                    Console.WriteLine("Attack Url: " & StrBuilder(ExpURI))
                    Console.ForegroundColor = Console.ForegroundColor.Green
                    Console.WriteLine("SIEGE -> 200 OK")
                    Console.ForegroundColor = Console.ForegroundColor.White
                    Return True
                ElseIf Mode = "1" Then
                    Dim ExpClient As New WebClient
                    Dim str As String = ExpClient.DownloadString(StrBuilder(ExpURI))
                    Console.Write(vbNewLine & "Status: ")
                    Console.WriteLine("Attack Url: " & StrBuilder(ExpURI) & vbNewLine)
                    Console.ForegroundColor = Console.ForegroundColor.Green
                    Console.WriteLine("SIEGE -> 200 OK")
                    If str.Contains(var0) Then
                        Console.WriteLine("SIEGE -> VULNERABLE!")
                    Else
                        Console.ForegroundColor = Console.ForegroundColor.Red
                        Console.WriteLine("SIEGE -> NOT VULNERABLE!")
                    End If
                    Console.ForegroundColor = Console.ForegroundColor.White
                    Return True
                Else
                    Console.WriteLine("SIEGE -> No Mode Specified or Invalid Mode " & Mode)
                    Return False
                End If
            Else
                Console.WriteLine("SIEGE -> Not using any exploit")
            End If
        Catch ex As Exception
            If Not ex.Message.Contains("404") Then
                Console.WriteLine("SIEGE -> Failed to run exploit")
                Return False
            Else
                Console.WriteLine("TARGET -> 404 Not Found")
                Return False
            End If

        End Try
    End Function
    Function Search(ByVal keyword As String)
        Try
            Dim found As Integer = 0
            Dim str As String
            For Each str In ExpList
                If str.Contains(keyword) Then
                    Console.WriteLine(str.Replace(Extension, ""))
                    found = found + 1
                End If
            Next
            Console.WriteLine(" ")
            Console.WriteLine("Exploits Found:  " & found)
        Catch ex As Exception
            Console.ForegroundColor = ConsoleColor.Red
            Console.Write("SIEGE -> Error: ")
            Console.ForegroundColor = ConsoleColor.White
            Console.Write(ex.Message)
        End Try
    End Function
    Function ShowInfo(ByVal exec As String)
        Try
            If exec = "variables" Then
                Console.WriteLine(" ")
                Console.WriteLine("---------- vars ----------")
                Console.WriteLine(" ")
                Console.WriteLine("TARGET -> " & Target)
                Console.WriteLine("var0 -> " & var0)
                Console.WriteLine("var1 -> " & Var1)
                Console.WriteLine("var2 -> " & var2)
                Console.WriteLine("var3 -> " & var3)
                Console.WriteLine("var4 -> " & var4)
                Console.WriteLine("var5 -> " & var5)
                Console.WriteLine("var6 -> " & var6)
                Console.WriteLine("var7 -> " & var7)
                Console.WriteLine("var8 -> " & var8)
                Console.WriteLine("var9 -> " & var9)
            End If
            If exec = "options" Then
                If Not ExpURI = String.Empty Then
                    If ExpURI.Contains("+target") Then
                        Console.WriteLine("TARGET -> " & Target)
                    End If
                    If ExpURI.Contains("+var0") Then
                        Console.WriteLine("var0 -> " & var0)
                    End If
                    If ExpURI.Contains("+var1") Then
                        Console.WriteLine("var1 -> " & Var1)
                    End If
                    If ExpURI.Contains("+var2") Then
                        Console.WriteLine("var2 -> " & var2)
                    End If
                    If ExpURI.Contains("+var3") Then
                        Console.WriteLine("var3 -> " & var3)
                    End If
                    If ExpURI.Contains("+var4") Then
                        Console.WriteLine("var4 -> " & var4)
                    End If
                    If ExpURI.Contains("+var5") Then
                        Console.WriteLine("var5 -> " & var5)
                    End If
                    If ExpURI.Contains("+var6") Then
                        Console.WriteLine("var6 -> " & var6)
                    End If
                    If ExpURI.Contains("+var7") Then
                        Console.WriteLine("var7 -> " & var7)
                    End If
                    If ExpURI.Contains("+var8") Then
                        Console.WriteLine("var8 -> " & var8)
                    End If
                    If ExpURI.Contains("+var9") Then
                        Console.WriteLine("var9 -> " & var9)
                    End If
                Else
                    Console.WriteLine("SIEGE -> Not using any exploit")
                End If
            End If
                Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
