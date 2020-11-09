using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Datos
{
    public class tipo_vehiculos_Admin
    {
        public IEnumerable<tipo_vehiculos_Cls> Consultar() 
        {
            IEnumerable<tipo_vehiculos> tipos = new List<tipo_vehiculos>();
            IEnumerable<tipo_vehiculos_Cls> tipos_new = new List<tipo_vehiculos_Cls>();
            tipo_vehiculos_Cls tipo = new tipo_vehiculos_Cls();
            
            using (LavApp_BDEntities contexto = new LavApp_BDEntities()) 
            {
               tipos = contexto.tipo_vehiculos.AsNoTracking().ToList();
            }

            foreach (tipo_vehiculos item in tipos)
            {
                tipo.id_tipo_vehiculo = item.id_tipo_vehiculo;
                tipo.txt_tipo_vehiculo = item.txt_tipo_vehiculo;

                if (item.sn_activo == 1)
                {
                    tipo.sn_activo = true;
                }
                else
                {
                    tipo.sn_activo = false;    
                }

                tipos_new.ToList().Add(tipo);
            }

            return tipos_new;
        }
        public tipo_vehiculos Consultar(int id)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.tipo_vehiculos.AsNoTracking().FirstOrDefault(c=>c.id_tipo_vehiculo==id);
            }
        }

        public void Guardar (tipo_vehiculos modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.tipo_vehiculos.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Modificar(tipo_vehiculos modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(tipo_vehiculos modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State=EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

    }
}