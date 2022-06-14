Imports Amazon
Imports Amazon.SecretsManager
Imports Amazon.SecretsManager.Model
Imports Amazon.Runtime
Imports Amazon.Runtime.CredentialManagement
Imports Amazon.IdentityManagement
Imports Amazon.IdentityManagement.Model
Imports System.Security.Principal
Imports Amazon.SecurityToken
Imports Amazon.SecurityToken.Model
Imports System.Text.Json
Imports System.ComponentModel

Public Class Form1
	Private SecretsArnString As String = "arn:aws:secretsmanager:us-east-1:268928949034:{0}"

	Private Class AccessKey
		Private _AccessKeyID As String
		Private _SecretAccessKey As String

		Public Property AccessKeyID() As String
			Get
				Return _AccessKeyID
			End Get
			Set(value As String)
				_AccessKeyID = value
			End Set
		End Property

		Public Property SecretAccessKey() As String
			Get
				Return _SecretAccessKey
			End Get
			Set(value As String)
				_SecretAccessKey = value
			End Set
		End Property

		Public Sub New(ByVal AccessKeyID As String, SecretAccessKey As String)
			Me.AccessKeyID = AccessKeyID
			Me.SecretAccessKey = SecretAccessKey
		End Sub

	End Class

	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Me.Text = "My Secrets"

		'Dim Identity As System.Security.Principal.WindowsIdentity
		'Identity = System.Security.Principal.WindowsIdentity.GetCurrent()
		'Dim Parts As String() = Identity.Name.Split("\")
		'Dim Domain As String = Parts(0)
		'Dim LogonName As String = Parts(1)
		'If Domain = "bbcgrp.local" Then
		'	UserName = LogonName + "@bbcgrp.local"
		'Else
		'	UserName = LogonName + "@balfourbeattyus.com"
		'End If


		If LoadProfileComboBox() = False Then
			Dim noProfileDialog As New NoProfileDialog
			If noProfileDialog.ShowDialog() = DialogResult.OK Then
				Dim newProfileForm As New NewProfileForm(True)
				If newProfileForm.ShowDialog() = DialogResult.OK Then
					If LoadProfileComboBox() = False Then
						Throw New System.Exception("An error occured saving the profile. Please report this to Cliff Williams cwilliams@balfourbeattyus.com")
					End If
				Else
					Me.Close()
				End If

			End If
		End If

		'If Profiles.Contains("default") Then
		'	SecretsIDTextBox.Text = UserName
		'End If
	End Sub

	Private Sub ProfilesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProfilesComboBox.SelectedIndexChanged
		Dim profileName As String = ProfilesComboBox.Items(ProfilesComboBox.SelectedIndex)

		AccessKeyIdCopyButton.Enabled = False
		SecretKeyCopyButton.Enabled = False

		'Environment.SetEnvironmentVariable("AWS_PROFILE", value)
		Dim chain As New CredentialProfileStoreChain()
		Dim Creds As BasicAWSCredentials = Nothing
		If chain.TryGetAWSCredentials(profileName, Creds) Then
			Dim iamClient = New AmazonIdentityManagementServiceClient(Creds)
			Dim Task As Task(Of GetUserResponse)
			Try
				Task = iamClient.GetUserAsync()
			Catch ex As Exception
				MsgBox("An error occerred. This is most likely because the AccessKeys in your local file are inactive (expired).")
				Return
			End Try
			Dim responseUser As GetUserResponse
			responseUser = Task.Result
			Dim IamUser As User = responseUser.User
			Dim Tags As List(Of IdentityManagement.Model.Tag) = IamUser.Tags
			Dim secretName As String
			Try
				secretName = Tags.Find(Function(t) t.Key = "SecretName").Value
			Catch ex As Exception
				MsgBox("Secret Name not found in your IAM account. Please report this to your AWS Global Administrator.")
				Return
			End Try
			SecretsIDTextBox.Text = secretName
		End If

	End Sub

	Private Sub RetrieveSecretButton_Click(sender As Object, e As EventArgs) Handles RetrieveSecretButton.Click
		Dim Region As String = "us-east-1"
		Dim SecretJSON As String
		'Dim AccessKeyID As String
		'Dim SecretKey As String

		Dim SecretId As String = SecretsIDTextBox.Text
		Dim secretARN As String = String.Format(SecretsArnString, SecretId)
		Dim Client As New AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(Region))
		Dim request As New GetSecretValueRequest With {
			.SecretId = SecretId
		}

		Dim response As GetSecretValueResponse

		Try
			response = Client.GetSecretValueAsync(request).Result

		Catch ex As DecryptionFailureException
			Throw
		Catch ex As InternalServiceErrorException
			Throw
		Catch ex As InvalidRequestException
			Throw
		Catch ex As InvalidParameterException
			Throw
		Catch ex As ResourceNotFoundException
			Throw
		Catch ex As System.AggregateException
			Throw
		End Try

		If response.SecretString IsNot Nothing Then
			SecretJSON = response.SecretString

			Dim MyAccessKeys As AccessKey = JsonSerializer.Deserialize(Of AccessKey)(SecretJSON)

			AccessKeyIDTextBox.Text = MyAccessKeys.AccessKeyID
			SecretAccessKeyTextBox.Text = MyAccessKeys.SecretAccessKey

			AccessKeyIdCopyButton.Enabled = True
			SecretKeyCopyButton.Enabled = True

		End If

	End Sub

	Private Shared Function GetLocalProfiles() As List(Of String)
		'Dim chain As New CredentialProfileStoreChain()
		'Dim credentialProfiles As New List(Of CredentialProfile)
		'credentialProfiles = chain.ListProfiles()
		Dim Names As New List(Of String)

		Dim sharedFile = New SharedCredentialsFile()
		Dim profiles = sharedFile.ListProfileNames()


		For Each profile In profiles
			Names.Add(profile)
		Next

		Return Names

	End Function

	Private Shared Function Get_AccountID(AccessKeyID As String, SecretAccessKey As String) As String
		Dim basicAWSCredentials = New BasicAWSCredentials(AccessKeyID, SecretAccessKey)
		Dim stsClient = New AmazonSecurityTokenServiceClient(basicAWSCredentials)
		Dim task As Task(Of GetCallerIdentityResponse) = stsClient.GetCallerIdentityAsync(New GetCallerIdentityRequest())
		Dim response As GetCallerIdentityResponse = task.Result
		Return response.Account
	End Function

	Private Sub UpdateLocalProfileButton_Click(sender As Object, e As EventArgs) Handles UpdateLocalProfileButton.Click
		Dim profileName As String = ProfilesComboBox.Items(ProfilesComboBox.SelectedIndex)
		Dim sharedFile = New SharedCredentialsFile()
		Dim profile As CredentialProfile = Nothing
		If sharedFile.TryGetProfile(profileName, profile) Then
			With profile.Options
				.AccessKey = AccessKeyIDTextBox.Text
				.SecretKey = SecretAccessKeyTextBox.Text
			End With
			sharedFile.RegisterProfile(profile)
		End If

	End Sub

	Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
		Me.Close()
	End Sub

	Private Sub NewLocalProfileButton_Click(sender As Object, e As EventArgs) Handles NewLocalProfileButton.Click
		Dim newProfileForm As New NewProfileForm
		If newProfileForm.ShowDialog() = DialogResult.OK Then
			If LoadProfileComboBox() = False Then
				Throw New System.Exception("An error occured saving the profile, please report this to Cliff Williams, cwilliams@balfourbeattyus.com")
			End If
		End If
	End Sub

	Private Sub AccessKeyIdCopyButton_Click(sender As Object, e As EventArgs) Handles AccessKeyIdCopyButton.Click
		Clipboard.Clear()
		Clipboard.SetText(AccessKeyIDTextBox.Text)
	End Sub

	Private Sub SecretKeyCopyButton_Click(sender As Object, e As EventArgs) Handles SecretKeyCopyButton.Click
		Clipboard.Clear()
		Clipboard.SetText(SecretAccessKeyTextBox.Text)
	End Sub

	Private Function LoadProfileComboBox() As Boolean
		Dim Profiles As List(Of String)
		Profiles = GetLocalProfiles()
		If Profiles.Count > 0 Then
			For Each Profile In Profiles
				ProfilesComboBox.Items.Add(Profile)
			Next
			ProfilesComboBox.SelectedIndex = 0
			Return True
		Else
			Return False
		End If

	End Function
End Class
