using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_EFile_Company.Hubs;
using Task_EFile_Company.Models;
using Task_EFile_Company_Domain.IRepositories;
using Task_EFile_Company_Domain.Models;

namespace Task_EFile_Company.Controllers
{
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;
        private readonly IHubContext<EditContact_Hub> _hubContext;

        public ContactController(IUnitOfWork unitOfWork, IMapper mapper, 
            IToastNotification toastNotification, IHubContext<EditContact_Hub> hubContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _toastNotification = toastNotification;
            _hubContext = hubContext;
        }
        public IActionResult Index()
        {
            return View(_mapper.Map<IEnumerable<ViewModel_Contact>>(_unitOfWork.contactRepository.GetAllData()));
        }


        public IActionResult Create()
        {
            return View(new ViewModel_Contact());
        }

        [HttpPost]
        public IActionResult Create(ViewModel_Contact model)
        {
           
            Contact obj = _mapper.Map<Contact>(model);
            _unitOfWork.contactRepository.Add(obj);
            _toastNotification.AddSuccessToastMessage("Contact Created Successfully");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
                return BadRequest();
           Contact obj = _unitOfWork.contactRepository.GetById(id);
            obj.FlagEdting = true;
            _unitOfWork.contactRepository.Edit(obj);
           await _hubContext.Clients.All.SendAsync("Send_Editing_ToALL_Client",obj,false);

            if (obj == null)
                return NotFound();
            return View( "Create",_mapper.Map<ViewModel_Contact>(obj) );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ViewModel_Contact model)
        {
            if (!ModelState.IsValid)
                return View("Create", model);

            model.FlagEdting = false;
            _unitOfWork.contactRepository.Edit(_mapper.Map<Contact>(model));
            await _hubContext.Clients.All.SendAsync("Send_Editing_ToALL_Client", model,true);
            _toastNotification.AddSuccessToastMessage("Contact Updated Seccessfully");
            return RedirectToAction(nameof(Index),nameof(Contact));
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == 0 || id == null)
                return BadRequest();

           Contact obj = _unitOfWork.contactRepository.GetById(id);
            if (obj == null)
                return NotFound();

           bool res = _unitOfWork.contactRepository.Delete(obj);
            if (res)
            {
                if( _unitOfWork.SaveData())
                {
                    await _hubContext.Clients.All.SendAsync("Send_Deleteing_ToALL_Client", obj);
                    _toastNotification.AddSuccessToastMessage("Contact Deleted Sucessfully");
                    return RedirectToAction(nameof(Index), nameof(Contact));
                }     
            }

            _toastNotification.AddErrorToastMessage("Contact Didnt Delete !!");
            return RedirectToAction(nameof(Index),nameof(Contact));

        }

        public IActionResult GetByID(int? id)
        {
            if (id == null)
                return BadRequest();
            var data = _unitOfWork.contactRepository.GetById(id);
            return Json(data);
        }


    }
}
