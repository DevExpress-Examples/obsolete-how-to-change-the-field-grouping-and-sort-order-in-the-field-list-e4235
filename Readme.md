# OBSOLETE: How to change the field grouping and sort order in the Field List


<p>Update: starting with version 16.1 it is possible to sort fields and folders using the <a href="https://documentation.devexpress.com/WindowsForms/DevExpressXtraPivotGridPivotGridControl_CustomCustomizationFormSorttopic.aspx">CustomCustomizationFormSort</a> event. <br><br>To accomplish this task, it is necessary to create a custom Customization Form descendant, and override the <strong>PivotCustomizationFieldsTree.AddNode</strong> method. To control node sort order, use the <strong>PivotCustomizationTreeNode.GroupPosition</strong> property. Automatic nodes return <strong>GroupPostion </strong>in interval [0..5]. It is necessary to return smaller or greater numbers to place nodes before or after default nodes.<br><br><br></p>

<br/>


