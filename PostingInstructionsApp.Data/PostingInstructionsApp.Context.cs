﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PostingInstructionsApp.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class InfrastructureEntities : DbContext
    {
        public InfrastructureEntities()
            : base("name=InfrastructureEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AuthorizationW> AuthorizationWS { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientVendorRel> ClientVendorRels { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<v_Clients> v_Clients { get; set; }
        public virtual DbSet<v_ClientVendors> v_ClientVendors { get; set; }
        public virtual DbSet<v_Employees> v_Employees { get; set; }
    }
}
