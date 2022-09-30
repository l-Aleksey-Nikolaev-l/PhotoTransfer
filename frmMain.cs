using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PhotoTransfer
{
    public partial class frmMain : Form
    {
        private DateTime lastClick = DateTime.Now; // Variable for borderCaptionPanel_MouseDown()
        private int borderSide = 12; // Variable for WndProc()
        private int paddingSize = 4; // Variable for WindowStateFunction() and WndProc()
        private int filesCount = 0; // Count of validation files
        private int transferedFilesCount = 0; // Count of transfered files
        private double generalFilesSize = 0; // Size all files for transfer
        private bool diskSpaceLeft = false;
        private bool diskSpaceRight = false;
        private bool isLeftTreeView = true;
        private bool isMove = false; // Pressed MOVE or COPY button?

        string sourceFolderPath = ""; // For example: F/Nikon/0200D850
        string destinationFolderPath = ""; // For example: E:/Archive
        string fileExtension; // Variable for get file extention (.jpg, .exe, ...)
        string extentions = @".dng|.DNG|.fff|.FFF|.jpg|.JPG|.JPEG|.jpeg|.nef|.NEF|.png|.PNG|.raw|.RAW|.tif|.tiff|.TIF|.TIFF|.mp4|.mov|.wma|.avi|.MP4|.MOV|.WMA|.AVI"; // Pattern with extentions

        TreeView selectedTreeView; // Variable for selected TreeView
        TreeView PrevLeftTreeView = null;
        TreeView PrevRightTreeView = null;

        LoadAllDrives allDrives = new LoadAllDrives(); // Class for load drives
        LoadDirectorys allDirectorys = new LoadDirectorys(); // Class for load directorys
        

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

/**/
        protected override void WndProc(ref Message sizing) // For resizing main window
        {
            if (sizing.Msg == 0x84) // If left mouse button is down
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
            CalculateFreeSpace(LeftFreeSpaceLabel, diskSpaceLeft, selectedTreeView);

            selectedTreeView.SelectedNode.BackColor = Color.FromArgb(120, 120, 120);
            selectedTreeView.SelectedNode.ForeColor = Color.White;
            isLeftTreeView = true;
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
            isLeftTreeView = true;
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
            CalculateFreeSpace(RightFreeSpaceLabel, diskSpaceRight, selectedTreeView);

            selectedTreeView.SelectedNode.BackColor = Color.FromArgb(120, 120, 120);
            selectedTreeView.SelectedNode.ForeColor = Color.White;
            isLeftTreeView = false;
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
            isLeftTreeView = false;
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

        private void ShowContent()
        {
            listView1.BeginUpdate();

            listView1.Clear();

            if (isLeftTreeView == true)
            {
                filesCount = 0;
            }

            int listCount = -1;
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
                    listCount++;
                    listView1.Items.Add(Path.GetFileName(fileInfo), 2);
                    listView1.Items[listCount].Group = listView1.Groups[0];
                    continue;
                }

                switch (extension)
                {
                    case ".dng":
                    case ".DNG":
                        listView1.Items.Add(Path.GetFileName(fileInfo), 0);
                        break;

                    case ".fff":
                    case ".FFF":
                        listView1.Items.Add(Path.GetFileName(fileInfo), 1);
                        break;

                    case ".jpg":
                    case ".JPG":
                    case ".JPEG":
                    case ".jpeg":
                        listView1.Items.Add(Path.GetFileName(fileInfo), 4);
                        break;

                    case ".nef":
                    case ".NEF":
                        listView1.Items.Add(Path.GetFileName(fileInfo), 5);
                        break;

                    case ".png":
                    case ".PNG":
                        listView1.Items.Add(Path.GetFileName(fileInfo), 6);
                        break;

                    case ".raw":
                    case ".RAW":
                        listView1.Items.Add(Path.GetFileName(fileInfo), 7);
                        break;

                    case ".tif":
                    case ".tiff":
                    case ".TIF":
                    case ".TIFF":
                        listView1.Items.Add(Path.GetFileName(fileInfo), 8);
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
                        break;

                    default:
                        continue;
                }

                if (isLeftTreeView == true)
                {
                    filesCount++;
                }

                listCount++;
                listView1.Items[listCount].Group = listView1.Groups[1];
                generalFilesSize += fi.Length;
            }
            listView1.EndUpdate();
            generalFilesSize = Math.Round(((generalFilesSize / 1024) / 1024), 2);
        }

        private void FilesFinded()
        {

            if (transferedFilesCount > 0)
            {
                label1.Text = filesCount + " / " + transferedFilesCount;
                return;
            }

            string folderWithFiles = LeftTreeView.SelectedNode.Text;
            string unitSize = " Mb";

            if(generalFilesSize > 1000)
            {
                generalFilesSize = Math.Round(generalFilesSize / 1024, 2);
                unitSize = " Gb";
            }

            if (filesCount == 0)
            {
                label1.Text = "In (" + folderWithFiles + ") folder files not founded";
            }
            else if (filesCount == 1)
            {
                label1.Text = "In (" + folderWithFiles + ") folder finded 1 file " + "(" + generalFilesSize + unitSize + ")";
            }
            else if (filesCount > 1)
            {
                label1.Text = "In (" + folderWithFiles + ") folder finded " + filesCount + " files " + "(" + generalFilesSize + unitSize + ")";
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
                    try
                    {
                        // Delete selected folder with all files
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(selectedTreeView.SelectedNode.FullPath, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                        selectedTreeView.SelectedNode.Remove(); // Delete selected node from selected TreeView
                    }
                    catch
                    {
                    }
                    
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
            CalculateFreeSpace(LeftFreeSpaceLabel, diskSpaceLeft, LeftTreeView);
        }

        private void RightFreeSpaceLabel_Click(object sender, EventArgs e)
        {
            if (diskSpaceRight == false) diskSpaceRight = true; else diskSpaceRight = false;
            CalculateFreeSpace(RightFreeSpaceLabel, diskSpaceRight, RightTreeView);
        }

        private void CalculateFreeSpace(Label label, bool diskSpace, TreeView treeView)
        {
            if (diskSpace == true)
            {
                DriveInfo totalSpace = new DriveInfo(treeView.SelectedNode.FullPath);
                double space = totalSpace.TotalSize;
                space /= Math.Pow(1024, 3);
                space = Math.Round(space, 2);
                label.Text = "Total space: " + space.ToString() + " Gb";
            }
            else
            {
                DriveInfo freeSpace = new DriveInfo(treeView.SelectedNode.FullPath);
                double space = freeSpace.AvailableFreeSpace;
                space /= Math.Pow(1024, 3);
                space = Math.Round(space, 2);
                label.Text = "Free space: " + space.ToString() + " Gb";
            }
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

        private void buttonForCopy_Click(object sender, EventArgs e)
        {
            isMove = false;
            Pre_DoWork();
        }

        private void buttonForMove_MouseEnter(object sender, EventArgs e)
        {
            bottomInfoPanel.BackColor = Color.DarkGoldenrod;
        }

        private void buttonForMove_MouseLeave(object sender, EventArgs e)
        {
            bottomInfoPanel.BackColor = Color.FromArgb(30, 30, 30);
        }

        private void buttonForMove_Click(object sender, EventArgs e)
        {
            isMove = true;
            Pre_DoWork();
        }


        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################


        private void Pre_DoWork()
        {
            sourceFolderPath = LeftTreeView.SelectedNode.FullPath; // For example: F/Nikon/0200D850
            destinationFolderPath = RightTreeView.SelectedNode.FullPath; // For example: E:/Archive

            if (Path.GetFileName(destinationFolderPath) != "Archive") // Destination folder name is Archve?
            {
                MessageBox.Show("Archive folder NOT selected!", "Hmmm...", 0, MessageBoxIcon.Stop);
                return;
            }

            BlockControls(LeftTreeView); // Change backcolor for nodes in LeftTreeView 
            BlockControls(RightTreeView); // Change backcolor for nodes in RightTreeView 

            GeneralProgressTransfer.Visible = true;
            ProgressTransfer.Visible = true;

            backgroundCopyMove.RunWorkerAsync(); // Start Async for backgroundCopyMove
        }

        private void backgroundCopyMove_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            CheckCopyAllFiles(); // Go to check files function

            backgroundCopyMove.CancelAsync(); // Cancel Async for backgroundCopyMove
            e.Cancel = true; // Stop DoWork
        }

        private void backgroundCopyMove_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            ProgressTransfer.Value = e.ProgressPercentage; // Show progress for one file

            if (e.ProgressPercentage == 100) // If transfer for file is end
            {
                GeneralProgressTransfer.Maximum = filesCount;
                GeneralProgressTransfer.Value = ++transferedFilesCount; // Show general transfer progress
                CalculateFreeSpace(LeftFreeSpaceLabel, diskSpaceLeft, LeftTreeView); // Update left label with free space
                CalculateFreeSpace(RightFreeSpaceLabel, diskSpaceRight, RightTreeView); // Update right label with free space
                FilesFinded(); // Update label with finded files
            }
        }

        private void backgroundCopyMove_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            string msg = "";

            if(isMove == false) // Pressed button for copy or for move?
            {
                msg = "Copied ";
            }
            else
            {
                msg = "Moved ";
            }

            MessageBox.Show("Done! " + msg + transferedFilesCount + " files!"); // Message after end all processes coping

            btnClose.Enabled = true;
            buttonForCopy.Enabled = true;
            buttonForMove.Enabled = true;
            LeftTreeView.Enabled = true;
            RightTreeView.Enabled = true;

            GeneralProgressTransfer.Visible = false;
            ProgressTransfer.Visible = false;

            GeneralProgressTransfer.Value = 0; // Reset value for GeneralProgressTransfer
            ProgressTransfer.Value = 0; // Reset value for ProgressTransfer
            transferedFilesCount = 0; // Reset value for transferedFilesCount


            allDirectorys.ShowDirectorys(RightTreeView); // Update directorys for RightTreeView
            CalculateFreeSpace(RightFreeSpaceLabel, diskSpaceRight, RightTreeView); // Update right label with free space


            allDirectorys.ShowDirectorys(LeftTreeView); // Update directorys for LeftTreeView
            CalculateFreeSpace(LeftFreeSpaceLabel, diskSpaceLeft, LeftTreeView); // Update left label with free space


            selectedTreeView.Focus(); // Focus on last selected treeView 
            ShowContent(); // Update content in listView
            FilesFinded(); // Update label with finded files
        }

        private void BlockControls(TreeView sourceTreeView) // Block controls and change nodes color
        {
            sourceTreeView.Enabled = false; // Disable all treeView's
            btnClose.Enabled = false; // Disable CLOSE button
            buttonForCopy.Enabled = false; // Disable COPY TO button
            buttonForMove.Enabled = false; // Disable MOVE TO button

            foreach (TreeNode TN in sourceTreeView.Nodes) // Find root nodes in treeView's
            {
                TN.BackColor = Color.FromArgb(100, 100, 100); // Change backcolor for node
                ReColorNodes(TN); // Send finded root node to recursive function ReColorNodes()
            }
            sourceTreeView.SelectedNode.BackColor = Color.FromArgb(120, 120, 120); // Change backcolor for selected node
        }

        private void ReColorNodes(TreeNode OTN) // Recursive function for change node backcolor
        {
            foreach (TreeNode TN in OTN.Nodes) // Find node in tree
            {
                TN.BackColor = Color.FromArgb(100, 100, 100); // Change backcolor for finded node
                ReColorNodes(TN); // Send finded node to recursive function ReColorNodes()
            }
        }

        private void CheckCopyAllFiles()
        {
            // 2018 / 07 July / 24

            Regex regexPattern = new Regex(extentions); // Regex pattern
            FileInfo sourceFileInfo; // Variable for get file information (Modification date, tags, ...)

            foreach (string checkFile in Directory.GetFileSystemEntries(sourceFolderPath, "*", SearchOption.TopDirectoryOnly)) // Find all files in current folder
            {
                sourceFileInfo = new FileInfo(checkFile); // Get all information about selected file
                fileExtension = sourceFileInfo.Extension; // Get file extension (.jpg, .exe, ...)

                if (regexPattern.IsMatch(checkFile) == true) // If file extension = extension from pattern
                {
                    CopyMoveFile(destinationFolderPath, sourceFileInfo); // Go to CopyMoveFile function with destination folder path and information about selected file
                }
                else // If file extension != extension from pattern
                {
                    continue; // Select next file
                }

                if (isMove == true) // If pressed MOVE TO button
                {
                    File.Delete(sourceFileInfo.FullName); // Delete file from source directory
                }
            }
        }

        private void CopyMoveFile(string pathTo, FileInfo checkedFileInfo)
        {
            DateTime origrnalDataTime = checkedFileInfo.LastWriteTime; // Save original date of file

            int fileDay = checkedFileInfo.LastWriteTime.Day; // Get DAY of file modified
            int fileMonth = checkedFileInfo.LastWriteTime.Month; // Get MONTH of file modified
            int fileYear = checkedFileInfo.LastWriteTime.Year; // Get YEAR of file modified

            string[] monthName = {"", "01 January", "02 February", "03 March", "04 April", "05 May", "06 June", "07 July", "08 August", "09 September", "10 October", "11 November", "12 December"}; // Rename month number to number with name - 01 January, 02 February, 03 March ...
            string month = monthName[fileMonth];

            string existsPath = pathTo + "//" + fileYear + "//" + month + "//" + fileDay; // Variable for check path

            if (Directory.Exists(existsPath) == false) // Directory is EXISTS?
            {
                Directory.CreateDirectory(existsPath); // Create directories
            }

            if (File.Exists(existsPath + "//" + checkedFileInfo.Name))  // File is EXISTS?
            {
                MessageBox.Show("File exists");
                return;
            }

            FileStream fileSource = new FileStream(checkedFileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream fileDestination = new FileStream(existsPath + "//" + checkedFileInfo.Name, FileMode.Create);

            byte[] bt = new byte[16384]; // 1Mb = 1048576 Bytes in Binary (not in decimal SI) / 512KB = 524288 Bytes / 4096 Bytes - is recomendation
            int readByte;

            while ((readByte = fileSource.Read(bt, 0, bt.Length)) > 0)
            {
                fileDestination.Write(bt, 0, readByte);
                backgroundCopyMove.ReportProgress((int)(fileSource.Position * 100 / fileSource.Length));
            }

            fileSource.Close();
            fileDestination.Close();
            File.SetCreationTime(existsPath + "//" + checkedFileInfo.Name, origrnalDataTime); // Restore origrnal Create Date of file
            File.SetLastWriteTime(existsPath + "//" + checkedFileInfo.Name, origrnalDataTime); // Restore origrnal Modified Date of file
        }

    }
}