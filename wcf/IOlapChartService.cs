#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MvcSampleBrowser
{
    [ServiceContract]
    public interface IOlapChartService
    {
        [OperationContract]
        Dictionary<string, object> InitializeChart(string action,string customObject);

        [OperationContract]
        Dictionary<string, object> DrillChart(string action, string drilledSeries, string olapReport,string customObject);

        [OperationContract]
        void Export(System.IO.Stream stream);
    }
}
