
namespace PhotoTransfer
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ImageList iconsList;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("GroupForFolders", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("GroupForFiles", System.Windows.Forms.HorizontalAlignment.Left);
            this.borderCaptionPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMinimaze = new System.Windows.Forms.Button();
            this.btnMaxNorm = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.LeftTreeView = new System.Windows.Forms.TreeView();
            this.contextMenuForTrees = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CreateNewFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftTreeLabel = new System.Windows.Forms.Label();
            this.leftSplitter = new System.Windows.Forms.Splitter();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.RightTreeView = new System.Windows.Forms.TreeView();
            this.rightTreeLabel = new System.Windows.Forms.Label();
            this.rightSplitter = new System.Windows.Forms.Splitter();
            this.centerPanel = new System.Windows.Forms.Panel();
            this.panelForFilesCount = new System.Windows.Forms.Panel();
            this.buttonForMove = new System.Windows.Forms.Button();
            this.buttonForCopy = new System.Windows.Forms.Button();
            this.ProgressTransfer = new System.Windows.Forms.ProgressBar();
            this.GeneralProgressTransfer = new System.Windows.Forms.ProgressBar();
            this.listView1 = new System.Windows.Forms.ListView();
            this.iconsForFiles = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.LeftFreeSpaceLabel = new System.Windows.Forms.Label();
            this.RightFreeSpaceLabel = new System.Windows.Forms.Label();
            this.bottomInfoPanel = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.backgroundCopyMove = new System.ComponentModel.BackgroundWorker();
            iconsList = new System.Windows.Forms.ImageList(this.components);
            this.borderCaptionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.leftPanel.SuspendLayout();
            this.contextMenuForTrees.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.centerPanel.SuspendLayout();
            this.bottomInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconsList
            // 
            iconsList.ColorDepth = global::PhotoTransfer.Properties.Settings.Default.Fill;
            iconsList.ImageSize = global::PhotoTransfer.Properties.Settings.Default.ImageSize;
            iconsList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconsList.ImageStream")));
            iconsList.Tag = global::PhotoTransfer.Properties.Settings.Default.Tag;
            iconsList.TransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            iconsList.Images.SetKeyName(0, "Fill dock 48.png");
            iconsList.Images.SetKeyName(1, "Breakout 48.png");
            iconsList.Images.SetKeyName(2, "CD.png");
            iconsList.Images.SetKeyName(3, "Drive C.png");
            iconsList.Images.SetKeyName(4, "HDD.png");
            iconsList.Images.SetKeyName(5, "Folder Close.png");
            iconsList.Images.SetKeyName(6, "Folder Open.png");
            // 
            // borderCaptionPanel
            // 
            this.borderCaptionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
            this.borderCaptionPanel.Controls.Add(this.pictureBox1);
            this.borderCaptionPanel.Controls.Add(this.btnMinimaze);
            this.borderCaptionPanel.Controls.Add(this.btnMaxNorm);
            this.borderCaptionPanel.Controls.Add(this.btnClose);
            this.borderCaptionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.borderCaptionPanel.Location = new System.Drawing.Point(0, 0);
            this.borderCaptionPanel.Margin = new System.Windows.Forms.Padding(2);
            this.borderCaptionPanel.Name = "borderCaptionPanel";
            this.borderCaptionPanel.Padding = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.borderCaptionPanel.Size = new System.Drawing.Size(1200, 35);
            this.borderCaptionPanel.TabIndex = 0;
            this.borderCaptionPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.borderCaptionPanel_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnMinimaze
            // 
            this.btnMinimaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimaze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
            this.btnMinimaze.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimaze.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMinimaze.FlatAppearance.BorderSize = 0;
            this.btnMinimaze.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnMinimaze.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(20)))));
            this.btnMinimaze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimaze.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMinimaze.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMinimaze.Location = new System.Drawing.Point(1100, 0);
            this.btnMinimaze.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimaze.Name = "btnMinimaze";
            this.btnMinimaze.Size = new System.Drawing.Size(31, 31);
            this.btnMinimaze.TabIndex = 0;
            this.btnMinimaze.Text = "_";
            this.btnMinimaze.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimaze.UseVisualStyleBackColor = false;
            this.btnMinimaze.Click += new System.EventHandler(this.btnMinimaze_Click);
            // 
            // btnMaxNorm
            // 
            this.btnMaxNorm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaxNorm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
            this.btnMaxNorm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMaxNorm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaxNorm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMaxNorm.FlatAppearance.BorderSize = 0;
            this.btnMaxNorm.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnMaxNorm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(255)))));
            this.btnMaxNorm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaxNorm.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMaxNorm.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMaxNorm.ImageKey = "Fill dock 48.png";
            this.btnMaxNorm.ImageList = iconsList;
            this.btnMaxNorm.Location = new System.Drawing.Point(1135, 0);
            this.btnMaxNorm.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaxNorm.Name = "btnMaxNorm";
            this.btnMaxNorm.Size = new System.Drawing.Size(31, 31);
            this.btnMaxNorm.TabIndex = 0;
            this.btnMaxNorm.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnMaxNorm.UseVisualStyleBackColor = false;
            this.btnMaxNorm.Click += new System.EventHandler(this.btnMaxNorm_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(1170, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(31, 31);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Χ";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.leftPanel.Controls.Add(this.LeftTreeView);
            this.leftPanel.Controls.Add(this.leftTreeLabel);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 35);
            this.leftPanel.MaximumSize = new System.Drawing.Size(400, 0);
            this.leftPanel.MinimumSize = new System.Drawing.Size(80, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(200, 683);
            this.leftPanel.TabIndex = 0;
            // 
            // LeftTreeView
            // 
            this.LeftTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(122)))), ((int)(((byte)(161)))));
            this.LeftTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LeftTreeView.ContextMenuStrip = this.contextMenuForTrees;
            this.LeftTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LeftTreeView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.LeftTreeView.FullRowSelect = true;
            this.LeftTreeView.ImageKey = "Folder Close.png";
            this.LeftTreeView.ImageList = iconsList;
            this.LeftTreeView.Indent = 32;
            this.LeftTreeView.ItemHeight = 32;
            this.LeftTreeView.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.LeftTreeView.Location = new System.Drawing.Point(0, 25);
            this.LeftTreeView.Name = "LeftTreeView";
            this.LeftTreeView.PathSeparator = "/";
            this.LeftTreeView.SelectedImageKey = "Folder Open.png";
            this.LeftTreeView.ShowLines = false;
            this.LeftTreeView.ShowPlusMinus = false;
            this.LeftTreeView.ShowRootLines = false;
            this.LeftTreeView.Size = new System.Drawing.Size(200, 658);
            this.LeftTreeView.StateImageList = iconsList;
            this.LeftTreeView.TabIndex = 0;
            this.LeftTreeView.TabStop = false;
            this.LeftTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.LeftTreeView_AfterLabelEdit);
            this.LeftTreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.LeftTreeView_BeforeCollapse);
            this.LeftTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.LeftTreeView_BeforeExpand);
            this.LeftTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.LeftTreeView_BeforeSelect);
            this.LeftTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.LeftTreeView_AfterSelect);
            this.LeftTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.LeftTreeView_NodeMouseClick);
            this.LeftTreeView.MouseEnter += new System.EventHandler(this.LeftTreeView_MouseEnter);
            // 
            // contextMenuForTrees
            // 
            this.contextMenuForTrees.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFolderToolStripMenuItem,
            this.CloseToolStripMenuItem,
            this.RefreshToolStripMenuItem,
            this.toolStripSeparator2,
            this.CreateNewFolderToolStripMenuItem,
            this.RenameFolderToolStripMenuItem,
            this.toolStripSeparator1,
            this.DeleteFolderToolStripMenuItem});
            this.contextMenuForTrees.Name = "contextMenuLeftTree";
            this.contextMenuForTrees.Size = new System.Drawing.Size(152, 148);
            // 
            // OpenFolderToolStripMenuItem
            // 
            this.OpenFolderToolStripMenuItem.Name = "OpenFolderToolStripMenuItem";
            this.OpenFolderToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.OpenFolderToolStripMenuItem.Text = "Open";
            this.OpenFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenFolderToolStripMenuItem_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.CloseToolStripMenuItem.Text = "Close";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.RefreshToolStripMenuItem.Text = "Refresh";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(148, 6);
            // 
            // CreateNewFolderToolStripMenuItem
            // 
            this.CreateNewFolderToolStripMenuItem.Name = "CreateNewFolderToolStripMenuItem";
            this.CreateNewFolderToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.CreateNewFolderToolStripMenuItem.Text = "New folder";
            this.CreateNewFolderToolStripMenuItem.Click += new System.EventHandler(this.CreateNewFolderToolStripMenuItem_Click);
            // 
            // RenameFolderToolStripMenuItem
            // 
            this.RenameFolderToolStripMenuItem.Name = "RenameFolderToolStripMenuItem";
            this.RenameFolderToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.RenameFolderToolStripMenuItem.Text = "Rename folder";
            this.RenameFolderToolStripMenuItem.Click += new System.EventHandler(this.RenameFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(148, 6);
            // 
            // DeleteFolderToolStripMenuItem
            // 
            this.DeleteFolderToolStripMenuItem.Name = "DeleteFolderToolStripMenuItem";
            this.DeleteFolderToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.DeleteFolderToolStripMenuItem.Text = "Delete folder";
            this.DeleteFolderToolStripMenuItem.Click += new System.EventHandler(this.DeleteFolderToolStripMenuItem_Click);
            // 
            // leftTreeLabel
            // 
            this.leftTreeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(122)))), ((int)(((byte)(161)))));
            this.leftTreeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftTreeLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftTreeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.leftTreeLabel.Location = new System.Drawing.Point(0, 0);
            this.leftTreeLabel.Name = "leftTreeLabel";
            this.leftTreeLabel.Size = new System.Drawing.Size(200, 25);
            this.leftTreeLabel.TabIndex = 0;
            this.leftTreeLabel.Text = "From...";
            this.leftTreeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftSplitter
            // 
            this.leftSplitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
            this.leftSplitter.Location = new System.Drawing.Point(200, 35);
            this.leftSplitter.Name = "leftSplitter";
            this.leftSplitter.Size = new System.Drawing.Size(4, 683);
            this.leftSplitter.TabIndex = 0;
            this.leftSplitter.TabStop = false;
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.rightPanel.Controls.Add(this.RightTreeView);
            this.rightPanel.Controls.Add(this.rightTreeLabel);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(1000, 35);
            this.rightPanel.MaximumSize = new System.Drawing.Size(400, 0);
            this.rightPanel.MinimumSize = new System.Drawing.Size(80, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(200, 683);
            this.rightPanel.TabIndex = 0;
            // 
            // RightTreeView
            // 
            this.RightTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(122)))), ((int)(((byte)(161)))));
            this.RightTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RightTreeView.ContextMenuStrip = this.contextMenuForTrees;
            this.RightTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RightTreeView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.RightTreeView.FullRowSelect = true;
            this.RightTreeView.ImageKey = "Folder Close.png";
            this.RightTreeView.ImageList = iconsList;
            this.RightTreeView.Indent = 32;
            this.RightTreeView.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.RightTreeView.Location = new System.Drawing.Point(0, 25);
            this.RightTreeView.Name = "RightTreeView";
            this.RightTreeView.PathSeparator = "/";
            this.RightTreeView.SelectedImageKey = "Folder Open.png";
            this.RightTreeView.ShowLines = false;
            this.RightTreeView.ShowPlusMinus = false;
            this.RightTreeView.ShowRootLines = false;
            this.RightTreeView.Size = new System.Drawing.Size(200, 658);
            this.RightTreeView.StateImageList = iconsList;
            this.RightTreeView.TabIndex = 0;
            this.RightTreeView.TabStop = false;
            this.RightTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.RightTreeView_AfterLabelEdit);
            this.RightTreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.RightTreeView_BeforeCollapse);
            this.RightTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.RightTreeView_BeforeExpand);
            this.RightTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.RightTreeView_BeforeSelect);
            this.RightTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RightTreeView_AfterSelect);
            this.RightTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.RightTreeView_NodeMouseClick);
            this.RightTreeView.MouseEnter += new System.EventHandler(this.RightTreeView_MouseEnter);
            // 
            // rightTreeLabel
            // 
            this.rightTreeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(122)))), ((int)(((byte)(161)))));
            this.rightTreeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rightTreeLabel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightTreeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.rightTreeLabel.Location = new System.Drawing.Point(0, 0);
            this.rightTreeLabel.Name = "rightTreeLabel";
            this.rightTreeLabel.Size = new System.Drawing.Size(200, 25);
            this.rightTreeLabel.TabIndex = 0;
            this.rightTreeLabel.Text = "To...";
            this.rightTreeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightSplitter
            // 
            this.rightSplitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
            this.rightSplitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightSplitter.Location = new System.Drawing.Point(996, 35);
            this.rightSplitter.Name = "rightSplitter";
            this.rightSplitter.Size = new System.Drawing.Size(4, 683);
            this.rightSplitter.TabIndex = 0;
            this.rightSplitter.TabStop = false;
            // 
            // centerPanel
            // 
            this.centerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
            this.centerPanel.Controls.Add(this.panelForFilesCount);
            this.centerPanel.Controls.Add(this.buttonForMove);
            this.centerPanel.Controls.Add(this.buttonForCopy);
            this.centerPanel.Controls.Add(this.ProgressTransfer);
            this.centerPanel.Controls.Add(this.GeneralProgressTransfer);
            this.centerPanel.Controls.Add(this.listView1);
            this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerPanel.Location = new System.Drawing.Point(204, 35);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Size = new System.Drawing.Size(792, 683);
            this.centerPanel.TabIndex = 0;
            // 
            // panelForFilesCount
            // 
            this.panelForFilesCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelForFilesCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(122)))), ((int)(((byte)(161)))));
            this.panelForFilesCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.panelForFilesCount.Location = new System.Drawing.Point(0, 657);
            this.panelForFilesCount.Margin = new System.Windows.Forms.Padding(0);
            this.panelForFilesCount.Name = "panelForFilesCount";
            this.panelForFilesCount.Size = new System.Drawing.Size(440, 58);
            this.panelForFilesCount.TabIndex = 1;
            // 
            // buttonForMove
            // 
            this.buttonForMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonForMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(122)))), ((int)(((byte)(161)))));
            this.buttonForMove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonForMove.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonForMove.FlatAppearance.BorderSize = 0;
            this.buttonForMove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Goldenrod;
            this.buttonForMove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGoldenrod;
            this.buttonForMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForMove.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.buttonForMove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.buttonForMove.Location = new System.Drawing.Point(620, 657);
            this.buttonForMove.Margin = new System.Windows.Forms.Padding(0);
            this.buttonForMove.MinimumSize = new System.Drawing.Size(172, 58);
            this.buttonForMove.Name = "buttonForMove";
            this.buttonForMove.Size = new System.Drawing.Size(172, 58);
            this.buttonForMove.TabIndex = 0;
            this.buttonForMove.Text = "Click for - MOVE";
            this.buttonForMove.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonForMove.UseVisualStyleBackColor = false;
            this.buttonForMove.Click += new System.EventHandler(this.buttonForMove_Click);
            this.buttonForMove.MouseEnter += new System.EventHandler(this.buttonForMove_MouseEnter);
            this.buttonForMove.MouseLeave += new System.EventHandler(this.buttonForMove_MouseLeave);
            // 
            // buttonForCopy
            // 
            this.buttonForCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonForCopy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(122)))), ((int)(((byte)(161)))));
            this.buttonForCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonForCopy.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.buttonForCopy.FlatAppearance.BorderSize = 0;
            this.buttonForCopy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(190)))), ((int)(((byte)(0)))));
            this.buttonForCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(148)))), ((int)(((byte)(54)))));
            this.buttonForCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonForCopy.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F);
            this.buttonForCopy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.buttonForCopy.Location = new System.Drawing.Point(444, 657);
            this.buttonForCopy.Margin = new System.Windows.Forms.Padding(0);
            this.buttonForCopy.MinimumSize = new System.Drawing.Size(172, 58);
            this.buttonForCopy.Name = "buttonForCopy";
            this.buttonForCopy.Size = new System.Drawing.Size(172, 58);
            this.buttonForCopy.TabIndex = 0;
            this.buttonForCopy.Text = "Click for - COPY";
            this.buttonForCopy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonForCopy.UseVisualStyleBackColor = false;
            this.buttonForCopy.Click += new System.EventHandler(this.buttonForCopy_Click);
            this.buttonForCopy.MouseEnter += new System.EventHandler(this.buttonForCopy_MouseEnter);
            this.buttonForCopy.MouseLeave += new System.EventHandler(this.buttonForCopy_MouseLeave);
            // 
            // ProgressTransfer
            // 
            this.ProgressTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ProgressTransfer.ForeColor = System.Drawing.Color.Red;
            this.ProgressTransfer.Location = new System.Drawing.Point(0, 645);
            this.ProgressTransfer.Margin = new System.Windows.Forms.Padding(0);
            this.ProgressTransfer.Name = "ProgressTransfer";
            this.ProgressTransfer.Size = new System.Drawing.Size(792, 4);
            this.ProgressTransfer.Step = 1;
            this.ProgressTransfer.TabIndex = 0;
            this.ProgressTransfer.Visible = false;
            // 
            // GeneralProgressTransfer
            // 
            this.GeneralProgressTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GeneralProgressTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.GeneralProgressTransfer.ForeColor = System.Drawing.Color.Red;
            this.GeneralProgressTransfer.Location = new System.Drawing.Point(0, 649);
            this.GeneralProgressTransfer.Margin = new System.Windows.Forms.Padding(0);
            this.GeneralProgressTransfer.Name = "GeneralProgressTransfer";
            this.GeneralProgressTransfer.Size = new System.Drawing.Size(792, 4);
            this.GeneralProgressTransfer.Step = 1;
            this.GeneralProgressTransfer.TabIndex = 0;
            this.GeneralProgressTransfer.Visible = false;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(122)))), ((int)(((byte)(161)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.ForeColor = System.Drawing.SystemColors.Control;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            listViewGroup1.Header = "GroupForFolders";
            listViewGroup1.Name = "GroupForFolders";
            listViewGroup2.Header = "GroupForFiles";
            listViewGroup2.Name = "GroupForFiles";
            this.listView1.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.iconsForFiles;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(792, 653);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 0;
            this.listView1.TileSize = new System.Drawing.Size(80, 80);
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // iconsForFiles
            // 
            this.iconsForFiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconsForFiles.ImageStream")));
            this.iconsForFiles.TransparentColor = System.Drawing.Color.Transparent;
            this.iconsForFiles.Images.SetKeyName(0, "dng-80.png");
            this.iconsForFiles.Images.SetKeyName(1, "fff-80.png");
            this.iconsForFiles.Images.SetKeyName(2, "folder-80.png");
            this.iconsForFiles.Images.SetKeyName(3, "image-file-80.png");
            this.iconsForFiles.Images.SetKeyName(4, "jpg-80.png");
            this.iconsForFiles.Images.SetKeyName(5, "nef-80.png");
            this.iconsForFiles.Images.SetKeyName(6, "png-80.png");
            this.iconsForFiles.Images.SetKeyName(7, "raw-80.png");
            this.iconsForFiles.Images.SetKeyName(8, "tif-80.png");
            this.iconsForFiles.Images.SetKeyName(9, "video-file-80.png");
            this.iconsForFiles.Images.SetKeyName(10, "X-grey-80.png");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.label1.Location = new System.Drawing.Point(250, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(700, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "In 0200D850 folder finded 50000 files";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LeftFreeSpaceLabel
            // 
            this.LeftFreeSpaceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LeftFreeSpaceLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LeftFreeSpaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LeftFreeSpaceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.LeftFreeSpaceLabel.Location = new System.Drawing.Point(6, 4);
            this.LeftFreeSpaceLabel.Margin = new System.Windows.Forms.Padding(0);
            this.LeftFreeSpaceLabel.Name = "LeftFreeSpaceLabel";
            this.LeftFreeSpaceLabel.Size = new System.Drawing.Size(197, 23);
            this.LeftFreeSpaceLabel.TabIndex = 0;
            this.LeftFreeSpaceLabel.Text = "Total space: 8888,88 Gb";
            this.LeftFreeSpaceLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.LeftFreeSpaceLabel.Click += new System.EventHandler(this.LeftFreeSpaceLabel_Click);
            // 
            // RightFreeSpaceLabel
            // 
            this.RightFreeSpaceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RightFreeSpaceLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RightFreeSpaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.RightFreeSpaceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(242)))), ((int)(((byte)(250)))));
            this.RightFreeSpaceLabel.Location = new System.Drawing.Point(998, 5);
            this.RightFreeSpaceLabel.Margin = new System.Windows.Forms.Padding(0);
            this.RightFreeSpaceLabel.Name = "RightFreeSpaceLabel";
            this.RightFreeSpaceLabel.Size = new System.Drawing.Size(196, 22);
            this.RightFreeSpaceLabel.TabIndex = 0;
            this.RightFreeSpaceLabel.Text = "Total space: 8888,88 Gb";
            this.RightFreeSpaceLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.RightFreeSpaceLabel.Click += new System.EventHandler(this.RightFreeSpaceLabel_Click);
            // 
            // bottomInfoPanel
            // 
            this.bottomInfoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
            this.bottomInfoPanel.Controls.Add(this.label1);
            this.bottomInfoPanel.Controls.Add(this.splitter1);
            this.bottomInfoPanel.Controls.Add(this.RightFreeSpaceLabel);
            this.bottomInfoPanel.Controls.Add(this.LeftFreeSpaceLabel);
            this.bottomInfoPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomInfoPanel.Location = new System.Drawing.Point(0, 718);
            this.bottomInfoPanel.Name = "bottomInfoPanel";
            this.bottomInfoPanel.Size = new System.Drawing.Size(1200, 32);
            this.bottomInfoPanel.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
            this.splitter1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1200, 4);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // backgroundCopyMove
            // 
            this.backgroundCopyMove.WorkerReportsProgress = true;
            this.backgroundCopyMove.WorkerSupportsCancellation = true;
            this.backgroundCopyMove.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundCopyMove_DoWork);
            this.backgroundCopyMove.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundCopyMove_ProgressChanged);
            this.backgroundCopyMove.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundCopyMove_RunWorkerCompleted);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(102)))), ((int)(((byte)(141)))));
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.centerPanel);
            this.Controls.Add(this.rightSplitter);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftSplitter);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.borderCaptionPanel);
            this.Controls.Add(this.bottomInfoPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1164, 400);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.borderCaptionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.contextMenuForTrees.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.centerPanel.ResumeLayout(false);
            this.bottomInfoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel borderCaptionPanel;
        private System.Windows.Forms.Button btnMinimaze;
        private System.Windows.Forms.Button btnMaxNorm;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Splitter leftSplitter;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Splitter rightSplitter;
        private System.Windows.Forms.Panel centerPanel;
        private System.Windows.Forms.TreeView LeftTreeView;
        private System.Windows.Forms.ContextMenuStrip contextMenuForTrees;
        private System.Windows.Forms.ToolStripMenuItem OpenFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateNewFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenameFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.TreeView RightTreeView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label leftTreeLabel;
        private System.Windows.Forms.Label rightTreeLabel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList iconsForFiles;
        private System.Windows.Forms.Label LeftFreeSpaceLabel;
        private System.Windows.Forms.Label RightFreeSpaceLabel;
        private System.Windows.Forms.Panel bottomInfoPanel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button buttonForCopy;
        private System.Windows.Forms.Button buttonForMove;
        private System.Windows.Forms.ProgressBar GeneralProgressTransfer;
        private System.Windows.Forms.Panel panelForFilesCount;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundCopyMove;
        private System.Windows.Forms.ProgressBar ProgressTransfer;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

