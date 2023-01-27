using System.IO;
using System.Windows.Forms;

namespace PhotoTransfer
{
    class LoadAllDrives
    {
        public void GetAllDrives(TreeView sourceTreeView)
        {
            int drivesCount = 0;
            sourceTreeView.Nodes.Clear();
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
            {

                if (driveInfo.DriveType == DriveType.CDRom && driveInfo.IsReady) // If it is CD-Rom and it is ready
                {
                    drivesCount = TreeIcons(sourceTreeView, driveInfo, drivesCount, 2); // drivesCount get number from TreeIcons() and get icon index from iconsList
                }
                else if (driveInfo.DriveType == DriveType.Fixed && driveInfo.Name == @"C:\") // If it is HDD and it is drive C:\
                {
                    drivesCount = TreeIcons(sourceTreeView, driveInfo, drivesCount, 3);
                }
                else if (driveInfo.DriveType == DriveType.Fixed && driveInfo.IsReady)  // If it is HDD and it is ready
                {
                    drivesCount = TreeIcons(sourceTreeView, driveInfo, drivesCount, 4);
                }
                else if (driveInfo.DriveType == DriveType.Removable && driveInfo.IsReady)  // If it is USB or SD-card and it is ready
                {
                    drivesCount = TreeIcons(sourceTreeView, driveInfo, drivesCount, 4);
                }
            }
        }

        private int TreeIcons(TreeView sourceTreeView, DriveInfo driveInfo, int driveNumber, int iconNumber) // Add drive in tree and add icon
        {
            sourceTreeView.Nodes.Add(driveInfo.Name); // Add a drive in tree
            sourceTreeView.Nodes[driveNumber].ImageIndex = iconNumber; // Set an icon for the drive as default
            sourceTreeView.Nodes[driveNumber].SelectedImageIndex = iconNumber; // Set an icon for the drive if drive was selected with the mouse
            return ++driveNumber;
        }

    }
}