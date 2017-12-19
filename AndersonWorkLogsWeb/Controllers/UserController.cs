using AccountsFunction;
using AccountsWebAuthentication.Helper;
using AndersonWorkLogsWeb.Controllers;
using System.Web.Mvc;

namespace AccountsWeb.Controllers
{
    public class UserController : BaseController
    {
        private IFUser _iFUser;
        public UserController(IFUser iFUser)
        {
            _iFUser = iFUser;
        }

        #region Read
        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFUser.Read());
        }
        #endregion
    }
}