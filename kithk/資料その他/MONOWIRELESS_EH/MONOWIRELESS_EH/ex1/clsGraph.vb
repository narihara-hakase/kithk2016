Module MChrt
    Public htChrt As Hashtable = New Hashtable

    Class CChartBasic
        Protected chrt As System.Windows.Forms.DataVisualization.Charting.Chart

        Protected Sub SetChartObj(ByRef c As System.Windows.Forms.DataVisualization.Charting.Chart)
            chrt = c
        End Sub

        Protected Sub New()
        End Sub

        Public Sub New(ByRef c As System.Windows.Forms.DataVisualization.Charting.Chart)
            SetChartObj(c)
        End Sub

        Public Sub Clear()
            chrt.Series("Series1").Points.Clear()
            chrt.Series("Series2").Points.Clear()
        End Sub

        Public Sub AddLineXY(ByVal x As Double, ByVal y As Double)
            chrt.Series("Series1").Points.AddXY(x, y)
        End Sub

        Public Sub AddPointXY(ByVal x As Double, ByVal y As Double)
            chrt.Series("Series2").Points.AddXY(x, y)
        End Sub

        Public Property Y_Title() As String
            Get
                Return chrt.ChartAreas("ChartArea1").AxisY.Title
            End Get
            Set(ByVal Value As String)
                chrt.ChartAreas("ChartArea1").AxisY.Title = Value
            End Set
        End Property

        Public Property X_Title() As String
            Get
                Return chrt.ChartAreas("ChartArea1").AxisX.Title
            End Get
            Set(ByVal Value As String)
                chrt.ChartAreas("ChartArea1").AxisX.Title = Value
            End Set
        End Property

        Public Property X_Min() As Double
            Get
                Return chrt.ChartAreas("ChartArea1").AxisX.Minimum
            End Get
            Set(ByVal Value As Double)
                chrt.ChartAreas("ChartArea1").AxisX.Minimum = Value
            End Set
        End Property

        Public Property X_Max() As Double
            Get
                Return chrt.ChartAreas("ChartArea1").AxisX.Maximum
            End Get
            Set(ByVal Value As Double)
                chrt.ChartAreas("ChartArea1").AxisX.Maximum = Value
            End Set
        End Property

        Public Property X_Interval() As Double
            Get
                Return chrt.ChartAreas("ChartArea1").AxisX.Interval
            End Get
            Set(ByVal Value As Double)
                chrt.ChartAreas("ChartArea1").AxisX.Interval = Value
            End Set
        End Property

        Public Property X_IntervalSub() As Double
            Get
                Return chrt.ChartAreas("ChartArea1").AxisX.MinorGrid.Interval
            End Get
            Set(ByVal Value As Double)
                chrt.ChartAreas("ChartArea1").AxisX.MinorGrid.Interval = Value
            End Set
        End Property

        Public Property X_SubGridEnabled() As Boolean
            Get
                Return chrt.ChartAreas("ChartArea1").AxisX.MinorGrid.Enabled
            End Get
            Set(ByVal Value As Boolean)
                chrt.ChartAreas("ChartArea1").AxisX.MinorGrid.Enabled = Value
            End Set
        End Property

        Public Property Y_Min() As Double
            Get
                Return chrt.ChartAreas("ChartArea1").AxisY.Minimum
            End Get
            Set(ByVal Value As Double)
                chrt.ChartAreas("ChartArea1").AxisY.Minimum = Value
            End Set
        End Property

        Public Property Y_Max() As Double
            Get
                Return chrt.ChartAreas("ChartArea1").AxisY.Maximum
            End Get
            Set(ByVal Value As Double)
                chrt.ChartAreas("ChartArea1").AxisY.Maximum = Value
            End Set
        End Property
    End Class

    Class CChartUpdate
        Inherits CChartBasic

        Private dPrev As Double
        Private bPrev As Boolean

        Private chrtUt As IChartUtil

        Property iXSplitMajor As Integer
        Property iXSplitMinor As Integer

        Property iZoomMode As Integer ' 0:none, 1:50%, 2:80%, 3:90%

        Public Sub New(ByRef c As System.Windows.Forms.DataVisualization.Charting.Chart, _
                       ByRef u As IChartUtil)

            dPrev = 0.0
            bPrev = False

            chrtUt = u
            SetChartObj(c)

            X_Min = 0
            X_Max = HIST_TABLE_SIZE

            iXSplitMajor = 10
            iXSplitMinor = 3
        End Sub

        Private Sub SetGridX(ByVal iMaxCount As Integer)
            Dim i, j As Integer

            ' calculate X axis interval (10 divide, 10.0 step, roundup)
            ' i = Int(Int(iMaxCount / iXSplitMajor + 9.99999) / iXSplitMajor) * iXSplitMajor
            i = Int((iMaxCount / iXSplitMajor) / 10) * 10
            j = (iMaxCount / iXSplitMajor) Mod 10
            If j > 0 Then
                i = i + 10
            End If

            X_Interval = i
            X_IntervalSub = i / iXSplitMinor
            X_SubGridEnabled = True

        End Sub

        Public Sub UpdateByHist(ByRef hist As CSnsHist)
            Dim dMax As Double
            Dim dMin As Double

            htChrt(chrt) = Me ' save myself (for event handling)

            chrtUt.ChartInit(Me)
            Clear()

            If Not IsNothing(hist) Then
                Dim i As Integer
                Dim bSkip = True
                bPrev = False
                dMax = -100000.0
                dMin = 100000.0

                X_Max = hist.GetEntryMax()
                If iZoomMode = 0 Then
                    X_Min = 0
                ElseIf iZoomMode = 1 Then
                    X_Min = X_Max * 0.5
                ElseIf iZoomMode = 2 Then
                    X_Min = X_Max * 0.8
                ElseIf iZoomMode = 3 Then
                    X_Min = X_Max * 0.9
                End If

                SetGridX(X_Max)

                For i = 0 To hist.GetEntryMax()
                    Dim data As CSnsData = hist.GetEntry(i)
                    Dim value As Double
                    Dim bRet As Boolean

                    bRet = chrtUt.GetData(value, data)

                    ' skip first nothing data
                    If (Not IsNothing(data)) And bRet And bSkip Then
                        bSkip = False

                        AddLineXY(0, value)
                    End If

                    ' data plot
                    If (Not IsNothing(data)) And bRet Then
                        AddLineXY(i, value)
                        AddPointXY(i, value)

                        ' save previous data
                        dPrev = value
                        bPrev = True

                        ' update max, min
                        If value > dMax Then
                            dMax = value
                        End If
                        If value < dMin Then
                            dMin = value
                        End If
                    Else
                        If (i = hist.GetEntryMax()) And bPrev Then
                            AddLineXY(i, dPrev)
                        End If
                    End If
                Next

                If bPrev Then
                    chrtUt.AdjustXRange(dMin, dMax)
                    Y_Max = dMax
                    Y_Min = dMin
                Else
                    ' nothing data set
                    AddLineXY(0, 0)
                End If
            End If
        End Sub

    End Class

    Interface IChartUtil
        Sub ChartInit(ByVal chrt As CChartUpdate)
        Function GetData(ByRef refValue As Double, ByRef data As CSnsData) As Boolean
        Sub AdjustXRange(ByRef dMin As Double, ByRef dMax As Double)
    End Interface

    Class CChartUtilTemp
        Implements IChartUtil


        Public Sub ChartInit(ByVal chrt As CChartUpdate) Implements IChartUtil.ChartInit
            chrt.Y_Title = "TEMP [degC]"

            chrt.Y_Min = -10
            chrt.Y_Max = 40
        End Sub

        Public Function GetData(ByRef refValue As Double, ByRef data As CSnsData) As Boolean Implements IChartUtil.GetData
            GetData = False
            If Not IsNothing(data) Then
                refValue = data.fTemp
                GetData = data.bTemp
            End If
        End Function

        Public Sub AdjustXRange(ByRef dMin As Double, ByRef dMax As Double) Implements IChartUtil.AdjustXRange
            If dMax > 40 Then
                dMax = 80
            Else
                dMax = 40
            End If

            If dMin <= 0 Then
                dMin = -40
            Else
                dMin = 0
            End If
        End Sub
    End Class


    Class CChartUtilHumid
        Implements IChartUtil

        Public Sub ChartInit(ByVal chrt As CChartUpdate) Implements IChartUtil.ChartInit
            chrt.Y_Title = "HUMID [%]"

            chrt.Y_Min = 0
            chrt.Y_Max = 100
        End Sub

        Public Function GetData(ByRef refValue As Double, ByRef data As CSnsData) As Boolean Implements IChartUtil.GetData
            GetData = False
            If Not IsNothing(data) Then
                refValue = data.fHumid
                GetData = data.bHumid
            End If
        End Function

        Public Sub AdjustXRange(ByRef dMin As Double, ByRef dMax As Double) Implements IChartUtil.AdjustXRange
            dMin = 0
            dMax = 100
        End Sub
    End Class

    Class CChartUtilLight
        Implements IChartUtil

        Public Sub ChartInit(ByVal chrt As CChartUpdate) Implements IChartUtil.ChartInit
            chrt.Y_Title = "LIGHT [Lux]"

            chrt.Y_Min = 0
            chrt.Y_Max = 1000
        End Sub

        Public Function GetData(ByRef refValue As Double, ByRef data As CSnsData) As Boolean Implements IChartUtil.GetData
            GetData = False
            If Not IsNothing(data) Then
                refValue = data.iLight
                GetData = data.bLight
            End If
        End Function

        Public Sub AdjustXRange(ByRef dMin As Double, ByRef dMax As Double) Implements IChartUtil.AdjustXRange
            If dMax > 25000 Then
                dMax = 60000
            ElseIf dMax > 10000 Then
                dMax = 25000
            ElseIf dMax > 1000 Then
                dMax = 10000
            Else
                dMax = 1000
            End If
            dMin = 0
        End Sub
    End Class


    Class CChartUtilVolt
        Implements IChartUtil

        Public Sub ChartInit(ByVal chrt As CChartUpdate) Implements IChartUtil.ChartInit
            chrt.Y_Title = "Volt [mV]"

            chrt.Y_Min = 2000
            chrt.Y_Max = 3600
        End Sub

        Public Function GetData(ByRef refValue As Double, ByRef data As CSnsData) As Boolean Implements IChartUtil.GetData
            GetData = False
            If Not IsNothing(data) Then
                refValue = data.iVolt
                GetData = data.bVolt
            End If
        End Function

        Public Sub AdjustXRange(ByRef dMin As Double, ByRef dMax As Double) Implements IChartUtil.AdjustXRange
            dMax = 3600
            dMin = 2000
        End Sub
    End Class

    Class CChartUtilLQI
        Implements IChartUtil

        Public Sub ChartInit(ByVal chrt As CChartUpdate) Implements IChartUtil.ChartInit
            chrt.Y_Title = "LQI [0..255]"

            chrt.Y_Min = 0
            chrt.Y_Max = 250
        End Sub

        Public Function GetData(ByRef refValue As Double, ByRef data As CSnsData) As Boolean Implements IChartUtil.GetData
            GetData = False
            If Not IsNothing(data) Then
                refValue = data.iLQI
                GetData = data.bLQI
            End If
        End Function

        Public Sub AdjustXRange(ByRef dMin As Double, ByRef dMax As Double) Implements IChartUtil.AdjustXRange
            dMax = 250
            dMin = 0
        End Sub
    End Class

    Class CChartUtilPC
        Implements IChartUtil

        Public Sub ChartInit(ByVal chrt As CChartUpdate) Implements IChartUtil.ChartInit
            chrt.Y_Title = "PlsCt"

            chrt.Y_Min = 0
            chrt.Y_Max = 100
        End Sub

        Public Function GetData(ByRef refValue As Double, ByRef data As CSnsData) As Boolean Implements IChartUtil.GetData
            GetData = False
            If Not IsNothing(data) Then
                refValue = data.iPC
                GetData = data.bPC
            End If
        End Function

        Public Sub AdjustXRange(ByRef dMin As Double, ByRef dMax As Double) Implements IChartUtil.AdjustXRange
            If dMax > 50 Then
                dMax = 250
            ElseIf dMax > 10 Then
                dMax = 50
            Else
                dMax = 10
            End If

            dMin = 0
        End Sub
    End Class
End Module
