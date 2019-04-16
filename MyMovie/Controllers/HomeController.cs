using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovie.Models;
using MyMovie.Services;
using MyMovie.ViewModels;

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
            //  this._repository.GetAll(); //注册服务后引用函数
            var students = new ShowStudents()
            {
                Students = this._repository.GetAll().ToList()
            };
            return View(students);
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
        //权限验证
        [Authorize]
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
                _repository.Add(new Student()
                {
                    Age = student.Age,
                    Gender = student.Gender,
                    Name = student.Name,
                    RegTime = DateTime.Now,
                    Password="1234",
                    ConfirmPassword = "1234"
                });
                return RedirectToAction(nameof(Index));
            }
            //ModelState.AddModelError(string.Empty,"Model error"); model错误
            return View();
        }

        public IActionResult Detail(int id)
        {
            return View(_repository.Get(id));
        }
    }
}
