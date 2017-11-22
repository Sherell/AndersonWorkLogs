using AndersonWorkLogsData;
using AndersonWorkLogsEntity;
using AndersonWorkLogsModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AndersonWorkLogsFunction
{
    public class FAttendance : IFAttendance
    {
        private IDAttendance _iDAttendance;

        public FAttendance()
        {
            _iDAttendance = new DAttendance();
        }

        #region CREATE
        public Attendance Create(int createdBy, Attendance attendance)
        {
            EAttendance eAttendance = EAttendance(attendance);
            eAttendance.CreatedDate = DateTime.Now;
            eAttendance.CreatedBy = createdBy;
            eAttendance = _iDAttendance.Create(eAttendance);
            return (Attendance(eAttendance));
        }
        #endregion

        #region READ
        public Attendance Read(int attendanceId)
        {
            EAttendance eAttendance = _iDAttendance.Read<EAttendance>(a => a.AttendanceId == attendanceId);
            return Attendance(eAttendance);
        }

        public List<Attendance> Read()
        {
            List<EAttendance> eAttendances = _iDAttendance.List<EAttendance>(a => true);
            return Attendances(eAttendances);
        }
        #endregion

        #region UPDATE
        public Attendance Update(int updatedBy, Attendance attendance)
        {
            EAttendance eAttendance = EAttendance(attendance);
            eAttendance.UpdatedDate = DateTime.Now;
            eAttendance.UpdatedBy = updatedBy;
            eAttendance = _iDAttendance.Update(eAttendance);
            return (Attendance(eAttendance));
        }
        #endregion

        #region DELETE
        public void Delete(int attendanceId)
        {
            _iDAttendance.Delete<EAttendance>(a => a.AttendanceId == attendanceId);
        }
        #endregion

        #region OTHER FUNCTION
        private List<Attendance> Attendances(List<EAttendance> eAttendances)
        {
            return eAttendances.Select(a => new Attendance
            {
                CreatedDate = a.CreatedDate,
                UpdatedDate = a.UpdatedDate,
                TimeIn = a.TimeIn,
                TimeOut = a.TimeOut,

                AttendanceId = a.AttendanceId,
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy
            }).ToList();
        }

        private EAttendance EAttendance(Attendance attendance)
        {
            return new EAttendance
            {
                CreatedDate = attendance.CreatedDate,
                UpdatedDate = attendance.UpdatedDate,
                TimeIn = attendance.TimeIn,
                TimeOut = attendance.TimeOut,

                AttendanceId = attendance.AttendanceId,
                CreatedBy = attendance.CreatedBy,
                UpdatedBy = attendance.UpdatedBy
            };
        }

        private Attendance Attendance(EAttendance eAttendance)
        {
            return new Attendance
            {
                CreatedDate = eAttendance.CreatedDate,
                UpdatedDate = eAttendance.UpdatedDate,
                TimeIn = eAttendance.TimeIn,
                TimeOut = eAttendance.TimeOut,

                AttendanceId = eAttendance.AttendanceId,
                CreatedBy = eAttendance.CreatedBy,
                UpdatedBy = eAttendance.UpdatedBy
            };
        }
        #endregion
    }
}
