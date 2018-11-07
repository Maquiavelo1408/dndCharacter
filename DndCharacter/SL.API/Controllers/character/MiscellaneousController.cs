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
        #region Equipment
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
                return new OkObjectResult(_responseFormatter.GetResponse());
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex.Message);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
        }

        [HttpPost("equipment", Name = "CreateEquipment")]
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

        [HttpPut("equipment", Name = "UpdateEquipment")]
        public IActionResult UpdateEquipment([FromBody] JObject jsonData)
        {
            var viewModelValidation = _requestHandler.ViewModelValidation(jsonData, "equipment", new EquipmentViewModelValidator());
            if (viewModelValidation.Result != null)
                return viewModelValidation.Result;
            var viewModel = viewModelValidation.ViewModel;
            try
            {
                viewModel = _miscellaneousLogicHandler.UpdateEquipment(viewModel);
                _responseFormatter.Add("equipment", viewModel);
                return new OkObjectResult(_responseFormatter.GetResponse());
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex.Message);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
        }

        [HttpDelete("equipment/{id}", Name ="DeleteEquipment")]
        public IActionResult DeleteEquipment(int id)
        {
            try
            {
                _miscellaneousLogicHandler.DeleteEquipment(id);
                _responseFormatter.SetMessage("Equipo borrado");
                return new OkObjectResult(_responseFormatter.GetResponse());
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex.Message);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
        }
        #endregion

        #region Skill

        [HttpGet("skill", Name ="GetSkills")]
        public IActionResult GetSkills()
        {
            var viewModelList = new List<SkillViewModel>();
            try
            {
                viewModelList = _miscellaneousLogicHandler.GetSkills();
                _responseFormatter.Add("skills", viewModelList);
                return new OkObjectResult(_responseFormatter.GetResponse());
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex.Message);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
        }

        [HttpGet("skill/{id}", Name = " GetSkilById")]
        public IActionResult GetSkilById(int id)
        {
            var viewModel = new SkillViewModel();
            try
            {
                viewModel = _miscellaneousLogicHandler.GetSkillById(id);
                _responseFormatter.Add("skill", viewModel);
                return new OkObjectResult(_responseFormatter.GetResponse());
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex.Message);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
        }

        [HttpPost("skill", Name ="CreateSkill")]
        public IActionResult CreateSkill([FromBody] JObject jsonData)
        {
            var viewModelValidation = _requestHandler.ViewModelValidation(jsonData, "skill", new SkillViewModelValidator());
            if (viewModelValidation.Result != null)
                return viewModelValidation.Result;
            var viewModel = viewModelValidation.ViewModel;
            try
            {
                viewModel = _miscellaneousLogicHandler.CreateSkill(viewModel);
                _responseFormatter.Add("skill", viewModel);
                return new OkObjectResult(_responseFormatter.GetResponse());
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex.Message);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
        }

        [HttpPut("skill", Name = "UpdateSkill")]
        public IActionResult UpdateSkill([FromBody] JObject jsonData)
        {
            var viewModelValidation = _requestHandler.ViewModelValidation(jsonData, "skill", new SkillViewModelValidator());
            if (viewModelValidation.Result != null)
                return viewModelValidation.Result;
            var viewModel = viewModelValidation.ViewModel;
            try
            {
                viewModel = _miscellaneousLogicHandler.UpdateSkill(viewModel);
                _responseFormatter.Add("skill", viewModel);
                return new OkObjectResult(_responseFormatter.GetResponse());
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex.Message);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
        }

        [HttpDelete("skill/{id}", Name ="DeleteSkill")]
        public IActionResult DeleteSkill(int id)
        {
            try
            {
                _miscellaneousLogicHandler.DeleteSkill(id);
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex.Message);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
            _responseFormatter.SetMessage("Skill borrado");
            return new OkObjectResult(_responseFormatter.GetResponse());
        }
        #endregion
    }
}
