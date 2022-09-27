using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoTransfer
{
    public partial class frmMain : Form
    {
        private DateTime lastClick = DateTime.Now; // Variable for borderCaptionPanel_MouseDown()
        private int borderSide = 12; // Variable for WndProc()
        private int paddingSize = 4; // Variable for WindowStateFunction() and WndProc()
        int filesCount = 0;
        private bool diskSpaceLeft = false;
        private bool diskSpaceRight = false;

        TreeView selectedTreeView; // Variable for selected TreeView
        TreeView PrevLeftTreeView = null;
        TreeView PrevRightTreeView = null;

        LoadAllDrives allDrives = new LoadAllDrives();
        LoadDirectorys allDirectorys = new LoadDirectorys();
        

        public frmMain()
        {
            InitializeComponent();
            Padding = new Padding(paddingSize);
            DoubleBuffered = true;
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
            allDrives.GetAllDrives(LeftTreeView);
            allDrives.GetAllDrives(RightTreeView);
            LeftTreeView.SelectedNode = LeftTreeView.TopNode;
            RightTreeView.SelectedNode = RightTreeView.TopNode;
            PrevLeftTreeView = LeftTreeView;
            PrevRightTreeView = RightTreeView;

        }


        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################

        private void LeftTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (PrevLeftTreeView != null && PrevLeftTreeView.SelectedNode != null)
            {
                PrevLeftTreeView.SelectedNode.BackColor = Color.Empty;
            }
            PrevLeftTreeView = selectedTreeView;
        }

        private void LeftTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedTreeView = e.Node.TreeView;
            allDirectorys.ShowDirectorys(selectedTreeView);
            CalculateFreeSpace(LeftFreeSpaceLabel, diskSpaceLeft);

            selectedTreeView.SelectedNode.BackColor = Color.FromArgb(120, 120, 120);
            selectedTreeView.SelectedNode.ForeColor = Color.White;
            ShowContent();
            FilesFinded();
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

        private void LeftTreeView_MouseEnter(object sender, EventArgs e)
        {
            selectedTreeView = LeftTreeView;
            selectedTreeView.Focus();
            ShowContent();
            FilesFinded();
        }


        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################

        private void RightTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (PrevRightTreeView != null && PrevRightTreeView.SelectedNode != null)
            {
                PrevRightTreeView.SelectedNode.BackColor = Color.Empty;
            }
            PrevRightTreeView = selectedTreeView;
        }

        private void RightTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedTreeView = e.Node.TreeView;
            allDirectorys.ShowDirectorys(selectedTreeView);
            CalculateFreeSpace(RightFreeSpaceLabel, diskSpaceRight);

            selectedTreeView.SelectedNode.BackColor = Color.FromArgb(120, 120, 120);
            selectedTreeView.SelectedNode.ForeColor = Color.White;
            ShowContent();
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

        private void RightTreeView_MouseEnter(object sender, EventArgs e)
        {
            selectedTreeView = RightTreeView;
            selectedTreeView.Focus();
            ShowContent();
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

        private void RenameFolder(NodeLabelEditEventArgs e) // Rename selected node and folder
        {

            List<string> savedNodes = e.Node.FullPath.Split('/').ToList();

            savedNodes[savedNodes.Count-1] = e.Label;
            
            string oldFolderName, newFolderName;
            oldFolderName = e.Node.FullPath; // Get old folder name
            newFolderName = e.Node.Parent.FullPath + "/" + e.Label; // Get new folder name
            Directory.Move(oldFolderName, newFolderName); // Rename folder
            selectedTreeView.SelectedNode.Name = e.Label;
            selectedTreeView.SelectedNode.Text = e.Label;
            selectedTreeView.SelectedNode.EndEdit(false); // Close editing
            selectedTreeView.LabelEdit = false;

            allDrives.GetAllDrives(selectedTreeView);

            foreach (TreeNode TN in selectedTreeView.Nodes)
            {
                if (TN.Text == savedNodes[0])
                {
                    selectedTreeView.Sort();
                    selectedTreeView.SelectedNode = TN;
                    
                    break;
                }
            }

            RestoreSelect(selectedTreeView.SelectedNode, savedNodes);
        }

        private void RestoreSelect(TreeNode selectedNode, List<string> nodesList)
        {
            nodesList.RemoveAt(0);

            if (nodesList.Count == 0)
            {
                return;
            }

            foreach (TreeNode TN in selectedNode.Nodes)
            {
                if (TN.Text == nodesList[0])
                {
                    selectedTreeView.SelectedNode = TN;
                    RestoreSelect(TN, nodesList);
                    break;
                }
            }
        }

        private void CalculateFreeSpace(Label label, bool diskSpace)
        {
            if (diskSpace == true)
            {
                DriveInfo totalSpace = new DriveInfo(selectedTreeView.SelectedNode.FullPath);
                Double space = totalSpace.TotalSize;
                space /= Math.Pow(1024, 3);
                space = Math.Round(space, 2);
                label.Text = "Total space: " + space.ToString() + " Gb";
            }
            else
            {
                DriveInfo freeSpace = new DriveInfo(selectedTreeView.SelectedNode.FullPath);
                Double space = freeSpace.AvailableFreeSpace;
                space /= Math.Pow(1024, 3);
                space = Math.Round(space, 2);
                label.Text = "Free space: " + space.ToString() + " Gb";
            }
        }

        private void FilesFinded()
        {
            string folderWithFiles = LeftTreeView.SelectedNode.Text;
            if(filesCount > 0)
            {
                label1.Text = "In (" + folderWithFiles + ") folder finded " + filesCount + " files";
            }
            else if(filesCount == 1)
            {
                label1.Text = "In (" + folderWithFiles + ") folder finded 1 file";
            }
            else
            {
                label1.Text = "In (" + folderWithFiles + ") folder files not founded";
            }
        }


        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################


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
            string newFolderName = "New_Folder";

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
            selectedTreeView.SelectedNode.BackColor = Color.Empty;

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
            selectedTreeView.SelectedNode.BackColor = Color.Empty;
        }


        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################


        private void LeftFreeSpaceLabel_Click(object sender, EventArgs e)
        {
            if (diskSpaceLeft == false) diskSpaceLeft = true; else diskSpaceLeft = false;
            selectedTreeView = new TreeView();
            selectedTreeView = LeftTreeView;
            CalculateFreeSpace(LeftFreeSpaceLabel, diskSpaceLeft);
        }

        private void RightFreeSpaceLabel_Click(object sender, EventArgs e)
        {
            if (diskSpaceRight == false) diskSpaceRight = true; else diskSpaceRight = false;
            selectedTreeView = new TreeView();
            selectedTreeView = RightTreeView;
            CalculateFreeSpace(RightFreeSpaceLabel, diskSpaceRight);
        }

        private void ShowContent()
        {
            listView1.BeginUpdate();

            listView1.Clear();

            filesCount = 0;
            int count = 0;
            string path = selectedTreeView.SelectedNode.FullPath;
            string extension;
            FileInfo fi;
            DirectoryInfo di;
            FileAttributes forFolder;

            foreach (string fileInfo in Directory.GetFileSystemEntries(path, "*", SearchOption.TopDirectoryOnly))
            {
                fi = new FileInfo(fileInfo);
                di = new DirectoryInfo(fileInfo);
                forFolder = File.GetAttributes(fi.ToString());
                extension = fi.Extension;

                if ((di.Attributes & FileAttributes.System) == FileAttributes.System || (di.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    continue;
                }

                if ((forFolder & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    listView1.Items.Add(Path.GetFileName(fileInfo), 2);
                    listView1.Items[count].Group = listView1.Groups[0];
                    count++;
                    continue;
                }

                switch (extension)
                {
                    case ".dng":
                    case ".DNG":
                        listView1.Items.Add(Path.GetFileName(fileInfo), 0);
                        listView1.Items[count].Group = listView1.Groups[1];
                        filesCount++;
                        break;

                    case ".fff":
                    case ".FFF":
                        listView1.Items.Add(Path.GetFileName(fileInfo), 1);
                        listView1.Items[count].Group = listView1.Groups[1];
                        filesCount++;
                        break;

                    case ".jpg":
                    case ".JPG":
                    case ".JPEG":
                    case ".jpeg":
                        listView1.Items.Add(Path.GetFileName(fileInfo), 4);
                        listView1.Items[count].Group = listView1.Groups[1];
                        filesCount++;
                        break;

                    case ".nef":
                    case ".NEF":
                        listView1.Items.Add(Path.GetFileName(fileInfo), 5);
                        listView1.Items[count].Group = listView1.Groups[1];
                        filesCount++;
                        break;

                    case ".png":
                    case ".PNG":
                        listView1.Items.Add(Path.GetFileName(fileInfo), 6);
                        listView1.Items[count].Group = listView1.Groups[1];
                        filesCount++;
                        break;

                    case ".raw":
                    case ".RAW":
                        listView1.Items.Add(Path.GetFileName(fileInfo), 7);
                        listView1.Items[count].Group = listView1.Groups[1];
                        filesCount++;
                        break;

                    case ".tif":
                    case ".tiff":
                    case ".TIF":
                    case ".TIFF":
                        listView1.Items.Add(Path.GetFileName(fileInfo), 8);
                        listView1.Items[count].Group = listView1.Groups[1];
                        filesCount++;
                        break;

                    case ".mp4":
                    case ".mov":
                    case ".wma":
                    case ".avi":
                    case ".MP4":
                    case ".MOV":
                    case ".WMA":
                    case ".AVI":
                        listView1.Items.Add(Path.GetFileName(fileInfo), 9);
                        listView1.Items[count].Group = listView1.Groups[1];
                        filesCount++;
                        break;

                    default:
                        continue;
                }
                count++;
            }
            listView1.EndUpdate();
        }


        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################


        private void buttonForCopy_MouseEnter(object sender, EventArgs e)
        {
            bottomInfoPanel.BackColor = Color.Teal;
        }

        private void buttonForCopy_MouseLeave(object sender, EventArgs e)
        {
            bottomInfoPanel.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void buttonForMove_MouseEnter(object sender, EventArgs e)
        {
            bottomInfoPanel.BackColor = Color.DarkGoldenrod;
        }

        private void buttonForMove_MouseLeave(object sender, EventArgs e)
        {
            bottomInfoPanel.BackColor = Color.FromArgb(30, 30, 30);
        }

        async private void buttonForCopy_Click(object sender, EventArgs e)
        {
            buttonForCopy.Enabled = false;
            buttonForMove.Enabled = false;
            progressTransfer.Visible = true;
            await Task.Delay(100);
            bottomInfoPanel.BackColor = Color.Teal;
            await Task.Delay(100);
            progressTransfer.Value = 99;
        }

        async private void buttonForMove_Click(object sender, EventArgs e)
        {
            buttonForCopy.Enabled = false;
            buttonForMove.Enabled = false;
            progressTransfer.Visible = true;
            await Task.Delay(100);
            bottomInfoPanel.BackColor = Color.DarkGoldenrod;
            await Task.Delay(100);
            progressTransfer.Value = 99;
        }
    }
}