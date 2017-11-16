using AndersonWorkLogsData;
using AndersonWorkLogsEntity;
using AndersonWorkLogsModel;
using System.Collections.Generic;
using System.Linq;

namespace AndersonWorkLogsFunction
{
    public class FWorkingHours : IFWorkingHours
    {
        private IDWorkingHours _iDWorkingHours;

        public FWorkingHours(IDWorkingHours iDWorkingHours)
        {
            _iDWorkingHours = iDWorkingHours;
        }

        #region CREATE
        public WorkingHours Create(WorkingHours workingHours)
        {
            EWorkingHours eWorkingHours = EWorkingHours(workingHours);
            eWorkingHours = _iDWorkingHours.Create(eWorkingHours);
            return (WorkingHours(eWorkingHours));
        }
        #endregion

        #region READ
        public WorkingHours Read(int logID)
        {
            EWorkingHours eWorkingHours = _iDWorkingHours.Read<EWorkingHours>(a => a.LogID == logID);
            return WorkingHours(eWorkingHours);
        }
        public List<WorkingHours> Read()
        {
            List<EWorkingHours> eWorkingHours = _iDWorkingHours.List<EWorkingHours>(a => true);
            return WorkingHours(eWorkingHours);
        }
        #endregion

        #region UPDATE
        public WorkingHours Update(WorkingHours workinghours)
        {
            var eWorkingHours = _iDWorkingHours.Update(EWorkingHours(workinghours));
            return (WorkingHours(eWorkingHours));
        }
        #endregion

        #region DELETE
        public void Delete(WorkingHours workingHours)
        {
            _iDWorkingHours.Delete(EWorkingHours(workingHours));
        }
        #endregion

        #region OTHER FUNCTION
        private EWorkingHours EWorkingHours(WorkingHours WorkingHours)
        {
            EWorkingHours returnEWorkingHours = new EWorkingHours
            {
                LogID = WorkingHours.LogID,

                Lastname = WorkingHours.Lastname,
                Firstname = WorkingHours.Firstname,
                TimeIn = WorkingHours.TimeIn,
                TimeOut = WorkingHours.TimeOut
            };
            return returnEWorkingHours;
        }
        private WorkingHours WorkingHours(EWorkingHours eWorkingHours)
        {
            WorkingHours returnWorkingHours = new WorkingHours
            {
                LogID = eWorkingHours.LogID,

                Lastname = eWorkingHours.Lastname,
                Firstname = eWorkingHours.Firstname,
                TimeIn = eWorkingHours.TimeIn,
                TimeOut = eWorkingHours.TimeOut
            };
            return returnWorkingHours;
        }
        private List<WorkingHours> WorkingHours(List<EWorkingHours> eWorkingHours)
        {
            var returnExams = eWorkingHours.Select(a => new WorkingHours
            {
                LogID = a.LogID,

                Lastname = a.Lastname,
                Firstname = a.Firstname,
                TimeIn = a.TimeIn,
                TimeOut = a.TimeOut


            });

            return returnExams.ToList();
        }
        #endregion
    }
}
