using BaseModel;
using System;
using System.Collections.Generic;

namespace AndersonWorkLogsModel
{
    public class Attendance : Base
    {
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public int AttendanceId { get; set; }

        public virtual ICollection<WorkLog> WorkLogs { get; set; }
        public virtual ICollection<WorkLog> DeletedWorkLogs { get; set; }
    }
}
