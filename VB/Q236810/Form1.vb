Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPivotGrid

Namespace Q236810
	Partial Public Class Form1
		Inherits XtraForm
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

		End Sub

		Private Sub Form1_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
			myPivotGridControl1.RetrieveFieldsAsync(PivotArea.FilterArea, False, Function() AnonymousMethod1())
		End Sub
		
		Private Function AnonymousMethod1() As Boolean
			myPivotGridControl1.FieldsCustomization()
			Return True
		End Function
	End Class
End Namespace