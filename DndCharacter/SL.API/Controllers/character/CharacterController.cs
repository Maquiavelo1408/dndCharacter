using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.BusinessLogic.LogicHandler;
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
    }
}