using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMovie.Models;
using MyMovie.Services;

namespace MyMovie.ViewComponents
{
    public class WelcomeViewComponent:ViewComponent
    {
        private readonly IRepository<Student> _repository;
        public WelcomeViewComponent(IRepository<Student> repository)//选择repository 
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var count =  _repository.GetAll().Count();
            return View("Default",count);
        }

        ///// <summary>
        ///// 未测试 异步
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    return View("three");
        //}
    }
}
