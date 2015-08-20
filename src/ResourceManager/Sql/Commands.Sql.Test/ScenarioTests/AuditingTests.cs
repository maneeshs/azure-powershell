﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.ScenarioTest.SqlTests;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Sql.Test.ScenarioTests
{
    public class AuditingTests : SqlTestsBase
    {
        protected Microsoft.Azure.Management.Storage.StorageManagementClient GetStorageV2Client()
        {
            var client = TestBase.GetServiceClient<Microsoft.Azure.Management.Storage.StorageManagementClient>(new CSMTestEnvironmentFactory());
            if (HttpMockServer.Mode == HttpRecorderMode.Playback)
            {
                client.LongRunningOperationInitialTimeout = 0;
                client.LongRunningOperationRetryTimeout = 0;
            }
            return client;
        }

        protected override void SetupManagementClients()
        {
            var sqlCSMClient = GetSqlClient();
            var storageClient = GetStorageClient();
            var storageV2Client = GetStorageV2Client();
            var resourcesClient = GetResourcesClient();
            var authorizationClient = GetAuthorizationManagementClient();
            helper.SetupSomeOfManagementClients(sqlCSMClient, storageClient, storageV2Client, resourcesClient, authorizationClient);
        }
        
        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyWithStorageV2()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithStorageV2");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingServerUpdatePolicyWithStorage()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithStorage");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyWithEventTypes()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithEventTypes");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingServerUpdatePolicyWithEventTypes()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithEventTypes");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingDisableDatabaseAuditing()
        {
            RunPowerShellTest("Test-AuditingDisableDatabaseAuditing");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingDisableServerAuditing()
        {
            RunPowerShellTest("Test-AuditingDisableServerAuditing");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingDatabaseDisableEnableKeepProperties()
        {
            RunPowerShellTest("Test-AuditingDatabaseDisableEnableKeepProperties");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingServerDisableEnableKeepProperties()
        {
            RunPowerShellTest("Test-AuditingServerDisableEnableKeepProperties");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingUseServerDefault()
        {
            RunPowerShellTest("Test-AuditingUseServerDefault");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingFailedDatabaseUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-AuditingFailedDatabaseUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingFailedServerUpdatePolicyWithNoStorage()
        {
            RunPowerShellTest("Test-AuditingFailedServerUpdatePolicyWithNoStorage");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingFailedUseServerDefault()
        {
            RunPowerShellTest("Test-AuditingFailedUseServerDefault");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyWithEventTypeShortcuts()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithEventTypeShortcuts");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingServerUpdatePolicyWithEventTypeShortcuts()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithEventTypeShortcuts");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingServerUpdatePolicyKeepPreviousStorage()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyKeepPreviousStorage");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingFailWithBadDatabaseIndentity()
        {
            RunPowerShellTest("Test-AuditingFailWithBadDatabaseIndentity");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingFailWithBadServerIndentity()
        {
            RunPowerShellTest("Test-AuditingFailWithBadServerIndentity");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingDatabaseStorageKeyRotation()
        {
            RunPowerShellTest("Test-AuditingDatabaseStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingServerStorageKeyRotation()
        {
            RunPowerShellTest("Test-AuditingServerStorageKeyRotation");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingServerUpdatePolicyWithRetention()
        {
            RunPowerShellTest("Test-AuditingServerUpdatePolicyWithRetention");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyWithRetention()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithRetention");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingServerRetentionKeepProperties()
        {
            RunPowerShellTest("Test-AuditingServerRetentionKeepProperties");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingDatabaseRetentionKeepProperties()
        {
            RunPowerShellTest("Test-AuditingDatabaseRetentionKeepProperties");
        }

        [Fact]
        [Trait(Category.Sql, Category.CheckIn)]
        public void TestAuditingDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion()
        {
            RunPowerShellTest("Test-AuditingDatabaseUpdatePolicyWithSameNameStorageOnDifferentRegion");
        }
    }
}