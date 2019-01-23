//
// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.
//

// Warning: This code was generated by a tool.
//
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet(VerbsData.Export, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "LogAnalyticRequestRateByInterval", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSLogAnalyticsOperationResult))]
    public partial class ExportAzureRmLogAnalyticRequestRateByInterval : ComputeAutomationBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.Location, VerbsData.Export))
                {
                    var parameters = new RequestRateByIntervalInput();
                    parameters.GroupByOperationName = this.GroupByOperationName;
                    parameters.BlobContainerSasUri = this.BlobContainerSasUri;
                    parameters.IntervalLength = this.IntervalLength;
                    parameters.FromTime = this.FromTime;
                    parameters.ToTime = this.ToTime;
                    parameters.GroupByResourceName = this.GroupByResourceName;
                    parameters.GroupByThrottlePolicy = this.GroupByThrottlePolicy;
                    string location = this.Location.Canonicalize();

                    var result = LogAnalyticsClient.ExportRequestRateByInterval(parameters, location);
                    var psObject = new PSLogAnalyticsOperationResult();
                    ComputeAutomationAutoMapperProfile.Mapper.Map<LogAnalyticsOperationResult, PSLogAnalyticsOperationResult>(result, psObject);
                    WriteObject(psObject);
                }
            });
        }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true)]
        [LocationCompleter("Microsoft.Compute/locations/logAnalytics")]
        public string Location { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 2,
            Mandatory = true)]
        public DateTime FromTime { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 3,
            Mandatory = true)]
        public DateTime ToTime { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 4,
            Mandatory = true)]
        public string BlobContainerSasUri { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 5,
            Mandatory = true)]
        public IntervalInMins IntervalLength { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Mandatory = false)]
        public SwitchParameter GroupByOperationName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Mandatory = false)]
        public SwitchParameter GroupByResourceName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Mandatory = false)]
        public SwitchParameter GroupByThrottlePolicy { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
    }
}
