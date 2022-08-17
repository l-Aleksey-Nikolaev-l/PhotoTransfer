
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
            this.btnClose = new System.Windows.Forms.Button();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.LeftTreeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.leftSplitter = new System.Windows.Forms.Splitter();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.rightSplitter = new System.Windows.Forms.Splitter();
            this.centerPanel = new System.Windows.Forms.Panel();
            this.bottomInfoPanel = new System.Windows.Forms.Panel();
            this.bottomSplitter = new System.Windows.Forms.Splitter();
            this.borderCaptionPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
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
            this.btnMinimaze.FlatAppearance.BorderSize = 0;
            this.btnMinimaze.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnMinimaze.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(20)))));
            this.btnMinimaze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimaze.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.btnMaxNorm.FlatAppearance.BorderSize = 0;
            this.btnMaxNorm.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.btnMaxNorm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(255)))));
            this.btnMaxNorm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaxNorm.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnMaxNorm.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMaxNorm.Location = new System.Drawing.Point(1134, 0);
            this.btnMaxNorm.Margin = new System.Windows.Forms.Padding(0);
            this.btnMaxNorm.Name = "btnMaxNorm";
            this.btnMaxNorm.Size = new System.Drawing.Size(31, 31);
            this.btnMaxNorm.TabIndex = 0;
            this.btnMaxNorm.Text = "▲";
            this.btnMaxNorm.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnMaxNorm.UseVisualStyleBackColor = false;
            this.btnMaxNorm.Click += new System.EventHandler(this.btnMaxNorm_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.leftPanel.Controls.Add(this.button1);
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
            this.LeftTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LeftTreeView.ForeColor = System.Drawing.SystemColors.Control;
            this.LeftTreeView.ImageIndex = 3;
            this.LeftTreeView.ImageList = this.imageList1;
            this.LeftTreeView.Indent = 30;
            this.LeftTreeView.ItemHeight = 30;
            this.LeftTreeView.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.LeftTreeView.Location = new System.Drawing.Point(0, 0);
            this.LeftTreeView.Name = "LeftTreeView";
            this.LeftTreeView.SelectedImageIndex = 3;
            this.LeftTreeView.ShowLines = false;
            this.LeftTreeView.ShowPlusMinus = false;
            this.LeftTreeView.ShowRootLines = false;
            this.LeftTreeView.Size = new System.Drawing.Size(200, 696);
            this.LeftTreeView.StateImageList = this.imageList1;
            this.LeftTreeView.TabIndex = 0;
            this.LeftTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.LeftTreeView_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-cd-48.png");
            this.imageList1.Images.SetKeyName(1, "icons8-c-drive-48.png");
            this.imageList1.Images.SetKeyName(2, "icons8-hdd-32.png");
            this.imageList1.Images.SetKeyName(3, "Close Folder.png");
            this.imageList1.Images.SetKeyName(4, "OpenFolder.png");
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(0, 696);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.bottomSplitter.Cursor = System.Windows.Forms.Cursors.Default;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView LeftTreeView;
        private System.Windows.Forms.ImageList imageList1;
    }
}

