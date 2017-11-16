using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BaseEntity;
namespace AndersonWorkLogsEntity
{
    [Table("WorkingHours")]
    public class EWorkingHours : EBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogID { get; set; }

        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string Date { get; set; }
    }
}
