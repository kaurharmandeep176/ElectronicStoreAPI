﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElectronicStore.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ElectronicStoreEntities : DbContext
    {
        public ElectronicStoreEntities()
            : base("name=ElectronicStoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Contact_Table> Contact_Table { get; set; }
        public virtual DbSet<Product_Table> Product_Table { get; set; }
        public virtual DbSet<Salary_Table> Salary_Table { get; set; }
        public virtual DbSet<Staff_Table> Staff_Table { get; set; }
    }
}