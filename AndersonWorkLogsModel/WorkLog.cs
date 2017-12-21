using BaseModel;

namespace AndersonWorkLogsModel
{
    public class WorkLog : Base
    {
        public int AttendanceId { get; set; }
        public int WorkLogId { get; set; }

        public string WorkDone { get; set; }

#pragma warning disable CS0436 // Type conflicts with imported type
        public virtual Attendance Attendance { get; set; }
#pragma warning restore CS0436 // Type conflicts with imported type
    }
}
