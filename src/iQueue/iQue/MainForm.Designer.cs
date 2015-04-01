namespace iQueue
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.runWebServiceButton = new System.Windows.Forms.Button();
            this.stopWebServiceButton = new System.Windows.Forms.Button();
            this.serverPort = new System.Windows.Forms.NumericUpDown();
            this.webServerSettings = new System.Windows.Forms.GroupBox();
            this.webServiceAddress = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.serverAutoStart = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.databaseSettings = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.databaseStatus = new System.Windows.Forms.Label();
            this.initDBButton = new System.Windows.Forms.Button();
            this.dbFileSelectButton = new System.Windows.Forms.Button();
            this.dbFilePath = new System.Windows.Forms.TextBox();
            this.openDBFile = new System.Windows.Forms.OpenFileDialog();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.logDirectoryPath = new System.Windows.Forms.TextBox();
            this.logSettings = new System.Windows.Forms.GroupBox();
            this.selectLogDirButton = new System.Windows.Forms.Button();
            this.logDirOpen = new System.Windows.Forms.FolderBrowserDialog();
            this.resetSettingsButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.webServerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ledOnlineCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.visitorsWaitCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.visitorsLateCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.visitorsDoneCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.visitorsOnlineCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toggleMainWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.goToWEBInterface = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьЖурналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.программаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перейтиВWEBинтерфейсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьРекламныйКонтентToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.скрытьОкноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перезапуститьПриложениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьПриложениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.следитьЗаЛогамиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logWatch = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьЛогToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьЖурналПриложенияToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проверитьНаличиеОбновленийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.активацияПрограммногоОбеспеченияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.регистрацияПОЧерезИнтернетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ledTestRichTextdbl = new System.Windows.Forms.RichTextBox();
            this.ledTestRichTextFull = new System.Windows.Forms.RichTextBox();
            this.queueToScreen = new System.Windows.Forms.Button();
            this.ledLogSuccess = new System.Windows.Forms.CheckBox();
            this.ledAutoStart = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ledStopButton = new System.Windows.Forms.Button();
            this.ledRestartButton = new System.Windows.Forms.Button();
            this.ledIndex = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.setColorButton = new System.Windows.Forms.Button();
            this.ledGetStatusButton = new System.Windows.Forms.Button();
            this.ledTestBrightness = new System.Windows.Forms.NumericUpDown();
            this.ledTestFontSize = new System.Windows.Forms.NumericUpDown();
            this.ledTestHeight = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.ledTestWidth = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ledTestDelay = new System.Windows.Forms.NumericUpDown();
            this.ledTestSpeed = new System.Windows.Forms.NumericUpDown();
            this.ledTestStunt = new System.Windows.Forms.ComboBox();
            this.ledTestRichText = new System.Windows.Forms.RichTextBox();
            this.screenScanButton = new System.Windows.Forms.Button();
            this.ledOnButton = new System.Windows.Forms.Button();
            this.ledOffButton = new System.Windows.Forms.Button();
            this.sendTextToLedButton = new System.Windows.Forms.Button();
            this.ledClearButton = new System.Windows.Forms.Button();
            this.ledStartButton = new System.Windows.Forms.Button();
            this.ledTestColorDialog = new System.Windows.Forms.ColorDialog();
            this.logReadTimer = new System.Windows.Forms.Timer(this.components);
            this.checkRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.ledTestRichTextFulldbl = new System.Windows.Forms.RichTextBox();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.serverPort)).BeginInit();
            this.webServerSettings.SuspendLayout();
            this.databaseSettings.SuspendLayout();
            this.logSettings.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTestBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTestFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTestHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTestWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTestDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTestSpeed)).BeginInit();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // runWebServiceButton
            // 
            this.runWebServiceButton.Location = new System.Drawing.Point(8, 90);
            this.runWebServiceButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.runWebServiceButton.Name = "runWebServiceButton";
            this.runWebServiceButton.Size = new System.Drawing.Size(227, 28);
            this.runWebServiceButton.TabIndex = 0;
            this.runWebServiceButton.Text = "Запустить WEB-сервис";
            this.runWebServiceButton.UseVisualStyleBackColor = true;
            this.runWebServiceButton.Click += new System.EventHandler(this.runWebServiceButton_Click);
            // 
            // stopWebServiceButton
            // 
            this.stopWebServiceButton.Location = new System.Drawing.Point(243, 90);
            this.stopWebServiceButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stopWebServiceButton.Name = "stopWebServiceButton";
            this.stopWebServiceButton.Size = new System.Drawing.Size(207, 28);
            this.stopWebServiceButton.TabIndex = 1;
            this.stopWebServiceButton.Text = "Остановить WEB-сервис";
            this.stopWebServiceButton.UseVisualStyleBackColor = true;
            this.stopWebServiceButton.Click += new System.EventHandler(this.stopWebServiceButton_Click);
            // 
            // serverPort
            // 
            this.serverPort.Location = new System.Drawing.Point(324, 22);
            this.serverPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.serverPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.serverPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.serverPort.Name = "serverPort";
            this.serverPort.Size = new System.Drawing.Size(77, 22);
            this.serverPort.TabIndex = 2;
            this.serverPort.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // webServerSettings
            // 
            this.webServerSettings.Controls.Add(this.webServiceAddress);
            this.webServerSettings.Controls.Add(this.label2);
            this.webServerSettings.Controls.Add(this.serverAutoStart);
            this.webServerSettings.Controls.Add(this.label1);
            this.webServerSettings.Controls.Add(this.stopWebServiceButton);
            this.webServerSettings.Controls.Add(this.serverPort);
            this.webServerSettings.Controls.Add(this.runWebServiceButton);
            this.webServerSettings.Location = new System.Drawing.Point(16, 41);
            this.webServerSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webServerSettings.Name = "webServerSettings";
            this.webServerSettings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webServerSettings.Size = new System.Drawing.Size(457, 129);
            this.webServerSettings.TabIndex = 3;
            this.webServerSettings.TabStop = false;
            this.webServerSettings.Text = "Управление WEB-сервисом";
            // 
            // webServiceAddress
            // 
            this.webServiceAddress.FormattingEnabled = true;
            this.webServiceAddress.Location = new System.Drawing.Point(119, 22);
            this.webServiceAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webServiceAddress.Name = "webServiceAddress";
            this.webServiceAddress.Size = new System.Drawing.Size(145, 24);
            this.webServiceAddress.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Адрес сервера";
            // 
            // serverAutoStart
            // 
            this.serverAutoStart.AutoSize = true;
            this.serverAutoStart.Checked = true;
            this.serverAutoStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.serverAutoStart.Location = new System.Drawing.Point(13, 55);
            this.serverAutoStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.serverAutoStart.Name = "serverAutoStart";
            this.serverAutoStart.Size = new System.Drawing.Size(340, 21);
            this.serverAutoStart.TabIndex = 6;
            this.serverAutoStart.Text = "автоматический запуск при старте программы";
            this.serverAutoStart.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Порт";
            // 
            // databaseSettings
            // 
            this.databaseSettings.Controls.Add(this.label3);
            this.databaseSettings.Controls.Add(this.databaseStatus);
            this.databaseSettings.Controls.Add(this.initDBButton);
            this.databaseSettings.Controls.Add(this.dbFileSelectButton);
            this.databaseSettings.Controls.Add(this.dbFilePath);
            this.databaseSettings.Location = new System.Drawing.Point(481, 110);
            this.databaseSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.databaseSettings.Name = "databaseSettings";
            this.databaseSettings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.databaseSettings.Size = new System.Drawing.Size(420, 94);
            this.databaseSettings.TabIndex = 4;
            this.databaseSettings.TabStop = false;
            this.databaseSettings.Text = "Настройки БД";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Состояние БД:";
            // 
            // databaseStatus
            // 
            this.databaseStatus.AutoSize = true;
            this.databaseStatus.ForeColor = System.Drawing.Color.Green;
            this.databaseStatus.Location = new System.Drawing.Point(123, 63);
            this.databaseStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.databaseStatus.Name = "databaseStatus";
            this.databaseStatus.Size = new System.Drawing.Size(28, 17);
            this.databaseStatus.TabIndex = 3;
            this.databaseStatus.Text = "ОК";
            // 
            // initDBButton
            // 
            this.initDBButton.Location = new System.Drawing.Point(300, 58);
            this.initDBButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.initDBButton.Name = "initDBButton";
            this.initDBButton.Size = new System.Drawing.Size(103, 28);
            this.initDBButton.TabIndex = 2;
            this.initDBButton.Text = "Создать БД";
            this.initDBButton.UseVisualStyleBackColor = true;
            this.initDBButton.Click += new System.EventHandler(this.initDBButton_Click);
            // 
            // dbFileSelectButton
            // 
            this.dbFileSelectButton.Location = new System.Drawing.Point(300, 20);
            this.dbFileSelectButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dbFileSelectButton.Name = "dbFileSelectButton";
            this.dbFileSelectButton.Size = new System.Drawing.Size(103, 28);
            this.dbFileSelectButton.TabIndex = 1;
            this.dbFileSelectButton.Text = "Обзор";
            this.dbFileSelectButton.UseVisualStyleBackColor = true;
            this.dbFileSelectButton.Click += new System.EventHandler(this.dbFileSelectButton_Click);
            // 
            // dbFilePath
            // 
            this.dbFilePath.Location = new System.Drawing.Point(8, 21);
            this.dbFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dbFilePath.Name = "dbFilePath";
            this.dbFilePath.Size = new System.Drawing.Size(277, 22);
            this.dbFilePath.TabIndex = 0;
            // 
            // openDBFile
            // 
            this.openDBFile.AutoUpgradeEnabled = false;
            this.openDBFile.CheckFileExists = false;
            this.openDBFile.DefaultExt = "*.db";
            this.openDBFile.FileName = "iQueue.db";
            this.openDBFile.Filter = "*.db|SQLite database";
            this.openDBFile.RestoreDirectory = true;
            this.openDBFile.Title = "Выберите файл базы данных";
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(16, 177);
            this.saveSettingsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(235, 28);
            this.saveSettingsButton.TabIndex = 5;
            this.saveSettingsButton.Text = "Сохранить настройки";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // logDirectoryPath
            // 
            this.logDirectoryPath.Location = new System.Drawing.Point(8, 22);
            this.logDirectoryPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logDirectoryPath.Name = "logDirectoryPath";
            this.logDirectoryPath.Size = new System.Drawing.Size(277, 22);
            this.logDirectoryPath.TabIndex = 6;
            // 
            // logSettings
            // 
            this.logSettings.Controls.Add(this.selectLogDirButton);
            this.logSettings.Controls.Add(this.logDirectoryPath);
            this.logSettings.Location = new System.Drawing.Point(481, 41);
            this.logSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logSettings.Name = "logSettings";
            this.logSettings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logSettings.Size = new System.Drawing.Size(420, 62);
            this.logSettings.TabIndex = 7;
            this.logSettings.TabStop = false;
            this.logSettings.Text = "Настройки журналирования";
            // 
            // selectLogDirButton
            // 
            this.selectLogDirButton.Location = new System.Drawing.Point(300, 20);
            this.selectLogDirButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectLogDirButton.Name = "selectLogDirButton";
            this.selectLogDirButton.Size = new System.Drawing.Size(103, 28);
            this.selectLogDirButton.TabIndex = 7;
            this.selectLogDirButton.Text = "Обзор";
            this.selectLogDirButton.UseVisualStyleBackColor = true;
            this.selectLogDirButton.Click += new System.EventHandler(this.selectLogDirButton_Click);
            // 
            // logDirOpen
            // 
            this.logDirOpen.Description = "Выберите директорию для логирования событий ПО";
            // 
            // resetSettingsButton
            // 
            this.resetSettingsButton.Location = new System.Drawing.Point(259, 177);
            this.resetSettingsButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.resetSettingsButton.Name = "resetSettingsButton";
            this.resetSettingsButton.Size = new System.Drawing.Size(207, 28);
            this.resetSettingsButton.TabIndex = 8;
            this.resetSettingsButton.Text = "Сбросить настройки";
            this.resetSettingsButton.UseVisualStyleBackColor = true;
            this.resetSettingsButton.Click += new System.EventHandler(this.resetSettingsButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.webServerStatus,
            this.toolStripStatusLabel3,
            this.ledOnlineCount,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel5,
            this.visitorsWaitCount,
            this.toolStripStatusLabel8,
            this.visitorsLateCount,
            this.toolStripStatusLabel6,
            this.visitorsDoneCount,
            this.toolStripStatusLabel4,
            this.visitorsOnlineCount,
            this.toolStripStatusLabel7});
            this.statusStrip1.Location = new System.Drawing.Point(0, 101);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1007, 25);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(97, 20);
            this.toolStripStatusLabel1.Text = "WEB-сервис:";
            // 
            // webServerStatus
            // 
            this.webServerStatus.BackColor = System.Drawing.SystemColors.HighlightText;
            this.webServerStatus.ForeColor = System.Drawing.Color.Firebrick;
            this.webServerStatus.Name = "webServerStatus";
            this.webServerStatus.Size = new System.Drawing.Size(90, 20);
            this.webServerStatus.Text = "не запущен";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(127, 20);
            this.toolStripStatusLabel3.Text = "Экранов ONLINE:";
            // 
            // ledOnlineCount
            // 
            this.ledOnlineCount.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ledOnlineCount.ForeColor = System.Drawing.Color.Green;
            this.ledOnlineCount.Name = "ledOnlineCount";
            this.ledOnlineCount.Size = new System.Drawing.Size(25, 20);
            this.ledOnlineCount.Text = "00";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(137, 20);
            this.toolStripStatusLabel2.Text = "Клиентов сегодня:";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(72, 20);
            this.toolStripStatusLabel5.Text = "ожидают";
            // 
            // visitorsWaitCount
            // 
            this.visitorsWaitCount.BackColor = System.Drawing.SystemColors.HighlightText;
            this.visitorsWaitCount.ForeColor = System.Drawing.Color.Gold;
            this.visitorsWaitCount.Name = "visitorsWaitCount";
            this.visitorsWaitCount.Size = new System.Drawing.Size(41, 20);
            this.visitorsWaitCount.Text = "0000";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(145, 20);
            this.toolStripStatusLabel8.Text = "из них с задержкой";
            // 
            // visitorsLateCount
            // 
            this.visitorsLateCount.BackColor = System.Drawing.SystemColors.HighlightText;
            this.visitorsLateCount.ForeColor = System.Drawing.Color.Brown;
            this.visitorsLateCount.Name = "visitorsLateCount";
            this.visitorsLateCount.Size = new System.Drawing.Size(41, 20);
            this.visitorsLateCount.Text = "0000";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(56, 20);
            this.toolStripStatusLabel6.Text = "готово";
            // 
            // visitorsDoneCount
            // 
            this.visitorsDoneCount.BackColor = System.Drawing.SystemColors.HighlightText;
            this.visitorsDoneCount.ForeColor = System.Drawing.Color.Green;
            this.visitorsDoneCount.Name = "visitorsDoneCount";
            this.visitorsDoneCount.Size = new System.Drawing.Size(41, 20);
            this.visitorsDoneCount.Text = "0000";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(47, 20);
            this.toolStripStatusLabel4.Text = "всего";
            // 
            // visitorsOnlineCount
            // 
            this.visitorsOnlineCount.BackColor = System.Drawing.SystemColors.HighlightText;
            this.visitorsOnlineCount.ForeColor = System.Drawing.Color.SteelBlue;
            this.visitorsOnlineCount.Name = "visitorsOnlineCount";
            this.visitorsOnlineCount.Size = new System.Drawing.Size(41, 20);
            this.visitorsOnlineCount.Text = "0000";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(0, 20);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "iQueue все еще работает";
            this.notifyIcon1.BalloonTipTitle = "Внимание!";
            this.notifyIcon1.ContextMenuStrip = this.contextMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Tag = "";
            this.notifyIcon1.Text = "iQueue";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toggleMainWindow,
            this.goToWEBInterface,
            this.открытьЖурналToolStripMenuItem,
            this.toolStripMenuItem2});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(286, 100);
            // 
            // toggleMainWindow
            // 
            this.toggleMainWindow.Name = "toggleMainWindow";
            this.toggleMainWindow.Size = new System.Drawing.Size(285, 24);
            this.toggleMainWindow.Text = "Показать/Скрыть окно";
            this.toggleMainWindow.Click += new System.EventHandler(this.toggleMainWindow_Click);
            // 
            // goToWEBInterface
            // 
            this.goToWEBInterface.Name = "goToWEBInterface";
            this.goToWEBInterface.Size = new System.Drawing.Size(285, 24);
            this.goToWEBInterface.Text = "Перейти в WEB-интерфейс";
            this.goToWEBInterface.Click += new System.EventHandler(this.goToWEBInterface_Click);
            // 
            // открытьЖурналToolStripMenuItem
            // 
            this.открытьЖурналToolStripMenuItem.Name = "открытьЖурналToolStripMenuItem";
            this.открытьЖурналToolStripMenuItem.Size = new System.Drawing.Size(285, 24);
            this.открытьЖурналToolStripMenuItem.Text = "Открыть журнал приложения";
            this.открытьЖурналToolStripMenuItem.Click += new System.EventHandler(this.открытьЖурналToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(285, 24);
            this.toolStripMenuItem2.Text = "Выход";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // logBox
            // 
            this.logBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.logBox.AutoWordSelection = true;
            this.logBox.BackColor = System.Drawing.Color.LightGray;
            this.logBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logBox.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logBox.Location = new System.Drawing.Point(0, 126);
            this.logBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(1007, 398);
            this.logBox.TabIndex = 14;
            this.logBox.Text = "";
            this.logBox.Visible = false;
            this.logBox.SelectionChanged += new System.EventHandler(this.logBox_SelectionChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.программаToolStripMenuItem,
            this.следитьЗаЛогамиToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1007, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // программаToolStripMenuItem
            // 
            this.программаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.перейтиВWEBинтерфейсToolStripMenuItem,
            this.изменитьРекламныйКонтентToolStripMenuItem,
            this.скрытьОкноToolStripMenuItem,
            this.перезапуститьПриложениеToolStripMenuItem,
            this.закрытьПриложениеToolStripMenuItem});
            this.программаToolStripMenuItem.Name = "программаToolStripMenuItem";
            this.программаToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.программаToolStripMenuItem.Text = "Файл";
            // 
            // перейтиВWEBинтерфейсToolStripMenuItem
            // 
            this.перейтиВWEBинтерфейсToolStripMenuItem.Name = "перейтиВWEBинтерфейсToolStripMenuItem";
            this.перейтиВWEBинтерфейсToolStripMenuItem.Size = new System.Drawing.Size(289, 24);
            this.перейтиВWEBинтерфейсToolStripMenuItem.Text = "Перейти в WEB-интерфейс";
            this.перейтиВWEBинтерфейсToolStripMenuItem.Click += new System.EventHandler(this.перейтиВWEBинтерфейсToolStripMenuItem_Click);
            // 
            // изменитьРекламныйКонтентToolStripMenuItem
            // 
            this.изменитьРекламныйКонтентToolStripMenuItem.Name = "изменитьРекламныйКонтентToolStripMenuItem";
            this.изменитьРекламныйКонтентToolStripMenuItem.Size = new System.Drawing.Size(289, 24);
            this.изменитьРекламныйКонтентToolStripMenuItem.Text = "Изменить рекламный контент";
            this.изменитьРекламныйКонтентToolStripMenuItem.Click += new System.EventHandler(this.изменитьРекламныйКонтентToolStripMenuItem_Click);
            // 
            // скрытьОкноToolStripMenuItem
            // 
            this.скрытьОкноToolStripMenuItem.Name = "скрытьОкноToolStripMenuItem";
            this.скрытьОкноToolStripMenuItem.Size = new System.Drawing.Size(289, 24);
            this.скрытьОкноToolStripMenuItem.Text = "Скрыть окно";
            this.скрытьОкноToolStripMenuItem.Click += new System.EventHandler(this.скрытьОкноToolStripMenuItem_Click);
            // 
            // перезапуститьПриложениеToolStripMenuItem
            // 
            this.перезапуститьПриложениеToolStripMenuItem.Name = "перезапуститьПриложениеToolStripMenuItem";
            this.перезапуститьПриложениеToolStripMenuItem.Size = new System.Drawing.Size(289, 24);
            this.перезапуститьПриложениеToolStripMenuItem.Text = "Перезапустить приложение";
            this.перезапуститьПриложениеToolStripMenuItem.Click += new System.EventHandler(this.перезапуститьПриложениеToolStripMenuItem_Click);
            // 
            // закрытьПриложениеToolStripMenuItem
            // 
            this.закрытьПриложениеToolStripMenuItem.Name = "закрытьПриложениеToolStripMenuItem";
            this.закрытьПриложениеToolStripMenuItem.Size = new System.Drawing.Size(289, 24);
            this.закрытьПриложениеToolStripMenuItem.Text = "Закрыть приложение";
            this.закрытьПриложениеToolStripMenuItem.Click += new System.EventHandler(this.закрытьПриложениеToolStripMenuItem_Click);
            // 
            // следитьЗаЛогамиToolStripMenuItem
            // 
            this.следитьЗаЛогамиToolStripMenuItem.Checked = true;
            this.следитьЗаЛогамиToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.следитьЗаЛогамиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logWatch,
            this.очиститьЛогToolStripMenuItem,
            this.открытьЖурналПриложенияToolStripMenuItem1});
            this.следитьЗаЛогамиToolStripMenuItem.Name = "следитьЗаЛогамиToolStripMenuItem";
            this.следитьЗаЛогамиToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.следитьЗаЛогамиToolStripMenuItem.Text = "Журнал";
            // 
            // logWatch
            // 
            this.logWatch.CheckOnClick = true;
            this.logWatch.Name = "logWatch";
            this.logWatch.Size = new System.Drawing.Size(322, 24);
            this.logWatch.Text = "Следить за журналом приложения";
            this.logWatch.CheckStateChanged += new System.EventHandler(this.logWatch_CheckStateChanged);
            // 
            // очиститьЛогToolStripMenuItem
            // 
            this.очиститьЛогToolStripMenuItem.Name = "очиститьЛогToolStripMenuItem";
            this.очиститьЛогToolStripMenuItem.Size = new System.Drawing.Size(322, 24);
            this.очиститьЛогToolStripMenuItem.Text = "Очистить журнал приложения";
            this.очиститьЛогToolStripMenuItem.Click += new System.EventHandler(this.очиститьЛогToolStripMenuItem_Click);
            // 
            // открытьЖурналПриложенияToolStripMenuItem1
            // 
            this.открытьЖурналПриложенияToolStripMenuItem1.Name = "открытьЖурналПриложенияToolStripMenuItem1";
            this.открытьЖурналПриложенияToolStripMenuItem1.Size = new System.Drawing.Size(322, 24);
            this.открытьЖурналПриложенияToolStripMenuItem1.Text = "Открыть журнал приложения";
            this.открытьЖурналПриложенияToolStripMenuItem1.Click += new System.EventHandler(this.открытьЖурналПриложенияToolStripMenuItem1_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.проверитьНаличиеОбновленийToolStripMenuItem,
            this.активацияПрограммногоОбеспеченияToolStripMenuItem,
            this.регистрацияПОЧерезИнтернетToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(309, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // проверитьНаличиеОбновленийToolStripMenuItem
            // 
            this.проверитьНаличиеОбновленийToolStripMenuItem.Name = "проверитьНаличиеОбновленийToolStripMenuItem";
            this.проверитьНаличиеОбновленийToolStripMenuItem.Size = new System.Drawing.Size(309, 24);
            this.проверитьНаличиеОбновленийToolStripMenuItem.Text = "Проверить наличие обновлений";
            this.проверитьНаличиеОбновленийToolStripMenuItem.Click += new System.EventHandler(this.проверитьНаличиеОбновленийToolStripMenuItem_Click);
            // 
            // активацияПрограммногоОбеспеченияToolStripMenuItem
            // 
            this.активацияПрограммногоОбеспеченияToolStripMenuItem.Name = "активацияПрограммногоОбеспеченияToolStripMenuItem";
            this.активацияПрограммногоОбеспеченияToolStripMenuItem.Size = new System.Drawing.Size(309, 24);
            this.активацияПрограммногоОбеспеченияToolStripMenuItem.Text = "Информация об активации ПО";
            this.активацияПрограммногоОбеспеченияToolStripMenuItem.Click += new System.EventHandler(this.активацияПрограммногоОбеспеченияToolStripMenuItem_Click);
            // 
            // регистрацияПОЧерезИнтернетToolStripMenuItem
            // 
            this.регистрацияПОЧерезИнтернетToolStripMenuItem.Name = "регистрацияПОЧерезИнтернетToolStripMenuItem";
            this.регистрацияПОЧерезИнтернетToolStripMenuItem.Size = new System.Drawing.Size(309, 24);
            this.регистрацияПОЧерезИнтернетToolStripMenuItem.Text = "Регистрация ПО через Интернет";
            this.регистрацияПОЧерезИнтернетToolStripMenuItem.Click += new System.EventHandler(this.регистрацияПОЧерезИнтернетToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ledTestRichTextdbl);
            this.groupBox1.Controls.Add(this.ledTestRichTextFull);
            this.groupBox1.Controls.Add(this.queueToScreen);
            this.groupBox1.Controls.Add(this.ledLogSuccess);
            this.groupBox1.Controls.Add(this.ledAutoStart);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.ledStopButton);
            this.groupBox1.Controls.Add(this.ledRestartButton);
            this.groupBox1.Controls.Add(this.ledIndex);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.setColorButton);
            this.groupBox1.Controls.Add(this.ledGetStatusButton);
            this.groupBox1.Controls.Add(this.ledTestBrightness);
            this.groupBox1.Controls.Add(this.ledTestFontSize);
            this.groupBox1.Controls.Add(this.ledTestHeight);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.ledTestWidth);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ledTestDelay);
            this.groupBox1.Controls.Add(this.ledTestSpeed);
            this.groupBox1.Controls.Add(this.ledTestStunt);
            this.groupBox1.Controls.Add(this.ledTestRichText);
            this.groupBox1.Controls.Add(this.screenScanButton);
            this.groupBox1.Controls.Add(this.ledOnButton);
            this.groupBox1.Controls.Add(this.ledOffButton);
            this.groupBox1.Controls.Add(this.sendTextToLedButton);
            this.groupBox1.Controls.Add(this.ledClearButton);
            this.groupBox1.Controls.Add(this.ledStartButton);
            this.groupBox1.Location = new System.Drawing.Point(16, 214);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(885, 249);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Проверка и настройка экранов";
            // 
            // ledTestRichTextdbl
            // 
            this.ledTestRichTextdbl.BackColor = System.Drawing.Color.Black;
            this.ledTestRichTextdbl.Font = new System.Drawing.Font("Courier New", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ledTestRichTextdbl.ForeColor = System.Drawing.Color.White;
            this.ledTestRichTextdbl.Location = new System.Drawing.Point(1156, 0);
            this.ledTestRichTextdbl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledTestRichTextdbl.Name = "ledTestRichTextdbl";
            this.ledTestRichTextdbl.Size = new System.Drawing.Size(223, 219);
            this.ledTestRichTextdbl.TabIndex = 39;
            this.ledTestRichTextdbl.Text = "";
            // 
            // ledTestRichTextFull
            // 
            this.ledTestRichTextFull.BackColor = System.Drawing.Color.Black;
            this.ledTestRichTextFull.Font = new System.Drawing.Font("Courier New", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ledTestRichTextFull.ForeColor = System.Drawing.Color.White;
            this.ledTestRichTextFull.Location = new System.Drawing.Point(243, 20);
            this.ledTestRichTextFull.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledTestRichTextFull.Name = "ledTestRichTextFull";
            this.ledTestRichTextFull.Size = new System.Drawing.Size(392, 217);
            this.ledTestRichTextFull.TabIndex = 37;
            this.ledTestRichTextFull.Text = "";
            // 
            // queueToScreen
            // 
            this.queueToScreen.Location = new System.Drawing.Point(647, 209);
            this.queueToScreen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.queueToScreen.Name = "queueToScreen";
            this.queueToScreen.Size = new System.Drawing.Size(164, 28);
            this.queueToScreen.TabIndex = 36;
            this.queueToScreen.Text = "Очередь";
            this.queueToScreen.UseVisualStyleBackColor = true;
            this.queueToScreen.Click += new System.EventHandler(this.queueToScreen_Click);
            // 
            // ledLogSuccess
            // 
            this.ledLogSuccess.AutoSize = true;
            this.ledLogSuccess.Location = new System.Drawing.Point(652, 64);
            this.ledLogSuccess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledLogSuccess.Name = "ledLogSuccess";
            this.ledLogSuccess.Size = new System.Drawing.Size(164, 21);
            this.ledLogSuccess.TabIndex = 35;
            this.ledLogSuccess.Text = "подбробный журнал";
            this.ledLogSuccess.UseVisualStyleBackColor = true;
            this.ledLogSuccess.CheckStateChanged += new System.EventHandler(this.ledLogSuccess_CheckStateChanged);
            // 
            // ledAutoStart
            // 
            this.ledAutoStart.AutoSize = true;
            this.ledAutoStart.Location = new System.Drawing.Point(652, 44);
            this.ledAutoStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledAutoStart.Name = "ledAutoStart";
            this.ledAutoStart.Size = new System.Drawing.Size(173, 21);
            this.ledAutoStart.TabIndex = 34;
            this.ledAutoStart.Text = "запускать при старте";
            this.ledAutoStart.UseVisualStyleBackColor = true;
            this.ledAutoStart.CheckStateChanged += new System.EventHandler(this.ledAutoStart_CheckStateChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1220, 114);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 17);
            this.label12.TabIndex = 33;
            this.label12.Text = "LED-индекс";
            // 
            // ledStopButton
            // 
            this.ledStopButton.Location = new System.Drawing.Point(739, 14);
            this.ledStopButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledStopButton.Name = "ledStopButton";
            this.ledStopButton.Size = new System.Drawing.Size(87, 28);
            this.ledStopButton.TabIndex = 31;
            this.ledStopButton.Text = "Стоп";
            this.ledStopButton.UseVisualStyleBackColor = true;
            this.ledStopButton.Click += new System.EventHandler(this.ledStopButton_Click);
            // 
            // ledRestartButton
            // 
            this.ledRestartButton.Location = new System.Drawing.Point(647, 14);
            this.ledRestartButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledRestartButton.Name = "ledRestartButton";
            this.ledRestartButton.Size = new System.Drawing.Size(87, 28);
            this.ledRestartButton.TabIndex = 30;
            this.ledRestartButton.Text = "Рестрарт";
            this.ledRestartButton.UseVisualStyleBackColor = true;
            this.ledRestartButton.Click += new System.EventHandler(this.ledRestartButton_Click);
            // 
            // ledIndex
            // 
            this.ledIndex.Location = new System.Drawing.Point(1316, 112);
            this.ledIndex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ledIndex.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.ledIndex.Name = "ledIndex";
            this.ledIndex.Size = new System.Drawing.Size(77, 22);
            this.ledIndex.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(916, 26);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 17);
            this.label11.TabIndex = 27;
            this.label11.Text = "Шрифт:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(649, 146);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "Яркость";
            // 
            // setColorButton
            // 
            this.setColorButton.Location = new System.Drawing.Point(429, 303);
            this.setColorButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.setColorButton.Name = "setColorButton";
            this.setColorButton.Size = new System.Drawing.Size(247, 28);
            this.setColorButton.TabIndex = 4;
            this.setColorButton.Text = "Задать цвет выделенного";
            this.setColorButton.UseVisualStyleBackColor = true;
            this.setColorButton.Click += new System.EventHandler(this.setColorButton_Click);
            // 
            // ledGetStatusButton
            // 
            this.ledGetStatusButton.Location = new System.Drawing.Point(735, 174);
            this.ledGetStatusButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledGetStatusButton.Name = "ledGetStatusButton";
            this.ledGetStatusButton.Size = new System.Drawing.Size(76, 28);
            this.ledGetStatusButton.TabIndex = 25;
            this.ledGetStatusButton.Text = "Статус";
            this.ledGetStatusButton.UseVisualStyleBackColor = true;
            this.ledGetStatusButton.Click += new System.EventHandler(this.ledGetStatusButton_Click);
            // 
            // ledTestBrightness
            // 
            this.ledTestBrightness.Location = new System.Drawing.Point(723, 142);
            this.ledTestBrightness.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledTestBrightness.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.ledTestBrightness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ledTestBrightness.Name = "ledTestBrightness";
            this.ledTestBrightness.Size = new System.Drawing.Size(151, 22);
            this.ledTestBrightness.TabIndex = 23;
            this.ledTestBrightness.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.ledTestBrightness.ValueChanged += new System.EventHandler(this.ledTestBrightness_ValueChanged);
            // 
            // ledTestFontSize
            // 
            this.ledTestFontSize.Location = new System.Drawing.Point(976, 21);
            this.ledTestFontSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledTestFontSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ledTestFontSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ledTestFontSize.Name = "ledTestFontSize";
            this.ledTestFontSize.Size = new System.Drawing.Size(37, 22);
            this.ledTestFontSize.TabIndex = 22;
            this.ledTestFontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.ledTestFontSize.ValueChanged += new System.EventHandler(this.ledTestFontSize_ValueChanged);
            // 
            // ledTestHeight
            // 
            this.ledTestHeight.Location = new System.Drawing.Point(1333, 20);
            this.ledTestHeight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledTestHeight.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.ledTestHeight.Name = "ledTestHeight";
            this.ledTestHeight.Size = new System.Drawing.Size(56, 22);
            this.ledTestHeight.TabIndex = 20;
            this.ledTestHeight.Value = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.ledTestHeight.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1312, 25);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "x";
            this.label9.Visible = false;
            // 
            // ledTestWidth
            // 
            this.ledTestWidth.Location = new System.Drawing.Point(1255, 20);
            this.ledTestWidth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledTestWidth.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.ledTestWidth.Name = "ledTestWidth";
            this.ledTestWidth.Size = new System.Drawing.Size(55, 22);
            this.ledTestWidth.TabIndex = 18;
            this.ledTestWidth.Value = new decimal(new int[] {
            160,
            0,
            0,
            0});
            this.ledTestWidth.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1172, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Размеры:";
            this.label8.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(780, 117);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Стоп";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(640, 89);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Анимация:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(648, 117);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Скорость";
            // 
            // ledTestDelay
            // 
            this.ledTestDelay.Location = new System.Drawing.Point(824, 113);
            this.ledTestDelay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledTestDelay.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ledTestDelay.Name = "ledTestDelay";
            this.ledTestDelay.Size = new System.Drawing.Size(49, 22);
            this.ledTestDelay.TabIndex = 12;
            this.ledTestDelay.Validated += new System.EventHandler(this.ledTestDelay_Validated);
            // 
            // ledTestSpeed
            // 
            this.ledTestSpeed.Location = new System.Drawing.Point(723, 113);
            this.ledTestSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledTestSpeed.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.ledTestSpeed.Name = "ledTestSpeed";
            this.ledTestSpeed.Size = new System.Drawing.Size(49, 22);
            this.ledTestSpeed.TabIndex = 11;
            this.ledTestSpeed.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.ledTestSpeed.Validated += new System.EventHandler(this.ledTestSpeed_Validated);
            // 
            // ledTestStunt
            // 
            this.ledTestStunt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ledTestStunt.FormattingEnabled = true;
            this.ledTestStunt.Items.AddRange(new object[] {
            "0x00: RANDOM",
            "0x01: STATIC",
            "0x02: DIRECT_SHOW",
            "0x03: MOVE_LEFT",
            "0x04: CONTINOUS_MOVE_LEFT",
            "0x05: MOVE_UP",
            "0x06: Continuum move up",
            "0x07: flicker",
            "0x08: snowing",
            "0x09: bubbling",
            "0x0A: middle out",
            "0x0B: move around",
            "0x0C: horizontal cross move",
            "0x0D: vertical cross move",
            "0x0E: scroll closed",
            "0x0F: scroll opened",
            "0x10: left stretch",
            "0x11: right stretch",
            "0x12: up stretch",
            "0x13: down stretch BX-",
            "0x14: left laser",
            "0x15: right laser",
            "0x16: up laser",
            "0x17: down laser",
            "0x18: cross curtain left and right",
            "0x19: cross curtain up and down ",
            "0x1A: curtain scattered to the left ",
            "0x1B: horizontal blinds",
            "0x1C: vertical blinds ",
            "0x1D: Curtain left ",
            "0x1E: Curtain right ",
            "0x1F: Curtain up ",
            "0x20: Curtain down ",
            "0x21: Move to center from left and right ",
            "0x22: Split to left and right ",
            "0x23: Move to center from up and down ",
            "0x24: Split to up and down ",
            "0x25: Move right",
            "0x26: Continuum move right",
            "0x27: Move down ",
            "0x28: Continuum move down "});
            this.ledTestStunt.Location = new System.Drawing.Point(723, 85);
            this.ledTestStunt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledTestStunt.Name = "ledTestStunt";
            this.ledTestStunt.Size = new System.Drawing.Size(149, 24);
            this.ledTestStunt.TabIndex = 10;
            this.ledTestStunt.TextUpdate += new System.EventHandler(this.ledTestStunt_TextUpdate);
            this.ledTestStunt.Validated += new System.EventHandler(this.ledTestStunt_Validated);
            // 
            // ledTestRichText
            // 
            this.ledTestRichText.BackColor = System.Drawing.Color.Black;
            this.ledTestRichText.Font = new System.Drawing.Font("Courier New", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ledTestRichText.ForeColor = System.Drawing.Color.White;
            this.ledTestRichText.Location = new System.Drawing.Point(11, 20);
            this.ledTestRichText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledTestRichText.Name = "ledTestRichText";
            this.ledTestRichText.Size = new System.Drawing.Size(223, 219);
            this.ledTestRichText.TabIndex = 8;
            this.ledTestRichText.Text = "";
            // 
            // screenScanButton
            // 
            this.screenScanButton.Location = new System.Drawing.Point(1277, 160);
            this.screenScanButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.screenScanButton.Name = "screenScanButton";
            this.screenScanButton.Size = new System.Drawing.Size(100, 28);
            this.screenScanButton.TabIndex = 7;
            this.screenScanButton.Text = "screenScan";
            this.screenScanButton.UseVisualStyleBackColor = true;
            this.screenScanButton.Click += new System.EventHandler(this.screenScanButton_Click);
            // 
            // ledOnButton
            // 
            this.ledOnButton.Location = new System.Drawing.Point(819, 174);
            this.ledOnButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledOnButton.Name = "ledOnButton";
            this.ledOnButton.Size = new System.Drawing.Size(59, 28);
            this.ledOnButton.TabIndex = 6;
            this.ledOnButton.Text = "On";
            this.ledOnButton.UseVisualStyleBackColor = true;
            this.ledOnButton.Click += new System.EventHandler(this.ledOnButton_Click);
            // 
            // ledOffButton
            // 
            this.ledOffButton.Location = new System.Drawing.Point(819, 209);
            this.ledOffButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledOffButton.Name = "ledOffButton";
            this.ledOffButton.Size = new System.Drawing.Size(59, 28);
            this.ledOffButton.TabIndex = 5;
            this.ledOffButton.Text = "Off";
            this.ledOffButton.UseVisualStyleBackColor = true;
            this.ledOffButton.Click += new System.EventHandler(this.ledOffButton_Click);
            // 
            // sendTextToLedButton
            // 
            this.sendTextToLedButton.Location = new System.Drawing.Point(644, 174);
            this.sendTextToLedButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sendTextToLedButton.Name = "sendTextToLedButton";
            this.sendTextToLedButton.Size = new System.Drawing.Size(88, 28);
            this.sendTextToLedButton.TabIndex = 3;
            this.sendTextToLedButton.Text = "Показать";
            this.sendTextToLedButton.UseVisualStyleBackColor = true;
            this.sendTextToLedButton.Click += new System.EventHandler(this.sendTextToLedButton_Click);
            // 
            // ledClearButton
            // 
            this.ledClearButton.Location = new System.Drawing.Point(1275, 82);
            this.ledClearButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledClearButton.Name = "ledClearButton";
            this.ledClearButton.Size = new System.Drawing.Size(92, 28);
            this.ledClearButton.TabIndex = 1;
            this.ledClearButton.Text = "Очистить";
            this.ledClearButton.UseVisualStyleBackColor = true;
            this.ledClearButton.Click += new System.EventHandler(this.ledClearButton_Click);
            // 
            // ledStartButton
            // 
            this.ledStartButton.Location = new System.Drawing.Point(1191, 82);
            this.ledStartButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledStartButton.Name = "ledStartButton";
            this.ledStartButton.Size = new System.Drawing.Size(76, 28);
            this.ledStartButton.TabIndex = 0;
            this.ledStartButton.Text = "Старт";
            this.ledStartButton.UseVisualStyleBackColor = true;
            this.ledStartButton.Click += new System.EventHandler(this.ledStartButton_Click);
            // 
            // ledTestColorDialog
            // 
            this.ledTestColorDialog.Color = System.Drawing.Color.Red;
            // 
            // logReadTimer
            // 
            this.logReadTimer.Enabled = true;
            this.logReadTimer.Interval = 1000;
            this.logReadTimer.Tick += new System.EventHandler(this.logReadTimer_Tick);
            // 
            // checkRefreshTimer
            // 
            this.checkRefreshTimer.Interval = 3000;
            this.checkRefreshTimer.Tick += new System.EventHandler(this.checkRefreshTimer_Tick);
            // 
            // ledTestRichTextFulldbl
            // 
            this.ledTestRichTextFulldbl.BackColor = System.Drawing.Color.Black;
            this.ledTestRichTextFulldbl.Font = new System.Drawing.Font("Courier New", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ledTestRichTextFulldbl.ForeColor = System.Drawing.Color.White;
            this.ledTestRichTextFulldbl.Location = new System.Drawing.Point(1392, 214);
            this.ledTestRichTextFulldbl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ledTestRichTextFulldbl.Name = "ledTestRichTextFulldbl";
            this.ledTestRichTextFulldbl.Size = new System.Drawing.Size(392, 217);
            this.ledTestRichTextFulldbl.TabIndex = 38;
            this.ledTestRichTextFulldbl.Text = "";
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip2.Location = new System.Drawing.Point(0, 79);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip2.Size = new System.Drawing.Size(1007, 22);
            this.statusStrip2.TabIndex = 39;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 524);
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.ledTestRichTextFulldbl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.logSettings);
            this.Controls.Add(this.resetSettingsButton);
            this.Controls.Add(this.webServerSettings);
            this.Controls.Add(this.databaseSettings);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.logBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1725, 1251);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(925, 265);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iQueue - настройка";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.serverPort)).EndInit();
            this.webServerSettings.ResumeLayout(false);
            this.webServerSettings.PerformLayout();
            this.databaseSettings.ResumeLayout(false);
            this.databaseSettings.PerformLayout();
            this.logSettings.ResumeLayout(false);
            this.logSettings.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ledIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTestBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTestFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTestHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTestWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTestDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledTestSpeed)).EndInit();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runWebServiceButton;
        private System.Windows.Forms.Button stopWebServiceButton;
        private System.Windows.Forms.NumericUpDown serverPort;
        private System.Windows.Forms.GroupBox webServerSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox databaseSettings;
        private System.Windows.Forms.Button dbFileSelectButton;
        private System.Windows.Forms.TextBox dbFilePath;
        private System.Windows.Forms.OpenFileDialog openDBFile;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.TextBox logDirectoryPath;
        private System.Windows.Forms.GroupBox logSettings;
        private System.Windows.Forms.Button selectLogDirButton;
        private System.Windows.Forms.FolderBrowserDialog logDirOpen;
        private System.Windows.Forms.Button resetSettingsButton;
        private System.Windows.Forms.CheckBox serverAutoStart;
        private System.Windows.Forms.Button initDBButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel webServerStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel ledOnlineCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel visitorsOnlineCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel visitorsWaitCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel visitorsDoneCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel visitorsLateCount;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem toggleMainWindow;
        private System.Windows.Forms.ToolStripMenuItem goToWEBInterface;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ComboBox webServiceAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label databaseStatus;
        private System.Windows.Forms.ToolStripMenuItem открытьЖурналToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ledStartButton;
        private System.Windows.Forms.Button ledClearButton;
        private System.Windows.Forms.Button sendTextToLedButton;
        private System.Windows.Forms.ColorDialog ledTestColorDialog;
        private System.Windows.Forms.Button setColorButton;
        private System.Windows.Forms.Button ledOnButton;
        private System.Windows.Forms.Button ledOffButton;
        private System.Windows.Forms.Button screenScanButton;
        private System.Windows.Forms.RichTextBox ledTestRichText;
        private System.Windows.Forms.ComboBox ledTestStunt;
        private System.Windows.Forms.NumericUpDown ledTestSpeed;
        private System.Windows.Forms.NumericUpDown ledTestDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown ledTestHeight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown ledTestWidth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown ledTestFontSize;
        private System.Windows.Forms.NumericUpDown ledTestBrightness;
        private System.Windows.Forms.Button ledGetStatusButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.Timer logReadTimer;
        private System.Windows.Forms.ToolStripMenuItem следитьЗаЛогамиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logWatch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown ledIndex;
        private System.Windows.Forms.ToolStripMenuItem очиститьЛогToolStripMenuItem;
        private System.Windows.Forms.Button ledRestartButton;
        private System.Windows.Forms.Button ledStopButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox ledAutoStart;
        private System.Windows.Forms.Timer checkRefreshTimer;
        private System.Windows.Forms.CheckBox ledLogSuccess;
        private System.Windows.Forms.Button queueToScreen;
        private System.Windows.Forms.RichTextBox ledTestRichTextFull;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.RichTextBox ledTestRichTextFulldbl;
        private System.Windows.Forms.RichTextBox ledTestRichTextdbl;
        private System.Windows.Forms.ToolStripMenuItem программаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перейтиВWEBинтерфейсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem скрытьОкноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перезапуститьПриложениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьПриложениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem активацияПрограммногоОбеспеченияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьЖурналПриложенияToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem проверитьНаличиеОбновленийToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem регистрацияПОЧерезИнтернетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьРекламныйКонтентToolStripMenuItem;
    }
}

