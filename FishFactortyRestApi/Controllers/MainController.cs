using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFactoryBusinessLogic.BindingModels;
using FishFactoryBusinessLogic.BusinessLogics;
using FishFactoryBusinessLogic.Interfaces;
using FishFactoryBusinessLogic.ViewModels;
using FishFactoryRestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FishFactoryRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly ICannedLogic _canned;
        private readonly MainLogic _main;
        public MainController(IOrderLogic order, ICannedLogic canned, MainLogic main)
        {
            _order = order;
            _canned = canned;
            _main = main;
        }
        [HttpGet]
        public List<CannedModel> GetCannedList() => _canned.Read(null)?.Select(rec =>
       Convert(rec)).ToList();
        [HttpGet]
        public CannedModel GetCanned(int cannedId) => Convert(_canned.Read(new
       CannedBindingModel
        { Id = cannedId })?[0]);
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
       OrderBindingModel
        { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
       _main.CreateOrder(model);
        private CannedModel Convert(CannedViewModel model)
        {
            if (model == null) return null;
            return new CannedModel
            {
                Id = model.Id,
                CannedName = model.CannedName,
                Price = model.Price
            };
        }
    }
}