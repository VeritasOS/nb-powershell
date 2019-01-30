# NetBackup PowerShell Cmdlets

This project contains the sample implementations and template for writing own PowerShell Cmdlets using REST APIs.
The implementation of certain cmdlets such as Jobs, Alerts, Policies, Token, etc are given. These are reference 
implementations that work with certain certain options. Newer options can be added. 
There is a TODO.cs file that contains the template of unimplemented cmdlets and can be implemented by overriding
the ProcessRecord function in the respective class. Newer cmdlets can be added by calling NetBackup REST APIS

Each NBCmdlet calls a NetBackup REST API underneath, fetches the response. Parses the response and creates PowerShell 
objects out of the JSON response. Each NBCmdlet is essentially a REST Client in itself.

Compile the NBCmdlets project to get NBCmdlets.dll. The NBCmdlets.dll can be imported as a regular PowerShell module.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.
See deployment for notes on how to deploy the project on a live system.

### Prerequisites

Visual Studio 2013.

## Deployment

The output of the project will be a dynamic link library called NBCmdlets.dll.
Import the PowerShell module created above with the following command.

Import-Module -Name "<Path to NBCmdlets.dll"
For example: 

```
Import-Module -Name "C:\MyWork\NBCmdlets\NBCmdlets\NBCmdlets.dll"
```

```
PS > Get-Command -Module NBCmdlets

CommandType     Name                                               ModuleName
-----------     ----                                               ----------
Cmdlet          Add-NBRecoverVMWareInstantAccessMount              NBCmdlets
Cmdlet          Get-AppDetails                                     NBCmdlets
Cmdlet          Get-NBAccessPermissions                            NBCmdlets
Cmdlet          Get-NBAccessRoles                                  NBCmdlets
Cmdlet          Get-NBAccessRules                                  NBCmdlets
Cmdlet          Get-NBAlert                                        NBCmdlets
Cmdlet          Get-NBAssetGroup                                   NBCmdlets
Cmdlet          Get-NBAssets                                       NBCmdlets
Cmdlet          Get-NBCatalog                                      NBCmdlets
Cmdlet          Get-NBConfigHost                                   NBCmdlets
Cmdlet          Get-NBConfigSLP                                    NBCmdlets
Cmdlet          Get-NBConfigSMTPServer                             NBCmdlets
Cmdlet          Get-NBConfigSnapshotProvider                       NBCmdlets
Cmdlet          Get-NBConfigVCenterTopology                        NBCmdlets
Cmdlet          Get-NBConfigVMServer                               NBCmdlets
Cmdlet          Get-NBJobs                                         NBCmdlets
Cmdlet          Get-NBLicencingCapacity                            NBCmdlets
Cmdlet          Get-NBObjectGroups                                 NBCmdlets
Cmdlet          Get-NBObjectTypes                                  NBCmdlets
Cmdlet          Get-NBPing                                         NBCmdlets
Cmdlet          Get-NBPolicy                                       NBCmdlets
Cmdlet          Get-NBRecoverVMWareInstantAccessMount              NBCmdlets
Cmdlet          Get-NBSecurityAuditLogs                            NBCmdlets
Cmdlet          Get-NBSecurityCACert                               NBCmdlets
Cmdlet          Get-NBSecurityCertificateCRL                       NBCmdlets
Cmdlet          Get-NBStatusCode                                   NBCmdlets
Cmdlet          Get-NBStorageBackupSize                            NBCmdlets
Cmdlet          Get-NBStorageUnits                                 NBCmdlets
Cmdlet          Get-NBToken                                        NBCmdlets
Cmdlet          Get-NBTokenKey                                     NBCmdlets
Cmdlet          Remove-NBJobs                                      NBCmdlets
Cmdlet          Remove-NBRecoverVMWareInstantAccessMount           NBCmdlets
Cmdlet          Set-NBAccessPermissions                            NBCmdlets
Cmdlet          Set-NBAccessRoles                                  NBCmdlets
Cmdlet          Set-NBAccessRules                                  NBCmdlets
Cmdlet          Set-NBAssetGroup                                   NBCmdlets
Cmdlet          Set-NBAssets                                       NBCmdlets
Cmdlet          Set-NBConfigHost                                   NBCmdlets
Cmdlet          Set-NBConfigSLP                                    NBCmdlets
Cmdlet          Set-NBConfigSMTPServer                             NBCmdlets
Cmdlet          Set-NBConfigSnapshotProvider                       NBCmdlets
Cmdlet          Set-NBConfigVMServer                               NBCmdlets
Cmdlet          Set-NBJobs                                         NBCmdlets
Cmdlet          Set-NBObjectGroups                                 NBCmdlets
Cmdlet          Set-NBObjectTypes                                  NBCmdlets
Cmdlet          Set-NBRecoverCloudAsset                            NBCmdlets
Cmdlet          Set-NBRecoverVMWareRecoverVM                       NBCmdlets
Cmdlet          Set-NBSecurityCertificateCRL                       NBCmdlets
```

## Built With

* [Visual Studio 2013](https://visualstudio.microsoft.com/vs/older-downloads/)

## Versioning

This is the version 1.0

## License
```
Copyright <2019> <Veritas Technologies LLC>

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in 
   the documentation and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote products derived from 
   this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, 
BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT 
SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL 
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
```