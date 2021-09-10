using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreFront.Data.EF/*.MetaData*/
{
    //class StoreFrontMetaData
    //{
    //}


    #region Accessory


    public class AccessoryMetadata
    {
        public int AccessoryID { get; set; }
        public int AccessoryType { get; set; }
        public decimal AccessoryPrice { get; set; }
        public Nullable<int> AccessoriesSold { get; set; }
        public Nullable<int> ColorID { get; set; }
        public string AccessoryDesrcp { get; set; }
        public Nullable<int> ShipperID { get; set; }
        public string AccessoryImage { get; set; }
        public Nullable<decimal> AccessorySales { get; set; }
        public Nullable<int> StockID { get; set; }
    }

    [MetadataType(typeof(AccessoryMetadata))]
    public partial class Accessory
    {
        //this is typically empty, unless you need to create custom properties
    }

    #endregion


    #region AccessoryType

    public class AccessoryTypeMetadata
    {

        public int AccessoryType1 { get; set; }
        public int AccsID { get; set; }
        public string AccessoryName { get; set; }
    }

    [MetadataType(typeof(AccessoryTypeMetadata))]
    public partial class AccessoryType
    {
        //this is typically empty, unless you need to create custom properties
    }


    #endregion




    #region Charger   

    public class ChargerMetadata
    {
        public int ChargerID { get; set; }
        [StringLength(25, ErrorMessage = "* Cannot exceed 25 characters")]
        [Display(Name = "Type of Charger")]
        public string Charge_type { get; set; }
    }

    [MetadataType(typeof(ChargerMetadata))]
    public partial class Charger
    {
        //this is typically empty, unless you need to create custom properties
    }

    #endregion

    #region Color 

    public class ColorMetadata
    {
        public int ColorID { get; set; }

        [StringLength(30, ErrorMessage = "* Cannot exceed 30 characters")]
        [Display(Name = "Headphone Color")]
        public string Shade { get; set; }

    }

    [MetadataType(typeof(ColorMetadata))]
    public partial class Color
    {
        //this is typically empty, unless you need to create custom properties
    }

    #endregion

    #region Employee   

    public class EmployeeMetadata
    {
        public int EmployeeID { get; set; }

        public Nullable<int> PositionID { get; set; }

        [Required(ErrorMessage = "* First Name is required")]
        [StringLength(50, ErrorMessage = "* Cannot exceed 50 characters")]
        [Display(Name = "Employee First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* Last Name is required")]
        [StringLength(50, ErrorMessage = "* Cannot exceed 50 characters")]
        [Display(Name = "Employee Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "* Hire date is required")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public System.DateTime HireDate { get; set; }

        [Required(ErrorMessage = "* Birthday is required")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birthday")]
        public System.DateTime BIrthdate { get; set; }


        [StringLength(11, ErrorMessage = "* Cannot exceed 11 characters")]
        [Display(Name = "Phone number")]
        public string Phone_ { get; set; }

        [StringLength(50, ErrorMessage = "* Email Cannot exceed 50 characters")]
        public string Email { get; set; }

        [StringLength(25, ErrorMessage = "* Street Cannot exceed 25 characters")]
        [Display(Name = "Street")]
        public string Emp_Street { get; set; }

        [StringLength(15, ErrorMessage = "* Address Cannot exceed 15 characters")]
        [Display(Name = "Address")]
        public string Adress2 { get; set; }

        [StringLength(25, ErrorMessage = "* City Cannot exceed 25 characters")]
        [Display(Name = "City")]
        public string Emp_City { get; set; }

        [StringLength(2, ErrorMessage = "* State Cannot exceed 2 characters")]
        [Display(Name = "State")]
        public string Emp_state { get; set; }

        [StringLength(5, ErrorMessage = "* Zip Cannot exceed 5 characters")]
        [Display(Name = "Zip")]
        public string Emp_zip { get; set; }
    }

    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee
    {
        //this is typically empty, unless you need to create custom properties
    }


    #endregion

    #region HeadPhoneStore
    public class HeadPhoneStoreMetadata
    {
        public int HeadPhoneID { get; set; }

        [Required(ErrorMessage = "* Head Phone Type is required")]
        [Display(Name = "Employee Phone Type")]
        public int HeadPhoneType { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Value must be greater than 0")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Display(Name = "Price")]
        public Nullable<decimal> HeadPhonePrice { get; set; }

        [Display(Name = "Wireless")]
        public Nullable<bool> isWireless { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Value must be greater than 0")]
        [Display(Name = "Head Phones Sold")]
        public Nullable<int> UnitsSold { get; set; }

        [Display(Name = "Over ear")]
        public Nullable<bool> isInOver { get; set; }

        [Display(Name = "Color")]
        public Nullable<int> ColorID { get; set; }

        [Required(ErrorMessage = "* Description is required")]
        [StringLength(100, ErrorMessage = "* Cannot exceed 100 characters")]
        [UIHint("MultilineText")]
        public string Description { get; set; }

        [Display(Name = "Microphone")]
        public Nullable<bool> isMic { get; set; }

        public Nullable<int> ChargerID { get; set; }

        [Required(ErrorMessage = "* Shipper is required")]
        public int ShipperID { get; set; }

        public Nullable<bool> isBlueTooth { get; set; }

        [Required(ErrorMessage = "* Weight is required")]
        [StringLength(10, ErrorMessage = "* Cannot exceed 10 characters")]
        public string Weight { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Value must be greater than 0")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public Nullable<decimal> Sales { get; set; }

        [Required(ErrorMessage = "* Stock ID is required")]
        public int StockID { get; set; }

        [StringLength(150, ErrorMessage = "* Cannot exceed 150 characters")]
        public int Image { get; set; }

        public virtual Charger Charger { get; set; }
        public virtual Color Color { get; set; }
        public virtual HeadPhoneType HeadPhoneType1 { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual Stock Stock { get; set; }
    }

    [MetadataType(typeof(HeadPhoneStoreMetadata))]
    public partial class HeadPhoneStore
    {
        //this is typically empty, unless you need to create custom properties
    }



    #endregion

    #region HeadPhoneType   
    public class HeadPhoneTypeMetadata
    {
        public int HeadPhoneType1 { get; set; }

        [StringLength(25, ErrorMessage = "* Cannot exceed 25 characters")]
        [Display(Name = "Head PhoneID")]
        public string HPT_ID { get; set; }
    }

    [MetadataType(typeof(HeadPhoneTypeMetadata))]
    public partial class HeadPhoneType
    {
        //this is typically empty, unless you need to create custom properties
    }



    #endregion

    #region Position   

    public class PositionMetadata
    {
        public int PositionID { get; set; }

        [StringLength(30, ErrorMessage = "* Cannot exceed 30 characters")]
        [Display(Name = "Position")]
        public string Position1 { get; set; }
    }

    [MetadataType(typeof(PositionMetadata))]
    public partial class Position
    {
        //this is typically empty, unless you need to create custom properties
    }



    #endregion

    #region Shipper   

    public class ShipperMetadata
    {
        public int ShipperID { get; set; }

        [StringLength(30, ErrorMessage = "* Cannot exceed 30 characters")]
        [Display(Name = "Shipper")]
        public string ShipperName { get; set; }

        [StringLength(75, ErrorMessage = "* Cannot exceed 75 characters")]
        public string Adress { get; set; }

        [StringLength(25, ErrorMessage = "* Cannot exceed 25 characters")]
        public string City { get; set; }

        [StringLength(2, ErrorMessage = "* Cannot exceed 2 characters")]
        public string State { get; set; }

        [StringLength(5, ErrorMessage = "* Cannot exceed 5 characters")]
        public string Zip { get; set; }
    }

    [MetadataType(typeof(ShipperMetadata))]
    public partial class Shipper
    {
        //this is typically empty, unless you need to create custom properties
    }


    #endregion

    #region Stock   

    public class StockMetadata
    {
        public int StockID { get; set; }

        [StringLength(15, ErrorMessage = "* Cannot exceed 15 characters")]
        public string StockValue { get; set; }
    }

    [MetadataType(typeof(StockMetadata))]
    public partial class Stock
    {
        //this is typically empty, unless you need to create custom properties
    }


    #endregion


    #region   


    #endregion    
    
    
    #region Speaker   

    public class SpeakerMetadata
    {
        public int SpeakerID { get; set; }
        public int SpeakerType { get; set; }
        public Nullable<decimal> SpeakerPrice { get; set; }
        public Nullable<int> SpkrsSold { get; set; }
        public Nullable<int> ColorID { get; set; }
        public string SpkrDescription { get; set; }
        public Nullable<int> ShipperID { get; set; }
        public string SpeakersImage { get; set; }
        public Nullable<decimal> SpkrSales { get; set; }
        public Nullable<int> StockID { get; set; }

        public virtual Color Color { get; set; }
        public virtual Shipper Shipper { get; set; }
        public virtual SpeakersType SpeakersType { get; set; }
    }

    [MetadataType(typeof(SpeakerMetadata))]
    public partial class Speaker
    {
        //this is typically empty, unless you need to create custom properties
    }

#endregion

    #region SpeakersType 

    public class SpeakersTypeMetadata
    {
        public int ColorID { get; set; }
        public int SpeakerType { get; set; }
        public int SpkrID { get; set; }
        public string SpkerName { get; set; }

    }

    [MetadataType(typeof(SpeakersTypeMetadata))]
    public partial class SpeakersType
    {
        //this is typically empty, unless you need to create custom properties
    }

    #endregion



}
