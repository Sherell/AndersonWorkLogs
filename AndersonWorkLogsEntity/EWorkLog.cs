using BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonWorkLogsEntity
{
    [Table("WorkLog")]
    public class EWorkLog : EBase
    {
        [ForeignKey("Attendance")]
        public int AttendanceId { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkLogId { get; set; }

        public string WorkDone { get; set; }

        public virtual EAttendance Attendance { get; set; }
    }
}
