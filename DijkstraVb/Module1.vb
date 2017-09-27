Imports System.Console
Module Module1
    Public inf = 10000
    Public QMatrix(,) =
        {
            {inf, 0.02, inf, 0.01, inf, inf, inf, inf, inf, inf, inf, inf},
            {0.02, inf, 0.03, inf, 0.05, inf, inf, inf, inf, inf, inf, inf},
            {inf, 0.03, inf, inf, inf, 0.06, inf, inf, inf, inf, inf, inf},
            {0.01, inf, inf, inf, 0.04, inf, 0.03, inf, inf, inf, inf, inf},
            {inf, 0.05, inf, inf, inf, 0.06, inf, 0.04, inf, inf, inf, inf},
            {inf, inf, 0.06, inf, inf, inf, inf, inf, 0.05, inf, inf, inf},
            {inf, inf, inf, 0.03, inf, inf, inf, inf, inf, 0.02, inf, inf},
            {inf, inf, inf, inf, 0.04, inf, 0.06, inf, inf, inf, 0.01, inf},
            {inf, inf, inf, inf, inf, 0.05, inf, 0.04, inf, inf, inf, 0.01},
            {inf, inf, inf, inf, inf, inf, 0.02, inf, inf, inf, 0.05, inf},
            {inf, inf, inf, inf, inf, inf, inf, 0.01, inf, 0.05, inf, 0.03},
            {inf, inf, inf, inf, inf, inf, inf, inf, 0.01, inf, 0.03, inf}
        }
    Public Matrix(,) =
        {
            {0, 3, inf, 2, inf, inf, inf, inf, inf, inf, inf, inf},
            {3, 0, 2, inf, 1.5, inf, inf, inf, inf, inf, inf, inf},
            {inf, 2, 0, inf, inf, 1, inf, inf, inf, inf, inf, inf},
            {2, inf, inf, 0, 2.5, inf, 3, inf, inf, inf, inf, inf},
            {inf, 1.5, inf, inf, 0, 1.5, inf, 4, inf, inf, inf, inf},
            {inf, inf, 1, inf, inf, 0, inf, inf, 2, inf, inf, inf},
            {inf, inf, inf, 3, inf, inf, 0, inf, inf, 1, inf, inf},
            {inf, inf, inf, inf, 4, inf, 0.5, 0, inf, inf, 3, inf},
            {inf, inf, inf, inf, inf, 2, inf, 3.5, 0, inf, inf, 3},
            {inf, inf, inf, inf, inf, inf, 1, inf, inf, 0, 1, inf},
            {inf, inf, inf, inf, inf, inf, inf, 3, inf, 1, 0, 3.5},
            {inf, inf, inf, inf, inf, inf, inf, inf, 3, inf, 3.5, 0}
        }
    Public Matrix0(,) =
        {
            {0, 3, inf, 2, inf, inf, inf, inf, inf, inf, inf, inf},
            {3, 0, 2, inf, 1.5, inf, inf, inf, inf, inf, inf, inf},
            {inf, 2, 0, inf, inf, 1, inf, inf, inf, inf, inf, inf},
            {2, inf, inf, 0, 2.5, inf, 3, inf, inf, inf, inf, inf},
            {inf, 1.5, inf, inf, 0, 1.5, inf, 4, inf, inf, inf, inf},
            {inf, inf, 1, inf, inf, 0, inf, inf, 2, inf, inf, inf},
            {inf, inf, inf, 3, inf, inf, 0, inf, inf, 1, inf, inf},
            {inf, inf, inf, inf, 4, inf, 0.5, 0, inf, inf, 3, inf},
            {inf, inf, inf, inf, inf, 2, inf, 3.5, 0, inf, inf, 3},
            {inf, inf, inf, inf, inf, inf, 1, inf, inf, 0, 1, inf},
            {inf, inf, inf, inf, inf, inf, inf, 3, inf, 1, 0, 3.5},
            {inf, inf, inf, inf, inf, inf, inf, inf, 3, inf, 3.5, 0}
        }
    Public ShortestPathSubscriptStringTemp(11, 11) As String
    Public OdOrigine(,) =
        {
            {0, 0, 300, 0, 0, 0, 0, 0, 0, 400, 0, 500},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {300, 0, 0, 0, 0, 0, 0, 0, 0, 100, 0, 250},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {400, 0, 100, 0, 0, 0, 0, 0, 0, 0, 0, 600},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {500, 0, 250, 0, 0, 0, 0, 0, 0, 600, 0, 0}
        }
    Public OdDistributeTemp(11, 11) As Double
    Public OdDistributedTemp(11, 11) As Double
    Public OdDistributed(11, 11) As Double
    Public n = 11
    Public S As New ArrayList
    Public U As New ArrayList
    Public distance(11) As Double
    Public previousVertex(11) As Double
    Public judgement() = {False, False, False, False, False, False, False, False, False, False, False, False}

    Sub Main()
        For i = 0 To 11
            ClearAll()
            FindPath(i)
            PrintPath(i)
            WriteLine("")
        Next
        WriteLine("*****************************************************************************************")
        WriteLine("通过Dijkstra算法已经成功找到从任意单源点出发到达其余各点的最短路径和最短路，最短路径如上")
        WriteLine("接下来进行OD分配")
        WriteLine("*****************************************************************************************")
        WriteLine("请按任意键继续……")
        ReadKey()
        WriteLine()
        Dim K As Integer
        WriteLine()
        WriteLine("请输入OD分配次数：（就本次项目而言，分配次数为4，则输入4）")
        K = Val(ReadLine())
        Dim Percentage(K) As Double
        WriteLine("就本次项目而言，分配百分比依次为【40】 【30】 【20】 【10】")
        For i = 1 To K
            Write("请输入第{0}次分配百分比，并按回车：", i)
            Percentage(i) = Val(ReadLine())
        Next
        WriteLine("*****************************************************************************************")
        WriteLine("参数设置完成")
        Write("分配次数为：")
        WriteLine("{0}次", K)
        WriteLine("每次分配的百分比为：")
        For i = 1 To K
            Console.Write("【{0}】 ", Percentage(i))
        Next
        WriteLine()
        WriteLine("*****************************************************************************************")
        WriteLine("请按任意键开始分配……")
        ReadKey()
        For i = 0 To K
            WriteLine("第{0}次分配：", i + 1)
            For j = 0 To 11
                For K = 0 To 11
                    Matrix(j, K) = QMatrix(j, K) * OdDistributed(j, K) + Matrix0(j, K)
                    ShortestPathSubscriptStringTemp(j, K) = ""
                Next
            Next
            For j = 0 To 11
                ClearAll()
                FindPath(j)
                PrintPath(j)
                Console.WriteLine("")
            Next

            For j = 0 To 11
                For K = 0 To 11
                    OdDistributeTemp(j, K) = (Percentage(i) / 100) * OdOrigine(j, K)
                Next
            Next

            For j = 0 To 11
                For K = 0 To 11
                    Dim x As Integer
                    x = 0
                    For t = 0 To ShortestPathSubscriptStringTemp(j, K).Length - 1
                        If ShortestPathSubscriptStringTemp(j, K).Substring(t, 1) = "/" Then
                            x = x + 1
                        End If
                    Next
                    Dim temp(x) As String
                    Dim y As Integer
                    y = 0
                    For t = 0 To ShortestPathSubscriptStringTemp(j, K).Length - 1
                        If ShortestPathSubscriptStringTemp(j, K).Substring(t, 1) <> "/" Then
                            temp(y) = temp(y) + ShortestPathSubscriptStringTemp(j, K).Substring(t, 1)
                        Else
                            y = y + 1
                        End If
                    Next
                    For t = 0 To temp.Length - 2
                        OdDistributedTemp(Val(temp(t)), Val(temp(t + 1))) += OdDistributeTemp(j, K)
                    Next
                Next
            Next
            For j = 0 To 11
                For K = 0 To 11
                    OdDistributed(j, K) += OdDistributedTemp(j, K)
                    OdDistributedTemp(j, K) = 0
                    OdDistributeTemp(j, K) = 0
                    ShortestPathSubscriptStringTemp(j, K) = ""
                Next
            Next
            WriteLine("*****************************************************************************************")
            WriteLine("打印分配结果如下：")
            For j = 0 To 11
                For K = 0 To 11
                    Write("{0} ", OdDistributed(j, K))
                Next
                WriteLine()
            Next
            WriteLine("*****************************************************************************************")
        Next
        WriteLine("请按任意键继续……")
        ReadKey()
    End Sub
    Sub FindPath(ByVal origin)
        S.Add(origin)
        judgement(origin) = True
        For i = 0 To 11
            If i <> origin Then
                U.Add(i)
            End If
        Next

        For i = 0 To 11

            distance(i) = Matrix(origin, i)
            previousVertex(i) = -1
        Next

        While U.Count > 0

            Dim minWeightSubscript As Integer
            minWeightSubscript = Val(U(0)) '转换INT
            For Each vertex As Integer In U
                If (Not (judgement(vertex))) And (distance(vertex) < distance(minWeightSubscript)) Then
                    minWeightSubscript = vertex
                End If
            Next
            S.Add(minWeightSubscript)
            judgement(minWeightSubscript) = True
            U.Remove(minWeightSubscript)
            For Each vertex As Integer In U
                If (distance(minWeightSubscript) + Matrix(minWeightSubscript, vertex) < distance(vertex)) Then
                    distance(vertex) = distance(minWeightSubscript) + Matrix(minWeightSubscript, vertex)
                    previousVertex(vertex) = minWeightSubscript
                End If
            Next
        End While
    End Sub
    Sub PrintPath(ByVal origin)
        Dim previousPoint As Integer
        Dim S As String
        For i = 0 To 11
            Write("V{0}到V{1}的最短路径为：     V{0}→", origin, i)
            previousPoint = previousVertex(i)
            S = ""
            While previousPoint > -1
                ShortestPathSubscriptStringTemp(origin, i) = previousPoint.ToString() & "/" & ShortestPathSubscriptStringTemp(origin, i)
                S = "V" + previousPoint.ToString() + "→" + S
                previousPoint = previousVertex(previousPoint)
            End While
            ShortestPathSubscriptStringTemp(origin, i) = origin.ToString() & "/" & ShortestPathSubscriptStringTemp(origin, i) & i.ToString()
            Write(S)
            Write("V{0}", i)
            WriteLine("     距离为：{0}", distance(i))

        Next
    End Sub
    Sub ClearAll()
        S.Clear()
        U.Clear()
        Array.Clear(distance, 0, 11)
        Array.Clear(previousVertex, 0, 11)
        Array.Clear(judgement, 0, 11)
    End Sub
End Module
