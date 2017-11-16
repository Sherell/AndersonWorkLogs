using System;


namespace AndersonWorkLogsModel
{
    public class WorkingHours : Base.Base
    {
        public int LogID { get; set; }

        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string Date { get; set; }
    }
}
