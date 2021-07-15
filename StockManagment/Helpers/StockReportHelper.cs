using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.interfaces.infrastructure.Repositories;
using Application.interfaces.Services;
using Application.interfaces.infrastructure.UnitOfWorks;
using StockManagment.ViewModels;
using Newtonsoft.Json;

namespace StockManagment.Helpers
{
    public static class StockReportHelper
    {

        public static ICollection<StockReportModel> Search(IUnitOfWork unitOfWork, string searchParamJsonString)
        {

            SearchFormViewModel mdl = JsonConvert.DeserializeObject<SearchFormViewModel>(searchParamJsonString);
            Dictionary<string, object> Params = new Dictionary<string, object>()
            {
                {"@ProductID",mdl?.ProductCode ?? ""},
                {"@Startdate",(int)(Convert.ToDateTime(mdl?.StartDate ?? DateTime.Now.ToShortDateString()).ToOADate())},
                {"@Enddate",(int)(Convert.ToDateTime(mdl?.EndDate ?? DateTime.Now.ToShortDateString()).ToOADate())},
            };
            return unitOfWork.RawSqlQuery<StockReportModel>($"GetStocks ", x => new StockReportModel { Row = (int)x[0], ActionType = (string)x[1], Date = (string)x[3], DocumentNumber = (string)x[2], OutputValue = (decimal)x[5], InputValue = (decimal)x[4], TotalStock = (decimal)x[6] }, Params);


        }

    }
}