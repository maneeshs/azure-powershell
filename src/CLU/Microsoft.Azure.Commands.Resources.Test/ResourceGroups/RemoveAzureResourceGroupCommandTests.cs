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

using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.Commands.Test.Utilities.Common;
using Moq;
using System.Management.Automation;
using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test
{
    public class RemoveAzureResourceGroupCommandTests : RMTestBase
    {
        private RemoveAzureResourceGroupCommand cmdlet;

        private Mock<ResourcesClient> resourcesClientMock;

        private Mock<ICommandRuntime> commandRuntimeMock;

        private string resourceGroupName = "myResourceGroup";
        private string resourceGroupId = "/subscriptions/subId/resourceGroups/myResourceGroup";

        public RemoveAzureResourceGroupCommandTests()
        {
            resourcesClientMock = new Mock<ResourcesClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new RemoveAzureResourceGroupCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                ResourcesClient = resourcesClientMock.Object
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemovesResourceGroup()
        {
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            resourcesClientMock.Setup(f => f.DeleteResourceGroup(resourceGroupName));

            cmdlet.Name = resourceGroupName;
            cmdlet.Force = true;

            cmdlet.ExecuteCmdlet();

            resourcesClientMock.Verify(f => f.DeleteResourceGroup(resourceGroupName), Times.Once());
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemovesResourceGroupFromId()
        {
            commandRuntimeMock.Setup(f => f.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            resourcesClientMock.Setup(f => f.DeleteResourceGroup(resourceGroupName));

            cmdlet.Id = resourceGroupId;
            cmdlet.Force = true;

            cmdlet.ExecuteCmdlet();

            resourcesClientMock.Verify(f => f.DeleteResourceGroup(resourceGroupName), Times.Once());
        }
    }
}