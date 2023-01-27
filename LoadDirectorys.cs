using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PhotoTransfer
{
    class LoadDirectorys
    {
        bool existNode = false;
        string selectedNode = null;

        LoadAllDrives allDrives = new LoadAllDrives();
        DirectoryInfo info;

        public void ShowDirectorys(TreeView SelectedTreeView)
        {
            foreach (string directoryInfo in Directory.GetDirectories(SelectedTreeView.SelectedNode.FullPath, "*", SearchOption.TopDirectoryOnly))
            {
                info = new DirectoryInfo(directoryInfo);

                if ((info.Attributes & FileAttributes.System) == FileAttributes.System | (info.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    continue;
                }

                ExistNode(SelectedTreeView, Path.GetFileName(directoryInfo));

                if (existNode == false)
                {
                    SelectedTreeView.SelectedNode.Nodes.Add(Path.GetFileName(directoryInfo));
                }
            }
        }

        private bool ExistNode(TreeView ExistTreeView, string existDirectory)
        {
            foreach (TreeNode node in ExistTreeView.SelectedNode.Nodes)
            {
                if (node.Text == existDirectory)
                {
                    return existNode = true;
                }
            }
            return existNode = false;
        }


//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################
//########################################################################################################################################


        public void RefreshDirectorys(Control mainForm)
        {
            var AllTreeView = GetControl(mainForm, typeof(TreeView));

            foreach (TreeView Tree in AllTreeView)
            {
                Reftreebranch(Tree);
            }
        }

        private IEnumerable<Control> GetControl(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetControl(ctrl, type)).Concat(controls).Where(c => c.GetType() == type);
        }

        private void Reftreebranch(TreeView SelectedTreeView)
        {
            selectedNode = SelectedTreeView.SelectedNode.Text;

            if (SelectedTreeView.SelectedNode.Parent != null)
            {
                SelectedTreeView.SelectedNode.Parent.Nodes.Clear();
            }
            else
            {
                SelectedTreeView.Nodes.Clear();
                allDrives.GetAllDrives(SelectedTreeView);
                SelectedTreeView.SelectedNode = SelectedTreeView.TopNode;
            }

            ShowDirectorys(SelectedTreeView);

            foreach (TreeNode node in SelectedTreeView.SelectedNode.Nodes)
            {
                if (node.Text == selectedNode)
                {
                    SelectedTreeView.SelectedNode = node;
                    break;
                }
            }
        }
    }
}