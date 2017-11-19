using AndersonWorkLogsModel;
using System.Collections.Generic;

namespace AndersonWorkLogsFunction
{
    public interface IFWorkLog
    {
        #region CREATE
        WorkLog Create(int createdBy, WorkLog workLog);
        #endregion

        #region READ
        WorkLog Read(int workLogId);
        List<WorkLog> Read();
        #endregion

        #region UPDATE
        WorkLog Update(int updatedBy, WorkLog workLog);
        #endregion

        #region DELETE
        void Delete(int WorkLogId);
        #endregion
    }

}
