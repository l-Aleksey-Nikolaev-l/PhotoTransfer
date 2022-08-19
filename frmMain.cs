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
        private DateTime lastClick = DateTime.Now; // Variable for borderCaptionPanel_MouseDown()
        private int borderSide = 12; // Variable for WndProc()
        private int paddingSize = 4; // Variable for WindowStateFunction() and WndProc()

        bool existNode = false; // Variable for ShowDirectorys() and ExistNode()
        TreeView selectedTreeView;

        public frmMain()
        {
            InitializeComponent();
            Padding = new Padding(paddingSize);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void borderCaptionPanel_MouseDown(object sender, MouseEventArgs e) // DoubleClick for Border Caption
        {
            TimeSpan length = DateTime.Now - lastClick; // Get new time interval
            TimeSpan interval = new TimeSpan(0, 0, 0, 0, 250); // Time for comparison

            if (length < interval) // If time less than 250ms
            {
                WindowStateFunction();
                return;
            }
            lastClick = DateTime.Now; // Get time of the last click in borderCaptionPanel

            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }


        /*
                protected override void WndProc(ref Message sizing) // For resizing main window
                {
                    if (sizing.Msg == 0x84) // If right mouse button is down
                    {
                        Point pos = new Point(sizing.LParam.ToInt32());
                        pos = PointToClient(pos); // Get mouse position in client field

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
                        btnMaxNorm.ImageIndex = 0;
                    }
                    else
                    {
                        Padding = new Padding(0);
                        btnMaxNorm.ImageIndex = 1;
                    }

                    base.WndProc(ref sizing);
                }

        */


//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################


        private void btnClose_Click(object sender, EventArgs e) // Button for close app
        {
            Dispose();
        }

        private void btnMaxNorm_Click(object sender, EventArgs e) // Button for normalize and maximize main window
        {
            WindowStateFunction();
        }

        private void WindowStateFunction() // Function for normalize and maximize main window
        {
            if (WindowState == FormWindowState.Normal)
            {
                Padding = new Padding(0);
                WindowState = FormWindowState.Maximized;
                btnMaxNorm.ImageIndex = 1;
                return;
            }
            else
            {
                Padding = new Padding(paddingSize);
                WindowState = FormWindowState.Normal;
                btnMaxNorm.ImageIndex = 0;
                return;
            }
        }

        private void btnMinimaze_Click(object sender, EventArgs e) // Button for minimize main window
        {
            WindowState = FormWindowState.Minimized;
        }

        private void frmMain_Load(object sender, EventArgs e) // LOAD
        {
            ReloadTrees(LeftTreeView); // Reload drives and directorys for LeftTreeView
            ReloadTrees(RightTreeView); // Reload drives and directorys for RightTreeView
        }


//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################

        private void LeftTreeView_AfterSelect(object sender, TreeViewEventArgs e) // Add directorys to LeftTreeView
        {
            ShowDirectorys(LeftTreeView);
        }

        private void LeftTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TopNodeIcon(6, e);
        }

        private void LeftTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            TopNodeIcon(5, e);
        }

        private void LeftTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e) // Remane selected node (folder)
        {
            RenameFolder(e);
        }


//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################

        private void RightTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowDirectorys(RightTreeView);
        }

        private void RightTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TopNodeIcon(6, e);
        }

        private void RightTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            TopNodeIcon(5, e);
        }

        private void RightTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            RenameFolder(e);
        }


//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################

        private void ReloadTrees(TreeView sourceTreeView) // Function for clear tree and add drives with icons again
        {
            int drivesCount = 0; // Variable for set drive number in tree
            sourceTreeView.Nodes.Clear(); // Clear sourse tree
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives()) // Get drives
            {

                if (driveInfo.DriveType == DriveType.CDRom && driveInfo.IsReady) // If it is CD-Rom and it is ready
                {
                    drivesCount = TreeIcons(sourceTreeView, driveInfo, drivesCount, 2); // drivesCount get number from TreeIcons() and index icon 0 from iconsList
                }
                else if (driveInfo.DriveType == DriveType.Fixed && driveInfo.Name == @"C:\") // If it is HDD and it is drive C:\
                {
                    drivesCount = TreeIcons(sourceTreeView, driveInfo, drivesCount, 3); 
                }
                else if (driveInfo.DriveType == DriveType.Fixed && driveInfo.IsReady)  // If it is HDD and it is ready
                {
                    drivesCount = TreeIcons(sourceTreeView, driveInfo, drivesCount, 4);
                }
            }
        }

        private int TreeIcons(TreeView oldTreeView, DriveInfo driveInfo, int driveNumber, int iconNumber) // Add drive in tree and add icon
        {
            oldTreeView.Nodes.Add(driveInfo.Name); // Add drive in tree
            oldTreeView.Nodes[driveNumber].ImageIndex = iconNumber; // Set selected icon for selected drive as default
            oldTreeView.Nodes[driveNumber].SelectedImageIndex = iconNumber; // Set icon for drive if drive was mouse selected
            return ++driveNumber; // Return new number for next drive
        }

        private void TopNodeIcon(int indexIcon, TreeViewCancelEventArgs e) // Save drives icons
        {
            if (e.Node.Text.Contains(':') == false) // Change icons for nodes without ":"
            {
                e.Node.ImageIndex = indexIcon;
                e.Node.SelectedImageIndex = indexIcon;
            }
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

        private void RenameFolder(NodeLabelEditEventArgs e) // Rename selected node
        {
            string oldNameFolder, newNameFolder; // Variables for folder names
            oldNameFolder = e.Node.FullPath; // Get old folder name
            newNameFolder = e.Node.Parent.FullPath + "\\" + e.Label; // Get new folder name
            Directory.Move(oldNameFolder, newNameFolder); // Rename folder
            selectedTreeView.SelectedNode.EndEdit(false); // Close editing
            selectedTreeView.LabelEdit = false;
        }


//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################


        private void contextMenuForTrees_Opened(object sender, EventArgs e) // Get selected TreeView
        {
            selectedTreeView = ((TreeView)((ControlAccessibleObject)contextMenuForTrees.SourceControl.AccessibilityObject).Owner).TopNode.TreeView;
        }



        private void OpenFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTreeView.SelectedNode.Expand();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTreeView.SelectedNode.Collapse();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadTrees(selectedTreeView); // Reload drives and directorys for selected TreeView
        }

        private void CreateNewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = selectedTreeView.SelectedNode.FullPath + "\\" + "New Folder";
            if (Directory.Exists(path))
            {
                MessageBox.Show("A folder with the same name exists", "Error!", 0, MessageBoxIcon.Error);
                return;
            }
            else 
            {
                selectedTreeView.SelectedNode.Nodes.Add("New Folder");
                Directory.CreateDirectory(path);
            }
        }

        private void RenameFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTreeView.LabelEdit = true;
            selectedTreeView.SelectedNode.BeginEdit(); // Start rename node
        }

        private void DeleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.GetFileSystemEntries(selectedTreeView.SelectedNode.FullPath).Length == 0)
            {
                Directory.Delete(selectedTreeView.SelectedNode.FullPath);
                selectedTreeView.SelectedNode.Remove();
            }
            else
            {
                DialogResult = MessageBox.Show("Folder is NOT empty! Delete folder " + selectedTreeView.SelectedNode.Text + "?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0, false);
                if (DialogResult == DialogResult.Yes)
                {
                    Directory.Delete(selectedTreeView.SelectedNode.FullPath, true);
                    selectedTreeView.SelectedNode.Remove();
                }
            }
        }


    }
}