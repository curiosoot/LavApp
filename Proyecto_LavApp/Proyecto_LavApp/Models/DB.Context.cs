﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_LavApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LavApp_BDEntities : DbContext
    {
        public LavApp_BDEntities()
            : base("name=LavApp_BDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<color_vehiculo> color_vehiculo { get; set; }
        public virtual DbSet<detalle_servicio> detalle_servicio { get; set; }
        public virtual DbSet<estado_servicio> estado_servicio { get; set; }
        public virtual DbSet<marca_vehiculos> marca_vehiculos { get; set; }
        public virtual DbSet<modelo_vehiculos> modelo_vehiculos { get; set; }
        public virtual DbSet<persona_vehiculo> persona_vehiculo { get; set; }
        public virtual DbSet<personas> personas { get; set; }
        public virtual DbSet<registro_servicio> registro_servicio { get; set; }
        public virtual DbSet<roles> roles { get; set; }
        public virtual DbSet<tipo_documento> tipo_documento { get; set; }
        public virtual DbSet<tipo_servicio> tipo_servicio { get; set; }
        public virtual DbSet<tipo_vehiculos> tipo_vehiculos { get; set; }
        public virtual DbSet<usuario_rol> usuario_rol { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
        public virtual DbSet<vehiculos> vehiculos { get; set; }
    }
}