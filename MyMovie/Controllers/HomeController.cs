using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovie.Models;
using MyMovie.Services;

namespace MyMovie.Controllers
{
    //当不配置路由时
    //[Route("v2/[controller]/[action]")]
    //[Route("[controller]/[action]")]
    //[Route("[controller]")]
    public class HomeController : Controller
    {
        //构造函数  自建的服务
        private readonly IRepository<Student> _repository;
        public  HomeController(IRepository<Student> repository)//选择repository 
        {
            _repository = repository;
        }


        //[Route("")]
        // [Route("[action]")]
        //[Route("Index")]
        public IActionResult Index()
        {
            //string a=this.ControllerContext.ActionDescriptor.ActionName;  //控制器名
            //this.ControllerContext.ActionDescriptor.ControllerName;
            //this.Request;
            //this.ControllerContext
            //this.File();//返回文件
            //this._repository.GetAll()();//注册服务后引用函数
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //防止跨域请求
        public IActionResult Create(Models.Student student)
        {
            if (ModelState.IsValid)//验证数据
            {
                return Json(new {success = "success"});
            }
            ModelState.AddModelError(string.Empty,"Model error");
            return View();
        }
    }
}
