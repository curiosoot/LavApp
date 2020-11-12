using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Datos
{
    public class vehiculos_Admin
    {
        public IEnumerable<vehiculos> Consultar()
        {
            marca_vehiculos_Admin marca_Admin = new marca_vehiculos_Admin();
            modelo_vehiculos_Admin modelo_Admin = new modelo_vehiculos_Admin();
            color_vehiculos_Admin color_Admin = new color_vehiculos_Admin();
            tipo_vehiculos_Admin veh_Admin = new tipo_vehiculos_Admin();
            personas_Admin persona_Admin = new personas_Admin();

            IEnumerable<vehiculos> modelo = new List<vehiculos>();

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                modelo = (from vehiculos in contexto.vehiculos
                          select new vehiculos
                          {
                              id_vehiculo = vehiculos.id_vehiculo,
                              id_tipo_vehiculo = vehiculos.id_tipo_vehiculo,
                              txt_placa = vehiculos.txt_placa,
                              id_marca_vehiculo = vehiculos.id_marca_vehiculo,
                              id_modelo_vehiculo = vehiculos.id_modelo_vehiculo,
                              id_color_vehiculo = vehiculos.id_color_vehiculo,
                              ano_vehiculo = vehiculos.ano_vehiculo,
                              color_vehiculo = color_Admin.Consultar(vehiculos.id_color_vehiculo),
                              marca_vehiculos = marca_Admin.Consultar(vehiculos.id_marca_vehiculo),
                              modelo_vehiculos = modelo_Admin.Consultar(vehiculos.id_modelo_vehiculo),
                              tipo_vehiculos = veh_Admin.Consultar(vehiculos.id_tipo_vehiculo),
                              personas = persona_Admin.Consultar(vehiculos.id_persona)
                          }).ToList();
            }

            return modelo;
        }

        public vehiculos Consultar(int id)
        {
            marca_vehiculos_Admin marca_Admin = new marca_vehiculos_Admin();
            modelo_vehiculos_Admin modelo_Admin = new modelo_vehiculos_Admin();
            color_vehiculos_Admin color_Admin = new color_vehiculos_Admin();
            tipo_vehiculos_Admin veh_Admin = new tipo_vehiculos_Admin();

            vehiculos modelo = new vehiculos();

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                modelo = (from vehiculos in contexto.vehiculos
                          where vehiculos.id_vehiculo == id
                          select new vehiculos
                          {
                              id_vehiculo = vehiculos.id_vehiculo,
                              id_tipo_vehiculo = vehiculos.id_tipo_vehiculo,
                              txt_placa = vehiculos.txt_placa,
                              id_marca_vehiculo = vehiculos.id_marca_vehiculo,
                              id_modelo_vehiculo = vehiculos.id_modelo_vehiculo,
                              id_color_vehiculo = vehiculos.id_color_vehiculo,
                              ano_vehiculo = vehiculos.ano_vehiculo,
                              color_vehiculo = color_Admin.Consultar(vehiculos.id_color_vehiculo),
                              marca_vehiculos = marca_Admin.Consultar(vehiculos.id_marca_vehiculo),
                              modelo_vehiculos = modelo_Admin.Consultar(vehiculos.id_modelo_vehiculo),
                              tipo_vehiculos = vehiculos.tipo_vehiculos
                          }).FirstOrDefault();
            }

            return modelo;
        }

        public void Guardar(vehiculos modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.vehiculos.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Modificar(vehiculos modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(vehiculos modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}