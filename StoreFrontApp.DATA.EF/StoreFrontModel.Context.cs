//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoreFrontApp.DATA.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StoreFrontEntities : DbContext
    {
        public StoreFrontEntities()
            : base("name=StoreFrontEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Charger> Chargers { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<HeadPhoneStore> HeadPhoneStores { get; set; }
        public virtual DbSet<HeadPhoneType> HeadPhoneTypes { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
    }
}
