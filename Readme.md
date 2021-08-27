<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/134061892/12.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4235)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Q236810/Form1.cs) (VB: [Form1.vb](./VB/Q236810/Form1.vb))
* [MyPivotGridControl.cs](./CS/Q236810/MyPivotGridControl.cs) (VB: [MyPivotGridControl.vb](./VB/Q236810/MyPivotGridControl.vb))
* [Program.cs](./CS/Q236810/Program.cs) (VB: [Program.vb](./VB/Q236810/Program.vb))
<!-- default file list end -->
# OBSOLETE: How to change the field grouping and sort order in the Field List
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4235)**
<!-- run online end -->


<p>Update: starting with version 16.1 it is possible to sort fields and folders using the <a href="https://documentation.devexpress.com/WindowsForms/DevExpressXtraPivotGridPivotGridControl_CustomCustomizationFormSorttopic.aspx">CustomCustomizationFormSort</a> event. <br><br>To accomplish this task, it is necessary to create a custom Customization Form descendant, and override the <strong>PivotCustomizationFieldsTree.AddNode</strong> method. To control node sort order, use the <strong>PivotCustomizationTreeNode.GroupPosition</strong> property. Automatic nodes return <strong>GroupPostion </strong>in interval [0..5]. It is necessary to return smaller or greater numbers to place nodes before or after default nodes.<br><br><br></p>

<br/>


