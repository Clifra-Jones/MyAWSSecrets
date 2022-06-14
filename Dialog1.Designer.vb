<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NoProfileDialog
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NoProfileDialog))
		Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
		Me.OK_Button = New System.Windows.Forms.Button()
		Me.Cancel_Button = New System.Windows.Forms.Button()
		Me.TextBox1 = New System.Windows.Forms.TextBox()
		Me.TableLayoutPanel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'TableLayoutPanel1
		'
		Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.TableLayoutPanel1.ColumnCount = 2
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
		Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
		Me.TableLayoutPanel1.Location = New System.Drawing.Point(257, 193)
		Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
		Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
		Me.TableLayoutPanel1.RowCount = 1
		Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
		Me.TableLayoutPanel1.Size = New System.Drawing.Size(170, 33)
		Me.TableLayoutPanel1.TabIndex = 0
		'
		'OK_Button
		'
		Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.OK_Button.Location = New System.Drawing.Point(4, 3)
		Me.OK_Button.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
		Me.OK_Button.Name = "OK_Button"
		Me.OK_Button.Size = New System.Drawing.Size(77, 27)
		Me.OK_Button.TabIndex = 0
		Me.OK_Button.Text = "OK"
		'
		'Cancel_Button
		'
		Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
		Me.Cancel_Button.Location = New System.Drawing.Point(89, 3)
		Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
		Me.Cancel_Button.Name = "Cancel_Button"
		Me.Cancel_Button.Size = New System.Drawing.Size(77, 27)
		Me.Cancel_Button.TabIndex = 1
		Me.Cancel_Button.Text = "Cancel"
		'
		'TextBox1
		'
		Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.TextBox1.Location = New System.Drawing.Point(12, 12)
		Me.TextBox1.Multiline = True
		Me.TextBox1.Name = "TextBox1"
		Me.TextBox1.ReadOnly = True
		Me.TextBox1.Size = New System.Drawing.Size(417, 162)
		Me.TextBox1.TabIndex = 1
		Me.TextBox1.Text = resources.GetString("TextBox1.Text")
		'
		'NoProfileDialog
		'
		Me.AcceptButton = Me.OK_Button
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel_Button
		Me.ClientSize = New System.Drawing.Size(441, 240)
		Me.Controls.Add(Me.TextBox1)
		Me.Controls.Add(Me.TableLayoutPanel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "NoProfileDialog"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Warning: No Profiles Found"
		Me.TableLayoutPanel1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents TextBox1 As TextBox
End Class
