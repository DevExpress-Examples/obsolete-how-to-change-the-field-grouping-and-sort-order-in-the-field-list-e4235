using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Data;
using DevExpress.XtraPivotGrid.ViewInfo;
using DevExpress.XtraPivotGrid.Customization;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using DevExpress.XtraEditors.Customization;
using DevExpress.XtraPivotGrid.Customization.ViewInfo;

namespace DXSample {
    public class MyPivotGridControl : PivotGridControl {
        public MyPivotGridControl() : base() { }
        public MyPivotGridControl(PivotGridViewInfoData viewInfoData) : base(viewInfoData) { }

        protected override PivotGridViewInfoData CreateData() {
            return new MyPivotGridViewInfoData(this);
        }
    }

    public class MyPivotGridViewInfoData : PivotGridViewInfoData {
        public MyPivotGridViewInfoData() : base() { }
        public MyPivotGridViewInfoData(IViewInfoControl control) : base(control) { }

        public new bool ShowCustomizationTree { get { return OptionsView.GroupFieldsInCustomizationWindow; } }

        protected override CustomizationForm CreateCustomizationForm(CustomizationFormStyle style) {
            return new MyCustomizationForm(this, style);
        }
    }

    public class MyCustomizationForm : CustomizationForm
    {

        public MyCustomizationForm(PivotGridViewInfoData data, CustomizationFormStyle style)
            : base(data, style)
        {
        }


        protected override CustomizationListBoxBase CreateCustomizationListBox()
        {
            return new MyPivotCustomizationTreeBox(this);
        }
    }


    public class MyPivotCustomizationTreeBox : PivotCustomizationTreeBox
    {
        public MyPivotCustomizationTreeBox(CustomizationForm form)
            : base(form)
        {
        }
        protected override PivotCustomizationFieldsTreeBase CreateFieldsTree()
        {
            return new MyPivotCustomizationFieldsTree(CustomizationFields, Data);
        }
    }

    public class MyPivotCustomizationFieldsTree : PivotCustomizationFieldsTree
    {
        public MyPivotCustomizationFieldsTree(CustomizationFormFields fields, PivotGridData data)
            : base(fields, data) { }
        protected override void AddNode(PivotCustomizationTreeNodeBase node)
        {
            if (this.IsGrouping )
            {
                if (node.Caption.Contains("G"))
                {

                    PivotCustomizationTreeNodeBase letterNode = FindOrCreateLetterNode(node, this.Root); 
                    letterNode = FindOrCreateFolderPath(node.Field.DisplayFolder, letterNode);
                    letterNode.AddChild( node );
                }              
            
                else
                    base.AddNode(node);
            }
        }

        private  NodeType GetNodeType(PivotCustomizationTreeNodeBase node )
        {
            if (node.Field.FieldName.Split('.')[0] == "[Measures]")
                if (node.Field.KPIType == PivotKPIType.None)                                    
                     return NodeType.Measure;                
                else                
                     return NodeType.KPI;
            return NodeType.Dimention ;
                
        }
        private PivotCustomizationTreeNodeBase FindOrCreateLetterNode(PivotCustomizationTreeNodeBase currentNode, PivotCustomizationTreeNodeBase rootNode)
        {
            string nodeCaption = "Letter " + "G"; // currentNode.Caption[0];            
            NodeType nodeType = GetNodeType(currentNode);
            string nodeName = nodeCaption + "_" + nodeType;

            PivotCustomizationTreeNodeBase letterNode = rootNode.FindChild(nodeName, null);
            if (letterNode == null)
            {
                letterNode = new MyPivotCustomizationTreeNode(nodeName, nodeType, nodeCaption);
                rootNode.AddChild(letterNode);
            }
            return letterNode;

        }
    }

    public class MyPivotCustomizationTreeNode : PivotCustomizationTreeNodeDimension
    {
        public MyPivotCustomizationTreeNode(string name, NodeType type, string caption)
            : base(name, type == NodeType.Measure, type == NodeType.KPI, caption)
        {
        }

        public override int GroupPosition
        {
            get
            {
                return base.GroupPosition - 10;
            }
        }
        
    }

    public enum NodeType { Dimention, Measure, KPI }

 
}