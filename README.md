# MyAWSSecrets

This small executable allows users with access to secrets in AWS Secrets Manager to retrieve thier secrets.
This is primarily used so that personnel with IAM Access Keys can retrieve thier keys after they've been rotated.
(See project SENDIAMAccountNotifications on creating a LAMBDA function to rotate Access Keys and notify users. This will also notify users who have a password about password expirations)
Our goal was to stop sending AWS Access Keys to user in CSV files that we then lose control over.

Requirement:

The user must have at least 1 IAM Account with assigned IAM Access Keys.

A Secret must be created in AWS Secrets Manager for any secret associated with an IAM Account.

On the users IAM account create a Tag named SecretName and a value of the SecretName in Secrets Manager used to store the access Keys.

Functionality:

When the user first runs the program and there are not stored profiles in the Share Profile file (normally created by the AWS CLI) the user will be prompted to create a new profile. The new profile form will open, the name will default to 'default' and the user will select the region and enter the AccessKeyID and SecretAccessKey, clicking OK saves the key to the profile.

To retrieve a secret select a profile from the Local Profile dropdown and click Retrieve Secret.

The Access Key ID and Secret Access Key display with copy buttons to the left.

If these are new values the Update Local Profile button will update the profile in the Shared Profile File.


Clicking New Local Profile allows the user to create additional profile. i.e. for different AWS Accounts.

How we use this program:
In our organization we have multiple AWS accounts where users have access keys. We rotate these keys every 90 days using a Lambda function. (See SendIAMAccountNotifications project)

The Lambda function runs once per day, if a key is over 90 days old the function creates a new set of keys and updates the user Secret with the new keys.
An email is sent to the user informint them that new keys were generated and they can access them with the My AWS Secrets application.
When a key reaches 100 days old the Lambda function inactivates the old keys, then when the key is 110 days old they are delted.
Between 90 days and 110 if the user has not access they new keys from Secrets Manager they receive an email prompting them to do so and warning that their old keys will be deactivated.

When a user gets thier 1st access keys for an IAM account we place the new keys in a text file on an AWS S3 buckey and send the a Pre-Sign URL to that file that expires in 24 hours.

Note: If you have multiple AWS Accounts and wish to keep all your secrets in one primary account update the Private variable SecretsArnString with the account number of your primary AWSAccount. I may change this to a configuration variable in the future but the idea is to make this simple for the end users. 

If you don't have visual studio to compile the project let me know and I can compile one with your AWS Account number in it. 

If you only have one AWS Account you can replace this string with "{0}".

