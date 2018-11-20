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
    public class CollectionController : BaseController
    {
        private readonly MiscellaneousLogicHandler _miscellaneousLogicHandler;
        private readonly IRequestHandler _requestHandler;
        public CollectionController(IResponseFormatter responseFormatter, DndRepository repository, MiscellaneousLogicHandler miscellaneousLogicHandler, IRequestHandler requestHandler) : base(responseFormatter, repository)
        {
            _miscellaneousLogicHandler = miscellaneousLogicHandler;
            _requestHandler = requestHandler;
        }
        [HttpGet("collection/{idCollection}", Name = "GetDataCollectionByIdCollection")]
        public IActionResult GetDataCollectionByIdCollection(int idCollection)
        {
            var viewModel = new List<DataCollectionViewModel>();
            try
            {
                viewModel = _miscellaneousLogicHandler.GetDataCollectionByIdCollection(idCollection);
                _responseFormatter.Add("datacollections", viewModel);
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
