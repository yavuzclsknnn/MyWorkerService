using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkerService_Core.Options
{
    public class WorkerSettings
    {
        public int IntervalMinutes { get; set; }
        public int RetryCount { get; set; }
    }
}
