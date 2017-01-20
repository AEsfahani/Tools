<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgramCompare
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgramCompare))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HowToUseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutSage100FolderCompareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tavFileSelection = New System.Windows.Forms.TabPage()
        Me.grpFileLocations = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGetComparisonFilesList = New System.Windows.Forms.Button()
        Me.txtDestinationFile = New System.Windows.Forms.TextBox()
        Me.btnGetBaseFileList = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBaseFile = New System.Windows.Forms.TextBox()
        Me.grpComparisonFile = New System.Windows.Forms.GroupBox()
        Me.btnSetComparisonFolder = New System.Windows.Forms.Button()
        Me.txtComparisonFolderPath = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCreateSourceFile = New System.Windows.Forms.Button()
        Me.tabInstallCompare = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvComparison = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnexporttoexcel2 = New System.Windows.Forms.Button()
        Me.btnCleargrid = New System.Windows.Forms.Button()
        Me.lblCaseNumber = New System.Windows.Forms.Label()
        Me.txtCaseNumber = New System.Windows.Forms.TextBox()
        Me.btnEmailComparisonFile = New System.Windows.Forms.Button()
        Me.btnCancelSearchFilterValue = New System.Windows.Forms.Button()
        Me.lblSearchFileName = New System.Windows.Forms.Label()
        Me.btnExportToExcel = New System.Windows.Forms.Button()
        Me.txtFileNameToSearch = New System.Windows.Forms.TextBox()
        Me.btnCompare = New System.Windows.Forms.Button()
        Me.cboViewSettings = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.tslblStatusMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslStatusGraphic = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToCSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.bwThreadEmailComparisonFile = New System.ComponentModel.BackgroundWorker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ChangeLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tavFileSelection.SuspendLayout()
        Me.grpFileLocations.SuspendLayout()
        Me.grpComparisonFile.SuspendLayout()
        Me.tabInstallCompare.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvComparison, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolStripMenuItem1, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(792, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem})
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(56, 20)
        Me.ToolStripMenuItem1.Text = "&Options"
        Me.ToolStripMenuItem1.Visible = False
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HowToUseToolStripMenuItem, Me.ChangeLogToolStripMenuItem, Me.AboutSage100FolderCompareToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HowToUseToolStripMenuItem
        '
        Me.HowToUseToolStripMenuItem.Name = "HowToUseToolStripMenuItem"
        Me.HowToUseToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.HowToUseToolStripMenuItem.Text = "How to use "
        '
        'AboutSage100FolderCompareToolStripMenuItem
        '
        Me.AboutSage100FolderCompareToolStripMenuItem.Name = "AboutSage100FolderCompareToolStripMenuItem"
        Me.AboutSage100FolderCompareToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.AboutSage100FolderCompareToolStripMenuItem.Text = "About Sage 100 Folder Compare"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tavFileSelection)
        Me.TabControl1.Controls.Add(Me.tabInstallCompare)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 24)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(792, 549)
        Me.TabControl1.TabIndex = 1
        '
        'tavFileSelection
        '
        Me.tavFileSelection.AutoScroll = True
        Me.tavFileSelection.Controls.Add(Me.grpFileLocations)
        Me.tavFileSelection.Controls.Add(Me.grpComparisonFile)
        Me.tavFileSelection.Location = New System.Drawing.Point(4, 22)
        Me.tavFileSelection.Name = "tavFileSelection"
        Me.tavFileSelection.Padding = New System.Windows.Forms.Padding(3)
        Me.tavFileSelection.Size = New System.Drawing.Size(784, 523)
        Me.tavFileSelection.TabIndex = 0
        Me.tavFileSelection.Text = "File Selection"
        Me.tavFileSelection.UseVisualStyleBackColor = True
        '
        'grpFileLocations
        '
        Me.grpFileLocations.Controls.Add(Me.Label7)
        Me.grpFileLocations.Controls.Add(Me.Label6)
        Me.grpFileLocations.Controls.Add(Me.Label4)
        Me.grpFileLocations.Controls.Add(Me.ComboBox1)
        Me.grpFileLocations.Controls.Add(Me.Button1)
        Me.grpFileLocations.Controls.Add(Me.Label1)
        Me.grpFileLocations.Controls.Add(Me.btnGetComparisonFilesList)
        Me.grpFileLocations.Controls.Add(Me.txtDestinationFile)
        Me.grpFileLocations.Controls.Add(Me.btnGetBaseFileList)
        Me.grpFileLocations.Controls.Add(Me.Label2)
        Me.grpFileLocations.Controls.Add(Me.txtBaseFile)
        Me.grpFileLocations.Location = New System.Drawing.Point(15, 118)
        Me.grpFileLocations.Name = "grpFileLocations"
        Me.grpFileLocations.Size = New System.Drawing.Size(761, 259)
        Me.grpFileLocations.TabIndex = 22
        Me.grpFileLocations.TabStop = False
        Me.grpFileLocations.Text = "Set Comparison and Base File Locations"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(44, 227)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(448, 13)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Click on the Comparison Tab or Click on Go to Comparison tab button to go to comp" & _
            "aison tab."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(44, 202)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(394, 13)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Once a comparison file and a Base file have been set within the text boxes above," & _
            ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(620, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Sage 100 Versions"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"4.50.4.0", "4.50.3.0", "4.50.2.0", "4.50.1.0", "4.50.0.0", "4.40.0.10", "4.40.0.9", "4.40.0.8", "4.40.0.7", "4.40.0.6", "4.40.0.5", "4.40.0.4", "4.40.0.3", "4.40.0.2", "4.40.0.1"})
        Me.ComboBox1.Location = New System.Drawing.Point(621, 39)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(115, 21)
        Me.ComboBox1.TabIndex = 21
        Me.ToolTip1.SetToolTip(Me.ComboBox1, "List of available Sage 100 Base file")
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.ForestGreen
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(283, 152)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(168, 23)
        Me.Button1.TabIndex = 20
        Me.Button1.Text = "Go to Comparison Tab"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Comparison File (This file will be compared to the base file)"
        '
        'btnGetComparisonFilesList
        '
        Me.btnGetComparisonFilesList.Location = New System.Drawing.Point(620, 114)
        Me.btnGetComparisonFilesList.Name = "btnGetComparisonFilesList"
        Me.btnGetComparisonFilesList.Size = New System.Drawing.Size(116, 23)
        Me.btnGetComparisonFilesList.TabIndex = 16
        Me.btnGetComparisonFilesList.Text = "Set Comparison File"
        Me.btnGetComparisonFilesList.UseVisualStyleBackColor = True
        '
        'txtDestinationFile
        '
        Me.txtDestinationFile.Location = New System.Drawing.Point(15, 114)
        Me.txtDestinationFile.Name = "txtDestinationFile"
        Me.txtDestinationFile.Size = New System.Drawing.Size(599, 20)
        Me.txtDestinationFile.TabIndex = 18
        Me.ToolTip1.SetToolTip(Me.txtDestinationFile, "Comparison File location")
        '
        'btnGetBaseFileList
        '
        Me.btnGetBaseFileList.Location = New System.Drawing.Point(620, 68)
        Me.btnGetBaseFileList.Name = "btnGetBaseFileList"
        Me.btnGetBaseFileList.Size = New System.Drawing.Size(116, 23)
        Me.btnGetBaseFileList.TabIndex = 17
        Me.btnGetBaseFileList.Text = "Set Base File"
        Me.btnGetBaseFileList.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(610, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Base File (This file will be used for the basis of comparison, you can select you" & _
            "r own base file or select one from the available list)"
        '
        'txtBaseFile
        '
        Me.txtBaseFile.Location = New System.Drawing.Point(15, 39)
        Me.txtBaseFile.Name = "txtBaseFile"
        Me.txtBaseFile.Size = New System.Drawing.Size(599, 20)
        Me.txtBaseFile.TabIndex = 14
        '
        'grpComparisonFile
        '
        Me.grpComparisonFile.Controls.Add(Me.btnSetComparisonFolder)
        Me.grpComparisonFile.Controls.Add(Me.txtComparisonFolderPath)
        Me.grpComparisonFile.Controls.Add(Me.Label3)
        Me.grpComparisonFile.Controls.Add(Me.btnCreateSourceFile)
        Me.grpComparisonFile.Location = New System.Drawing.Point(13, 10)
        Me.grpComparisonFile.Name = "grpComparisonFile"
        Me.grpComparisonFile.Size = New System.Drawing.Size(763, 94)
        Me.grpComparisonFile.TabIndex = 21
        Me.grpComparisonFile.TabStop = False
        Me.grpComparisonFile.Text = "Comparison File Creation(XML Format)"
        '
        'btnSetComparisonFolder
        '
        Me.btnSetComparisonFolder.Location = New System.Drawing.Point(19, 65)
        Me.btnSetComparisonFolder.Name = "btnSetComparisonFolder"
        Me.btnSetComparisonFolder.Size = New System.Drawing.Size(128, 23)
        Me.btnSetComparisonFolder.TabIndex = 24
        Me.btnSetComparisonFolder.Text = "Set Comparison Folder"
        Me.ToolTip1.SetToolTip(Me.btnSetComparisonFolder, "Click this button to Set Comparison Folder")
        Me.btnSetComparisonFolder.UseVisualStyleBackColor = True
        '
        'txtComparisonFolderPath
        '
        Me.txtComparisonFolderPath.Location = New System.Drawing.Point(17, 32)
        Me.txtComparisonFolderPath.Name = "txtComparisonFolderPath"
        Me.txtComparisonFolderPath.Size = New System.Drawing.Size(588, 20)
        Me.txtComparisonFolderPath.TabIndex = 23
        Me.ToolTip1.SetToolTip(Me.txtComparisonFolderPath, "Enter Sage 100 Folder to create Comparison file from:")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(434, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Set Sage 100 Folder To Create Comparison File from:(The path should have MAS90 fo" & _
            "lder)"
        '
        'btnCreateSourceFile
        '
        Me.btnCreateSourceFile.Enabled = False
        Me.btnCreateSourceFile.Location = New System.Drawing.Point(153, 65)
        Me.btnCreateSourceFile.Name = "btnCreateSourceFile"
        Me.btnCreateSourceFile.Size = New System.Drawing.Size(135, 23)
        Me.btnCreateSourceFile.TabIndex = 21
        Me.btnCreateSourceFile.Text = "Create Comparison File"
        Me.ToolTip1.SetToolTip(Me.btnCreateSourceFile, "Create Comparison File")
        Me.btnCreateSourceFile.UseVisualStyleBackColor = True
        '
        'tabInstallCompare
        '
        Me.tabInstallCompare.Controls.Add(Me.Panel2)
        Me.tabInstallCompare.Controls.Add(Me.Panel1)
        Me.tabInstallCompare.Location = New System.Drawing.Point(4, 22)
        Me.tabInstallCompare.Name = "tabInstallCompare"
        Me.tabInstallCompare.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInstallCompare.Size = New System.Drawing.Size(784, 523)
        Me.tabInstallCompare.TabIndex = 1
        Me.tabInstallCompare.Text = "Installation Comparison"
        Me.tabInstallCompare.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvComparison)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 72)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(778, 430)
        Me.Panel2.TabIndex = 5
        '
        'dgvComparison
        '
        Me.dgvComparison.AllowUserToAddRows = False
        Me.dgvComparison.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComparison.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvComparison.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvComparison.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvComparison.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvComparison.Location = New System.Drawing.Point(0, 0)
        Me.dgvComparison.Name = "dgvComparison"
        Me.dgvComparison.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvComparison.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvComparison.Size = New System.Drawing.Size(778, 430)
        Me.dgvComparison.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnexporttoexcel2)
        Me.Panel1.Controls.Add(Me.btnCleargrid)
        Me.Panel1.Controls.Add(Me.lblCaseNumber)
        Me.Panel1.Controls.Add(Me.txtCaseNumber)
        Me.Panel1.Controls.Add(Me.btnEmailComparisonFile)
        Me.Panel1.Controls.Add(Me.btnCancelSearchFilterValue)
        Me.Panel1.Controls.Add(Me.lblSearchFileName)
        Me.Panel1.Controls.Add(Me.btnExportToExcel)
        Me.Panel1.Controls.Add(Me.txtFileNameToSearch)
        Me.Panel1.Controls.Add(Me.btnCompare)
        Me.Panel1.Controls.Add(Me.cboViewSettings)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(778, 69)
        Me.Panel1.TabIndex = 4
        '
        'btnexporttoexcel2
        '
        Me.btnexporttoexcel2.Enabled = False
        Me.btnexporttoexcel2.Location = New System.Drawing.Point(435, 35)
        Me.btnexporttoexcel2.Name = "btnexporttoexcel2"
        Me.btnexporttoexcel2.Size = New System.Drawing.Size(127, 23)
        Me.btnexporttoexcel2.TabIndex = 16
        Me.btnexporttoexcel2.Text = "Export To Excel"
        Me.btnexporttoexcel2.UseVisualStyleBackColor = True
        Me.btnexporttoexcel2.Visible = False
        '
        'btnCleargrid
        '
        Me.btnCleargrid.BackColor = System.Drawing.Color.ForestGreen
        Me.btnCleargrid.ForeColor = System.Drawing.Color.White
        Me.btnCleargrid.Location = New System.Drawing.Point(435, 6)
        Me.btnCleargrid.Name = "btnCleargrid"
        Me.btnCleargrid.Size = New System.Drawing.Size(127, 23)
        Me.btnCleargrid.TabIndex = 15
        Me.btnCleargrid.Text = "Clear Grid"
        Me.btnCleargrid.UseVisualStyleBackColor = False
        '
        'lblCaseNumber
        '
        Me.lblCaseNumber.AutoSize = True
        Me.lblCaseNumber.Location = New System.Drawing.Point(643, 14)
        Me.lblCaseNumber.Name = "lblCaseNumber"
        Me.lblCaseNumber.Size = New System.Drawing.Size(71, 13)
        Me.lblCaseNumber.TabIndex = 14
        Me.lblCaseNumber.Text = "Case Number"
        Me.lblCaseNumber.Visible = False
        '
        'txtCaseNumber
        '
        Me.txtCaseNumber.Location = New System.Drawing.Point(633, 11)
        Me.txtCaseNumber.MaxLength = 9
        Me.txtCaseNumber.Name = "txtCaseNumber"
        Me.txtCaseNumber.Size = New System.Drawing.Size(128, 20)
        Me.txtCaseNumber.TabIndex = 13
        Me.txtCaseNumber.Visible = False
        '
        'btnEmailComparisonFile
        '
        Me.btnEmailComparisonFile.Enabled = False
        Me.btnEmailComparisonFile.Location = New System.Drawing.Point(646, 8)
        Me.btnEmailComparisonFile.Name = "btnEmailComparisonFile"
        Me.btnEmailComparisonFile.Size = New System.Drawing.Size(127, 23)
        Me.btnEmailComparisonFile.TabIndex = 12
        Me.btnEmailComparisonFile.Text = "Email Comparison File"
        Me.btnEmailComparisonFile.UseVisualStyleBackColor = True
        Me.btnEmailComparisonFile.Visible = False
        '
        'btnCancelSearchFilterValue
        '
        Me.btnCancelSearchFilterValue.Location = New System.Drawing.Point(306, 35)
        Me.btnCancelSearchFilterValue.Name = "btnCancelSearchFilterValue"
        Me.btnCancelSearchFilterValue.Size = New System.Drawing.Size(123, 23)
        Me.btnCancelSearchFilterValue.TabIndex = 11
        Me.btnCancelSearchFilterValue.Text = "Clear Search"
        Me.btnCancelSearchFilterValue.UseVisualStyleBackColor = True
        '
        'lblSearchFileName
        '
        Me.lblSearchFileName.AutoSize = True
        Me.lblSearchFileName.Location = New System.Drawing.Point(5, 38)
        Me.lblSearchFileName.Name = "lblSearchFileName"
        Me.lblSearchFileName.Size = New System.Drawing.Size(91, 13)
        Me.lblSearchFileName.TabIndex = 10
        Me.lblSearchFileName.Text = "Search File Name"
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Enabled = False
        Me.btnExportToExcel.Location = New System.Drawing.Point(646, 35)
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(127, 23)
        Me.btnExportToExcel.TabIndex = 9
        Me.btnExportToExcel.Text = "Export To Excel"
        Me.btnExportToExcel.UseVisualStyleBackColor = True
        Me.btnExportToExcel.Visible = False
        '
        'txtFileNameToSearch
        '
        Me.txtFileNameToSearch.Location = New System.Drawing.Point(102, 35)
        Me.txtFileNameToSearch.Name = "txtFileNameToSearch"
        Me.txtFileNameToSearch.Size = New System.Drawing.Size(198, 20)
        Me.txtFileNameToSearch.TabIndex = 7
        '
        'btnCompare
        '
        Me.btnCompare.BackColor = System.Drawing.Color.ForestGreen
        Me.btnCompare.Enabled = False
        Me.btnCompare.ForeColor = System.Drawing.Color.White
        Me.btnCompare.Location = New System.Drawing.Point(306, 6)
        Me.btnCompare.Name = "btnCompare"
        Me.btnCompare.Size = New System.Drawing.Size(123, 23)
        Me.btnCompare.TabIndex = 6
        Me.btnCompare.Text = "Compare Folders/Files"
        Me.btnCompare.UseVisualStyleBackColor = False
        '
        'cboViewSettings
        '
        Me.cboViewSettings.FormattingEnabled = True
        Me.cboViewSettings.Location = New System.Drawing.Point(102, 8)
        Me.cboViewSettings.Name = "cboViewSettings"
        Me.cboViewSettings.Size = New System.Drawing.Size(198, 21)
        Me.cboViewSettings.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "View Settings"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.tslblStatusMessage, Me.tslStatusGraphic})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 551)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(792, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.CausesValidation = False
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'tslblStatusMessage
        '
        Me.tslblStatusMessage.Enabled = False
        Me.tslblStatusMessage.Name = "tslblStatusMessage"
        Me.tslblStatusMessage.Size = New System.Drawing.Size(83, 17)
        Me.tslblStatusMessage.Text = "Status Message"
        Me.tslblStatusMessage.ToolTipText = "d"
        Me.tslblStatusMessage.Visible = False
        '
        'tslStatusGraphic
        '
        Me.tslStatusGraphic.AutoSize = False
        Me.tslStatusGraphic.Enabled = False
        Me.tslStatusGraphic.Image = Global.Accounting.Application.CS.My.Resources.Resources.status_anim
        Me.tslStatusGraphic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tslStatusGraphic.Name = "tslStatusGraphic"
        Me.tslStatusGraphic.Size = New System.Drawing.Size(90, 17)
        Me.tslStatusGraphic.Text = "Sending Email"
        Me.tslStatusGraphic.ToolTipText = "Sending Email"
        Me.tslStatusGraphic.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 250
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Enabled = False
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToExcelToolStripMenuItem, Me.ExportToCSVToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(161, 48)
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Enabled = False
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ExportToExcelToolStripMenuItem.Text = "Export To Excel"
        '
        'ExportToCSVToolStripMenuItem
        '
        Me.ExportToCSVToolStripMenuItem.Enabled = False
        Me.ExportToCSVToolStripMenuItem.Name = "ExportToCSVToolStripMenuItem"
        Me.ExportToCSVToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ExportToCSVToolStripMenuItem.Text = "Export To CSV"
        '
        'bwThreadEmailComparisonFile
        '
        '
        'ChangeLogToolStripMenuItem
        '
        Me.ChangeLogToolStripMenuItem.Name = "ChangeLogToolStripMenuItem"
        Me.ChangeLogToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.ChangeLogToolStripMenuItem.Text = "Change Log"
        '
        'frmProgramCompare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmProgramCompare"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sage 100 Folder Compare"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tavFileSelection.ResumeLayout(False)
        Me.grpFileLocations.ResumeLayout(False)
        Me.grpFileLocations.PerformLayout()
        Me.grpComparisonFile.ResumeLayout(False)
        Me.grpComparisonFile.PerformLayout()
        Me.tabInstallCompare.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvComparison, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tavFileSelection As System.Windows.Forms.TabPage
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents grpComparisonFile As System.Windows.Forms.GroupBox
    Friend WithEvents btnSetComparisonFolder As System.Windows.Forms.Button
    Friend WithEvents txtComparisonFolderPath As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCreateSourceFile As System.Windows.Forms.Button
    Friend WithEvents grpFileLocations As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGetComparisonFilesList As System.Windows.Forms.Button
    Friend WithEvents txtDestinationFile As System.Windows.Forms.TextBox
    Friend WithEvents btnGetBaseFileList As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBaseFile As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToCSVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabInstallCompare As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelSearchFilterValue As System.Windows.Forms.Button
    Friend WithEvents lblSearchFileName As System.Windows.Forms.Label
    Friend WithEvents btnExportToExcel As System.Windows.Forms.Button
    Friend WithEvents txtFileNameToSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnCompare As System.Windows.Forms.Button
    Friend WithEvents cboViewSettings As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnEmailComparisonFile As System.Windows.Forms.Button
    Friend WithEvents lblCaseNumber As System.Windows.Forms.Label
    Friend WithEvents txtCaseNumber As System.Windows.Forms.TextBox
    Friend WithEvents tslblStatusMessage As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tslStatusGraphic As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents bwThreadEmailComparisonFile As System.ComponentModel.BackgroundWorker
    Friend WithEvents dgvComparison As System.Windows.Forms.DataGridView
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutSage100FolderCompareToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCleargrid As System.Windows.Forms.Button
    Friend WithEvents btnexporttoexcel2 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents HowToUseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
