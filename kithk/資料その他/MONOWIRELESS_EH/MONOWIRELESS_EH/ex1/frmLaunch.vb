Imports System
Imports System.IO.Ports

Public Class frmLaunch
    Dim bLoaded As Boolean

    Private Sub Form2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If bLoaded = False Then
            frmMain.Close()
        End If
    End Sub


    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' find com ports
        ' Get a list of serial port names.
        Dim ports As String() = SerialPort.GetPortNames()

        ' Display each port name to the console.
        Dim port As String
        For Each port In ports
            cbSerial.Items.Add(port)
        Next port
        cbSerial.SelectedIndex = cbSerial.Items.Count - 1
        txtRsvStart.Text = "0"

        cbBaud.SelectedIndex = 1

        bLoaded = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            With frmMain
                .strComPort = cbSerial.SelectedItem
                .iBaudRate = CInt(cbBaud.SelectedItem)

                If chkReserve.Checked Then
                    .bRsvID = True
                    .iRsvStart = CInt(txtRsvStart.Text)
                    .iRsvCount = CInt(txtRsvCount.Text)
                    .strRsvPrefix = txtRsvPrefix.Text

                    If .iRsvCount <= 0 Then
                        Throw New Exception("input error")
                    End If
                End If

                .iHistCount = numHistCount.Value
                .iHistUpdateLong = numHistUpdateLong.Value

                .bUpdHalf = chkSlowScreenUpd.Checked

                .goConnect()
                .WindowState = FormWindowState.Normal

                bLoaded = True

                Me.Close()
            End With

        Catch ex As Exception
            MessageBox.Show("Some error in input dialogue? Terminate...")
            frmMain.Close()
            Me.Close()
        End Try

    End Sub

    Private Sub chkReserve_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReserve.CheckedChanged
        Dim bStat = chkReserve.Checked

        txtRsvCount.Enabled = bStat
        txtRsvPrefix.Enabled = bStat
        txtRsvStart.Enabled = bStat
    End Sub

End Class