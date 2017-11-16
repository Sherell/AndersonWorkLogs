using BaseData;
using AndersonWorkLogsEntity;
using System.Collections.Generic;

namespace AndersonWorkLogsData
{
    public interface IDWorkingHours : IDBase
    {
        #region Read
        List<EWorkingHours> Read();
        #endregion
    }
}
