using System.IO;
using System.Windows.Forms;

namespace PhotoTransfer
{
    class LoadAllDrives
    {
        public void GetAllDrives(TreeView sourceTreeView) // Function for clear tree and add drives with icons again
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

    }
}
