using AndersonCRMFunction;
using AccountsWebAuthentication.Helper;
using AndersonWorkLogsWeb.Controllers;
using System.Web.Mvc;

namespace AndersonCRMWeb.Controllers
{
    public class EmployeeController : BaseController
    {
        private IFEmployee _iFEmployee;
        public EmployeeController(IFEmployee iFEmployee)
        {
            _iFEmployee = iFEmployee;
        }

        #region Read
        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFEmployee.Read());
        }
        #endregion
    }
}