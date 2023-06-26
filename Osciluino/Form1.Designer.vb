<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PortaComboBox = New System.Windows.Forms.ComboBox()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.StopButton = New System.Windows.Forms.Button()
        Me.OscChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.sRadioButton = New System.Windows.Forms.RadioButton()
        Me.msRadioButton = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.JanelaXComboBox = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.UnidadeYComboBox = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.JanelaYComboBox = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SalvarArquivoDadosButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CaminhoArquivoComboBox = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.SobreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SobreToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.OscChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Porta"
        '
        'PortaComboBox
        '
        Me.PortaComboBox.FormattingEnabled = True
        Me.PortaComboBox.Location = New System.Drawing.Point(55, 19)
        Me.PortaComboBox.Name = "PortaComboBox"
        Me.PortaComboBox.Size = New System.Drawing.Size(121, 21)
        Me.PortaComboBox.TabIndex = 2
        '
        'StartButton
        '
        Me.StartButton.BackColor = System.Drawing.Color.Lime
        Me.StartButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartButton.Location = New System.Drawing.Point(349, 10)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 75)
        Me.StartButton.TabIndex = 3
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = False
        '
        'StopButton
        '
        Me.StopButton.BackColor = System.Drawing.Color.IndianRed
        Me.StopButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StopButton.Location = New System.Drawing.Point(268, 10)
        Me.StopButton.Name = "StopButton"
        Me.StopButton.Size = New System.Drawing.Size(75, 75)
        Me.StopButton.TabIndex = 4
        Me.StopButton.Text = "Stop"
        Me.StopButton.UseVisualStyleBackColor = False
        '
        'OscChart
        '
        ChartArea1.Name = "ChartArea1"
        Me.OscChart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.OscChart.Legends.Add(Legend1)
        Me.OscChart.Location = New System.Drawing.Point(6, 19)
        Me.OscChart.Name = "OscChart"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Legend = "Legend1"
        Series1.Name = "OscData"
        Me.OscChart.Series.Add(Series1)
        Me.OscChart.Size = New System.Drawing.Size(777, 468)
        Me.OscChart.TabIndex = 5
        Me.OscChart.Text = "Chart1"
        '
        'ResetButton
        '
        Me.ResetButton.BackColor = System.Drawing.Color.Aqua
        Me.ResetButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetButton.Location = New System.Drawing.Point(789, 19)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(151, 51)
        Me.ResetButton.TabIndex = 6
        Me.ResetButton.Text = "Resetar"
        Me.ResetButton.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.sRadioButton)
        Me.GroupBox1.Controls.Add(Me.msRadioButton)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.JanelaXComboBox)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.UnidadeYComboBox)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.JanelaYComboBox)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.OscChart)
        Me.GroupBox1.Controls.Add(Me.ResetButton)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(949, 499)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Gráfico"
        '
        'sRadioButton
        '
        Me.sRadioButton.AutoSize = True
        Me.sRadioButton.Location = New System.Drawing.Point(893, 356)
        Me.sRadioButton.Name = "sRadioButton"
        Me.sRadioButton.Size = New System.Drawing.Size(30, 17)
        Me.sRadioButton.TabIndex = 19
        Me.sRadioButton.TabStop = True
        Me.sRadioButton.Text = "s"
        Me.sRadioButton.UseVisualStyleBackColor = True
        '
        'msRadioButton
        '
        Me.msRadioButton.AutoSize = True
        Me.msRadioButton.Location = New System.Drawing.Point(852, 356)
        Me.msRadioButton.Name = "msRadioButton"
        Me.msRadioButton.Size = New System.Drawing.Size(38, 17)
        Me.msRadioButton.TabIndex = 18
        Me.msRadioButton.TabStop = True
        Me.msRadioButton.Text = "ms"
        Me.msRadioButton.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Aqua
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(789, 76)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(151, 51)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Salvar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'JanelaXComboBox
        '
        Me.JanelaXComboBox.FormattingEnabled = True
        Me.JanelaXComboBox.Location = New System.Drawing.Point(851, 382)
        Me.JanelaXComboBox.Name = "JanelaXComboBox"
        Me.JanelaXComboBox.Size = New System.Drawing.Size(89, 21)
        Me.JanelaXComboBox.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(788, 385)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Janela X"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(788, 358)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Unidade X"
        '
        'UnidadeYComboBox
        '
        Me.UnidadeYComboBox.FormattingEnabled = True
        Me.UnidadeYComboBox.Items.AddRange(New Object() {"V", "analog", "A"})
        Me.UnidadeYComboBox.Location = New System.Drawing.Point(851, 439)
        Me.UnidadeYComboBox.Name = "UnidadeYComboBox"
        Me.UnidadeYComboBox.Size = New System.Drawing.Size(89, 21)
        Me.UnidadeYComboBox.TabIndex = 12
        Me.UnidadeYComboBox.Text = "V"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(788, 442)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Unidade Y"
        '
        'JanelaYComboBox
        '
        Me.JanelaYComboBox.FormattingEnabled = True
        Me.JanelaYComboBox.Items.AddRange(New Object() {"5", "1023"})
        Me.JanelaYComboBox.Location = New System.Drawing.Point(851, 466)
        Me.JanelaYComboBox.Name = "JanelaYComboBox"
        Me.JanelaYComboBox.Size = New System.Drawing.Size(89, 21)
        Me.JanelaYComboBox.TabIndex = 10
        Me.JanelaYComboBox.Text = "5"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(788, 469)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Janela Y"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.SalvarArquivoDadosButton)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.CaminhoArquivoComboBox)
        Me.GroupBox2.Controls.Add(Me.PortaComboBox)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 532)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(515, 89)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Configuração"
        '
        'SalvarArquivoDadosButton
        '
        Me.SalvarArquivoDadosButton.BackColor = System.Drawing.Color.Orange
        Me.SalvarArquivoDadosButton.Location = New System.Drawing.Point(428, 44)
        Me.SalvarArquivoDadosButton.Name = "SalvarArquivoDadosButton"
        Me.SalvarArquivoDadosButton.Size = New System.Drawing.Size(81, 23)
        Me.SalvarArquivoDadosButton.TabIndex = 5
        Me.SalvarArquivoDadosButton.Text = "Salvar como"
        Me.SalvarArquivoDadosButton.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Arquivo"
        '
        'CaminhoArquivoComboBox
        '
        Me.CaminhoArquivoComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CaminhoArquivoComboBox.FormattingEnabled = True
        Me.CaminhoArquivoComboBox.Location = New System.Drawing.Point(55, 46)
        Me.CaminhoArquivoComboBox.Name = "CaminhoArquivoComboBox"
        Me.CaminhoArquivoComboBox.Size = New System.Drawing.Size(367, 20)
        Me.CaminhoArquivoComboBox.TabIndex = 3
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.StartButton)
        Me.GroupBox3.Controls.Add(Me.StopButton)
        Me.GroupBox3.Location = New System.Drawing.Point(533, 532)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(428, 89)
        Me.GroupBox3.TabIndex = 11
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Controles"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SobreToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(972, 24)
        Me.MenuStrip1.TabIndex = 12
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SobreToolStripMenuItem
        '
        Me.SobreToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SobreToolStripMenuItem1})
        Me.SobreToolStripMenuItem.Name = "SobreToolStripMenuItem"
        Me.SobreToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.SobreToolStripMenuItem.Text = "Ajuda"
        '
        'SobreToolStripMenuItem1
        '
        Me.SobreToolStripMenuItem1.Name = "SobreToolStripMenuItem1"
        Me.SobreToolStripMenuItem1.Size = New System.Drawing.Size(104, 22)
        Me.SobreToolStripMenuItem1.Text = "Sobre"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(972, 630)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Osciluino - by Érison Rocha"
        CType(Me.OscChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PortaComboBox As ComboBox
    Friend WithEvents StartButton As Button
    Friend WithEvents StopButton As Button
    Friend WithEvents OscChart As DataVisualization.Charting.Chart
    Friend WithEvents ResetButton As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents UnidadeYComboBox As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents JanelaYComboBox As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents SalvarArquivoDadosButton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents CaminhoArquivoComboBox As ComboBox
    Friend WithEvents JanelaXComboBox As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents sRadioButton As RadioButton
    Friend WithEvents msRadioButton As RadioButton
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents SobreToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SobreToolStripMenuItem1 As ToolStripMenuItem
End Class
