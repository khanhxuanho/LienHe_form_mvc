//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaiLH.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;


    public partial class LienLacEntities : DbContext
    {
        public LienLacEntities()
            : base("name=LienLacEntities")
        {
        }
        public virtual DbSet<LienHe> LienHes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<LienLacEntities>(null);
            modelBuilder.Entity<LienHe>().ToTable("LienHe");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            //throw new UnintentionalCodeFirstException();
        }


    }
}
