﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Desktop_App
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MedicalLaboratoryEntities : DbContext
    {
        public MedicalLaboratoryEntities()
            : base("name=MedicalLaboratoryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<add_inform> add_inform { get; set; }
        public virtual DbSet<analyzer> analyzer { get; set; }
        public virtual DbSet<authorization> authorization { get; set; }
        public virtual DbSet<biomaterial> biomaterial { get; set; }
        public virtual DbSet<ins_company> ins_company { get; set; }
        public virtual DbSet<ins_policy_type> ins_policy_type { get; set; }
        public virtual DbSet<order> order { get; set; }
        public virtual DbSet<payment_servic> payment_servic { get; set; }
        public virtual DbSet<performed_service> performed_service { get; set; }
        public virtual DbSet<role> role { get; set; }
        public virtual DbSet<service> service { get; set; }
        public virtual DbSet<service_order> service_order { get; set; }
        public virtual DbSet<status_order> status_order { get; set; }
        public virtual DbSet<status_service> status_service { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<work_analyzer> work_analyzer { get; set; }
    }
}
