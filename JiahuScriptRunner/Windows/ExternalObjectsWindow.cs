using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace JiahuScriptRunner.Windows
{
    public partial class ExternalObjectsWindow : Form
    {
        private const string SystemNamespaceName = "System";
        private const int ColumnWidthOffset = 30;
        private const string ObjectTag = "Object";
        private const string ImageListObject = "Object";
        private const string ImageListMethod = "Method";
        private const string ImageListProperty = "Property";

        private readonly IList<object> _externalObject;

        public ExternalObjectsWindow(IList<object> externalObject)
        {
            _externalObject = externalObject;
            InitializeComponent();

            PopulateObjectView();
            SelectDefaultFunction();
        }

        private void SelectDefaultFunction()
        {
            if (lvExternalObjects.Items.Count > 0)
            {
                lvExternalObjects.Select();
                lvExternalObjects.Items[0].Selected = true;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PopulateObjectView()
        {
            lvExternalObjects.Columns.Add(new ColumnHeader { Text = ObjectTag, Width = lvExternalObjects.Width - ColumnWidthOffset });

            foreach (object externalObject in _externalObject)
            {
                lvExternalObjects.Items.Add(new ListViewItem(externalObject.GetType().Name) { Tag = externalObject });
            }
        }

        private void ListViewExternalObjectSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvExternalObjects.SelectedItems.Count > 0)
            {
                ConstructTreeview(lvExternalObjects.SelectedItems[0].Tag);
            }
        }

        private void ConstructTreeview(object item)
        {
            treeObjectView.Nodes.Clear();
            TreeNode node = treeObjectView.Nodes.Add(item.GetType().Name, item.GetType().Name, ImageListObject);
            node.SelectedImageKey = ImageListObject;

            GetObjectProperties(item, node);

            node.Expand();
        }

        private void GetObjectProperties(object item, TreeNode treeNode)
        {
            foreach (PropertyInfo propertyInfo in item.GetType().GetProperties())
            {
                TreeNode propertyNode = treeNode.Nodes.Add(propertyInfo.Name, propertyInfo.Name, ImageListProperty);
                propertyNode.SelectedImageKey = ImageListProperty;
                propertyNode.Tag = propertyInfo.GetValue(item);

                if (propertyInfo.PropertyType.IsArray && !IsBaseType(propertyInfo.PropertyType))
                {
                    Array typedArray = propertyNode.Tag as Array;
                    if (typedArray != null)
                    {
                        foreach (object arrayItem in typedArray)
                        {
                            TreeNode subNode = propertyNode.Nodes.Add(arrayItem.GetHashCode().ToString(), arrayItem.GetType().Name, ImageListObject);
                            subNode.SelectedImageKey = ImageListObject;

                            GetObjectProperties(arrayItem, subNode);
                        }
                    }
                }
                else if (!IsBaseType(propertyInfo.PropertyType))
                {
                    GetObjectProperties(propertyNode.Tag, propertyNode);
                }
            }

            foreach (MethodInfo methodInfo in item.GetType().GetMethods().Where(x => x.MemberType == MemberTypes.Method))
            {
                if (methodInfo.GetBaseDefinition().DeclaringType != typeof (object) && !methodInfo.IsSpecialName)
                {
                    TreeNode propertyNode = treeNode.Nodes.Add(methodInfo.Name, methodInfo.Name + "()", ImageListMethod);
                    propertyNode.SelectedImageKey = ImageListMethod;

                    propertyNode.Tag = methodInfo.ReturnType;
                }
            }
        }

        private bool IsBaseType(Type type)
        {
            return type.Namespace == SystemNamespaceName;
        }

        private void treeObjectView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lvDataView.Items.Clear();
            treeObjectView.SelectedImageIndex = e.Node.ImageIndex;
            
            if (e.Node.Tag != null)
            {
                if (e.Node.Tag.GetType().IsArray)
                {
                    Array typedArray = e.Node.Tag as Array;
                    if (typedArray != null)
                    {
                        foreach (object item in typedArray)
                        {
                            ListViewItem lvItem = lvDataView.Items.Add(item.GetType().Name);

                            if (IsBaseType(e.Node.Tag.GetType()))
                            {
                                lvItem.SubItems.Add(item.ToString());
                            }
                        }
                    }
                    return;
                }

                if (e.Node.Tag.GetType() == typeof(Type))
                {
                    Type type = (Type)e.Node.Tag;
                    ListViewItem lvItem = lvDataView.Items.Add("Return Type");
                    lvItem.SubItems.Add(type.Name);
                    return;
                }

                if (IsBaseType(e.Node.Tag.GetType()))
                {
                    ListViewItem lvItem = lvDataView.Items.Add(e.Node.Tag.GetType().Name);
                    lvItem.SubItems.Add(e.Node.Tag.ToString());
                }
            }
        }
    }
}