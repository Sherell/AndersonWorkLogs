using AndersonWorkLogsData;
using AndersonWorkLogsEntity;
using AndersonWorkLogsModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AndersonWorkLogsFunction
{
    public class FWorkLog : IFWorkLog
    {
        private IDWorkLog _iDWorkLog;

        public FWorkLog()
        {
            _iDWorkLog = new DWorkLog();
        }

        #region CREATE
        public WorkLog Create(int createdBy, WorkLog workLog)
        {
            EWorkLog eWorkLog = EWorkLog(workLog);
            eWorkLog.CreatedDate = DateTime.Now;
            eWorkLog.CreatedBy = createdBy;
            eWorkLog = _iDWorkLog.Create(eWorkLog);
            return (WorkLog(eWorkLog));
        }
        #endregion

        #region READ
        public List<WorkLog> Read(int attendanceId)
        {
            List<EWorkLog> eWorkLogs = _iDWorkLog.List<EWorkLog>(a => a.AttendanceId == attendanceId);
            return Companies(eWorkLogs);
        }

        public List<WorkLog> Read()
        {
            List<EWorkLog> eWorkLogs = _iDWorkLog.List<EWorkLog>(a => true);
            return Companies(eWorkLogs);
        }
        #endregion

        #region UPDATE
        public WorkLog Update(int updatedBy, WorkLog workLog)
        {
            EWorkLog eWorkLog = EWorkLog(workLog);
            eWorkLog.UpdatedDate = DateTime.Now;
            eWorkLog.UpdatedBy = updatedBy;
            eWorkLog = _iDWorkLog.Update(eWorkLog);
            return (WorkLog(eWorkLog));
        }
        #endregion

        #region DELETE
        public void Delete(int workLogId)
        {
            _iDWorkLog.Delete<EWorkLog>(a => a.WorkLogId == workLogId);
        }
        #endregion

        #region OTHER FUNCTION
        private List<WorkLog> Companies(List<EWorkLog> eWorkLogs)
        {
            return eWorkLogs.Select(a => new WorkLog
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,
                AttendanceId = a.AttendanceId,

                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy,
                WorkLogId = a.WorkLogId,

                WorkDone = a.WorkDone
            }).ToList();
        }

        private EWorkLog EWorkLog(WorkLog workLog)
        {
            return new EWorkLog
            {
                CreatedDate = workLog.CreatedDate,
                UpdatedDate = workLog.UpdatedDate,
                AttendanceId = workLog.AttendanceId,

                CreatedBy = workLog.CreatedBy,
                UpdatedBy = workLog.UpdatedBy,
                WorkLogId = workLog.WorkLogId,

                WorkDone = workLog.WorkDone
            };
        }

        private WorkLog WorkLog(EWorkLog eWorkLog)
        {
            return new WorkLog
            {
                CreatedDate = eWorkLog.CreatedDate,
                UpdatedDate = eWorkLog.UpdatedDate,
                AttendanceId = eWorkLog.AttendanceId,

                CreatedBy = eWorkLog.CreatedBy,
                UpdatedBy = eWorkLog.UpdatedBy,
                WorkLogId = eWorkLog.WorkLogId,

                WorkDone = eWorkLog.WorkDone
            };
        }
        #endregion
    }
}
