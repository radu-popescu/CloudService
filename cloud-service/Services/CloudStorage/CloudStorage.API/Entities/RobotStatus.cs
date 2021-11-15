using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudStorage.API.Entities
{
    public class RobotStatus
    {
        public string Key { get; set; }

        public string ActorId { get; set; }

        public bool Active { get; set; }

        public bool PowerOff { get; set; }

        public string Idle { get; set; }

        public string Battery { get; set; }

        public string CurrentTask { get; set; }

        public RobotStatus(){ }

        public RobotStatus(string key)
        {
            key = Key;
        }

        public string Timestamp 
        {
            get 
            {
                string value = DateTime.UtcNow.ToString("{dd/MM/yy H:mm:ss}");

                return value;   
            }
        }

    }
}
