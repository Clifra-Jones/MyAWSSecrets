Imports Amazon
Imports Amazon.SecretsManager
Imports Amazon.SecretsManager.Model
Imports Amazon.Runtime
Imports Amazon.Runtime.CredentialManagement
Imports Amazon.RegionEndpoint
Imports System.ComponentModel

Public Class NewProfileForm
	Private Class AWS_Region
		Private _code As String
		Private _name As String

		Public Property Code As String
			Get
				Return _code
			End Get
			Set(value As String)
				_code = value
			End Set
		End Property

		Public Property Name As String
			Get
				Return _name
			End Get
			Set(value As String)
				_name = value
			End Set
		End Property

		Public Sub New(Code, Name)
			Me.Code = Code
			Me.Name = Name
		End Sub
	End Class

	Public Sub New(Optional DefaultProfile As Boolean = False)

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		With RegionComboBox
			.Items.Add(RegionEndpoint.GetBySystemName("us-east-1"))
			.Items.Add(RegionEndpoint.GetBySystemName("us-east-2"))
			.Items.Add(RegionEndpoint.GetBySystemName("us-west-1"))
			.Items.Add(RegionEndpoint.GetBySystemName("us-west-2"))
		End With

		If DefaultProfile = True Then
			ProfileNameTextBox.Text = "default"
			ProfileNameTextBox.Enabled = False
		End If

	End Sub

	Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
		If ValidateChildren() Then
			Dim profileName As String = ProfileNameTextBox.Text

			Dim sharedFile As New SharedCredentialsFile()
			Dim options = New CredentialProfileOptions With {
			.AccessKey = AccessKeyIDTextBox.Text,
			.SecretKey = SecretAccessKeyTextBox.Text
		}
			Dim profile As New CredentialProfile(profileName, options) With {
			.Region = RegionComboBox.Items(RegionComboBox.SelectedIndex)
		}

			sharedFile.RegisterProfile(profile)
			Me.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.Close()
		End If

	End Sub

	Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
		Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
	End Sub

	Private Sub ProfileNameTextBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ProfileNameTextBox.Validating
		If String.IsNullOrWhiteSpace(ProfileNameTextBox.Text) Then
			e.Cancel = True
			ProfileNameTextBox.Select()
			ErrorProvider1.SetError(ProfileNameTextBox, "Profile Name cannot be blank!")
		Else
			e.Cancel = False
			ErrorProvider1.SetError(ProfileNameTextBox, "")
		End If
	End Sub

	Private Sub RegionComboBox_Validating(sender As Object, e As CancelEventArgs) Handles RegionComboBox.Validating
		If RegionComboBox.SelectedIndex = -1 Then
			e.Cancel = True
			RegionComboBox.Select()
			ErrorProvider1.SetError(RegionComboBox, "You must select a region!")
		Else
			e.Cancel = False
			ErrorProvider1.SetError(RegionComboBox, "")
		End If
	End Sub

	Private Sub AccessKeyIDTextBox_Validating(sender As Object, e As CancelEventArgs) Handles AccessKeyIDTextBox.Validating
		If String.IsNullOrWhiteSpace(AccessKeyIDTextBox.Text) Then
			e.Cancel = True
			AccessKeyIDTextBox.Select()
			ErrorProvider1.SetError(AccessKeyIDTextBox, "Access Key ID is required!")
		Else
			e.Cancel = False
			ErrorProvider1.SetError(AccessKeyIDTextBox, "")
		End If
	End Sub

	Private Sub SecretAccessKeyTextBox_Validating(sender As Object, e As CancelEventArgs) Handles SecretAccessKeyTextBox.Validating
		If String.IsNullOrEmpty(SecretAccessKeyTextBox.Text) Then
			e.Cancel = False
			SecretAccessKeyTextBox.Select()
			ErrorProvider1.SetError(SecretAccessKeyTextBox, "Secret Access Key is required!")
		Else
			e.Cancel = False
			ErrorProvider1.SetError(SecretAccessKeyTextBox, "")
		End If
	End Sub
End Class