using AccountsWebAuthentication.Controllers;
using AccountsWebAuthentication.Helper;

namespace AndersonWorkLogsWeb.Controllers
{
    [CustomAuthorize(AllowedRoles = new string[] { "AndersonWorkLog" })]
    public class BaseController : BaseAccountsController
    {
    }
}