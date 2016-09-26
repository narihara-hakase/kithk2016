Imports System
Imports System.IO.Ports
Imports System.Reflection
Imports System.ComponentModel
Imports System.IO

Public Class frmMain
    Const MAX_TAG_DISPLAY_IDX As Integer = 99

    ' setting information comes from Form2
    Public strComPort As String
    Public iBaudRate As Integer

    Public strRsvPrefix As String
    Public iRsvStart As Integer
    Public iRsvCount As Integer
    Public bRsvID As Boolean = False

    Public iHistCount As Integer
    Public iHistUpdateLong As Integer

    Public bUpdHalf As Boolean = False

    ' tag data container
    Dim snsObjs As CSnsObjects ' data object update every second
    Dim snsObjsLong As CSnsObjects ' data object update every minutes

    ' text and label component for 'whole view'
    Dim TagDispTxt(MAX_TAG_DISPLAY_IDX) As TextBox
    Dim TagDispLbl(MAX_TAG_DISPLAY_IDX) As Label

    ' the selected tag number for Chart View
    Dim iChartNumber As Integer

    ' tick timer
    Dim thetime As ULong = 0 ' tick time counter incremented at Timer1
    Dim timeChartNumberSelected As ULong = 0 ' store tick count when tag is selected for chart view

    Dim iThTemp As Integer = 25
    Dim iThHumid As Integer = 50
    Dim iThVolt As Integer = 25
    Dim iThLQI As Integer = 80

    Dim iHumdOptShow = 0 ' alternate display at Humid area (0:HUMID, 1:LIGHT, 2:PC)

    Dim chrtTemp As CChartUpdate = Nothing
    Dim chrtHumid As CChartUpdate = Nothing
    Dim chrtLight As CChartUpdate = Nothing
    Dim chrtVolt As CChartUpdate = Nothing
    Dim chrtLQI As CChartUpdate = Nothing
    Dim chrtPC As CChartUpdate = Nothing

    ' anim table
    Dim animcol As CAnimCol = New CAnimCol

    'grab keyboard event before it's passed to controls
    <System.Security.Permissions.UIPermission( _
    System.Security.Permissions.SecurityAction.LinkDemand, _
    Window:=System.Security.Permissions.UIPermissionWindow.AllWindows)> _
    Protected Overrides Function ProcessDialogKey( _
        ByVal keyData As Keys) As Boolean
        If (keyData And Keys.KeyCode) = Keys.Left Or _
           (keyData And Keys.KeyCode) = Keys.Right Or _
           (keyData And Keys.KeyCode) = Keys.Up Or _
           (keyData And Keys.KeyCode) = Keys.Down Or _
           (keyData And Keys.KeyCode) = Keys.X Then

            KeyOp(keyData And Keys.KeyCode)

            ' return means `handled'
            Return True
        End If

        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Class CAnimCol
        Private ColorProfile(100) As Integer

        Sub New()
            Dim i, k As Integer

            ' define color profile 
            For i = 0 To 7
                ColorProfile(i) = (i + 1) * 32 - 1
            Next
            k = i
            For i = k To k + 3
                ColorProfile(i) = 255
            Next
            k = i
            For i = k To k + 7
                ColorProfile(i) = 255 - (i - k) * 12
            Next
            k = i
            For i = k To 99
                ColorProfile(i) = ColorProfile(i - 1) - 3
                If ColorProfile(i) <= 0 Then
                    ColorProfile(i) = 0
                End If
            Next
        End Sub

        Public Function GetColIdx(ByVal t As ULong, ByVal tref As ULong) As Integer
            GetColIdx = 255
            Dim td As ULong

            If t <= tref Then
                td = tref - t
                If td < 100 Then
                    GetColIdx = 255 - ColorProfile(td)
                End If
            End If
        End Function

    End Class

    Public Sub KeyOp(ByVal keycode As Integer)
        Dim iMax, iCol, iRow, iRowMax As Integer

        iMax = 0

        iCol = iChartNumber Mod 10
        iRow = (iChartNumber - iCol) / 10

        For i = 0 To MAX_TAG_DISPLAY_IDX
            If TagDispLbl(i).Visible = True Then
                iMax = i
            End If
        Next

        iRowMax = CInt(iMax / 10)

        If keycode = Keys.Home Then

            If rbTemp.Checked = True Then
                rbLQI.Checked = True
            ElseIf rbHumd.Checked = True Then
                rbTemp.Checked = True
            ElseIf rbVolt.Checked = True Then
                rbHumd.Checked = True
            ElseIf rbLQI.Checked = True Then
                rbVolt.Checked = True
            End If

        ElseIf keycode = Keys.Down Then
            iChartNumber = iChartNumber + 10
            If iChartNumber > iMax Then
                iChartNumber = iChartNumber Mod 10
                If iChartNumber > iMax Then
                    iChartNumber = 0
                End If
            End If

            timeChartNumberSelected = thetime
            UpdateCharts()
        ElseIf keycode = Keys.Up Then
            If iRow = 0 Then
                iRow = iRowMax
            Else
                iRow = iRow - 1
            End If

            iChartNumber = iRow * 10 + iCol
            If iChartNumber > iMax Then
                iChartNumber = iChartNumber - 10
            End If

            timeChartNumberSelected = thetime
            UpdateCharts()
        ElseIf keycode = Keys.Right Then
            iChartNumber = iChartNumber + 1
            If iChartNumber > iMax Then
                iChartNumber = 0
            End If

            timeChartNumberSelected = thetime
            UpdateCharts()

        ElseIf keycode = Keys.Left Then
            iChartNumber = iChartNumber - 1
            If iChartNumber < 0 Then
                iChartNumber = iMax
            End If

            timeChartNumberSelected = thetime
            UpdateCharts()
        ElseIf keycode = Keys.X Then
            If rbTemp.Checked = True Then
                rbHumd.Checked = True
            ElseIf rbHumd.Checked = True Then
                rbVolt.Checked = True
            ElseIf rbVolt.Checked = True Then
                rbLQI.Checked = True
            ElseIf rbLQI.Checked = True Then
                rbTemp.Checked = True
            End If
        End If

    End Sub


    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim s As TextBox
        Dim l As Label

        Dim i As Integer

        ' open setting dialogue
        frmLaunch.Show()

        ' form components
        For i = 0 To MAX_TAG_DISPLAY_IDX

            ' l = Controls("Label" & (i + 1))
            l = New Label()

            l.Size = New Point(60, 15)
            l.Font = New Font("Trebuchet MS", 9)
            l.Cursor = Cursors.Hand
            Controls.Add(l)

            ' s = Controls("TextBox" & (i + 1))
            s = New TextBox()
            s.Size = New Point(50, 25)
            s.Font = New Font("Trebuchet MS", 12)
            s.TextAlign = HorizontalAlignment.Center
            s.TabStop = False
            s.Cursor = Cursors.Hand
            Controls.Add(s)

            TagDispTxt(i) = s
            TagDispLbl(i) = l

            ' locate controls
            Dim p, q As Point
            p.X = (i Mod 10) * 84 + 120
            p.Y = CInt(i / 10 - 0.45) * 50 + 430
            s.Location = p
            s.Width = 60

            q.X = p.X
            q.Y = p.Y - 16
            l.Location = q

            l.Visible = False
            s.Visible = False

            ' register event handler
            AddHandler TagDispTxt(i).Click, AddressOf TextMouseClick
            AddHandler TagDispLbl(i).Click, AddressOf TextMouseClick
            AddHandler TagDispTxt(i).GotFocus, AddressOf TextGotFocus

        Next

        ' set temp
        lblTemp.Text = TrackBar1.Value

    End Sub

    ' start the process
    Public Sub goConnect()
        Dim i As Integer

        MSns.HIST_TABLE_SIZE = iHistCount
        snsObjs = New CSnsObjects
        snsObjsLong = New CSnsObjects

        If bRsvID Then
            Dim iMax As Integer
            Dim strFormat As String = ""

            iMax = iRsvStart + iRsvCount - 1
            While iMax > 0
                strFormat = strFormat + "0"
                iMax = Int(iMax / 10)
            End While

            For i = iRsvStart To iRsvStart + iRsvCount - 1
                Dim str As String

                str = strRsvPrefix + Format(i, strFormat)

                str = ";0;RSV;0;0;" + str + ";3000;2500;5000;0500;000"
                snsObjs.AddEntryTemporary(New CSnsData(str), 0)
                snsObjsLong.AddEntryTemporary(New CSnsData(str), 0)
            Next
        End If

        Timer1.Start()
        Timer2.Start()
        Timer3.Interval = iHistUpdateLong * 1000
        Timer3.Start()

        chkLong.Text = "Slow (" & iHistUpdateLong & "sec) update"

        Try
            SerialPort1.PortName = strComPort
            SerialPort1.BaudRate = iBaudRate

            If SerialPort1.IsOpen = True Then
                Throw New Exception("The Port " & strComPort & " has already been in use.")
            End If
            Call SerialPort1.Open()
        Catch ex As Exception
            MessageBox.Show("Cannot open the port: (" & ex.Message & ")", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try
    End Sub

    ' event handler when got data from serial port
    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim strDataReceived As String
        Dim bFlag As Boolean = True

        While SerialPort1.BytesToRead > 0
            Try
                strDataReceived = SerialPort1.ReadLine
            Catch ex As Exception
                strDataReceived = ex.Message
                bFlag = False
            End Try

            If bFlag Then
                Dim data = New CSnsData(strDataReceived)
                If data.bStored Then
                    snsObjs.AddEntryTemporary(data, thetime)
                    snsObjsLong.AddEntryTemporary(data, thetime)
                    SaveRawLog(data)
                End If
            End If
        End While

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim i, c As Integer

        'PictureBox1.Focus()

        thetime = thetime + 1

        If bUpdHalf And (1 = (thetime Mod 2)) Then
            ' just skip
            Exit Sub
        End If

        For i = 0 To MAX_TAG_DISPLAY_IDX

            Dim hist As CSnsHist
            hist = snsObjs.Find(i)

            If IsNothing(hist) Then
                ' nothing data
                TagDispLbl(i).Visible = False
                TagDispTxt(i).Visible = False
            Else
                Dim data As CSnsData = hist.snsLastData

                If Not IsNothing(data) Then
                    Dim iTarget As Integer
                    Dim iComfort As Integer
                    Dim bReverse As Boolean = False

                    c = animcol.GetColIdx(hist.iTimeStamp, thetime)

                    If rbTemp.Checked Then
                        If data.bTemp Then
                            TagDispTxt(i).Text = Format(data.fTemp, "00.0") & "°C"
                        Else
                            TagDispTxt(i).Text = "--.-°C"
                        End If
                        iTarget = data.fTemp
                        iComfort = 2
                    End If
                    If rbHumd.Checked Then
                        If iHumdOptShow = 0 Then
                            If data.bHumid Then
                                TagDispTxt(i).Text = Format(data.fHumid, "00.0") & "%"
                            Else
                                TagDispTxt(i).Text = "--.-%"
                            End If
                            iTarget = data.fHumid
                            iComfort = 10
                        ElseIf iHumdOptShow = 1 Then
                            If data.bLight Then
                                TagDispTxt(i).Text = data.iLight
                            Else
                                TagDispTxt(i).Text = "---"
                            End If
                            iTarget = data.iLight
                            iComfort = 100
                        ElseIf iHumdOptShow = 2 Then
                            If data.bPC Then
                                TagDispTxt(i).Text = data.iPC
                            Else
                                TagDispTxt(i).Text = "---"
                            End If
                            iTarget = data.iPC
                            iComfort = 2
                        End If

                    End If
                    If rbVolt.Checked Then
                        If data.bVolt Then
                            TagDispTxt(i).Text = data.iVolt
                        Else
                            TagDispTxt(i).Text = "---"
                        End If
                        iTarget = data.iVolt / 100
                        iComfort = 2
                        bReverse = True
                    End If
                    If rbLQI.Checked Then
                        If data.bLQI Then
                            TagDispTxt(i).Text = data.iLQI
                        Else
                            TagDispTxt(i).Text = "---"
                        End If
                        iTarget = data.iLQI
                        iComfort = 10
                        bReverse = True
                    End If

                    Dim f, b As Color

                    If iTarget >= TrackBar1.Value + iComfort Then
                        If bReverse Then
                            b = Color.FromArgb(c, c, 255)
                            f = Color.FromArgb(0, 0, c)
                        Else
                            b = Color.FromArgb(255, c, c)
                            f = Color.FromArgb(c, 0, 0)
                        End If
                    ElseIf iTarget <= TrackBar1.Value - iComfort Then
                        If bReverse Then
                            b = Color.FromArgb(255, c, c)
                            f = Color.FromArgb(c, 0, 0)
                        Else
                            b = Color.FromArgb(c, c, 255)
                            f = Color.FromArgb(0, 0, c)
                        End If
                    Else
                        b = Color.FromArgb(c, 255, c)
                        f = Color.FromArgb(0, c / 2, 0)
                    End If

                    TagDispTxt(i).ForeColor = f
                    TagDispTxt(i).BackColor = b

                    ' Highlight the Label in Graph
                    c = animcol.GetColIdx(timeChartNumberSelected, thetime)

                    If i = iChartNumber Then
                        b = Color.FromArgb(c, 255, c)
                        f = Color.FromArgb(c, 0, c)

                        TagDispLbl(i).ForeColor = f
                        TagDispLbl(i).BackColor = b

                        lblGraphTitle.ForeColor = f
                        If c = 255 Then
                            lblGraphTitle.BackColor = Color.Lavender
                        Else
                            lblGraphTitle.BackColor = b
                        End If
                    Else
                        TagDispLbl(i).ForeColor = Color.Black
                        TagDispLbl(i).BackColor = Color.Transparent
                    End If

                    If i <= MAX_TAG_DISPLAY_IDX Then
                        TagDispLbl(i).Visible = True
                        TagDispLbl(i).Text = data.sID
                        TagDispTxt(i).Visible = True
                    End If
                End If

            End If


        Next

    End Sub

    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar1.Scroll
        If rbVolt.Checked Then
            lblTemp.Text = TrackBar1.Value * 100
        Else
            lblTemp.Text = TrackBar1.Value
        End If
    End Sub

    Private Sub rbTemp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTemp.CheckedChanged
        If rbTemp.Checked = True Then
            rbVolt.Checked = False
            rbHumd.Checked = False
            rbLQI.Checked = False

            TrackBar1.Minimum = 20
            TrackBar1.Maximum = 40

            TrackBar1.Value = iThTemp
            lblTemp.Text = TrackBar1.Value
        Else
            Try
                iThTemp = TrackBar1.Value
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub rbHumd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbHumd.CheckedChanged
        If rbHumd.Checked = True Then
            Try
                If iHumdOptShow = 0 Then
                    rbHumd.Text = "HUMID"
                    TrackBar1.Minimum = 20
                    TrackBar1.Maximum = 80

                    TrackBar1.Value = iThHumid
                ElseIf iHumdOptShow = 1 Then
                    rbHumd.Text = "LIGHT"
                    TrackBar1.Minimum = 0
                    TrackBar1.Maximum = 2000
                ElseIf iHumdOptShow = 2 Then
                    rbHumd.Text = "PlsCt"
                    TrackBar1.Minimum = 0
                    TrackBar1.Maximum = 20
                End If

                rbVolt.Checked = False
                rbTemp.Checked = False
                rbLQI.Checked = False

                lblTemp.Text = TrackBar1.Value
            Catch ex As Exception

            End Try
        Else
            If iHumdOptShow = 0 Then
                iThHumid = TrackBar1.Value
            End If
        End If
    End Sub

    Private Sub rbVolt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbVolt.CheckedChanged
        If rbVolt.Checked = True Then
            Try
                rbHumd.Checked = False
                rbTemp.Checked = False
                rbLQI.Checked = False

                TrackBar1.Minimum = 20
                TrackBar1.Maximum = 36

                TrackBar1.Value = iThVolt
                lblTemp.Text = TrackBar1.Value * 100
            Catch ex As Exception

            End Try
        Else
            iThVolt = TrackBar1.Value
        End If
    End Sub

    Private Sub rbLQI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbLQI.CheckedChanged
        If rbLQI.Checked = True Then
            Try

                rbVolt.Checked = False
                rbTemp.Checked = False
                rbHumd.Checked = False

                TrackBar1.Minimum = 20
                TrackBar1.Maximum = 200

                TrackBar1.Value = iThLQI
                lblTemp.Text = TrackBar1.Value
            Catch ex As Exception

            End Try
        Else
            iThLQI = TrackBar1.Value
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        snsObjs.FinalizeEntry()
        UpdateCharts()

        ' update time information
        Dim dt As DateTime = DateTime.Now
        Dim dt_start As DateTime
        If chkLong.Checked Then
            dt_start = dt.AddSeconds(-(iHistCount * iHistUpdateLong))
            lblTimeEnd.Text = _
                Format(dt.Hour, "00") + ":" + _
                Format(dt.Minute, "00")

            lblTimeStart.Text = _
                Format(dt_start.Hour, "00") + ":" + _
                Format(dt_start.Minute, "00")
        Else
            dt_start = dt.AddSeconds(-iHistCount)
            lblTimeEnd.Text = _
                Format(dt.Hour, "00") + ":" + _
                Format(dt.Minute, "00") + ":" + _
                Format(dt.Second, "00")

            lblTimeStart.Text = _
                Format(dt_start.Hour, "00") + ":" + _
                Format(dt_start.Minute, "00") + ":" + _
                Format(dt_start.Second, "00")
        End If

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        snsObjsLong.FinalizeEntry()
        SaveTick(False)
        UpdateCharts()
    End Sub

    ' generate string as YYYYMMDDhhmm
    Private Function MakeDateFormat(ByVal dt As DateTime) As String
        Dim str As String

        str = Format(dt.Year, "0000") _
            + Format(dt.Month, "00") _
            + Format(dt.Day, "00") _
            + Format(dt.Hour, "00") _
            + Format(dt.Minute, "00")

        MakeDateFormat = str
    End Function

    ' SaveTick, called every minuts (processing every hour)
    '   process all data files and save it into log files
    '   they are saved into "./{ID}/{ID}_yyyymmddhh00.txt"
    '
    Dim lasthour As Integer = -1 ' the last hour number when logs are saved by SaveTick
    Private Sub SaveTick(ByVal bForceSave As Boolean)
        Dim dt As DateTime = DateTime.Now

        Dim bCond As Boolean
        Dim strDate As String

        If Not bForceSave Then
            bCond = (Not dt.Hour = lasthour) And (dt.Minute = 0 Or dt.Minute = 1)
            If dt.Minute = 1 Then
                dt = dt.AddHours(-1)
                dt = dt.AddMinutes(-1)
                strDate = MakeDateFormat(dt)
            Else
                dt = dt.AddHours(-1)
                strDate = MakeDateFormat(dt)
            End If
        Else
            ' debug sequence (save every tick)
            strDate = MakeDateFormat(dt) + Format(dt.Second, "00")
            bCond = True ' for debug (save every minutes)
        End If

        If bCond Then
            lasthour = dt.Hour

            Dim i As Integer
            For i = 0 To Int(3600 / iHistUpdateLong) - 1 ' save last 60 items
                Dim strFile As String
                Dim hist As CSnsHist = snsObjsLong.Find(i)

                If Not IsNothing(hist) Then
                    Dim j As Integer

                    If Not System.IO.Directory.Exists(hist.sID) Then
                        System.IO.Directory.CreateDirectory(hist.sID)
                    End If

                    strFile = hist.sID + "/" + hist.sID + "_" + strDate + ".txt"
                    Dim sw As StreamWriter = New StreamWriter(strFile)

                    sw.WriteLine("#;" + hist.sID + ";" + strDate + ";")

                    For j = 0 To iHistUpdateLong - 1
                        Dim jHistIdx As Integer = hist.GetEntryMax() - iHistUpdateLong + j 'skip the latest data (e.g. 240 ... 299, 300(the latest is skipping)

                        If jHistIdx >= 0 And jHistIdx <= hist.GetEntryMax() Then
                            Dim data As CSnsData = hist.GetEntry(jHistIdx)
                            If Not IsNothing(data) Then
                                sw.WriteLine(data.ToString(strDate, j))
                            Else
                                sw.WriteLine(";;NODT;;" + Format(j, "000") + ";" + hist.sID + ";")
                            End If
                        End If
                    Next

                    sw.Close()

                End If
            Next
        End If

    End Sub

    Private Sub UpdateCharts()
        Dim sobj As CSnsObjects

        If chkLong.Checked Then
            sobj = snsObjsLong
        Else
            sobj = snsObjs
        End If

        Dim hist As CSnsHist = sobj.Find(iChartNumber)

        ' set header title
        If Not IsNothing(hist) Then
            lblGraphTitle.Text = "Chart view: " & hist.sID
        End If

        ' prepare updating object
        If IsNothing(chrtTemp) Then
            chrtTemp = New CChartUpdate(Chart1, New CChartUtilTemp)
        End If
        If IsNothing(chrtHumid) Then
            chrtHumid = New CChartUpdate(Chart2, New CChartUtilHumid)
        End If
        If IsNothing(chrtVolt) Then
            chrtVolt = New CChartUpdate(Chart3, New CChartUtilVolt)
            chrtVolt.iXSplitMajor = 5
            chrtVolt.iXSplitMinor = 6
        End If
        If IsNothing(chrtLQI) Then
            chrtLQI = New CChartUpdate(Chart4, New CChartUtilLQI)
            chrtLQI.iXSplitMajor = 5
            chrtLQI.iXSplitMinor = 6
        End If
        If IsNothing(chrtLight) Then
            chrtLight = New CChartUpdate(Chart2, New CChartUtilLight)
        End If
        If IsNothing(chrtPC) Then
            chrtPC = New CChartUpdate(Chart2, New CChartUtilPC)
        End If

        ' update it!
        chrtTemp.UpdateByHist(hist)
        If iHumdOptShow = 0 Then
            chrtHumid.UpdateByHist(hist)
        ElseIf iHumdOptShow = 1 Then
            chrtLight.UpdateByHist(hist)
        ElseIf iHumdOptShow = 2 Then
            chrtPC.UpdateByHist(hist)
        End If
        chrtVolt.UpdateByHist(hist)
        chrtLQI.UpdateByHist(hist)
    End Sub


    Private Sub TextMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Dim i As Integer

        For i = 0 To MAX_TAG_DISPLAY_IDX
            Try
                If sender.Location = TagDispTxt(i).Location Or sender.Location = TagDispLbl(i).Location Then
                    If TagDispTxt(i).Visible = True Then
                        iChartNumber = i
                        timeChartNumberSelected = thetime
                    End If

                    UpdateCharts()
                End If
            Catch ex As Exception

            End Try
        Next
    End Sub


    Private Sub TextGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        btnDmy.Focus()
    End Sub

    Private Sub btnSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSort.Click
        snsObjs.SortByName()
        snsObjsLong.SortByName()

        ' for debug
        SaveTick(True)

    End Sub

    Private Sub btnDmy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDmy.Click
        frmAbout.Show()
    End Sub

    Private Sub rbHumd_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rbHumd.MouseDown
        If e.Clicks = 2 Then
            iHumdOptShow = (iHumdOptShow + 1) Mod 3
            rbHumd_CheckedChanged(sender, e)
        End If
    End Sub

    Private Sub chkLong_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLong.CheckedChanged
        UpdateCharts()
    End Sub

    Private Sub pictTOCOSbannar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pictTOCOSbannar.Click
        Process.Start("http://mono-wireless.com/")
    End Sub


    Private Sub Chart1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chart1.Click
        Chrt_MouseDown(sender, e)
    End Sub

    Private Sub Chart2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chart2.Click
        Chrt_MouseDown(sender, e)
    End Sub

    Private Sub Chart3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chart3.Click
        Chrt_MouseDown(sender, e)
    End Sub

    Private Sub Chart4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chart4.Click
        Chrt_MouseDown(sender, e)
    End Sub


    Private Sub Chrt_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Dim c As CChartUpdate

        c = htChrt(sender)
        If Not IsNothing(c) Then

            c.iZoomMode = (c.iZoomMode + 1) Mod 4
            UpdateCharts()

        End If
    End Sub

End Class