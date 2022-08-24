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
using System.Text.RegularExpressions;

namespace PhotoTransfer
{
    public partial class frmMain : Form
    {


        private DateTime lastClick = DateTime.Now; // Variable for borderCaptionPanel_MouseDown()
        private int borderSide = 12; // Variable for WndProc()
        private int paddingSize = 4; // Variable for WindowStateFunction() and WndProc()
        
        TreeView selectedTreeView; // Variable for selected TreeView

        LoadAllDrives allDrives = new LoadAllDrives();
        LoadDirectorys allDirectorys = new LoadDirectorys();



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


/**/
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

/**/


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
            
            allDrives.GetAllDrives(LeftTreeView);
            allDrives.GetAllDrives(RightTreeView);
            LeftTreeView.SelectedNode = LeftTreeView.TopNode;
            RightTreeView.SelectedNode = RightTreeView.TopNode;

        }


//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################


        private void LeftTreeView_AfterSelect(object sender, TreeViewEventArgs e) // Add directorys to LeftTreeView
        {
            selectedTreeView = e.Node.TreeView;
            allDirectorys.ShowDirectorys(selectedTreeView);
        }

        private void LeftTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            selectedTreeView = e.Node.TreeView;
        }

        private void LeftTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TopNodeIcon(6, e);
        }

        private void LeftTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            TopNodeIcon(5, e);
        }

        private void LeftTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            RenameFolder(e);
        }


        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################

        private void RightTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedTreeView = e.Node.TreeView;
            allDirectorys.ShowDirectorys(selectedTreeView);
        }

        private void RightTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            selectedTreeView = e.Node.TreeView;
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

        
        private void TopNodeIcon(int indexIcon, TreeViewCancelEventArgs e) // Save drives icons
        {
            if (e.Node.Text.Contains(':') == false) // Change icons for nodes without ":"
            {
                e.Node.ImageIndex = indexIcon;
            }
        }

        private void RenameFolder(NodeLabelEditEventArgs e) // Rename selected node
        {
            string oldFolderName, newFolderName;
            oldFolderName = e.Node.FullPath; // Get old folder name
            newFolderName = e.Node.Parent.FullPath + "\\" + e.Label; // Get new folder name
            Directory.Move(oldFolderName, newFolderName); // Rename folder
            selectedTreeView.SelectedNode.Name = e.Label;
            selectedTreeView.SelectedNode.Text = e.Label;
            allDirectorys.RefreshDirectorys(this);
            selectedTreeView.SelectedNode.EndEdit(false); // Close editing
            selectedTreeView.LabelEdit = false;
        }



//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################


        private void contextMenuForTrees_Opened(object sender, EventArgs e) // Get selected TreeView
        {
            //selectedTreeView = ((TreeView)((ControlAccessibleObject)contextMenuForTrees.SourceControl.AccessibilityObject).Owner).TopNode.TreeView;
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
            allDirectorys.RefreshDirectorys(this);
        }

        private void CreateNewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newFolderName = "New Folder";

            repeat:

            string path = selectedTreeView.SelectedNode.FullPath + "\\" + newFolderName;
            if (Directory.Exists(path) == true)
            {
                newFolderName += 1;
                goto repeat;
            }
            else
            {
                selectedTreeView.SelectedNode.Nodes.Add(newFolderName);
                Directory.CreateDirectory(path);
            }

            foreach (TreeNode node in selectedTreeView.SelectedNode.Nodes) // Find the node with saved name in parent branch
            {
                if (node.Text == newFolderName) // If the found node name is equivalent to the saved node
                {
                    selectedTreeView.SelectedNode = node; // Select node only
                    break; // Exit from loop
                }
            }
            allDirectorys.RefreshDirectorys(this);
        }

        private void RenameFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTreeView.LabelEdit = true;
            selectedTreeView.SelectedNode.BeginEdit(); // Start rename node
        }

        private void DeleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.GetFileSystemEntries(selectedTreeView.SelectedNode.FullPath).Length == 0) // If selected folder is empty
            {
                Directory.Delete(selectedTreeView.SelectedNode.FullPath); // Delete selected folder
                selectedTreeView.SelectedNode.Remove(); // Delete selected node from selected TreeView
            }
            else // If selected folder is NOT empty
            {
                DialogResult = MessageBox.Show("Folder is NOT empty! Delete folder " + selectedTreeView.SelectedNode.Text + "?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0, false);
                if (DialogResult == DialogResult.Yes)
                {
                    Directory.Delete(selectedTreeView.SelectedNode.FullPath, true); // Delete selected folder with all files
                    selectedTreeView.SelectedNode.Remove(); // Delete selected node from selected TreeView
                }
            }
            allDirectorys.RefreshDirectorys(this);
        }

    }
}