<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
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
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
		Me.ProfilesComboBox = New System.Windows.Forms.ComboBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.SecretsIDTextBox = New System.Windows.Forms.TextBox()
		Me.RetrieveSecretButton = New System.Windows.Forms.Button()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.AccessKeyIDTextBox = New System.Windows.Forms.TextBox()
		Me.SecretAccessKeyTextBox = New System.Windows.Forms.TextBox()
		Me.CloseButton = New System.Windows.Forms.Button()
		Me.UpdateLocalProfileButton = New System.Windows.Forms.Button()
		Me.NewLocalProfileButton = New System.Windows.Forms.Button()
		Me.AccessKeyIdCopyButton = New System.Windows.Forms.Button()
		Me.SecretKeyCopyButton = New System.Windows.Forms.Button()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.SuspendLayout()
		'
		'ProfilesComboBox
		'
		Me.ProfilesComboBox.FormattingEnabled = True
		Me.ProfilesComboBox.Location = New System.Drawing.Point(109, 21)
		Me.ProfilesComboBox.Name = "ProfilesComboBox"
		Me.ProfilesComboBox.Size = New System.Drawing.Size(179, 23)
		Me.ProfilesComboBox.TabIndex = 1
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
		Me.Label1.Location = New System.Drawing.Point(20, 24)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(83, 15)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Local Profiles:"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
		Me.Label3.Location = New System.Drawing.Point(40, 67)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(63, 15)
		Me.Label3.TabIndex = 3
		Me.Label3.Text = "Secret ID:"
		'
		'SecretsIDTextBox
		'
		Me.SecretsIDTextBox.Location = New System.Drawing.Point(109, 64)
		Me.SecretsIDTextBox.Name = "SecretsIDTextBox"
		Me.SecretsIDTextBox.ReadOnly = True
		Me.SecretsIDTextBox.Size = New System.Drawing.Size(368, 23)
		Me.SecretsIDTextBox.TabIndex = 4
		'
		'RetrieveSecretButton
		'
		Me.RetrieveSecretButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
		Me.RetrieveSecretButton.Location = New System.Drawing.Point(20, 115)
		Me.RetrieveSecretButton.Name = "RetrieveSecretButton"
		Me.RetrieveSecretButton.Size = New System.Drawing.Size(114, 23)
		Me.RetrieveSecretButton.TabIndex = 5
		Me.RetrieveSecretButton.Text = "Retrieve Secret"
		Me.RetrieveSecretButton.UseVisualStyleBackColor = True
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
		Me.Label4.Location = New System.Drawing.Point(43, 157)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(87, 15)
		Me.Label4.TabIndex = 6
		Me.Label4.Text = "Access Key ID:"
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
		Me.Label5.Location = New System.Drawing.Point(19, 187)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(111, 15)
		Me.Label5.TabIndex = 7
		Me.Label5.Text = "Secret Access Key:"
		'
		'AccessKeyIDTextBox
		'
		Me.AccessKeyIDTextBox.Location = New System.Drawing.Point(136, 154)
		Me.AccessKeyIDTextBox.Name = "AccessKeyIDTextBox"
		Me.AccessKeyIDTextBox.ReadOnly = True
		Me.AccessKeyIDTextBox.Size = New System.Drawing.Size(254, 23)
		Me.AccessKeyIDTextBox.TabIndex = 8
		'
		'SecretAccessKeyTextBox
		'
		Me.SecretAccessKeyTextBox.Location = New System.Drawing.Point(136, 184)
		Me.SecretAccessKeyTextBox.Name = "SecretAccessKeyTextBox"
		Me.SecretAccessKeyTextBox.ReadOnly = True
		Me.SecretAccessKeyTextBox.Size = New System.Drawing.Size(485, 23)
		Me.SecretAccessKeyTextBox.TabIndex = 9
		'
		'CloseButton
		'
		Me.CloseButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
		Me.CloseButton.Location = New System.Drawing.Point(636, 266)
		Me.CloseButton.Name = "CloseButton"
		Me.CloseButton.Size = New System.Drawing.Size(75, 23)
		Me.CloseButton.TabIndex = 14
		Me.CloseButton.Text = "Close"
		Me.CloseButton.UseVisualStyleBackColor = True
		'
		'UpdateLocalProfileButton
		'
		Me.UpdateLocalProfileButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
		Me.UpdateLocalProfileButton.Location = New System.Drawing.Point(20, 247)
		Me.UpdateLocalProfileButton.Name = "UpdateLocalProfileButton"
		Me.UpdateLocalProfileButton.Size = New System.Drawing.Size(143, 23)
		Me.UpdateLocalProfileButton.TabIndex = 10
		Me.UpdateLocalProfileButton.Text = "Update Local Profile"
		Me.UpdateLocalProfileButton.UseVisualStyleBackColor = True
		'
		'NewLocalProfileButton
		'
		Me.NewLocalProfileButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
		Me.NewLocalProfileButton.Location = New System.Drawing.Point(298, 22)
		Me.NewLocalProfileButton.Name = "NewLocalProfileButton"
		Me.NewLocalProfileButton.Size = New System.Drawing.Size(119, 23)
		Me.NewLocalProfileButton.TabIndex = 15
		Me.NewLocalProfileButton.Text = "New Local Profile"
		Me.NewLocalProfileButton.UseVisualStyleBackColor = True
		'
		'AccessKeyIdCopyButton
		'
		Me.AccessKeyIdCopyButton.AutoSize = True
		Me.AccessKeyIdCopyButton.BackColor = System.Drawing.Color.Transparent
		Me.AccessKeyIdCopyButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
		Me.AccessKeyIdCopyButton.FlatAppearance.BorderSize = 0
		Me.AccessKeyIdCopyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.AccessKeyIdCopyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.AccessKeyIdCopyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.AccessKeyIdCopyButton.Image = Global.MyAWSSecrets.My.Resources.Resources.copy_small
		Me.AccessKeyIdCopyButton.Location = New System.Drawing.Point(396, 152)
		Me.AccessKeyIdCopyButton.Name = "AccessKeyIdCopyButton"
		Me.AccessKeyIdCopyButton.Size = New System.Drawing.Size(21, 25)
		Me.AccessKeyIdCopyButton.TabIndex = 16
		Me.ToolTip1.SetToolTip(Me.AccessKeyIdCopyButton, "Copy to Clipboard")
		Me.AccessKeyIdCopyButton.UseVisualStyleBackColor = False
		'
		'SecretKeyCopyButton
		'
		Me.SecretKeyCopyButton.FlatAppearance.BorderSize = 0
		Me.SecretKeyCopyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
		Me.SecretKeyCopyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
		Me.SecretKeyCopyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.SecretKeyCopyButton.Image = Global.MyAWSSecrets.My.Resources.Resources.copy_small
		Me.SecretKeyCopyButton.Location = New System.Drawing.Point(627, 183)
		Me.SecretKeyCopyButton.Name = "SecretKeyCopyButton"
		Me.SecretKeyCopyButton.Size = New System.Drawing.Size(22, 23)
		Me.SecretKeyCopyButton.TabIndex = 17
		Me.ToolTip1.SetToolTip(Me.SecretKeyCopyButton, "Copy to Clipboard")
		Me.SecretKeyCopyButton.UseVisualStyleBackColor = True
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(723, 301)
		Me.Controls.Add(Me.SecretKeyCopyButton)
		Me.Controls.Add(Me.AccessKeyIdCopyButton)
		Me.Controls.Add(Me.NewLocalProfileButton)
		Me.Controls.Add(Me.CloseButton)
		Me.Controls.Add(Me.UpdateLocalProfileButton)
		Me.Controls.Add(Me.SecretAccessKeyTextBox)
		Me.Controls.Add(Me.AccessKeyIDTextBox)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.RetrieveSecretButton)
		Me.Controls.Add(Me.SecretsIDTextBox)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.ProfilesComboBox)
		Me.Controls.Add(Me.Label1)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "Form1"
		Me.Text = "My AWS Secrets"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents ProfilesComboBox As ComboBox
	Friend WithEvents Label1 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents SecretsIDTextBox As TextBox
	Friend WithEvents RetrieveSecretButton As Button
	Friend WithEvents Label4 As Label
	Friend WithEvents Label5 As Label
	Friend WithEvents AccessKeyIDTextBox As TextBox
	Friend WithEvents SecretAccessKeyTextBox As TextBox
	Friend WithEvents CloseButton As Button
	Friend WithEvents UpdateLocalProfileButton As Button
	Friend WithEvents NewLocalProfileButton As Button
	Friend WithEvents AccessKeyIdCopyButton As Button
	Friend WithEvents SecretKeyCopyButton As Button
	Friend WithEvents ToolTip1 As ToolTip
End Class
