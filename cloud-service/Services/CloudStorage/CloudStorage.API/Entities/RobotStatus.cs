using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisJson.API.Entities
{
    /*
     * This class will be used to accomodate the data required the robot entity
     */
    public class RobotStatus
    {
        //initializing an empty constructor for this class
        public RobotStatus() { }

        //setting the properties of the entity

        //public string Key { get; set; }

        public string ActorId { get; set; }

        public bool Active { get; set; }

        public bool PowerOff { get; set; }

        public string Idle { get; set; }

        public string Battery { get; set; }

        public string CurrentTask { get; set; }

        //initializing a timestamp for each object of this class
        public string Timestamp 
        {
            get 
            {
                string value = DateTime.UtcNow.ToString("{dd/MM/yy H:mm:ss}");

                return value;   
            }
        }

        //public RobotStatus() { }

        /*public RobotStatus(string key)
        {
            key = Key;
        }*/
    }
}
