using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagment.ViewModels {
    public class StockReportModel {
        public int Row { get; set; }
        public string Date { get; set; }
        public string DocumentNumber { get; set; }
        public decimal OutputValue { get; set; }
        public decimal InputValue { get; set; }
        public decimal TotalStock { get; set; }
        public string ActionType { get; set; }
    }
}
