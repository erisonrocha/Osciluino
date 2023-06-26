Imports System.ComponentModel
Imports System.IO.Ports
Imports System.Text.RegularExpressions

Public Class Form1

    Private Shared IsRunning As Boolean = False
    Private Shared WithEvents sp As SerialPort
    Private Shared PlotName As String = "OscData"
    Private Shared PleaseConfigPlot As Boolean = False
    Private Shared DataFileFullPath As String = ""

    Sub PlotConfig(Optional ByVal DoNotClear = False)

        If Not DoNotClear Then OscChart.Series(PlotName).Points.Clear()
        OscChart.Series(PlotName).ChartType = DataVisualization.Charting.SeriesChartType.Line 'StepLine
        OscChart.Series(PlotName).BorderWidth = 2
        OscChart.ChartAreas(OscChart.ChartAreas.Count - 1).AxisY.Title = UnidadeYComboBox.Text '"V"
        OscChart.ChartAreas(OscChart.ChartAreas.Count - 1).AxisX.Title = If(sRadioButton.Checked, "s", "ms") '"ms"

        OscChart.ChartAreas(OscChart.ChartAreas.Count - 1).AxisY.Minimum = 0.0
        OscChart.ChartAreas(OscChart.ChartAreas.Count - 1).AxisX.Minimum = If(OscChart.Series(PlotName).Points.Count > 0, OscChart.Series(PlotName).Points(0).XValue, 0.0)

        OscChart.ChartAreas(OscChart.ChartAreas.Count - 1).AxisX.MajorGrid.Enabled = False
        OscChart.ChartAreas(OscChart.ChartAreas.Count - 1).AxisX.MinorGrid.Enabled = False
        OscChart.ChartAreas(OscChart.ChartAreas.Count - 1).AxisY.MajorGrid.Enabled = False
        OscChart.ChartAreas(OscChart.ChartAreas.Count - 1).AxisY.MinorGrid.Enabled = False

        If GetNumberCB(JanelaYComboBox) > 0 Then
            OscChart.ChartAreas(OscChart.ChartAreas.Count - 1).AxisY.Maximum = JanelaYComboBox.Text
        Else
            OscChart.ChartAreas(OscChart.ChartAreas.Count - 1).AxisY.Maximum = 1023.0
        End If

    End Sub

    Private Function GetNumberCB(cb As ComboBox) As String
        Dim s As String = 0
        cb.Text = cb.Text.Trim
        If cb.Text <> "" Then
            If IsNumeric(cb.Text) Then
                s = cb.Text
            End If
        End If
        Return s
    End Function

    Private Sub EnableControls(ByVal enable As Boolean)
        JanelaYComboBox.Enabled = enable
        sRadioButton.Enabled = enable
        msRadioButton.Enabled = enable
        UnidadeYComboBox.Enabled = enable
        StartButton.Enabled = enable
        PortaComboBox.Enabled = enable
        SalvarArquivoDadosButton.Enabled = enable
        CaminhoArquivoComboBox.Enabled = enable
    End Sub
    Private Async Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click

        Try
            Dim PodeSalvarDados As Boolean = False
            If DataFileFullPath.Trim <> "" Then
                If Not New IO.FileInfo(DataFileFullPath).Exists Then
                    Throw New Exception("Caminho arquivos de dados não encontrado! Por favor, salve-o de novo.")
                Else
                    PodeSalvarDados = True
                End If
            End If

            Dim janelay As String = Invoke(Function() GetNumberCB(JanelaYComboBox))
            If janelay = "0" Then Throw New Exception("Janela Y não pode ser zero!")

            Dim unidadex As Double = If(sRadioButton.Checked, 1000, 1)

            Dim porta As String = Invoke(Function() PortaComboBox.Text.ToUpper)
            If Not New Regex("\bCOM[1-9]\d*\b$", RegexOptions.IgnorePatternWhitespace).IsMatch(porta) Then Throw New Exception("Porta serial inválida!")

            PlotConfig()
            EnableControls(False)

            Dim t As Task =
                Task.Run(Sub()

                             sp = New SerialPort(porta, 115200)
                             If sp.IsOpen Then
                                 sp.Close()
                                 sp.Open()
                             End If
                             If Not sp.IsOpen Then sp.Open()


                             IsRunning = True
                             Do

                                 sp.Write(New Byte() {0}, 0, 1)

                                 Dim dados As System.Text.StringBuilder = New System.Text.StringBuilder()
                                 Do While IsRunning

                                     Dim bytelido As Byte = sp.ReadByte()
                                     If bytelido = 120 Then 'x
                                         Do
                                             bytelido = sp.ReadByte()
                                             dados.Append(Convert.ChangeType(bytelido, GetType(Char)))
                                         Loop While bytelido <> 122 'z
                                         Exit Do
                                     End If
                                 Loop

                                 Dim dadostuple As List(Of String) = dados.ToString.Replace("z", "").Split("y").ToList
                                 If dadostuple.Count > 1 Then
                                     If IsNumeric(dadostuple(0)) And IsNumeric(dadostuple(1)) Then
                                         If dadostuple(1) <= 1024 And dadostuple(1) >= 0 Then
                                             Dim dp As New DataVisualization.Charting.DataPoint With {
                                                 .XValue = dadostuple(0) / unidadex,
                                                 .YValues = New Double() {dadostuple(1) * janelay / 1023.0}
                                             }
                                             Invoke(Sub()
                                                        OscChart.Series(PlotName).Points.Add(dp)
                                                        If OscChart.Series(PlotName).Points.Count > 0 Then
                                                            OscChart.ChartAreas(OscChart.ChartAreas.Count - 1).AxisX.Minimum = OscChart.Series(PlotName).Points(0).XValue
                                                        End If
                                                        If PodeSalvarDados Then AddToDataLog(dp.XValue, dp.YValues(0), DataFileFullPath)
                                                    End Sub)
                                         End If
                                     End If
                                 End If

                                 If PleaseConfigPlot Then
                                     Invoke(Sub() PlotConfig())
                                     PleaseConfigPlot = False
                                 End If

                                 '-> escala x
                                 Dim janelax As String = Invoke(Function() GetNumberCB(JanelaXComboBox))
                                 If janelax > 1 Then
                                     If OscChart.Series(PlotName).Points.Count > 5 Then

                                         Dim x2 As Double = OscChart.Series(PlotName).Points(OscChart.Series(PlotName).Points.Count - 1).XValue
                                         Dim x1 As Double = OscChart.Series(PlotName).Points(0).XValue
                                         Dim janelaxatual As Double = x2 - x1

                                         Dim limitex As Double = x2 - janelax

                                         If janelaxatual > janelax Then

                                             Dim indexlimite As Integer = OscChart.Series(PlotName).Points.ToList.FindIndex(Function(v) v.XValue >= limitex)
                                             For i = 1 To indexlimite
                                                 Invoke(Sub() OscChart.Series(PlotName).Points.RemoveAt(0))
                                             Next
                                             Invoke(Sub() OscChart.ChartAreas(OscChart.ChartAreas.Count - 1).AxisX.Minimum = OscChart.Series(PlotName).Points(0).XValue)

                                         End If

                                     End If
                                 End If


                             Loop While IsRunning

                             If sp.IsOpen Then sp.Close()
                             Invoke(Sub() EnableControls(True))

                         End Sub)
            Await t

        Catch ex As Exception
            If Not IsNothing(sp) Then
                If sp.IsOpen Then sp.Close()
            End If
            IsRunning = False
            EnableControls(True)
            MsgBox("Erro em começar: " & ex.Message)
        End Try

    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        IsRunning = False
        EnableControls(True)
    End Sub

    Public Sub GetSerialPortNames(sender As Object)
        Dim lst As New List(Of String)
        lst.Clear()
        For Each sp As String In My.Computer.Ports.SerialPortNames
            lst.Add(sp)
        Next

        Dim combo As ComboBox = Convert.ChangeType(sender, GetType(ComboBox))
        combo.Items.Clear()
        For Each item As Object In lst
            combo.Items.Add(item)
        Next

    End Sub
    Private Sub PortaComboBox_DropDown(sender As Object, e As EventArgs) Handles PortaComboBox.DropDown
        GetSerialPortNames(sender)
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Try
            If sp.IsOpen Then sp.Close()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        PleaseConfigPlot = True
        If Not IsRunning Then PlotConfig()
    End Sub

    Private Sub msRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles msRadioButton.CheckedChanged
        OscChart.ChartAreas(OscChart.ChartAreas.Count - 1).AxisX.Title = "ms"
        PlotConfig(DoNotClear:=True)
    End Sub

    Private Sub sRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles sRadioButton.CheckedChanged
        OscChart.ChartAreas(OscChart.ChartAreas.Count - 1).AxisX.Title = "s"
        PlotConfig(DoNotClear:=True)
    End Sub

    Private Sub UnidadeYComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UnidadeYComboBox.SelectedIndexChanged
        JanelaYComboBox.Text = ""
        If UnidadeYComboBox.Text.Trim.ToUpper = "V" Then JanelaYComboBox.Text = "5"
        If UnidadeYComboBox.Text.Trim.ToUpper = "ANALOG" Then JanelaYComboBox.Text = "1023"
        OscChart.ChartAreas(OscChart.ChartAreas.Count - 1).AxisY.Title = UnidadeYComboBox.Text.Trim
    End Sub

    Private Sub UnidadeYComboBox_TextChanged(sender As Object, e As EventArgs) Handles UnidadeYComboBox.TextChanged
        UnidadeYComboBox_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        PlotConfig()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sf As New SaveFileDialog

        sf.AddExtension = True
        sf.DefaultExt = ".png"
        sf.Filter = "png files (*.png)|*.png|All files (*.*)|*.*"
        sf.FilterIndex = 1
        sf.RestoreDirectory = True
        sf.FileName = "Plot Osciluino - " & Format(Now, "hhmm.ddMMMyyy")

        If sf.ShowDialog() = DialogResult.OK Then
            OscChart.SaveImage(sf.FileName, DataVisualization.Charting.ChartImageFormat.Png)
        End If
    End Sub

    Private Sub SalvarArquivoDadosButton_Click(sender As Object, e As EventArgs) Handles SalvarArquivoDadosButton.Click
        CaminhoArquivoComboBox.Text = ""

        Dim DefaultName As String = "Osciluino data - " & Format$(Now, "hh.mm.ss dd.MMM.yyyy")
        Dim DefaultTerm As String = ".csv"

        Using sf As New SaveFileDialog
            sf.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)
            sf.DefaultExt = DefaultTerm
            sf.FileName = DefaultName
            If sf.ShowDialog() = DialogResult.Cancel Then
                Exit Sub
            End If
            DataFileFullPath = sf.FileName
        End Using

        If Strings.Right(DataFileFullPath, 4) <> DefaultTerm Then DataFileFullPath = DataFileFullPath & DefaultTerm
        If Strings.Right(DataFileFullPath.Replace(DefaultTerm, ""), 1) = "\" Then DataFileFullPath = DataFileFullPath & DefaultTerm

        If Not New IO.FileInfo(DataFileFullPath).Directory.Exists Then Throw New Exception("Caminho arquivos de dados não encontrado!")

        CaminhoArquivoComboBox.Text = DataFileFullPath

        InitDataLog(DataFileFullPath)
    End Sub

    Sub AddToDataLog(c1, c2, ArqLogSelect)
        EscrverLogMeas(c1.ToString & ";" & c2.ToString, ArqLogSelect, True)
    End Sub

    Sub AddToDataLogUnit(ArqLogSelect)
        EscrverLogMeas("tempo[" & If(sRadioButton.Checked, "s", "ms") & "];valor[" & UnidadeYComboBox.Text & "]", ArqLogSelect, True)
    End Sub

    Sub InitDataLog(ByVal ArqLogSelect As String)
        EscrverLogMeas("", ArqLogSelect, True)
        EscrverLogMeas(Now.ToLongDateString & " " & Now.ToLongTimeString, ArqLogSelect, True)
        EscrverLogMeas("", ArqLogSelect, True)
        AddToDataLogUnit(ArqLogSelect)
        EscrverLogMeas("", ArqLogSelect, True)
    End Sub

    Sub EscrverLogMeas(ByVal StrToWrite As String, ByVal ArqLogSelect As String, Optional ByVal Append As Boolean = False)
        Try
            Using writer As New IO.StreamWriter(ArqLogSelect, Append)
                writer.WriteLine(StrToWrite)
            End Using
        Catch ex As Exception
            MsgBox("Erro em salar no arquivo de dados: " & ex.Message)
        End Try
    End Sub

    Sub AbrirLog(ByVal ArqLogSelect As Integer)
        Try
            If Not (New IO.FileInfo(ArqLogSelect)).Exists Then Throw New Exception("File data not found!")
            Process.Start("excel.exe", """" & ArqLogSelect & """")
        Catch ex As Exception
            MsgBox("Error log file: " & ex.Message)
        End Try
    End Sub

    Private Sub CaminhoArquivoComboBox_TextChanged(sender As Object, e As EventArgs) Handles CaminhoArquivoComboBox.TextChanged
        DataFileFullPath = CaminhoArquivoComboBox.Text
    End Sub

    Private Sub SobreToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SobreToolStripMenuItem1.Click
        MsgBox("
Osciluino v1.0

Osciluino é uma projeto pedagógico que visa implementar um osciloscópio simples com arduino.

Desenvolvido por Érison Rocha

Disponível em https://github.com/erisonrocha/osciluino.git")
    End Sub

End Class

