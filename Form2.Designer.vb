<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewProfileForm
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
		Me.components = New System.ComponentModel.Container()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.ProfileNameTextBox = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.RegionComboBox = New System.Windows.Forms.ComboBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.AccessKeyIDTextBox = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.SecretAccessKeyTextBox = New System.Windows.Forms.TextBox()
		Me.OKButton = New System.Windows.Forms.Button()
		Me.Cancel = New System.Windows.Forms.Button()
		Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
		CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
		Me.Label1.Location = New System.Drawing.Point(35, 14)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(83, 15)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Profile Name:"
		'
		'ProfileNameTextBox
		'
		Me.ProfileNameTextBox.Location = New System.Drawing.Point(124, 11)
		Me.ProfileNameTextBox.Name = "ProfileNameTextBox"
		Me.ProfileNameTextBox.Size = New System.Drawing.Size(221, 23)
		Me.ProfileNameTextBox.TabIndex = 1
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
		Me.Label2.Location = New System.Drawing.Point(69, 50)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(49, 15)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "Region:"
		'
		'RegionComboBox
		'
		Me.RegionComboBox.DisplayMember = "DisplayName"
		Me.RegionComboBox.FormattingEnabled = True
		Me.RegionComboBox.Location = New System.Drawing.Point(124, 47)
		Me.RegionComboBox.Name = "RegionComboBox"
		Me.RegionComboBox.Size = New System.Drawing.Size(134, 23)
		Me.RegionComboBox.TabIndex = 3
		Me.RegionComboBox.ValueMember = "SystemName"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
		Me.Label3.Location = New System.Drawing.Point(31, 86)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(87, 15)
		Me.Label3.TabIndex = 4
		Me.Label3.Text = "Access Key ID:"
		'
		'AccessKeyIDTextBox
		'
		Me.AccessKeyIDTextBox.Location = New System.Drawing.Point(124, 83)
		Me.AccessKeyIDTextBox.Name = "AccessKeyIDTextBox"
		Me.AccessKeyIDTextBox.Size = New System.Drawing.Size(201, 23)
		Me.AccessKeyIDTextBox.TabIndex = 5
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
		Me.Label4.Location = New System.Drawing.Point(7, 121)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(111, 15)
		Me.Label4.TabIndex = 6
		Me.Label4.Text = "Secret Access Key:"
		'
		'SecretAccessKeyTextBox
		'
		Me.SecretAccessKeyTextBox.Location = New System.Drawing.Point(124, 118)
		Me.SecretAccessKeyTextBox.Name = "SecretAccessKeyTextBox"
		Me.SecretAccessKeyTextBox.Size = New System.Drawing.Size(354, 23)
		Me.SecretAccessKeyTextBox.TabIndex = 7
		'
		'OKButton
		'
		Me.OKButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
		Me.OKButton.Location = New System.Drawing.Point(451, 173)
		Me.OKButton.Name = "OKButton"
		Me.OKButton.Size = New System.Drawing.Size(75, 23)
		Me.OKButton.TabIndex = 8
		Me.OKButton.Text = "OK"
		Me.OKButton.UseVisualStyleBackColor = True
		'
		'Cancel
		'
		Me.Cancel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
		Me.Cancel.Location = New System.Drawing.Point(370, 173)
		Me.Cancel.Name = "Cancel"
		Me.Cancel.Size = New System.Drawing.Size(75, 23)
		Me.Cancel.TabIndex = 9
		Me.Cancel.Text = "Cancel"
		Me.Cancel.UseVisualStyleBackColor = True
		'
		'ErrorProvider1
		'
		Me.ErrorProvider1.ContainerControl = Me
		'
		'NewProfileForm
		'
		Me.AcceptButton = Me.OKButton
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.Cancel
		Me.ClientSize = New System.Drawing.Size(538, 208)
		Me.Controls.Add(Me.Cancel)
		Me.Controls.Add(Me.OKButton)
		Me.Controls.Add(Me.SecretAccessKeyTextBox)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.AccessKeyIDTextBox)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.RegionComboBox)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.ProfileNameTextBox)
		Me.Controls.Add(Me.Label1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.Name = "NewProfileForm"
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "New Local Profile"
		CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents Label1 As Label
	Friend WithEvents ProfileNameTextBox As TextBox
	Friend WithEvents Label2 As Label
	Friend WithEvents RegionComboBox As ComboBox
	Friend WithEvents Label3 As Label
	Friend WithEvents AccessKeyIDTextBox As TextBox
	Friend WithEvents Label4 As Label
	Friend WithEvents SecretAccessKeyTextBox As TextBox
	Friend WithEvents OKButton As Button
	Friend WithEvents Cancel As Button
	Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
