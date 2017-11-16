
using AndersonWorkLogsModel;
using System.Collections.Generic;
using System.Linq;

namespace AndersonWorkLogsFunction
{
    public interface IFWorkingHours
    {
        #region CREATE
        WorkingHours Create(WorkingHours WorkingHours);
        #endregion

        #region READ
        WorkingHours Read(int logID);
        #endregion

        #region UPDATE
        WorkingHours Update(WorkingHours WorkingHours);
        #endregion

        #region DELETE
        void Delete(WorkingHours WorkingHours);
        #endregion

        #region OTHER FUNCTION
        #endregion
    }

}
