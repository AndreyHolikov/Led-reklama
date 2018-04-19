using AutoMapper;
using Led.BLL.DTO;
using Led.BLL.Interfaces;
using Led.BLL.Services;
using Led.DAL.EF;
using Led.DAL.Interfaces;
using Led.DAL.Repositories;
using Led.WEB.Models;
using Led.WEB.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Led.WEB.Controllers
{
    public class HomeController : Controller
    {
        EFUnitOfWork unitOfWork;
        public HomeController()
        {
            //string ConnectionString = ConfigurationManager.ConnectionStrings["LedContextLocalhost"].ConnectionString;
            unitOfWork = DatabaseConfiguration.GetEFUnitOfWork();
        }

        public HomeController(IUnitOfWork unitOfWork)
        {
            //string ConnectionString = ConfigurationManager.ConnectionStrings["LedContextLocalhost"].ConnectionString;
            this.unitOfWork = (EFUnitOfWork)unitOfWork;
        }

        IAddressService addressService;
        public HomeController(IAddressService serv)
        {
            addressService = serv;

            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<DisplayDTO, DisplayViewModel>();
            //    //    .ForMember("Name", opt => opt.MapFrom(obj => obj.Name));
            //    //.ForMember(opt => opt.City, opt => opt.MapFrom(src => src.City.Name));
            //    //cfg.CreateMap<City, CityDTO>();
            //    //cfg.CreateMap<Display, DisplayDTO>();
            //});
        }

        public ActionResult Index()
        {
            //AddressService addressService = new AddressService(unitOfWork);

            //IEnumerable<AddressDTO> addressDTOs = addressService.GetAll();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<AddressDTO, AddressViewModel>()).CreateMapper();
            //var model = mapper.Map<IEnumerable<AddressDTO>, List<AddressViewModel>>(addressDTOs);

            //using (LedContext context = new LedContext())
            //{
            //    context.Addresses.ToList();
            //}
            //return View("IndexAddress");

            IDisplayService displayService = new DisplayService(unitOfWork);

            var displays = new MapperConfiguration(cfg => cfg.CreateMap<DisplayDTO, DisplayViewModel>()).CreateMapper();
            ViewBag.Displays = Mapper.Map<IEnumerable<DisplayDTO>, List<DisplayViewModel>>(displayService.GetAll());

            //ICalculatorService calculatorService = new CalculatorService(unitOfWork);
            //var calculators = new MapperConfiguration(cfg => cfg.CreateMap<CalculatorDTO, CityViewModel>()).CreateMapper();
            //ViewData["Calculators"] = Mapper.Map<IEnumerable<CalculatorDTO>, List<CalculatorDTO>>(calculatorService.GetAll());

            //int modelCount = addresses.ToList().Count;
            //if (modelCount > 0)
            //    ViewBag.Message = $"В базе данных {modelCount} объект";
            return View();
        }

        //public ActionResult MakeOrder(int? id)
        //{
        //    try
        //    {
        //        PhoneDTO phone = orderService.GetPhone(id);
        //        var order = new OrderViewModel { PhoneId = phone.Id };

        //        return View(order);
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return Content(ex.Message);
        //    }
        //}
        //[HttpPost]
        //public ActionResult MakeOrder(OrderViewModel order)
        //{
        //    try
        //    {
        //        var orderDto = new OrderDTO { PhoneId = order.PhoneId, Address = order.Address, PhoneNumber = order.PhoneNumber };
        //        orderService.MakeOrder(orderDto);
        //        return Content("<h2>Ваш заказ успешно оформлен</h2>");
        //    }
        //    catch (ValidationException ex)
        //    {
        //        ModelState.AddModelError(ex.Property, ex.Message);
        //    }
        //    return View(order);
        //}
        protected override void Dispose(bool disposing)
        {
            //addressService.Dispose();
            base.Dispose(disposing);
        }
    }
}