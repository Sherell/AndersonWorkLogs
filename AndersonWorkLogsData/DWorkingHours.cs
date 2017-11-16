using BaseData;
using AndersonWorkLogsContext;
using AndersonWorkLogsEntity;
using System.Collections.Generic;
using System.Linq;
namespace AndersonWorkLogsData
{
    public class DWorkingHours : DBase, IDWorkingHours
    {
        public DWorkingHours() : base(new Context())
        {

        }
        #region Create
        #endregion

        #region Read
        public List<EWorkingHours> Read()
        {
            using (var context = new Context())
            {
                return context.WorkingHours
                    .OrderBy(a => a.Lastname)
                    .ToList();
            }
        }
        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion

        #region Other Function
        #endregion
    }
}
