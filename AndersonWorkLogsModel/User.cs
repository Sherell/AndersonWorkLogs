using BaseModel;
using System.Collections.Generic;

namespace AndersonWorkLogsModel
{
    public class User : Base
    {
        public bool IsActive { get; set; }

        public int EmployeeId { get; set; }
        public int UserId { get; set; }

        public string Username { get; set; }
       
    }
}