Imports Microsoft.VisualBasic
Imports DevExpress.XtraPivotGrid
Imports DevExpress.XtraPivotGrid.Data
Imports DevExpress.XtraPivotGrid.ViewInfo
Imports DevExpress.XtraPivotGrid.Customization
Imports System.Collections.Generic
Imports System.Collections
Imports System.Reflection
Imports DevExpress.XtraEditors.Customization
Imports DevExpress.XtraPivotGrid.Customization.ViewInfo

Namespace DXSample
	Public Class MyPivotGridControl
		Inherits PivotGridControl
		Public Sub New()
			MyBase.New()
		End Sub
		Public Sub New(ByVal viewInfoData As PivotGridViewInfoData)
			MyBase.New(viewInfoData)
		End Sub

		Protected Overrides Function CreateData() As PivotGridViewInfoData
			Return New MyPivotGridViewInfoData(Me)
		End Function
	End Class

	Public Class MyPivotGridViewInfoData
		Inherits PivotGridViewInfoData
		Public Sub New()
			MyBase.New()
		End Sub
		Public Sub New(ByVal control As IViewInfoControl)
			MyBase.New(control)
		End Sub

		Public Shadows ReadOnly Property ShowCustomizationTree() As Boolean
			Get
				Return OptionsView.GroupFieldsInCustomizationWindow
			End Get
		End Property

		Protected Overrides Function CreateCustomizationForm(ByVal style As CustomizationFormStyle) As CustomizationForm
			Return New MyCustomizationForm(Me, style)
		End Function
	End Class

	Public Class MyCustomizationForm
		Inherits CustomizationForm

		Public Sub New(ByVal data As PivotGridViewInfoData, ByVal style As CustomizationFormStyle)
			MyBase.New(data, style)
		End Sub


		Protected Overrides Function CreateCustomizationListBox() As CustomizationListBoxBase
			Return New MyPivotCustomizationTreeBox(Me)
		End Function
	End Class


	Public Class MyPivotCustomizationTreeBox
		Inherits PivotCustomizationTreeBox
		Public Sub New(ByVal form As CustomizationForm)
			MyBase.New(form)
		End Sub
		Protected Overrides Function CreateFieldsTree() As PivotCustomizationFieldsTreeBase
			Return New MyPivotCustomizationFieldsTree(CustomizationFields, Data)
		End Function
	End Class

	Public Class MyPivotCustomizationFieldsTree
		Inherits PivotCustomizationFieldsTree
		Public Sub New(ByVal fields As CustomizationFormFields, ByVal data As PivotGridData)
			MyBase.New(fields, data)
		End Sub
		Protected Overrides Sub AddNode(ByVal node As PivotCustomizationTreeNodeBase)
			If Me.IsGrouping Then
				If node.Caption.Contains("G") Then

					Dim letterNode As PivotCustomizationTreeNodeBase = FindOrCreateLetterNode(node, Me.Root)
					letterNode = FindOrCreateFolderPath(node.Field.DisplayFolder, letterNode)
					letterNode.AddChild(node)

				Else
					MyBase.AddNode(node)
				End If
			End If
		End Sub

		Private Function GetNodeType(ByVal node As PivotCustomizationTreeNodeBase) As NodeType
			If node.Field.FieldName.Split("."c)(0) = "[Measures]" Then
				If node.Field.KPIType = PivotKPIType.None Then
					 Return NodeType.Measure
				Else
					 Return NodeType.KPI
				End If
			End If
			Return NodeType.Dimention

		End Function
		Private Function FindOrCreateLetterNode(ByVal currentNode As PivotCustomizationTreeNodeBase, ByVal rootNode As PivotCustomizationTreeNodeBase) As PivotCustomizationTreeNodeBase
			Dim nodeCaption As String = "Letter " & "G" ' currentNode.Caption[0];
			Dim nodeType As NodeType = GetNodeType(currentNode)
			Dim nodeName As String = nodeCaption & "_" & nodeType

			Dim letterNode As PivotCustomizationTreeNodeBase = rootNode.FindChild(nodeName, Nothing)
			If letterNode Is Nothing Then
				letterNode = New MyPivotCustomizationTreeNode(nodeName, nodeType, nodeCaption)
				rootNode.AddChild(letterNode)
			End If
			Return letterNode

		End Function
	End Class

	Public Class MyPivotCustomizationTreeNode
		Inherits PivotCustomizationTreeNodeDimension
		Public Sub New(ByVal name As String, ByVal type As NodeType, ByVal caption As String)
			MyBase.New(name, type = NodeType.Measure, type = NodeType.KPI, caption)
		End Sub

		Public Overrides ReadOnly Property GroupPosition() As Integer
			Get
				Return MyBase.GroupPosition - 10
			End Get
		End Property

	End Class

	Public Enum NodeType
		Dimention
		Measure
		KPI
	End Enum


End Namespace