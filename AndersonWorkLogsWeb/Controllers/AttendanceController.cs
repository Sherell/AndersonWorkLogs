using AndersonWorkLogsFunction;
using AndersonWorkLogsModel;
using System.Web.Mvc;

namespace AndersonWorkLogsWeb.Controllers
{
    public class AttendanceController : BaseController
    {
        private IFAttendance _iFAttendance;
        public AttendanceController(IFAttendance iFAttendance)
        {
            _iFAttendance = iFAttendance;
        }

        #region Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Attendance());
        }

        [HttpPost]
        public ActionResult Create(Attendance attendance)
        {
            var createdAttendance = _iFAttendance.Create(UserId, attendance);
            return RedirectToAction("Index");
        }
        #endregion

        #region Read
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Read()
        {
            return Json(_iFAttendance.Read());
        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(_iFAttendance.Read(id));
        }

        [HttpPost]
        public ActionResult Update(Attendance attendance)
        {
            var createdAttendance = _iFAttendance.Update(UserId, attendance);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            _iFAttendance.Delete(id);
            return Json(string.Empty);
        }
        #endregion
    }
}