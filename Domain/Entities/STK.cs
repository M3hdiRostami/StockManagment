using Domain.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class STK : BaseEntity
    {
        public string MalKodu { get; set; }
        public string MalAdi { get; set; }
       
        public virtual ICollection<STI> Islemller { get; set; }

    }
}
