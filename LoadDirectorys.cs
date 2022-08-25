using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PhotoTransfer
{
    class LoadDirectorys
    {
        bool existNode = false; // Variable for exist directorys
        string selectedNode = null; // Variable for save the last selected node in branch
        LoadAllDrives allDrives = new LoadAllDrives();
        DirectoryInfo info; // Variable for directory attributes

        public void ShowDirectorys(TreeView SelectedTreeView) // Get all directorys in selected node
        {
            foreach (string directoryInfo in Directory.GetDirectories(SelectedTreeView.SelectedNode.FullPath, "*", SearchOption.TopDirectoryOnly)) // Get all directorys in selected node
            {
                info = new DirectoryInfo(directoryInfo); // Get properties of directory

                if ((info.Attributes & FileAttributes.System) == FileAttributes.System | (info.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden) // If directory is System or Hidden
                {
                    continue; // Stop this loop and go to the next foreach loop
                }

                ExistNode(SelectedTreeView, Path.GetFileName(directoryInfo)); // Check exist directory name in selected node

                if (existNode == false) // If directory not exists
                {
                    SelectedTreeView.SelectedNode.Nodes.Add(Path.GetFileName(directoryInfo)); // Add node as directory name
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


//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################

        public void RefreshDirectorys(Control mainForm) // Refresh directirys in parent node
        {
            var AllTreeView = GetControl(mainForm, typeof(TreeView)); // Get all TreeView's from main form

            foreach (TreeView Tree in AllTreeView) // Get TreeView control from variable AllControls
            {
                Reftreebranch(Tree);
            }
        }

        private IEnumerable<Control> GetControl(Control control, Type type) // Find all controls with TreeView type in main control ( mainForm )
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetControl(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
        }

        private void Reftreebranch(TreeView SelectedTreeView)
        {
            selectedNode = SelectedTreeView.SelectedNode.Text; // Seve name from the last selected node in branch

            if (SelectedTreeView.SelectedNode.Parent != null) // If the last selected node have parent node
            {
                SelectedTreeView.SelectedNode.Parent.Nodes.Clear(); // Clear all nodes in parent
            }
            else  // If the last selected node NOT have parent node
            {
                SelectedTreeView.Nodes.Clear(); // Clear selected TreeView
                allDrives.GetAllDrives(SelectedTreeView); // Get all drives
                SelectedTreeView.SelectedNode = SelectedTreeView.TopNode; // Select top node in selected TreeView
            }

            ShowDirectorys(SelectedTreeView); // Get all directorys in selected branch

            foreach (TreeNode node in SelectedTreeView.SelectedNode.Nodes) // Find the node with saved name in new branch
            {
                if (node.Text == selectedNode) // If the found node name is equivalent to the saved name
                {
                    SelectedTreeView.SelectedNode = node; // Select node only
                    break; // Exit from loop
                }
            }
        }
    }
}