<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea4 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend4 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series8 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.lblTemp = New System.Windows.Forms.Label()
        Me.rbTemp = New System.Windows.Forms.RadioButton()
        Me.rbHumd = New System.Windows.Forms.RadioButton()
        Me.rbVolt = New System.Windows.Forms.RadioButton()
        Me.rbLQI = New System.Windows.Forms.RadioButton()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart3 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart4 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btnSort = New System.Windows.Forms.Button()
        Me.btnDmy = New System.Windows.Forms.Button()
        Me.lblGraphTitle = New System.Windows.Forms.Label()
        Me.lblTagsView = New System.Windows.Forms.Label()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.chkLong = New System.Windows.Forms.CheckBox()
        Me.pictTOCOSbannar = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTimeEnd = New System.Windows.Forms.Label()
        Me.lblTimeStart = New System.Windows.Forms.Label()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictTOCOSbannar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 38400
        Me.SerialPort1.PortName = "COM17"
        '
        'Timer1
        '
        Me.Timer1.Interval = 33
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(0, 669)
        Me.TrackBar1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TrackBar1.Maximum = 40
        Me.TrackBar1.Minimum = 20
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(116, 56)
        Me.TrackBar1.TabIndex = 0
        Me.TrackBar1.TabStop = False
        Me.TrackBar1.Value = 25
        '
        'lblTemp
        '
        Me.lblTemp.AutoSize = True
        Me.lblTemp.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemp.Location = New System.Drawing.Point(23, 712)
        Me.lblTemp.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTemp.Name = "lblTemp"
        Me.lblTemp.Size = New System.Drawing.Size(59, 20)
        Me.lblTemp.TabIndex = 216
        Me.lblTemp.Text = "lblTemp"
        '
        'rbTemp
        '
        Me.rbTemp.AutoSize = True
        Me.rbTemp.Checked = True
        Me.rbTemp.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTemp.Location = New System.Drawing.Point(13, 552)
        Me.rbTemp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbTemp.Name = "rbTemp"
        Me.rbTemp.Size = New System.Drawing.Size(66, 24)
        Me.rbTemp.TabIndex = 217
        Me.rbTemp.TabStop = True
        Me.rbTemp.Text = "TEMP"
        Me.rbTemp.UseVisualStyleBackColor = True
        '
        'rbHumd
        '
        Me.rbHumd.AutoSize = True
        Me.rbHumd.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbHumd.Location = New System.Drawing.Point(13, 580)
        Me.rbHumd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbHumd.Name = "rbHumd"
        Me.rbHumd.Size = New System.Drawing.Size(74, 24)
        Me.rbHumd.TabIndex = 218
        Me.rbHumd.Text = "HUMID"
        Me.rbHumd.UseVisualStyleBackColor = True
        '
        'rbVolt
        '
        Me.rbVolt.AutoSize = True
        Me.rbVolt.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbVolt.Location = New System.Drawing.Point(13, 608)
        Me.rbVolt.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbVolt.Name = "rbVolt"
        Me.rbVolt.Size = New System.Drawing.Size(64, 24)
        Me.rbVolt.TabIndex = 219
        Me.rbVolt.Text = "VOLT"
        Me.rbVolt.UseVisualStyleBackColor = True
        '
        'rbLQI
        '
        Me.rbLQI.AutoSize = True
        Me.rbLQI.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLQI.Location = New System.Drawing.Point(13, 635)
        Me.rbLQI.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbLQI.Name = "rbLQI"
        Me.rbLQI.Size = New System.Drawing.Size(52, 24)
        Me.rbLQI.TabIndex = 220
        Me.rbLQI.Text = "LQI"
        Me.rbLQI.UseVisualStyleBackColor = True
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(255, Byte), Integer))
        ChartArea1.AlignmentOrientation = CType((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical Or System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal), System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)
        ChartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[True]
        ChartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea1.AxisX.ScaleBreakStyle.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea1.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Enabled = False
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(-4, 36)
        Me.Chart1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Chart1.Name = "Chart1"
        Series1.BorderWidth = 2
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Color = System.Drawing.Color.Tomato
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series1.YValuesPerPoint = 4
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series2.Color = System.Drawing.Color.Tomato
        Series2.Legend = "Legend1"
        Series2.MarkerColor = System.Drawing.Color.Tomato
        Series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series2.Name = "Series2"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(933, 169)
        Me.Chart1.TabIndex = 221
        Me.Chart1.Text = "chrtData"
        '
        'Chart2
        '
        Me.Chart2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(255, Byte), Integer))
        ChartArea2.AlignmentOrientation = CType((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical Or System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal), System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)
        ChartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[True]
        ChartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea2.AxisX.ScaleBreakStyle.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea2.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Legend2.Enabled = False
        Legend2.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend2)
        Me.Chart2.Location = New System.Drawing.Point(-4, 196)
        Me.Chart2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Chart2.Name = "Chart2"
        Series3.BorderWidth = 2
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series3.YValuesPerPoint = 4
        Series4.ChartArea = "ChartArea1"
        Series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series4.Legend = "Legend1"
        Series4.MarkerColor = System.Drawing.Color.RoyalBlue
        Series4.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series4.Name = "Series2"
        Me.Chart2.Series.Add(Series3)
        Me.Chart2.Series.Add(Series4)
        Me.Chart2.Size = New System.Drawing.Size(933, 169)
        Me.Chart2.TabIndex = 222
        Me.Chart2.Text = "chrtData"
        '
        'Chart3
        '
        Me.Chart3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(255, Byte), Integer))
        ChartArea3.AlignmentOrientation = CType((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical Or System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal), System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)
        ChartArea3.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[True]
        ChartArea3.AxisX.MinorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea3.AxisX.ScaleBreakStyle.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea3.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes
        ChartArea3.Name = "ChartArea1"
        Me.Chart3.ChartAreas.Add(ChartArea3)
        Legend3.Enabled = False
        Legend3.Name = "Legend1"
        Me.Chart3.Legends.Add(Legend3)
        Me.Chart3.Location = New System.Drawing.Point(957, 36)
        Me.Chart3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Chart3.Name = "Chart3"
        Series5.BorderWidth = 2
        Series5.ChartArea = "ChartArea1"
        Series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series5.Color = System.Drawing.Color.DimGray
        Series5.Legend = "Legend1"
        Series5.Name = "Series1"
        Series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series5.YValuesPerPoint = 4
        Series6.ChartArea = "ChartArea1"
        Series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series6.Color = System.Drawing.Color.White
        Series6.Legend = "Legend1"
        Series6.MarkerColor = System.Drawing.Color.DimGray
        Series6.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series6.Name = "Series2"
        Me.Chart3.Series.Add(Series5)
        Me.Chart3.Series.Add(Series6)
        Me.Chart3.Size = New System.Drawing.Size(347, 169)
        Me.Chart3.TabIndex = 223
        Me.Chart3.Text = "chrtData"
        '
        'Chart4
        '
        Me.Chart4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(255, Byte), Integer))
        ChartArea4.AlignmentOrientation = CType((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical Or System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal), System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)
        ChartArea4.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.[True]
        ChartArea4.AxisX.MinorGrid.LineColor = System.Drawing.Color.DarkGray
        ChartArea4.AxisX.ScaleBreakStyle.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        ChartArea4.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes
        ChartArea4.Name = "ChartArea1"
        Me.Chart4.ChartAreas.Add(ChartArea4)
        Legend4.Enabled = False
        Legend4.Name = "Legend1"
        Me.Chart4.Legends.Add(Legend4)
        Me.Chart4.Location = New System.Drawing.Point(957, 196)
        Me.Chart4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Chart4.Name = "Chart4"
        Series7.BorderWidth = 2
        Series7.ChartArea = "ChartArea1"
        Series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series7.Color = System.Drawing.Color.ForestGreen
        Series7.Legend = "Legend1"
        Series7.Name = "Series1"
        Series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series7.YValuesPerPoint = 4
        Series8.ChartArea = "ChartArea1"
        Series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series8.Legend = "Legend1"
        Series8.MarkerColor = System.Drawing.Color.ForestGreen
        Series8.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle
        Series8.Name = "Series2"
        Me.Chart4.Series.Add(Series7)
        Me.Chart4.Series.Add(Series8)
        Me.Chart4.Size = New System.Drawing.Size(347, 169)
        Me.Chart4.TabIndex = 224
        Me.Chart4.Text = "chrtData"
        '
        'btnSort
        '
        Me.btnSort.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSort.Location = New System.Drawing.Point(9, 751)
        Me.btnSort.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSort.Name = "btnSort"
        Me.btnSort.Size = New System.Drawing.Size(96, 55)
        Me.btnSort.TabIndex = 225
        Me.btnSort.TabStop = False
        Me.btnSort.Text = "Sort By ID"
        Me.btnSort.UseVisualStyleBackColor = True
        '
        'btnDmy
        '
        Me.btnDmy.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDmy.Location = New System.Drawing.Point(9, 812)
        Me.btnDmy.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDmy.Name = "btnDmy"
        Me.btnDmy.Size = New System.Drawing.Size(96, 28)
        Me.btnDmy.TabIndex = 226
        Me.btnDmy.TabStop = False
        Me.btnDmy.Text = "About..."
        Me.btnDmy.UseVisualStyleBackColor = True
        '
        'lblGraphTitle
        '
        Me.lblGraphTitle.AutoSize = True
        Me.lblGraphTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblGraphTitle.Font = New System.Drawing.Font("Trebuchet MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGraphTitle.Location = New System.Drawing.Point(207, -1)
        Me.lblGraphTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGraphTitle.Name = "lblGraphTitle"
        Me.lblGraphTitle.Size = New System.Drawing.Size(147, 29)
        Me.lblGraphTitle.TabIndex = 227
        Me.lblGraphTitle.Text = "Chart View: "
        '
        'lblTagsView
        '
        Me.lblTagsView.AutoSize = True
        Me.lblTagsView.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTagsView.Location = New System.Drawing.Point(4, 519)
        Me.lblTagsView.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTagsView.Name = "lblTagsView"
        Me.lblTagsView.Size = New System.Drawing.Size(119, 24)
        Me.lblTagsView.TabIndex = 228
        Me.lblTagsView.Text = "Tag(s) view: "
        '
        'Timer3
        '
        Me.Timer3.Interval = 60000
        '
        'chkLong
        '
        Me.chkLong.AutoSize = True
        Me.chkLong.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.chkLong.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLong.Location = New System.Drawing.Point(957, 5)
        Me.chkLong.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkLong.Name = "chkLong"
        Me.chkLong.Size = New System.Drawing.Size(113, 24)
        Me.chkLong.TabIndex = 229
        Me.chkLong.Text = "Slow Update"
        Me.chkLong.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkLong.UseVisualStyleBackColor = False
        '
        'pictTOCOSbannar
        '
        Me.pictTOCOSbannar.Image = Global.MONOEHDemoAPP.My.Resources.Resources.MONO_WIRELESS_ENGINE_01
        Me.pictTOCOSbannar.InitialImage = Nothing
        Me.pictTOCOSbannar.Location = New System.Drawing.Point(-4, 372)
        Me.pictTOCOSbannar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pictTOCOSbannar.Name = "pictTOCOSbannar"
        Me.pictTOCOSbannar.Size = New System.Drawing.Size(2560, 128)
        Me.pictTOCOSbannar.TabIndex = 230
        Me.pictTOCOSbannar.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PictureBox1.Location = New System.Drawing.Point(-4, -6)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(2560, 381)
        Me.PictureBox1.TabIndex = 232
        Me.PictureBox1.TabStop = False
        '
        'lblTimeEnd
        '
        Me.lblTimeEnd.AutoSize = True
        Me.lblTimeEnd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTimeEnd.Location = New System.Drawing.Point(840, 26)
        Me.lblTimeEnd.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTimeEnd.Name = "lblTimeEnd"
        Me.lblTimeEnd.Size = New System.Drawing.Size(48, 15)
        Me.lblTimeEnd.TabIndex = 233
        Me.lblTimeEnd.Text = "Label1"
        '
        'lblTimeStart
        '
        Me.lblTimeStart.AutoSize = True
        Me.lblTimeStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTimeStart.Location = New System.Drawing.Point(84, 25)
        Me.lblTimeStart.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTimeStart.Name = "lblTimeStart"
        Me.lblTimeStart.Size = New System.Drawing.Size(48, 15)
        Me.lblTimeStart.TabIndex = 234
        Me.lblTimeStart.Text = "Label1"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1320, 854)
        Me.Controls.Add(Me.lblTimeStart)
        Me.Controls.Add(Me.lblTimeEnd)
        Me.Controls.Add(Me.chkLong)
        Me.Controls.Add(Me.lblGraphTitle)
        Me.Controls.Add(Me.Chart4)
        Me.Controls.Add(Me.Chart3)
        Me.Controls.Add(Me.Chart2)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblTagsView)
        Me.Controls.Add(Me.btnDmy)
        Me.Controls.Add(Me.btnSort)
        Me.Controls.Add(Me.rbLQI)
        Me.Controls.Add(Me.rbVolt)
        Me.Controls.Add(Me.rbHumd)
        Me.Controls.Add(Me.rbTemp)
        Me.Controls.Add(Me.lblTemp)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.pictTOCOSbannar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "MONO Wireless (20151021-1)"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictTOCOSbannar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents lblTemp As System.Windows.Forms.Label
    Friend WithEvents rbTemp As System.Windows.Forms.RadioButton
    Friend WithEvents rbHumd As System.Windows.Forms.RadioButton
    Friend WithEvents rbVolt As System.Windows.Forms.RadioButton
    Friend WithEvents rbLQI As System.Windows.Forms.RadioButton
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Chart3 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Chart4 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents btnSort As System.Windows.Forms.Button
    Friend WithEvents btnDmy As System.Windows.Forms.Button
    Friend WithEvents lblGraphTitle As System.Windows.Forms.Label
    Friend WithEvents lblTagsView As System.Windows.Forms.Label
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents chkLong As System.Windows.Forms.CheckBox
    Friend WithEvents pictTOCOSbannar As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTimeEnd As System.Windows.Forms.Label
    Friend WithEvents lblTimeStart As System.Windows.Forms.Label

End Class
