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
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Public Class Form1
	Private SecretsArnString As String = "arn:aws:secretsmanager:us-east-1:268928949034:{0}"


	'	Private Class AccessKey
	'		Private _AccessKeyID As String
	'		Private _SecretAccessKey As String

	'		Public Property AccessKeyID() As String
	'			Get
	'				Return _AccessKeyID
	'			End Get
	'			Set(value As String)
	'				_AccessKeyID = value
	'			End Set
	'		End Property

	'		Public Property SecretAccessKey() As String
	'			Get
	'				Return _SecretAccessKey
	'			End Get
	'			Set(value As String)
	'				_SecretAccessKey = value
	'			End Set
	'		End Property

	'		Public Sub New(ByVal AccessKeyID As String, SecretAccessKey As String)
	'			Me.AccessKeyID = AccessKeyID
	'			Me.SecretAccessKey = SecretAccessKey
	'		End Sub

	'	End Class

	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.

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

	End Sub

	Private Sub ProfilesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProfilesComboBox.SelectedIndexChanged
		Dim profileName As String = ProfilesComboBox.Items(ProfilesComboBox.SelectedIndex)

		AccessKeyIdCopyButton.Enabled = False
		SecretKeyCopyButton.Enabled = False

		Dim chain As New CredentialProfileStoreChain()
		Dim Creds As BasicAWSCredentials = Nothing

		If chain.TryGetAWSCredentials(profileName, Creds) Then
			Dim iamClient = New AmazonIdentityManagementServiceClient(Creds)
			Dim userResponseTask As Task(Of GetUserResponse)

			Try
				userResponseTask = iamClient.GetUserAsync()
			Catch ex As Exception
				MsgBox("An error occerred. This is most likely because the AccessKeys in your local file are inactive (expired).", MsgBoxStyle.Information, "My AWS Secrets")
				Return
			End Try

			Dim UserResponse = userResponseTask.Result
			Dim IamUser As User = UserResponse.User

			If IamUser.Tags.Count = 0 Then
				MsgBox("Secret Name not found in your IAM account. Please report this to your AWS Global Administrator.", MsgBoxStyle.Information, "My AWS Secrets")
				Return
			End If

			Dim Tags As List(Of IdentityManagement.Model.Tag) = IamUser.Tags
			Dim secretName As String

			Try
				secretName = Tags.Find(Function(t) t.Key = "SecretName").Value
			Catch ex As Exception
				MsgBox("Secret Name not found in your IAM account. Please report this to your AWS Global Administrator.", MsgBoxStyle.Information, "My AWS Secrets")
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

			AccessKeyIDTextBox.Text = MyAccessKeys.AccessKeyId
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

	Private Shared Function Get_CuurentAccountID() As String
		Dim stsClient = New AmazonSecurityTokenServiceClient()
		Dim accountId = stsClient.GetCallerIdentityAsync(New GetCallerIdentityRequest()).Result.Account
		Return accountId

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
		ProfilesComboBox.Items.Clear()
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

	Private Sub AboutLinkLabel_Click(sender As Object, e As EventArgs) Handles AboutLinkLabel.Click
		Dim MyAboutBox = New AboutBox
		MyAboutBox.ShowDialog()
	End Sub

	Private Shared Sub BackupProfileFile(saveFilePath As String)
		Dim sharedFilePath As String = SharedCredentialsFile.DefaultFilePath
		'	Read the file into a vatiable
		Dim FileContent As String = File.ReadAllText(sharedFilePath)
		Dim plainKey As String = System.Security.Principal.WindowsIdentity.GetCurrent().User.AccountDomainSid.Value
		plainKey = Strings.Right(plainKey, 16)
		Dim key = Encoding.UTF8.GetBytes(plainKey)

		Dim iv(15) As Byte
		Dim array() As Byte
		Using aes As Aes = Aes.Create()
			aes.Key = key
			aes.IV = iv
			Using encryptor = aes.CreateEncryptor(aes.Key, aes.IV)
				Using ms As New MemoryStream
					Using cs As New CryptoStream(ms, encryptor, CryptoStreamMode.Write)
						Using sw As New StreamWriter(cs)
							sw.Write(FileContent)
						End Using
						array = ms.ToArray()
					End Using
				End Using
			End Using

			Dim StringB64 = Convert.ToBase64String(array)
			File.WriteAllText(saveFilePath, StringB64)
		End Using
	End Sub

	Private Shared Sub RestoreProfileFile(backupFilePath As String)
		Dim sharedFilePath As String = SharedCredentialsFile.DefaultFilePath
		Dim FileContent As String = File.ReadAllText(backupFilePath)
		Dim PlainKey As String = Strings.Right(System.Security.Principal.WindowsIdentity.GetCurrent().User.AccountDomainSid.Value, 16)
		Dim iv(15) As Byte
		Dim Buffer As Byte() = Convert.FromBase64String(FileContent)
		Using aes As Aes = Aes.Create()
			aes.Key = Encoding.UTF8.GetBytes(PlainKey)
			aes.IV = iv
			Using decryptor = aes.CreateDecryptor(aes.Key, aes.IV)
				Using ms As New MemoryStream(Buffer)
					Using cs As New CryptoStream(ms, decryptor, CryptoStreamMode.Read)
						Using sr As New StreamReader(cs)
							Dim outFileContent As String = sr.ReadToEnd()
							File.WriteAllText(sharedFilePath, outFileContent)
						End Using
					End Using
				End Using
			End Using
		End Using
	End Sub

	Private Sub BackupProfilesButton_Click(sender As Object, e As EventArgs) Handles BackupProfilesButton.Click
		Dim folderBrowser As New FolderBrowserDialog

		folderBrowser.Description = "Select folder to store your backup. It is recomended that you use a network or cloud based folder."
		folderBrowser.UseDescriptionForTitle = True
		Dim selectedFolder As String = Nothing
		If folderBrowser.ShowDialog = DialogResult.OK Then
			selectedFolder = folderBrowser.SelectedPath
			Dim credentialFile = selectedFolder + "\Credentials.bkf"
			BackupProfileFile(credentialFile)
			MsgBox("Your AWS Credentials have been backup to:" + credentialFile, MsgBoxStyle.Information, "My AWS Secrets")
		End If

	End Sub

	Private Sub RestoreProfilesButton_Click(sender As Object, e As EventArgs) Handles RestoreProfilesButton.Click
		Dim openFile As New OpenFileDialog
		With openFile
			.Filter = "bkf files (*.bkf)|*.bkf"
			.InitialDirectory = Environment.GetEnvironmentVariable("USERPROFILE")
			If openFile.ShowDialog = DialogResult.OK Then
				Dim filePath = openFile.FileName
				RestoreProfileFile(filePath)
				MsgBox("You AWS Credentials have been restored.", MsgBoxStyle.Information, "My AWS Secrets")
				LoadProfileComboBox()
			End If
		End With

	End Sub
End Class
