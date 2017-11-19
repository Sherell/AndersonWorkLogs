using BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AndersonWorkLogsEntity
{
    [Table("Attendance")]
    public class EAttendance : EBase
    {
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }

        public virtual ICollection<EWorkLog> WorkLogs { get; set; }
    }
}
