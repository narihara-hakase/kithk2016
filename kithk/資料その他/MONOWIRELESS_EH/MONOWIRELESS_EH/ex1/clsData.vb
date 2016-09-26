Imports System.IO

Module MSns

    Public HIST_TABLE_SIZE As Integer = 300
    Public Const SNS_ERROR_DATA As Integer = -32760

    Private MAX_AVERAGE As Integer = 30000 ' maximu times of average

    ' check sensor data
    Public Function IsSnsError(ByVal value As Double) As Boolean
        IsSnsError = False
        If value <= SNS_ERROR_DATA Then
            IsSnsError = True
        End If
    End Function


    ' represents A SINGLE DATA entry
    Public Class CSnsData
        Property iVolt As Integer
        Property fHumid As Single
        Property fTemp As Single
        Property iLQI As Integer
        Property iLight As Integer
        Property iPC As Integer
        Property bVolt As Boolean
        Property bHumid As Boolean
        Property bTemp As Boolean
        Property bLQI As Boolean
        Property bLight As Boolean
        Property bPC As Boolean
        Property iSeq As Integer

        Property sID As String
        Property bStored As String

        ' validate and store input data text
        Private Function checkValue(ByRef str As String, ByRef bRet As Boolean) As Integer
            bRet = False
            checkValue = 0

            Try
                checkValue = CInt(str)
                If IsSnsError(checkValue) Then
                    ' error value
                Else
                    bRet = True
                End If

            Catch ex As Exception
                ' error value
            End Try
        End Function

        ' 
        Public Sub New()
            iVolt = 0
            fHumid = 0
            fTemp = 0
            iLQI = 0
            iLight = 0
            iPC = 0
            iSeq = 0

            bVolt = False
            bHumid = False
            bTemp = False
            bLQI = False
            bLight = False
            bPC = False

            bStored = False
            sID = ""
        End Sub

        ' take it back to the strign
        Overloads Function ToString(ByVal strTimeStamp As String, ByVal ct As Integer) As String
            Dim str As String

            str = ";" + strTimeStamp _
                + ";" + "DATA" _
                + ";" + Format(iLQI, "000") _
                + ";" + Format(ct, "000") _
                + ";" + sID

            If bVolt Then
                str = str + ";" + Format(iVolt, "0000")
            Else
                str = str + ";"
            End If

            If bTemp Then
                ' str = str + ";" + Format(fTemp, "00.00")
                str = str + ";" + Format(fTemp * 100, "0000")
            Else
                str = str + ";"
            End If

            If bHumid Then
                ' str = str + ";" + Format(fHumid, "00.00")
                str = str + ";" + Format(fHumid * 100, "0000")
            Else
                str = str + ";"
            End If

            If bLight Then
                str = str + ";" + Format(iLight, "000")
            Else
                str = str + ";"
            End If

            str = str + ";" + Format(iPC, "0")

            ToString = str
        End Function


        Overloads Function ToString() As String
            Dim dt As DateTime = DateTime.Now
            ToString = ToString(dt.ToString(), iSeq)
        End Function


        ' construct by data text
        Public Sub New(ByVal str As String)
            Dim aStr As String()
            bStored = False

            Dim bSeq As Boolean

            ' format sample is as below
            ' ;379010;001BC501207008B2;132;016;07008B2;2990;2779;5285;0000;000;
            aStr = Split(str, ";", 16)

            If (aStr.Length >= 11) Then
                iLQI = checkValue(aStr(3), bLQI)
                iSeq = checkValue(aStr(4), bSeq)
                sID = aStr(5)
                iVolt = checkValue(aStr(6), bVolt)
                fTemp = checkValue(aStr(7), bTemp)
                fHumid = checkValue(aStr(8), bHumid)
                iLight = checkValue(aStr(9), bLight)
                iPC = checkValue(aStr(10), bPC)

                fTemp = fTemp / 100.0
                fHumid = fHumid / 100.0
                iLight = iLight ' x5 は紛らわしいのでやめた (2013/1/8)

                bStored = True
            End If
        End Sub

        ' copy constructor
        Public Sub New(ByRef data As CSnsData)
            iVolt = data.iVolt
            fHumid = data.fHumid
            fTemp = data.fTemp
            iLQI = data.iLQI
            iLight = data.iLight
            iPC = data.iPC

            bVolt = data.bVolt
            bHumid = data.bHumid
            bTemp = data.bTemp
            bLQI = data.bLQI
            bLight = data.bLight
            bPC = data.bPC

            sID = data.sID
            bStored = data.bStored
        End Sub
    End Class

    Public Class CSnsDataAverage
        Inherits CSnsData

        Dim iCtVolt, iCtHumid, iCtTemp, iCtLQI, iCtLight, iCtPC As Integer

        Public Sub Add(ByRef data As CSnsData)
            If data.bVolt And iCtVolt < MAX_AVERAGE Then
                iCtVolt = iCtVolt + 1
                iVolt = iVolt + data.iVolt
                bVolt = True
            End If
            If data.bHumid And iCtHumid < MAX_AVERAGE Then
                iCtHumid = iCtHumid + 1
                fHumid = fHumid + data.fHumid
                bHumid = True
            End If
            If data.bTemp And iCtTemp < MAX_AVERAGE Then
                iCtTemp = iCtTemp + 1
                fTemp = fTemp + data.fTemp
                bTemp = True
            End If
            If data.bLQI And iCtLQI < MAX_AVERAGE Then
                iCtLQI = iCtLQI + 1
                iLQI = iLQI + data.iLQI
                bLQI = True
            End If
            If data.bLight And iCtLight < MAX_AVERAGE Then
                iCtLight = iCtLight + 1
                iLight = iLight + data.iLight
                bLight = True
            End If
            If data.bPC And iCtPC < MAX_AVERAGE Then
                iCtPC = iCtPC + 1
                iPC = iPC + data.iPC
                bPC = True
            End If

            sID = data.sID
        End Sub

        Public Function GetAverage() As CSnsData
            GetAverage = New CSnsData()

            With GetAverage
                If bVolt Then
                    .iVolt = iVolt / iCtVolt
                    .bVolt = True
                    .bStored = True
                End If
                If bHumid Then
                    .fHumid = fHumid / iCtHumid
                    .bHumid = True
                    .bStored = True
                End If
                If bTemp Then
                    .fTemp = fTemp / iCtTemp
                    .bTemp = True
                    .bStored = True
                End If
                If bLQI Then
                    .iLQI = iLQI / iCtLQI
                    .bLQI = True
                    .bStored = True
                End If
                If bLight Then
                    .iLight = iLight / iCtLight
                    .bLight = True
                    .bStored = True
                End If
                If bPC Then
                    .iPC = iPC / iCtPC
                    .bPC = True
                    .bStored = True
                End If
            End With
        End Function
    End Class

    ' represents ONE SENSOR DATA entry with history
    Public Class CSnsHist
        Property iTimeStamp As Integer ' the time stamp of the latest sensor data
        Property snsLastData As CSnsData ' store the last sensor data (same as snsComingData, but will not be set as Nothing)
        Private snsHist() As CSnsData ' history buffer (use as ring buffer)
        Private iIdx As Integer ' current index of buffer
        Property sID As String ' the sensor ID string

        Private iMaxTable As Integer

        Private snsAverage As CSnsDataAverage = New CSnsDataAverage ' store average date

        ' constructor
        Public Sub New()
            Dim i As Integer
            iMaxTable = HIST_TABLE_SIZE
            snsHist = New CSnsData(iMaxTable) {}

            For i = 0 To iMaxTable
                snsHist(i) = Nothing
            Next
            sID = Nothing
        End Sub

        ' put the latest Sensor Data
        Public Sub AddEntryTemporary(ByVal data As CSnsData, ByVal ts As ULong)
            snsLastData = data
            iTimeStamp = ts

            snsAverage.Add(data)

            If IsNothing(sID) Then
                sID = data.sID
            End If
        End Sub

        ' store the latest coming data into history buffer
        ' (called by periodical timer, like 1sec)
        Public Sub FinalizeEntry()
            Dim data As CSnsData

            iIdx = iIdx + 1
            If iIdx > iMaxTable Then
                iIdx = 0
            End If
            data = snsAverage.GetAverage()
            data.sID = sID
            If data.bStored Then
                snsHist(iIdx) = data
            Else
                snsHist(iIdx) = Nothing
            End If
            snsAverage = New CSnsDataAverage
        End Sub

        ' get a sensor data entry from history buffer by index.
        '   0: oldest
        '   HIST_TABLE_SIZE: latest
        Public Function GetEntry(ByVal i As Integer) As CSnsData
            i = i + iIdx + 1
            If i > iMaxTable Then
                i = i - iMaxTable - 1
            End If

            If i > iMaxTable Then
                GetEntry = Nothing
            Else
                GetEntry = snsHist(i)
            End If
        End Function

        ' return the maximum index of history buffer (0 .. GetEntryMax())
        Public Function GetEntryMax() As Integer
            GetEntryMax = iMaxTable
        End Function
    End Class

    ' represents Many Sensors
    Public Class CSnsObjects
        Private htDataByName As Hashtable ' index is sensor ID name
        Private htDataByIdx As Hashtable  ' index is serial number (just for displaying)
        Private htIdx As Hashtable        ' index is sensor ID name and stores serial number
        Private iNumEntry As Integer      ' Number of Max entries (seems not used...)

        Public Sub New()
            htDataByName = New Hashtable
            htDataByIdx = New Hashtable
            htIdx = New Hashtable
            iNumEntry = 0
        End Sub

        ' add the latest sensor data entry
        '   if the sensor ID appears at the first time, the new CSnsHist entry is added
        Public Function AddEntryTemporary(ByVal data As CSnsData, ByVal ts As ULong) As Boolean
            Dim bRet As Boolean = False
            Dim sh As CSnsHist

            If (Not IsNothing(data)) And (Not IsNothing(data.sID)) And (data.bStored) Then
                ' find data from hash table
                sh = htDataByName(data.sID)
                If IsNothing(sh) Then
                    ' save serial index
                    htIdx(data.sID) = iNumEntry

                    ' create new history object
                    sh = New CSnsHist()
                    htDataByName(data.sID) = sh
                    htDataByIdx(iNumEntry) = sh
                    sh.AddEntryTemporary(data, ts)

                    iNumEntry = iNumEntry + 1

                    bRet = True
                Else
                    sh.AddEntryTemporary(data, ts)

                    bRet = True
                End If
            End If

            AddEntryTemporary = bRet
        End Function

        ' store as history index
        Public Sub FinalizeEntry()

            Dim i As Integer
            For i = 0 To htDataByIdx.Count - 1
                Dim hist As CSnsHist

                hist = htDataByIdx.Values(i)
                hist.FinalizeEntry()
            Next
        End Sub

        ' find a CSnsHist object by sensor ID string
        Public Function Find(ByRef str As String) As CSnsHist
            Find = htDataByName(str)
        End Function

        ' find a serial number by sensor ID string
        Public Function FindSerial(ByRef str As String) As Integer
            Dim iRet As Integer

            If (Not IsNothing(str)) And IsNothing(htIdx(str)) Then
                iRet = -1
            Else
                iRet = htIdx(str)
            End If

            FindSerial = iRet
        End Function

        ' find a CSnsHist object by serial number
        Public Function Find(ByRef i As Integer) As CSnsHist
            Find = htDataByIdx(i)
        End Function

        Public Property Count() As Integer
            Get
                Return iNumEntry
            End Get
            Set(ByVal Value As Integer)
                ' do nothing
            End Set
        End Property

        ' serial number is sorted by sensor ID name
        Public Sub SortByName()
            Dim sl As New SortedList(htDataByName)
            Dim i As Integer = 0

            htIdx = New Hashtable
            htDataByIdx = New Hashtable

            For Each item As Object In sl.Values
                Dim hist As CSnsHist

                hist = DirectCast(item, CSnsHist)
                htIdx(i) = hist
                htDataByIdx(i) = hist
                i = i + 1
            Next

        End Sub

    End Class


    ' Save 
    Public Sub SaveRawLog(ByRef data As CSnsData)
        Dim strFile As String
        Dim strDate As String
        Dim strOut As String
        Dim dt As DateTime = DateTime.Now

        strDate = _
              Format(dt.Year, "0000") _
            + Format(dt.Month, "00") _
            + Format(dt.Day, "00") _
            + Format(dt.Hour, "00")
        
        If Not System.IO.Directory.Exists(data.sID) Then
            System.IO.Directory.CreateDirectory(data.sID)
        End If

        ' strFile = data.sID + "/" + data.sID + "_" + strDate + "_raw.txt"
        strFile = data.sID + "/" + "raw.txt"
        Dim sw As StreamWriter = New StreamWriter(strFile, True)

        strOut = data.ToString()
        sw.WriteLine(strOut)
        sw.Close()

    End Sub

End Module
