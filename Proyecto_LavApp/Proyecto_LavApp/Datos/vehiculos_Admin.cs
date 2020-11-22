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
        public List<vehiculos> Consultar()
        {
            marca_vehiculos_Admin marca_Admin = new marca_vehiculos_Admin();
            modelo_vehiculos_Admin modelo_Admin = new modelo_vehiculos_Admin();
            color_vehiculos_Admin color_Admin = new color_vehiculos_Admin();
            tipo_vehiculos_Admin veh_Admin = new tipo_vehiculos_Admin();
            personas_Admin persona_Admin = new personas_Admin();

            IEnumerable<vehiculos_Cls> modelo_Cls = new List<vehiculos_Cls>();
            List<vehiculos> modelo = new List<vehiculos>();

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                modelo_Cls = (from vehiculos in contexto.vehiculos
                              select new vehiculos_Cls
                              {
                                  id_vehiculo = vehiculos.id_vehiculo,
                                  id_tipo_vehiculo = vehiculos.id_tipo_vehiculo,
                                  id_persona = vehiculos.id_persona,
                                  txt_placa = vehiculos.txt_placa,
                                  id_marca_vehiculo = vehiculos.id_marca_vehiculo,
                                  id_modelo_vehiculo = vehiculos.id_modelo_vehiculo,
                                  id_color_vehiculo = vehiculos.id_color_vehiculo,
                                  ano_vehiculo = vehiculos.ano_vehiculo
                }).ToList();
            }

            foreach (vehiculos_Cls item in modelo_Cls)
            {
                vehiculos modelo_new = new vehiculos();

                modelo_new.id_vehiculo = item.id_vehiculo;
                modelo_new.id_tipo_vehiculo = item.id_tipo_vehiculo;
                modelo_new.id_persona = item.id_persona;
                modelo_new.txt_placa = item.txt_placa;
                modelo_new.id_marca_vehiculo = item.id_marca_vehiculo;
                modelo_new.id_modelo_vehiculo = item.id_modelo_vehiculo;
                modelo_new.id_color_vehiculo = item.id_color_vehiculo;
                modelo_new.ano_vehiculo = item.ano_vehiculo;
                modelo_new.color_vehiculo = color_Admin.Consultar(item.id_color_vehiculo);
                modelo_new.marca_vehiculos = marca_Admin.Consultar(item.id_marca_vehiculo);
                modelo_new.modelo_vehiculos = modelo_Admin.Consultar(item.id_modelo_vehiculo);
                modelo_new.tipo_vehiculos = veh_Admin.Consultar(item.id_tipo_vehiculo);
                modelo_new.personas = persona_Admin.Consultar(item.id_persona);

                modelo.Add(modelo_new);
            };

            return modelo;
        }

        public vehiculos Consultar(int id)
        {
            marca_vehiculos_Admin marca_Admin = new marca_vehiculos_Admin();
            modelo_vehiculos_Admin modelo_Admin = new modelo_vehiculos_Admin();
            color_vehiculos_Admin color_Admin = new color_vehiculos_Admin();
            tipo_vehiculos_Admin veh_Admin = new tipo_vehiculos_Admin();
            personas_Admin persona_Admin = new personas_Admin();

            vehiculos_Cls modelo_Cls = new vehiculos_Cls();
            vehiculos modelo = new vehiculos();

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                modelo_Cls = (from vehiculos in contexto.vehiculos
                              where vehiculos.id_vehiculo == id
                              select new vehiculos_Cls
                              {
                                  id_vehiculo = vehiculos.id_vehiculo,
                                  id_tipo_vehiculo = vehiculos.id_tipo_vehiculo,
                                  id_persona = vehiculos.id_persona,
                                  txt_placa = vehiculos.txt_placa,
                                  id_marca_vehiculo = vehiculos.id_marca_vehiculo,
                                  id_modelo_vehiculo = vehiculos.id_modelo_vehiculo,
                                  id_color_vehiculo = vehiculos.id_color_vehiculo,
                                  ano_vehiculo = vehiculos.ano_vehiculo
                              }).FirstOrDefault();
            }

                modelo.id_vehiculo = modelo_Cls.id_vehiculo;
                modelo.id_tipo_vehiculo = modelo_Cls.id_tipo_vehiculo;
                modelo.id_persona = modelo_Cls.id_persona;
                modelo.txt_placa = modelo_Cls.txt_placa;
                modelo.id_marca_vehiculo = modelo_Cls.id_marca_vehiculo;
                modelo.id_modelo_vehiculo = modelo_Cls.id_modelo_vehiculo;
                modelo.id_color_vehiculo = modelo_Cls.id_color_vehiculo;
                modelo.ano_vehiculo = modelo_Cls.ano_vehiculo;
                modelo.color_vehiculo = color_Admin.Consultar(modelo_Cls.id_color_vehiculo);
                modelo.marca_vehiculos = marca_Admin.Consultar(modelo_Cls.id_marca_vehiculo);
                modelo.modelo_vehiculos = modelo_Admin.Consultar(modelo_Cls.id_modelo_vehiculo);
                modelo.tipo_vehiculos = veh_Admin.Consultar(modelo_Cls.id_tipo_vehiculo);
                modelo.personas = persona_Admin.Consultar(modelo_Cls.id_persona);

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

        public void Eliminar(int id)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                var modelo = contexto.vehiculos.Find(id);
                contexto.vehiculos.Remove(modelo);
                contexto.SaveChanges();
            }
        }
    }
}