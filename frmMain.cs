using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace PhotoTransfer
{
    public partial class frmMain : Form
    {
        private DateTime lastClick = DateTime.Now;
        private int borderSide = 12;
        private int paddingSize = 4;

        bool existNode = false;

        public frmMain()
        {
            InitializeComponent();
            Padding = new Padding(paddingSize);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void borderCaptionPanel_MouseDown(object sender, MouseEventArgs e)
        {
            TimeSpan length = DateTime.Now - lastClick;
            TimeSpan interval = new TimeSpan(0, 0, 0, 0, 250);

            if (length < interval)
            {
                WindowStateFunction();
                return;
            }
            lastClick = DateTime.Now;

            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }


/*
        protected override void WndProc(ref Message sizing)
        {
            if (sizing.Msg == 0x84)
            {
                Point pos = new Point(sizing.LParam.ToInt32());
                pos = PointToClient(pos);

                // Left top corner ==========================================================================================
                if (pos.X <= borderSide && pos.Y <= borderSide)
                {
                    sizing.Result = (IntPtr)13;
                    return;
                }

                // Left bottom corner ==========================================================================================
                if (pos.X <= borderSide && pos.Y >= ClientSize.Height - borderSide)
                {
                    sizing.Result = (IntPtr)16;
                    return;
                }

                // Right bottom corner ==========================================================================================
                if (pos.X >= ClientSize.Width - borderSide && pos.Y >= ClientSize.Height - borderSide)
                {
                    sizing.Result = (IntPtr)17;
                    return;
                }

                // Right top corner ==========================================================================================
                if (pos.X >= ClientSize.Width - borderSide && pos.Y <= borderSide)
                {
                    sizing.Result = (IntPtr)14;
                    return;
                }

                // Bottom side ==========================================================================================
                if (pos.Y >= ClientSize.Height - borderSide)
                {
                    sizing.Result = (IntPtr)15;
                    return;
                }

                // Top side ==========================================================================================
                if (pos.Y <= borderSide)
                {
                    sizing.Result = (IntPtr)12;
                    return;
                }

                // Left side ==========================================================================================
                if (pos.X <= borderSide)
                {
                    sizing.Result = (IntPtr)10;
                    return;
                }

                // Right side ==========================================================================================
                if (pos.X >= ClientSize.Width - borderSide)
                {
                    sizing.Result = (IntPtr)11;
                    return;
                }
            }
            if (WindowState != FormWindowState.Maximized)
            {
                Padding = new Padding(paddingSize);
                btnMaxNorm.Text = "▲";
            }
            else
            {
                Padding = new Padding(0);
                btnMaxNorm.Text = "▼";
            }

            base.WndProc(ref sizing);
        }

*/

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnMaxNorm_Click(object sender, EventArgs e)
        {
            WindowStateFunction();
        }

        private void WindowStateFunction()
        {
            if (WindowState == FormWindowState.Normal)
            {
                Padding = new Padding(0);
                WindowState = FormWindowState.Maximized;
                btnMaxNorm.Text = "▼";
                return;
            }
            else
            {
                Padding = new Padding(paddingSize);
                WindowState = FormWindowState.Normal;
                btnMaxNorm.Text = "▲";
                return;
            }
        }

        private void btnMinimaze_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReloadTrees();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ReloadTrees();
        }

        private void ReloadTrees()
        {
            int i = 0;
            LeftTreeView.Nodes.Clear();
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
            {

                if (driveInfo.DriveType == DriveType.CDRom && driveInfo.IsReady)
                {
                    i = TreeIcons(driveInfo, i, 0);
                }
                else if (driveInfo.DriveType == DriveType.Fixed && driveInfo.Name == @"C:\")
                {
                    i = TreeIcons(driveInfo, i, 1);
                }
                else if (driveInfo.DriveType == DriveType.Fixed && driveInfo.IsReady)
                {
                    i = TreeIcons(driveInfo, i, 2);
                }
            }
        }

        private int TreeIcons(DriveInfo driveInfo, int driveNumber, int iconNumber)
        {
            LeftTreeView.Nodes.Add(driveInfo.Name);
            LeftTreeView.Nodes[driveNumber].ImageIndex = iconNumber;
            LeftTreeView.Nodes[driveNumber].SelectedImageIndex = iconNumber;
            return ++driveNumber;
        }

        private void LeftTreeView_AfterSelect(object sender, TreeViewEventArgs e) // Add directorys if LeftTreeView
        {
            ShowDirectorys(LeftTreeView);
        }


        private void ShowDirectorys(TreeView SelectedTreeView) // Get all directorys in selected node
        {
            string theLastDirectory; // Variable for directory name without full path
            DirectoryInfo info;

            foreach (string directoryInfo in Directory.GetDirectories(SelectedTreeView.SelectedNode.FullPath, "*", SearchOption.TopDirectoryOnly)) // Get all directorys in selected node
            {
                info = new DirectoryInfo(directoryInfo); // Get properties of directory

                if ((info.Attributes & FileAttributes.System) == FileAttributes.System | (info.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden) // If directory is System or Hidden
                {
                    continue; // Stop and go to next foreach loop
                }

                theLastDirectory = Path.GetFileName(directoryInfo); // Get a directory name in selected node without full path
                ExistNode(SelectedTreeView, theLastDirectory); // Check exist directory name in selected node

                if (existNode == false) // If directory not exists
                {
                    SelectedTreeView.SelectedNode.Nodes.Add(theLastDirectory); // Add node as directory name
                }
            }
        }

        private bool ExistNode(TreeView ExistTreeView, string existDirectory) // Exist directory name in selected node
        {
            foreach (TreeNode node in ExistTreeView.SelectedNode.Nodes) // Get node name from selected node in TreeView
            {
                if (node.Text == existDirectory) // If directory name from selected node in TreeView exists
                {
                    return existNode = true; // Return "Have this name"
                }
            }
            return existNode = false; // Return "Don't have this name" if directory name not exists
        }
    }
}