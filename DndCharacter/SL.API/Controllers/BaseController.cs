using DAL.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using SL.API.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SL.API.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IResponseFormatter _responseFormatter;
        protected readonly DndRepository _dndRepository;

        public BaseController(IResponseFormatter responseFormatter, DndRepository repository)
        {
            _responseFormatter = responseFormatter;
            _dndRepository = repository;
        }
    }
}
