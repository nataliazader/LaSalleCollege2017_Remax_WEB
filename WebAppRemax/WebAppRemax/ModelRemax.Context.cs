﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppRemax
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RemaxEntities : DbContext
    {
        public RemaxEntities()
            : base("name=RemaxEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AgentLanguages> AgentLanguages { get; set; }
        public virtual DbSet<BuildingType> BuildingType { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Houses> Houses { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<NumBedrooms> NumBedrooms { get; set; }
        public virtual DbSet<NumParking> NumParking { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<PropertyType> PropertyType { get; set; }
    }
}