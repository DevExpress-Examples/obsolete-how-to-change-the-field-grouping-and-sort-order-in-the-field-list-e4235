Imports Microsoft.VisualBasic
Imports System
Namespace Q236810
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.myPivotGridControl1 = New DXSample.MyPivotGridControl()
			CType(Me.myPivotGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' myPivotGridControl1
			' 
			Me.myPivotGridControl1.Cursor = System.Windows.Forms.Cursors.Default
			Me.myPivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.myPivotGridControl1.Location = New System.Drawing.Point(0, 0)
			Me.myPivotGridControl1.Name = "myPivotGridControl1"
			Me.myPivotGridControl1.OLAPConnectionString = "provider=MSOLAP;data source=http://demos.devexpress.com/Services/OLAP/msmdpump.dl" & "l;initial catalog=""Adventure Works DW Standard Edition"";cube name=""Adventure Wor" & "ks"""
			Me.myPivotGridControl1.OLAPDataProvider = DevExpress.XtraPivotGrid.OLAPDataProvider.Adomd
			Me.myPivotGridControl1.OptionsBehavior.UseAsyncMode = True
			Me.myPivotGridControl1.Size = New System.Drawing.Size(402, 273)
			Me.myPivotGridControl1.TabIndex = 0
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(402, 273)
			Me.Controls.Add(Me.myPivotGridControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
'			Me.Shown += New System.EventHandler(Me.Form1_Shown);
			CType(Me.myPivotGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private myPivotGridControl1 As DXSample.MyPivotGridControl


	End Class
End Namespace

