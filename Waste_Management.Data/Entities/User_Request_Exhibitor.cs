using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waste_Management.Data.Entities
{
    public class User_Request_Exhibitor
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime ResultTime { get; set; }
        public string Address { get; set; }
    }
}
