<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLaunch
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLaunch))
        Me.cbSerial = New System.Windows.Forms.ComboBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.txtRsvStart = New System.Windows.Forms.TextBox()
        Me.Labelt101 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cbBaud = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkReserve = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRsvPrefix = New System.Windows.Forms.TextBox()
        Me.txtRsvCount = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numHistCount = New System.Windows.Forms.NumericUpDown()
        Me.numHistUpdateLong = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkSlowScreenUpd = New System.Windows.Forms.CheckBox()
        CType(Me.numHistCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numHistUpdateLong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbSerial
        '
        Me.cbSerial.FormattingEnabled = True
        Me.cbSerial.Location = New System.Drawing.Point(32, 38)
        Me.cbSerial.Name = "cbSerial"
        Me.cbSerial.Size = New System.Drawing.Size(85, 20)
        Me.cbSerial.TabIndex = 220
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Enabled = False
        Me.lblCount.Location = New System.Drawing.Point(30, 145)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(53, 12)
        Me.lblCount.TabIndex = 219
        Me.lblCount.Text = "StartNum"
        '
        'txtRsvStart
        '
        Me.txtRsvStart.Enabled = False
        Me.txtRsvStart.Location = New System.Drawing.Point(111, 142)
        Me.txtRsvStart.Name = "txtRsvStart"
        Me.txtRsvStart.Size = New System.Drawing.Size(48, 19)
        Me.txtRsvStart.TabIndex = 218
        Me.txtRsvStart.Text = "0"
        '
        'Labelt101
        '
        Me.Labelt101.AutoSize = True
        Me.Labelt101.Location = New System.Drawing.Point(30, 23)
        Me.Labelt101.Name = "Labelt101"
        Me.Labelt101.Size = New System.Drawing.Size(49, 12)
        Me.Labelt101.TabIndex = 217
        Me.Labelt101.Text = "ComPort"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(233, 249)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 44)
        Me.Button2.TabIndex = 215
        Me.Button2.Text = "OPEN"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cbBaud
        '
        Me.cbBaud.FormattingEnabled = True
        Me.cbBaud.Items.AddRange(New Object() {"38400", "115200"})
        Me.cbBaud.Location = New System.Drawing.Point(143, 38)
        Me.cbBaud.Name = "cbBaud"
        Me.cbBaud.Size = New System.Drawing.Size(85, 20)
        Me.cbBaud.TabIndex = 222
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(141, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 12)
        Me.Label1.TabIndex = 221
        Me.Label1.Text = "BaudRate"
        '
        'chkReserve
        '
        Me.chkReserve.AutoSize = True
        Me.chkReserve.Location = New System.Drawing.Point(12, 90)
        Me.chkReserve.Name = "chkReserve"
        Me.chkReserve.Size = New System.Drawing.Size(81, 16)
        Me.chkReserve.TabIndex = 223
        Me.chkReserve.Text = "Reserve ID"
        Me.chkReserve.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(30, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 12)
        Me.Label2.TabIndex = 225
        Me.Label2.Text = "Prefix"
        '
        'txtRsvPrefix
        '
        Me.txtRsvPrefix.Enabled = False
        Me.txtRsvPrefix.Location = New System.Drawing.Point(111, 117)
        Me.txtRsvPrefix.Name = "txtRsvPrefix"
        Me.txtRsvPrefix.Size = New System.Drawing.Size(102, 19)
        Me.txtRsvPrefix.TabIndex = 224
        Me.txtRsvPrefix.Text = "A"
        '
        'txtRsvCount
        '
        Me.txtRsvCount.Enabled = False
        Me.txtRsvCount.Location = New System.Drawing.Point(111, 167)
        Me.txtRsvCount.Name = "txtRsvCount"
        Me.txtRsvCount.Size = New System.Drawing.Size(48, 19)
        Me.txtRsvCount.TabIndex = 226
        Me.txtRsvCount.Text = "50"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(30, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 12)
        Me.Label3.TabIndex = 227
        Me.Label3.Text = "Count"
        '
        'numHistCount
        '
        Me.numHistCount.Location = New System.Drawing.Point(448, 111)
        Me.numHistCount.Maximum = New Decimal(New Integer() {1200, 0, 0, 0})
        Me.numHistCount.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.numHistCount.Name = "numHistCount"
        Me.numHistCount.Size = New System.Drawing.Size(92, 19)
        Me.numHistCount.TabIndex = 228
        Me.numHistCount.Value = New Decimal(New Integer() {300, 0, 0, 0})
        '
        'numHistUpdateLong
        '
        Me.numHistUpdateLong.Location = New System.Drawing.Point(448, 138)
        Me.numHistUpdateLong.Maximum = New Decimal(New Integer() {1200, 0, 0, 0})
        Me.numHistUpdateLong.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numHistUpdateLong.Name = "numHistUpdateLong"
        Me.numHistUpdateLong.Size = New System.Drawing.Size(92, 19)
        Me.numHistUpdateLong.TabIndex = 229
        Me.numHistUpdateLong.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(375, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 12)
        Me.Label4.TabIndex = 230
        Me.Label4.Text = "History Size"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(331, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(111, 12)
        Me.Label5.TabIndex = 231
        Me.Label5.Text = "Slow update time (s)"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkSlowScreenUpd
        '
        Me.chkSlowScreenUpd.AutoSize = True
        Me.chkSlowScreenUpd.Location = New System.Drawing.Point(11, 210)
        Me.chkSlowScreenUpd.Name = "chkSlowScreenUpd"
        Me.chkSlowScreenUpd.Size = New System.Drawing.Size(196, 16)
        Me.chkSlowScreenUpd.TabIndex = 232
        Me.chkSlowScreenUpd.Text = "Update Screen at half fps (15fps)"
        Me.chkSlowScreenUpd.UseVisualStyleBackColor = True
        '
        'frmLaunch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 318)
        Me.Controls.Add(Me.chkSlowScreenUpd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numHistUpdateLong)
        Me.Controls.Add(Me.numHistCount)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtRsvCount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRsvPrefix)
        Me.Controls.Add(Me.chkReserve)
        Me.Controls.Add(Me.cbBaud)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbSerial)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.txtRsvStart)
        Me.Controls.Add(Me.Labelt101)
        Me.Controls.Add(Me.Button2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLaunch"
        Me.Text = "MONO Wireless (20151021-1)"
        CType(Me.numHistCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numHistUpdateLong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbSerial As System.Windows.Forms.ComboBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents txtRsvStart As System.Windows.Forms.TextBox
    Friend WithEvents Labelt101 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cbBaud As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkReserve As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRsvPrefix As System.Windows.Forms.TextBox
    Friend WithEvents txtRsvCount As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents numHistCount As System.Windows.Forms.NumericUpDown
    Friend WithEvents numHistUpdateLong As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkSlowScreenUpd As System.Windows.Forms.CheckBox
End Class
