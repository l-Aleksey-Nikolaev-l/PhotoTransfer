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
        private DateTime lastClick = DateTime.Now;
        private int borderSide = 12;
        private int paddingSize = 4;
        private int filesCount = 0;
        private int copiesCount = 0;
        private int transferedFilesCount = 0;
        private double generalFilesSize = 0;
        private bool diskSpaceLeft = false;
        private bool diskSpaceRight = false;
        private bool isMove = false;

        string sourceFolderPath = ""; // For example: F/Nikon/0200D850
        string destinationFolderPath = ""; // For example: E:/Archive
        string extentions = @".dng|.DNG|.fff|.FFF|.jpg|.JPG|.JPEG|.jpeg|.nef|.NEF|.png|.PNG|.raw|.RAW|.tif|.tiff|.TIF|.TIFF|.mp4|.mov|.wma|.avi|.MP4|.MOV|.WMA|.AVI";

        FileInfo sourceFileInfo;

        TreeView selectedTreeView;
        TreeView prevSelectedTreeView;

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

        private void btnMinimaze_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void frmMain_Load(object sender, EventArgs e)
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


        private void LeftTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (selectedTreeView != null)
            {
                selectedTreeView.SelectedNode.BackColor = Color.Empty;
            }
        }

        private void LeftTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedTreeView = e.Node.TreeView;
            allDirectorys.ShowDirectorys(selectedTreeView);
            CalculateFreeSpace(LeftFreeSpaceLabel, diskSpaceLeft, selectedTreeView);
            ShowContent(selectedTreeView);
            FilesFinded(); // Show files in bottom panel
            SelectedItemColor(selectedTreeView);
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
            ShowContent(selectedTreeView);
            SelectedItemColor(selectedTreeView);
        }


        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################


        private void RightTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (selectedTreeView != null)
            {
                selectedTreeView.SelectedNode.BackColor = Color.Empty;
            }
        }

        private void RightTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedTreeView = e.Node.TreeView;
            allDirectorys.ShowDirectorys(selectedTreeView);
            CalculateFreeSpace(RightFreeSpaceLabel, diskSpaceRight, selectedTreeView);
            ShowContent(selectedTreeView);
            SelectedItemColor(selectedTreeView);
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
            ShowContent(selectedTreeView);
            SelectedItemColor(selectedTreeView);
        }


        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################
        //########################################################################################################################################


        private void TopNodeIcon(int indexIcon, TreeViewCancelEventArgs e)
        {
            if (e.Node.Text.Contains(':') == false)
            {
                e.Node.ImageIndex = indexIcon;
            }
        }

        private void RenameFolder(NodeLabelEditEventArgs e)
        {

            List<string> savedNodes = e.Node.FullPath.Split('/').ToList();

            savedNodes[savedNodes.Count-1] = e.Label;
            
            string oldFolderName, newFolderName;
            oldFolderName = e.Node.FullPath;
            newFolderName = e.Node.Parent.FullPath + "/" + e.Label;
            Directory.Move(oldFolderName, newFolderName);
            selectedTreeView.SelectedNode.Name = e.Label;
            selectedTreeView.SelectedNode.Text = e.Label;
            selectedTreeView.SelectedNode.EndEdit(false);
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

        private void ShowContent(TreeView inputTreeView)
        {
            listView1.BeginUpdate();

            listView1.Clear();

            if (inputTreeView == LeftTreeView)
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

                if (inputTreeView == LeftTreeView)
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

        private void SelectedItemColor (TreeView activeTree)
        {

            if (activeTree == LeftTreeView)
            {
                prevSelectedTreeView = RightTreeView;
            } else
            {
                prevSelectedTreeView = LeftTreeView;
            }

            if (prevSelectedTreeView.SelectedNode == null)
            {
                return;
            }

            Color activeColor;
            Color nonActiveColor;

            activeColor = Color.FromArgb(0, 120, 215);
            nonActiveColor = Color.FromArgb(120, 120, 120);

            prevSelectedTreeView.SelectedNode.BackColor = nonActiveColor;
            selectedTreeView.SelectedNode.BackColor = activeColor;
            TreeLabelColor(activeTree, activeColor, nonActiveColor);
        }

        private void TreeLabelColor(TreeView activeTree, Color activeColor, Color nonActiveColor)
        {
            if (activeTree == LeftTreeView)
            {
                leftTreeLabel.BackColor = activeColor;
                rightTreeLabel.BackColor = nonActiveColor;
            }
            else
            {
                leftTreeLabel.BackColor = nonActiveColor;
                rightTreeLabel.BackColor = activeColor;
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

            foreach (TreeNode node in selectedTreeView.SelectedNode.Nodes)
            {
                if (node.Text == newFolderName)
                {
                    selectedTreeView.SelectedNode = node;
                    break;
                }
            }

            allDirectorys.RefreshDirectorys(this);
            selectedTreeView.SelectedNode.BackColor = Color.Empty;

        }

        private void RenameFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectedTreeView.LabelEdit = true;
            selectedTreeView.SelectedNode.BeginEdit();
        }

        private void DeleteFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.GetFileSystemEntries(selectedTreeView.SelectedNode.FullPath).Length == 0)
            {
                Directory.Delete(selectedTreeView.SelectedNode.FullPath);
                selectedTreeView.SelectedNode.Remove();
            }
            else // If selected folder is NOT empty
            {
                DialogResult = MessageBox.Show("Folder is NOT empty! Delete folder " + selectedTreeView.SelectedNode.Text + "?", "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2, 0, false);
                if (DialogResult == DialogResult.Yes)
                {
                    try
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(selectedTreeView.SelectedNode.FullPath, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                        selectedTreeView.SelectedNode.Remove();
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
            bottomInfoPanel.BackColor = Color.FromArgb(103, 148, 54);
        }

        private void buttonForCopy_MouseLeave(object sender, EventArgs e)
        {
            bottomInfoPanel.BackColor = Color.Black;
        }

        private void buttonForCopy_Click(object sender, EventArgs e)
        {
            Pre_DoWork();
        }

        private void buttonForMove_MouseEnter(object sender, EventArgs e)
        {
            bottomInfoPanel.BackColor = Color.DarkGoldenrod;
        }

        private void buttonForMove_MouseLeave(object sender, EventArgs e)
        {
            bottomInfoPanel.BackColor = Color.Black;
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

            if (Path.GetFileName(destinationFolderPath) != "Archive")
            {
                MessageBox.Show("Archive folder NOT selected!", "Hmmm...", 0, MessageBoxIcon.Stop);
                return;
            }

            BlockControls(LeftTreeView);
            BlockControls(RightTreeView);

            GeneralProgressTransfer.Visible = true;
            ProgressTransfer.Visible = true;

            backgroundCopyMove.RunWorkerAsync();
        }

        private void backgroundCopyMove_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            GetAndTransferAllFiles();

            backgroundCopyMove.CancelAsync();
            e.Cancel = true;
        }

        private void backgroundCopyMove_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            ProgressTransfer.Value = e.ProgressPercentage; // Show progress for a one file

            if (e.ProgressPercentage == 100)
            {
                GeneralProgressTransfer.Maximum = filesCount;
                GeneralProgressTransfer.Value = ++transferedFilesCount;
                CalculateFreeSpace(LeftFreeSpaceLabel, diskSpaceLeft, LeftTreeView);
                CalculateFreeSpace(RightFreeSpaceLabel, diskSpaceRight, RightTreeView);
                FilesFinded();
            }
        }

        private void backgroundCopyMove_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            string msg;

            if(isMove == false)
            {
                msg = "Copied ";
            }
            else
            {
                msg = "Moved ";
                isMove = false;
            }

            MessageBox.Show("Done! " + msg + transferedFilesCount + " files!");

            if (copiesCount > 0)
            {
                MessageBox.Show("Attantion!" + "\n" + "In SOURSE folder - " + copiesCount + " file(s) is COPIES." + "\n" + "Check them!", "NOT transfered " + copiesCount + " files", 0, MessageBoxIcon.Exclamation);
            }

            UnBlockControls(LeftTreeView);
            UnBlockControls(RightTreeView);

            GeneralProgressTransfer.Visible = false;
            ProgressTransfer.Visible = false;

            GeneralProgressTransfer.Value = 0;
            ProgressTransfer.Value = 0;
            transferedFilesCount = 0;
            copiesCount = 0;


            allDirectorys.ShowDirectorys(RightTreeView); 
            CalculateFreeSpace(RightFreeSpaceLabel, diskSpaceRight, RightTreeView);


            allDirectorys.ShowDirectorys(LeftTreeView);
            CalculateFreeSpace(LeftFreeSpaceLabel, diskSpaceLeft, LeftTreeView);


            selectedTreeView.Focus();
            ShowContent(selectedTreeView);
            FilesFinded();
        }

        private void BlockControls(TreeView sourceTreeView) // Block controls and change nodes color
        {
            sourceTreeView.Enabled = false;
            btnClose.Enabled = false;
            buttonForCopy.Enabled = false;
            buttonForMove.Enabled = false;
            Color newColor = Color.FromArgb(100, 100, 100);

            foreach (TreeNode sourceTreeNodes in sourceTreeView.Nodes)
            {
                sourceTreeNodes.BackColor = newColor;
                ReColorNodes(sourceTreeNodes, newColor);
            }
            sourceTreeView.SelectedNode.BackColor = Color.FromArgb(120, 120, 120);
        }

        private void UnBlockControls(TreeView sourceTreeView) // UnBlock controls and change nodes color
        {
            sourceTreeView.Enabled = true;
            btnClose.Enabled = true;
            buttonForCopy.Enabled = true;
            buttonForMove.Enabled = true;
            Color newColor = Color.FromArgb(64, 64, 64);

            foreach (TreeNode sourceTreeNodes in sourceTreeView.Nodes)
            {
                sourceTreeNodes.BackColor = newColor;
                ReColorNodes(sourceTreeNodes, newColor);
            }
            sourceTreeView.SelectedNode.BackColor = Color.FromArgb(0, 120, 215);
        }

        private void ReColorNodes(TreeNode sourceTreeNodes, Color newColor)
        {
            foreach (TreeNode foundedTreeNode in sourceTreeNodes.Nodes)
            {
                foundedTreeNode.BackColor = newColor;
                ReColorNodes(foundedTreeNode, newColor);
            }
        }

        private void GetAndTransferAllFiles()
        {
            Regex extentionsPattern = new Regex(extentions);
            
            foreach (string getFile in Directory.GetFileSystemEntries(sourceFolderPath, "*", SearchOption.TopDirectoryOnly))
            {
                sourceFileInfo = new FileInfo(getFile);

                if (extentionsPattern.IsMatch(getFile) == false)
                {
                    continue;
                }

                PreparationForTransferring(destinationFolderPath, sourceFileInfo);

                if (isMove == true) // If pressed MOVE TO button
                {
                    File.Delete(sourceFileInfo.FullName);
                }
            }
        }

        private void PreparationForTransferring(string destinationFolderPath, FileInfo sourceFileInfo)
        {
            string newDestinationFolderPath = CreateNewPath(destinationFolderPath, sourceFileInfo);
            CheckExistenceOfDirectory(newDestinationFolderPath);
            newDestinationFolderPath = CheckExistenceOfFile(newDestinationFolderPath, sourceFileInfo);
            TransferFile(newDestinationFolderPath, sourceFileInfo);
            RestoreShootingDate(newDestinationFolderPath, sourceFileInfo);
        }

        private string CreateNewPath(string newDestinationFolderPath, FileInfo sourceFileInfo)
        {
            int fileDay = sourceFileInfo.LastWriteTime.Day;
            int fileMonth = sourceFileInfo.LastWriteTime.Month;
            int fileYear = sourceFileInfo.LastWriteTime.Year;

            string day = fileDay.ToString();
            string[] monthName = {"01 January", "02 February", "03 March", "04 April", "05 May", "06 June", "07 July", "08 August", "09 September", "10 October", "11 November", "12 December" };
            string month = monthName[fileMonth - 1];

            if (fileDay < 10)
            {
                day = "0" + fileDay.ToString();
            }

            return newDestinationFolderPath + "//" + fileYear + "//" + month + "//" + day;
        }
       
        private void CheckExistenceOfDirectory(string newDestinationFolderPath)
        {
            if (Directory.Exists(newDestinationFolderPath) == false)
            {
                Directory.CreateDirectory(newDestinationFolderPath);
            }
        }

        private string CheckExistenceOfFile(string newDestinationFolderPath, FileInfo sourceFileInfo)
        {
            if (File.Exists(newDestinationFolderPath + "//" + sourceFileInfo.Name))
            {
                if (Directory.Exists(newDestinationFolderPath + "//" + "_COPIES") == false)
                {
                    Directory.CreateDirectory(newDestinationFolderPath + "//" + "_COPIES");
                }
            }
            return newDestinationFolderPath += "//" + "_COPIES";
        }

        private void TransferFile(string newDestinationFolderPath, FileInfo sourceFileInfo)
        {
            FileStream sourceFile = new FileStream(sourceFileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
            FileStream destinationFile = new FileStream(newDestinationFolderPath + "//" + sourceFileInfo.Name, FileMode.Create);
            FileStream destinationFileData = new FileStream(sourceFileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);

            byte[] originalFileData = new byte[4096]; // 1Mb = 1048576 Bytes in Binary (not in decimal SI) / 512KB = 524288 Bytes / 4096 Bytes - is recomendation
            byte[] newFileData = new byte[4096];

            int readByte;

            while ((readByte = sourceFile.Read(originalFileData, 0, originalFileData.Length)) > 0)
            {
                destinationFile.Write(originalFileData, 0, readByte);
                CheckDataOfNewFile(originalFileData, newFileData, destinationFileData);
                backgroundCopyMove.ReportProgress((int)(sourceFile.Position * 100 / sourceFile.Length));
            }

            sourceFile.Close();
            destinationFile.Close();
            destinationFileData.Close();
        }

        private void CheckDataOfNewFile(byte[] originalFileData, byte[] newFileData, FileStream destinationFileData)
        {
            bool compareFilesData;
            do
            {
                destinationFileData.Read(newFileData, 0, 4096);
                compareFilesData = originalFileData.SequenceEqual(newFileData);
            }
            while (compareFilesData == false);
        }

        private void RestoreShootingDate(string newDestinationFolderPath, FileInfo sourceFileInfo)
        {
            DateTime origrnalDataTime = sourceFileInfo.LastWriteTime;
            File.SetCreationTime(newDestinationFolderPath + "//" + sourceFileInfo.Name, origrnalDataTime);
            File.SetLastWriteTime(newDestinationFolderPath + "//" + sourceFileInfo.Name, origrnalDataTime);
        }
    }
}