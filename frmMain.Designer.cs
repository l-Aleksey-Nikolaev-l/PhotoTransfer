
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.borderCaptionPanel = new System.Windows.Forms.Panel();
            this.btnMinimaze = new System.Windows.Forms.Button();
            this.btnMaxNorm = new System.Windows.Forms.Button();
            this.iconsList = new System.Windows.Forms.ImageList(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.LeftTreeView = new System.Windows.Forms.TreeView();
            this.contextMenuForTrees = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateNewFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftSplitter = new System.Windows.Forms.Splitter();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.RightTreeView = new System.Windows.Forms.TreeView();
            this.rightSplitter = new System.Windows.Forms.Splitter();
            this.centerPanel = new System.Windows.Forms.Panel();
            this.bottomInfoPanel = new System.Windows.Forms.Panel();
            this.bottomSplitter = new System.Windows.Forms.Splitter();
            this.borderCaptionPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.contextMenuForTrees.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.bottomInfoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // borderCaptionPanel
            // 
            this.borderCaptionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
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
            // btnMinimaze
            // 
            this.btnMinimaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimaze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMinimaze.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMinimaze.FlatAppearance.BorderSize = 0;
            this.btnMinimaze.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnMinimaze.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(20)))));
            this.btnMinimaze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimaze.Font = new System.Drawing.Font("Arial Narrow", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMinimaze.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMinimaze.Location = new System.Drawing.Point(1099, 0);
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
            this.btnMaxNorm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMaxNorm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMaxNorm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnMaxNorm.FlatAppearance.BorderSize = 0;
            this.btnMaxNorm.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnMaxNorm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(255)))));
            this.btnMaxNorm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaxNorm.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMaxNorm.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMaxNorm.ImageIndex = 0;
            this.btnMaxNorm.ImageList = this.iconsList;
            this.btnMaxNorm.Location = new System.Drawing.Point(1134, 0);
            this.btnMaxNorm.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaxNorm.Name = "btnMaxNorm";
            this.btnMaxNorm.Size = new System.Drawing.Size(31, 31);
            this.btnMaxNorm.TabIndex = 0;
            this.btnMaxNorm.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnMaxNorm.UseVisualStyleBackColor = false;
            this.btnMaxNorm.Click += new System.EventHandler(this.btnMaxNorm_Click);
            // 
            // iconsList
            // 
            this.iconsList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconsList.ImageStream")));
            this.iconsList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconsList.Images.SetKeyName(0, "Fill dock 48.png");
            this.iconsList.Images.SetKeyName(1, "Breakout 48.png");
            this.iconsList.Images.SetKeyName(2, "CD.png");
            this.iconsList.Images.SetKeyName(3, "Drive C.png");
            this.iconsList.Images.SetKeyName(4, "HDD.png");
            this.iconsList.Images.SetKeyName(5, "Folder Close.png");
            this.iconsList.Images.SetKeyName(6, "Folder Open.png");
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(1169, 0);
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
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.leftPanel.Controls.Add(this.LeftTreeView);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 35);
            this.leftPanel.MaximumSize = new System.Drawing.Size(300, 0);
            this.leftPanel.MinimumSize = new System.Drawing.Size(150, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(200, 733);
            this.leftPanel.TabIndex = 1;
            // 
            // LeftTreeView
            // 
            this.LeftTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.LeftTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LeftTreeView.ContextMenuStrip = this.contextMenuForTrees;
            this.LeftTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LeftTreeView.ForeColor = System.Drawing.SystemColors.Control;
            this.LeftTreeView.ImageIndex = 5;
            this.LeftTreeView.ImageList = this.iconsList;
            this.LeftTreeView.Indent = 32;
            this.LeftTreeView.ItemHeight = 32;
            this.LeftTreeView.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.LeftTreeView.Location = new System.Drawing.Point(0, 0);
            this.LeftTreeView.Name = "LeftTreeView";
            this.LeftTreeView.SelectedImageIndex = 5;
            this.LeftTreeView.ShowLines = false;
            this.LeftTreeView.ShowPlusMinus = false;
            this.LeftTreeView.Size = new System.Drawing.Size(200, 733);
            this.LeftTreeView.StateImageList = this.iconsList;
            this.LeftTreeView.TabIndex = 0;
            this.LeftTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.LeftTreeView_AfterLabelEdit);
            this.LeftTreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.LeftTreeView_BeforeCollapse);
            this.LeftTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.LeftTreeView_BeforeExpand);
            this.LeftTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.LeftTreeView_AfterSelect);
            // 
            // RightTreeView
            // 
            this.RightTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.RightTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RightTreeView.ContextMenuStrip = this.contextMenuForTrees;
            this.RightTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RightTreeView.ForeColor = System.Drawing.SystemColors.Control;
            this.RightTreeView.ImageIndex = 5;
            this.RightTreeView.ImageList = this.iconsList;
            this.RightTreeView.Indent = 32;
            this.RightTreeView.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.RightTreeView.Location = new System.Drawing.Point(0, 0);
            this.RightTreeView.Name = "RightTreeView";
            this.RightTreeView.SelectedImageIndex = 5;
            this.RightTreeView.ShowLines = false;
            this.RightTreeView.ShowPlusMinus = false;
            this.RightTreeView.Size = new System.Drawing.Size(200, 733);
            this.RightTreeView.StateImageList = this.iconsList;
            this.RightTreeView.TabIndex = 0;
            this.RightTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.RightTreeView_AfterLabelEdit);
            this.RightTreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.RightTreeView_BeforeCollapse);
            this.RightTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.RightTreeView_BeforeExpand);
            this.RightTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.RightTreeView_AfterSelect);
            // 
            // contextMenuForTrees
            // 
            this.contextMenuForTrees.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFolderToolStripMenuItem,
            this.CloseToolStripMenuItem,
            this.RefreshToolStripMenuItem,
            this.CreateNewFolderToolStripMenuItem,
            this.RenameFolderToolStripMenuItem,
            this.toolStripSeparator1,
            this.DeleteFolderToolStripMenuItem});
            this.contextMenuForTrees.Name = "contextMenuLeftTree";
            this.contextMenuForTrees.Size = new System.Drawing.Size(168, 142);
            this.contextMenuForTrees.Opened += new System.EventHandler(this.contextMenuForTrees_Opened);
            // 
            // OpenFolderToolStripMenuItem
            // 
            this.OpenFolderToolStripMenuItem.Name = "OpenFolderToolStripMenuItem";
            this.OpenFolderToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.OpenFolderToolStripMenuItem.Text = "Open";
            this.OpenFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenFolderToolStripMenuItem_Click);
            // 
            // CloseToolStripMenuItem
            // 
            this.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem";
            this.CloseToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.CloseToolStripMenuItem.Text = "Close";
            this.CloseToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // RefreshToolStripMenuItem
            // 
            this.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem";
            this.RefreshToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.RefreshToolStripMenuItem.Text = "Refresh";
            this.RefreshToolStripMenuItem.Click += new System.EventHandler(this.RefreshToolStripMenuItem_Click);
            // 
            // CreateNewFolderToolStripMenuItem
            // 
            this.CreateNewFolderToolStripMenuItem.Name = "CreateNewFolderToolStripMenuItem";
            this.CreateNewFolderToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.CreateNewFolderToolStripMenuItem.Text = "Create new folder";
            this.CreateNewFolderToolStripMenuItem.Click += new System.EventHandler(this.CreateNewFolderToolStripMenuItem_Click);
            // 
            // RenameFolderToolStripMenuItem
            // 
            this.RenameFolderToolStripMenuItem.Name = "RenameFolderToolStripMenuItem";
            this.RenameFolderToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.RenameFolderToolStripMenuItem.Text = "Rename folder";
            this.RenameFolderToolStripMenuItem.Click += new System.EventHandler(this.RenameFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // DeleteFolderToolStripMenuItem
            // 
            this.DeleteFolderToolStripMenuItem.Name = "DeleteFolderToolStripMenuItem";
            this.DeleteFolderToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.DeleteFolderToolStripMenuItem.Text = "Delete folder";
            this.DeleteFolderToolStripMenuItem.Click += new System.EventHandler(this.DeleteFolderToolStripMenuItem_Click);
            // 
            // leftSplitter
            // 
            this.leftSplitter.Location = new System.Drawing.Point(200, 35);
            this.leftSplitter.Name = "leftSplitter";
            this.leftSplitter.Size = new System.Drawing.Size(4, 733);
            this.leftSplitter.TabIndex = 2;
            this.leftSplitter.TabStop = false;
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.rightPanel.Controls.Add(this.RightTreeView);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(1000, 35);
            this.rightPanel.MaximumSize = new System.Drawing.Size(300, 0);
            this.rightPanel.MinimumSize = new System.Drawing.Size(150, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(200, 733);
            this.rightPanel.TabIndex = 4;
            // 
            // rightSplitter
            // 
            this.rightSplitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightSplitter.Location = new System.Drawing.Point(996, 35);
            this.rightSplitter.Name = "rightSplitter";
            this.rightSplitter.Size = new System.Drawing.Size(4, 733);
            this.rightSplitter.TabIndex = 5;
            this.rightSplitter.TabStop = false;
            // 
            // centerPanel
            // 
            this.centerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerPanel.Location = new System.Drawing.Point(204, 35);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Size = new System.Drawing.Size(792, 733);
            this.centerPanel.TabIndex = 6;
            // 
            // bottomInfoPanel
            // 
            this.bottomInfoPanel.Controls.Add(this.bottomSplitter);
            this.bottomInfoPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomInfoPanel.Location = new System.Drawing.Point(0, 768);
            this.bottomInfoPanel.Name = "bottomInfoPanel";
            this.bottomInfoPanel.Size = new System.Drawing.Size(1200, 32);
            this.bottomInfoPanel.TabIndex = 7;
            // 
            // bottomSplitter
            // 
            this.bottomSplitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.bottomSplitter.Location = new System.Drawing.Point(0, 0);
            this.bottomSplitter.Name = "bottomSplitter";
            this.bottomSplitter.Size = new System.Drawing.Size(1200, 4);
            this.bottomSplitter.TabIndex = 0;
            this.bottomSplitter.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.centerPanel);
            this.Controls.Add(this.rightSplitter);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftSplitter);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.borderCaptionPanel);
            this.Controls.Add(this.bottomInfoPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.borderCaptionPanel.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.contextMenuForTrees.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
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
        private System.Windows.Forms.Panel bottomInfoPanel;
        private System.Windows.Forms.Splitter bottomSplitter;
        private System.Windows.Forms.TreeView LeftTreeView;
        private System.Windows.Forms.ImageList iconsList;
        private System.Windows.Forms.ContextMenuStrip contextMenuForTrees;
        private System.Windows.Forms.ToolStripMenuItem OpenFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateNewFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenameFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem RefreshToolStripMenuItem;
        private System.Windows.Forms.TreeView RightTreeView;
    }
}

