using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chart.Core
{
    public class RecvDataInfo
    {
        public byte[] Data;
        public IPEndPoint ipEndPoint;
    }
    public class ServiceObject : RecvDataInfo
    {
        public string UserId;
        public string UserName;
        public DateTime LastRec;
    }
}
