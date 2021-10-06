//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreFront.Data.EF
{
    using System;
    using System.Collections.Generic;

    public partial class HeadPhoneStore
    {
        public int HeadPhoneID { get; set; }
        public int HeadPhoneType { get; set; }
        public Nullable<decimal> HeadPhonePrice { get; set; }
        public Nullable<bool> isWireless { get; set; }
        public Nullable<int> UnitsSold { get; set; }
        public Nullable<bool> isInOver { get; set; }
        public Nullable<int> ColorID { get; set; }
        public string Description { get; set; }
        public Nullable<bool> isMic { get; set; }
        public Nullable<int> ChargerID { get; set; }
        public int ShipperID { get; set; }
        public Nullable<bool> isBlueTooth { get; set; }
        public string Weight { get; set; }
        public Nullable<decimal> Sales { get; set; }
        public int StockID { get; set; }
        public string Image { get; set; }
    
        public virtual Charger Charger { get; set; }
        public virtual Color Color { get; set; }
        public virtual HeadPhoneType HeadPhoneType1 { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
