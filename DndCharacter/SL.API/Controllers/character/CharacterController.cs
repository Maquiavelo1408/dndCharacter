using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.BusinessLogic.LogicHandler;
using BL.BusinessLogic.Validations;
using BL.BusinessLogic.ViewModel;
using DAL.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SL.API.Common;

namespace SL.API.Controllers
{ 
    [Route("api/character/[controller]")]
    [ApiController]
    public class CharacterController : BaseController
    {
        private readonly CharacterLoginHandler _characterLoginHandler;
        private readonly IRequestHandler _requestHandler;

        public CharacterController(IResponseFormatter responseFormatter, DndRepository repository, CharacterLoginHandler characterLoginHandler, IRequestHandler requestHandler) : base(responseFormatter, repository)
        {
            _requestHandler = requestHandler;
            _characterLoginHandler = characterLoginHandler;
        }
        #region Character
        [HttpGet("character", Name = "GetCharacter")]
        public IActionResult GetCharacter()
        {
            var viewModel = new List<CharacterViewModel>();
            try
            {
                viewModel = _characterLoginHandler.GetCharacters();
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
            _responseFormatter.Add("characters", viewModel);
            return new OkObjectResult(_responseFormatter.GetResponse());
        }

        [HttpGet("character/{id}", Name ="GetCharacterById")]
        public IActionResult GetCharacterById(int id)
        {
            var vm = new CharacterViewModel();
            try
            {
                vm = _characterLoginHandler.GetCharacterById(id);
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
            _responseFormatter.Add("character", vm);
            return new OkObjectResult(_responseFormatter.GetResponse());
        }

        [HttpPost("character", Name = "CreateCharacter")]
        public IActionResult CreateCharacter([FromBody] JObject jsonData)
        {
            var viewModelValidation = _requestHandler.ViewModelValidation(jsonData, "character", new CharacterViewModelValidator());
            if (viewModelValidation.Result != null)
                return viewModelValidation.Result;

            var viewModel = viewModelValidation.ViewModel;
            try
            {
                viewModel = _characterLoginHandler.CreateCharacter(viewModel);
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
            _responseFormatter.Add("character", viewModel);
            return new OkObjectResult(_responseFormatter.GetResponse());
        }

        [HttpPut("character", Name = "UpdateCharacter")]
        public IActionResult UpdateCharacter([FromBody] JObject jsonData)
        {
            var viewModelValidation = _requestHandler.ViewModelValidation(jsonData, "character", new CharacterViewModelValidator());
            if (viewModelValidation.Result != null)
                return viewModelValidation.Result;

            var viewModel = viewModelValidation.ViewModel;

            try
            {
                viewModel = _characterLoginHandler.UpdateCharacter(viewModel);
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
            _responseFormatter.Add("character", viewModel);
            return new OkObjectResult(_responseFormatter.GetResponse());
        }

        [HttpDelete("character/{id}", Name ="DeleteCharacter")]
        public IActionResult DeleteCharacter(int id)
        {
            try
            {
                _characterLoginHandler.DeleteCharacter(id);
            }
            catch (Exception ex)
            {
                _responseFormatter.SetError(ex);
                return new BadRequestObjectResult(_responseFormatter.GetResponse());
            }
            _responseFormatter.SetMessage("Personaje borrado");
            return new OkObjectResult(_responseFormatter.GetResponse());
        }
        #endregion
    }
}