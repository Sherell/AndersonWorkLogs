using AndersonWorkLogsModel;
using System.Collections.Generic;

namespace AndersonWorkLogsFunction
{
    public interface IFAttendance
    {
        #region CREATE
        Attendance Create(int createdBy, Attendance attendance);
        #endregion

        #region READ
        Attendance ReadId(int attendanceId);
        List<Attendance> Read(int userId);
        #endregion

        #region UPDATE
        Attendance Update(int updatedBy, Attendance attendance);
        void Approve(int approvedBy, int attendanceId);
        #endregion

        #region DELETE
        void Delete(int AttendanceId);
        #endregion
    }

}
