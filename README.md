# GCX Email

## Summary

Provides email functionality for community (site) creation workflows
  
## Prerequisites

The following user accounts (as reflected in the app settings) are required:

| Account             | Membership requirements                                  |
| ------------------- | -------------------------------------------------------- |
| delegated_username  | |

## Version 

![dotnet 6](https://img.shields.io/badge/net6.0-blue.svg)

## API permission

MSGraph

| API / Permissions name    | Type        | Admin consent | Justification             |
| ------------------------- | ----------- | ------------- | ------------------------- |
| Mail.Send                 | Delegated   | Yes           | Send email                | 
| User.Read                 | Delegated   | Yes           | Read user for mail sender | 

## App setting

| Name                | Description                                         |
| ------------------- | --------------------------------------------------- |
| AzureWebJobsStorage | Connection string for the storage acoount           |
| clientId            | The application (client) ID of the app registration |
| delegated_username  | The email sender address                            |
| keyVaultUrl         | Address for the key vault                           |
| secretName          | Secret name used to authorize the function app      |
| secretNamePassword  | The secret name for the email sender password       |
| sharePointUrl       | Url for a SharePoint site                           |    
| tenantId            | Id of the Azure tenant that hosts the function app  |
| userId              | The object id for the email sender                  |

## Version history

Version|Date|Comments
-------|----|--------
1.0|2023-10-10|Initial release

## Disclaimer

**THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.**
