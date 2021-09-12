using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_EFile_Company.Models;
using Task_EFile_Company_Domain.IRepositories;

namespace Task_EFile_Company.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IToastNotification _toastNotification;

        public UserLoginController(IUnitOfWork unitOfWork, IToastNotification toastNotification)
        {
            _unitOfWork = unitOfWork;
            _toastNotification =toastNotification;
        }
        public IActionResult LogIn()
        {
            GlobalData.Logged_Username = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogIn(ViewModel_UserLogin model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var obj = _unitOfWork.userLoginRepository.GetAllData().Where(m => m.UserName.Contains(model.UserName)
            && m.Password.Contains(model.Password)).FirstOrDefault();
            if (obj != null)
            {
               
                GlobalData.Logged_Username = obj.UserName;
                _toastNotification.AddSuccessToastMessage("LoggedIn Successfully");
                return RedirectToAction(nameof(Index), "Contact");
            }
            _toastNotification.AddErrorToastMessage("Username or Password Incorrect!!");
            return View(model);
        }
    }
}
