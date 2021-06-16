//using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
//using Domain;
//using Service;
using MVCAjax.Models;

namespace MVCAjax.Controllers
{
    public class StudentController : Controller
    {
        //private StudentService service = new StudentService();
        Proxy.StudentProxy proxy = new Proxy.StudentProxy();

        // GET: Students
        public ActionResult IndexRazor()
        {
            //var model = (
            //    from c in service.Get()
            //    select new StudentModel
            //    {
            //        studentID = c.studentID,
            //        studentName = c.studentName,
            //        studentAddress = c.studentAddress
            //    }

            var response = Task.Run(() => proxy.GetStudentsAsync());

            return View(response.Result.Listado);
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult searchStudents(string nameOrLastName)
        {
            //return Json(service.SearchByNameOrLastName(nameOrLastName), JsonRequestBehavior.AllowGet);
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public JsonResult getStudents()
        {
            var response = Task.Run(() => proxy.GetStudentsAsync());
            return Json(response.Result.Listado, JsonRequestBehavior.AllowGet);
            //return Json(service.Get(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult studentDetail(int id)
        {
            //service.GetById(id)
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult createStudent(StudentModel std)
        {
            var response = Task.Run(() => proxy.InsertAsync(std));
            string message = response.Result.Mensaje;
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpDelete]
        public ActionResult deleteStudent(int id)
        {
            //service.Delete(id);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
    }
}