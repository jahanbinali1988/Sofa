using System;
using System.Collections.Generic;
using System.Text;

namespace Sofa.SharedKernel.BaseClasses
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string VehicleDeviceTableName { get; set; }
        public string GeofenceDeviceTableName { get; set; }
        public string AssetStatusTableName { get; set; }
    }
}
