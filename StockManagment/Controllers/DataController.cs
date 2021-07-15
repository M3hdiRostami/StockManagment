using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using StockManagment.ViewModels;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Application.interfaces.infrastructure.UnitOfWorks;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Application.interfaces.Services;
using Domain.Entities;
using Persistence.Services;
using StockManagment.Helpers;

namespace StockManagment.Controllers {
    
    [Route("api/[controller]/[action]")]
    public class DataController : Controller
    {

        private readonly IUnitOfWork _Uofwork;
        private readonly IService<STK> ProductService;
        public DataController(IUnitOfWork uofwork,IService<STK> productService)
        {
            _Uofwork = uofwork;
            ProductService = productService;
        }



        [HttpGet]
        public object GET(DataSourceLoadOptions loadOptions, [FromQuery] string Value)
        {
            var result = StockReportHelper.Search(_Uofwork, Value);
            return DataSourceLoader.Load(result, loadOptions);
        }
        [HttpGet]
        public async ValueTask<object> GetProducts()
        {
          return await ProductService.GetAllAsync();
      
        }
    }
}