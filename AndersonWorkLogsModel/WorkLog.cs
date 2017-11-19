using BaseModel;

namespace AndersonWorkLogsModel
{
    public class WorkLog : Base
    {
        public int AttendanceId { get; set; }
        public int WorkLogId { get; set; }

        public string WorkDone { get; set; }

        public virtual Attendance Attendance { get; set; }
    }
}
