using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GameLib.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            switch (statusCode)
            {
                case 400:
                    {
                        ViewBag.Title = "Bad Request";
                        ViewBag.ErrorMessage = "Something Went Wrong";
                        break;
                    }

                case 403:
                    {
                        ViewBag.Title = "Forbidden";
                        ViewBag.ErrorMessage = "Access Denied";
                        break;
                    }

                case 404:
                    {
                        ViewBag.Title = "Not Found";
                        ViewBag.ErrorMessage = "Not Found";
                        break;
                    }

                case 500:
                    {
                        ViewBag.Title = "Internal Server Error";
                        ViewBag.ErrorMessage = "Internal Server Error";
                        break;
                    }
            }

            return View(statusCode);
        }
    }
}