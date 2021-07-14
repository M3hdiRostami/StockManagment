using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class STI : BaseEntity
    {
        public short IslemTur { get; set; }
        public string EvrakNo { get; set; }
        public int Tarih { get; set; }
        public int MalID { get; set; }
        public decimal Miktar { get; set; }
        public decimal Fiyat { get; set; }
        public decimal Tutar { get; set; }
        public string Birim { get; set; }
        public virtual STK Mal { get; set; }



    }
}
