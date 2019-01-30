/* ***********************************************************************************************************************************************
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

*********************************************************************************************************************************************** */

// This file contains unImplemented  cmdlets. To provide the implementation you need to follow the below steps.
// 1. Create a new file with the preffered name as <Verb><Cmdlet_Name>.cs 
// 2. Cut the class structure from below unimplemented cmdlets.
// 3. Implement the ProcessRecord() function for that class each class.
// 4. Refer to already implemented classes for more infomation and reference.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using System.Net;


namespace NBCmdlets
{
    class ToDo
    {
    }

    // #############################################
    [Cmdlet(VerbsCommon.Get, "AppDetails")]
    public class GetAppDetails : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Remove", "NBJobs")]
    public class RemoveNBJobs : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBAssetGroup")]
    public class GetNBAssetGroup : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Set", "NBAssetGroup")]
    public class SetNBAssetGroup : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBAssets")]
    public class GetNBAssets : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Set", "NBAssets")]
    public class SetNBAssets : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Set", "NBConfigVMServer")]
    public class SetNBConfigVMServer : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBConfigVMServer")]
    public class GetNBConfigVMServer : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Set", "NBConfigSLP")]
    public class SetNBConfigSLP : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBConfigSLP")]
    public class GetNBConfigSLP : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Set", "NBConfigSMTPServer")]
    public class SetNBConfigSMTPServer : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBConfigSMTPServer")]
    public class GetNBConfigSMTPServer : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Set", "NBConfigSnapshotProvider")]
    public class SetNBConfigSnapshotProvider : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBConfigSnapshotProvider")]
    public class GetNBConfigSnapshotProvider : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBConfigVCenterTopology")]
    public class GetNBConfigVCenterTopology : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Set", "NBAccessRules")]
    public class SetNBAccessRules : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBAccessRules")]
    public class GetNBAccessRules : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Set", "NBObjectGroups")]
    public class SetObjectGreoups : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBObjectGroups")]
    public class GetObjectGreoups : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Set", "NBObjectTypes")]
    public class SetNBObjectTypes : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBObjectTypes")]
    public class GetNBObjectTypes : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Set", "NBAccessPermissions")]
    public class SetNBAccessPermissions : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBAccessPermissions")]
    public class GetNBAccessPermissions : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Set", "NBAccessRoles")]
    public class SetNBAccessRoles : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBAccessRoles")]
    public class GetNBAccessRoles : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Set", "NBRecoverCloudAsset")]
    public class SetNBRecoverCloudAsset : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Add", "NBRecoverVMWareInstantAccessMount")]
    public class AddNBRecoverVMWareInstantAccessMount : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Set", "NBRecoverVMWareRecoverVM")]
    public class AddNBRecoverVMWareRecoverVMVMWareRecoverVM : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBRecoverVMWareInstantAccessMount")]
    public class GetNBRecoverVMWareInstantAccessMount : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Remove", "NBRecoverVMWareInstantAccessMount")]
    public class RemoveNBRecoverVMWareInstantAccessMount : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBLicencingCapacity")]
    public class GetNBLicencinCapacity : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBStatusCode")]
    public class GetNBStatusCode : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBStorageBackupSize")]
    public class GetNBStorageBackupSize : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBStorageUnits")]
    public class GetNBStorageUnits : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBSecurityAuditLogs")]
    public class GetNBSecurityAuditLogs : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBSecurityCACert")]
    public class GetNBSecurityCACert  : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Get", "NBSecurityCertificateCRL")]
    public class GetNBSecurityCertificateCRL : Cmdlet
    {
    }

    // #############################################
    [Cmdlet("Set", "NBSecurityCertificateCRL")]
    public class SetNBSecurityCertificateCRL : Cmdlet
    {
    }


}

