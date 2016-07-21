using GHW.Test.Models;
using GHW.Test.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GHW.Test.Controllers
{
    public class StuController : Controller
    {
        TestModelContainer db = new TestModelContainer();
        // GET: Stu
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult List(int id)
        {
            int pageIndex = id;
            int pageSize = 3;
            List<StudentDTO> list = db.StudentSet.OrderBy(c => c.CId).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList().Select(s=>s.ToDTO()).ToList();
            int rowCount = db.StudentSet.Count();
            int pageCount = Convert.ToInt32(Math.Ceiling((rowCount * 1.0) / pageSize));
            //封装数据。
            StudentListModel<StudentDTO> dataModel = new StudentListModel<StudentDTO>()
            {
                SourceData = list,
                PageIndex = pageIndex,
                PageCount = pageCount,
                PageSize = pageSize,
                RowCount = rowCount
            };
            //将数据转换成json格式返回。
            JsonModel jsModel = new JsonModel()
            {
                Data = dataModel,
                Msg = "OK",
                Statu = "1"
            };
            //System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //string str = jss.Serialize(jsModel);
            return Json(jsModel,JsonRequestBehavior.AllowGet);
        }


    }
}