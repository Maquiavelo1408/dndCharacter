using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.BusinessLogic.LogicHandler;
using BL.BusinessLogic.Validations;
using BL.BusinessLogic.ViewModel;
using BL.BusinessLogic.ViewModels;
using DAL.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SL.API.Common;

namespace SL.API.Controllers.character
{
    [Route("api/miscellaneous/[controller]")]
    public class MiscellaneousController : BaseController
    {
        private readonly MiscellaneousLogicHandler _miscellaneousLogicHandler;
        private readonly IRequestHandler _requestHandler;
        public MiscellaneousController(IResponseFormatter responseFormatter, DndRepository repository, MiscellaneousLogicHandler miscellaneousLogicHandler, IRequestHandler requestHandler) : base(responseFormatter, repository)
        {
            _miscellaneousLogicHandler = miscellaneousLogicHandler;
            _requestHandler = requestHandler;
        }

        [HttpGet("equipment", Name = "GetEquipment")]
        public IActionResult GetEquipment()
        {
            try
            {
                var viewModels = _miscellaneousLogicHandler.GetEquipments();
                _responseFormatter.Add("equipments", viewModels);
                return new OkObjectResult(_responseFormatter.GetResponse());
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex.Message);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
        }

        [HttpGet("equipment/{id}", Name = "GetEquipmentById")]
        public IActionResult GetEquipmentById(int id)
        {
            var viewModel = new EquipmentViewModel();
            try
            {
                viewModel = _miscellaneousLogicHandler.GetEquipmentById(id);
                _responseFormatter.Add("equipment", viewModel);
                return new OkObjectResult(viewModel);
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex.Message);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
        }

        [HttpPost("equipmente", Name = "CreateEquipment")]
        public IActionResult CreateEquipment([FromBody] JObject jsonData)
        {
            var viewModelValidations = _requestHandler.ViewModelValidation(jsonData, "equipment", new EquipmentViewModelValidator());
            if (viewModelValidations.Result != null)
                return viewModelValidations.Result;
            var viewModel = viewModelValidations.ViewModel;
            try
            {
                viewModel = _miscellaneousLogicHandler.CreateEquipment(viewModel);
                _responseFormatter.Add("equipment", viewModel);
                return new OkObjectResult(_responseFormatter.GetResponse());
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex.Message);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
        }
    }
}
