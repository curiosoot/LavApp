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
            List<tipo_vehiculos> tipos_new = new List<tipo_vehiculos>();
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                tipos_new = contexto.tipo_vehiculos.AsNoTracking().ToList();
            }
            return Transformar(tipos_new);
        }

        public tipo_vehiculos_Cls Consultar(int id)
        {
            tipo_vehiculos tipos = new tipo_vehiculos();
            tipo_vehiculos_Cls tipos_new = new tipo_vehiculos_Cls();
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                tipos = contexto.tipo_vehiculos.AsNoTracking().FirstOrDefault(c => c.id_tipo_vehiculo == id);
            }

            tipos_new.id_tipo_vehiculo = tipos.id_tipo_vehiculo;
            tipos_new.txt_tipo_vehiculo = tipos.txt_tipo_vehiculo;

            if (tipos.sn_activo == 1)
            {
                tipos_new.sn_activo = true;
            }
            else
            {
                tipos_new.sn_activo = false;
            }
            return tipos_new;
        }

        public List<tipo_vehiculos_Cls> Transformar(List<tipo_vehiculos> tipos_new) 
        {
            List<tipo_vehiculos_Cls> tipos = new List<tipo_vehiculos_Cls>();

            foreach (tipo_vehiculos item in tipos_new)
            {
                tipo_vehiculos_Cls tipo = new tipo_vehiculos_Cls();

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

                tipos.Add(tipo);
            }
            return tipos;
        }

        public IEnumerable<tipo_vehiculos> Retornar(IEnumerable<tipo_vehiculos_Cls> tipos_new)
        {
            IEnumerable<tipo_vehiculos> tipos = new List<tipo_vehiculos>();
            tipo_vehiculos tipo = new tipo_vehiculos();

            foreach (tipo_vehiculos_Cls item in tipos_new)
            {
                tipo.id_tipo_vehiculo = item.id_tipo_vehiculo;
                tipo.txt_tipo_vehiculo = item.txt_tipo_vehiculo;

                if (item.sn_activo == true)
                {
                    tipo.sn_activo = 1;
                }
                else
                {
                    tipo.sn_activo = 0;
                }

                tipos.ToList().Add(tipo);
            }
            return tipos;
        }

        public void Guardar (tipo_vehiculos_Cls modelo)
        {
            tipo_vehiculos modelo_new = new tipo_vehiculos();

            modelo_new.id_tipo_vehiculo = modelo.id_tipo_vehiculo;
            modelo_new.txt_tipo_vehiculo = modelo.txt_tipo_vehiculo;

            if (modelo.sn_activo == true)
            {
                modelo_new.sn_activo = 1;
            }
            else
            {
                modelo_new.sn_activo = 0;
            }

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.tipo_vehiculos.Add(modelo_new);
                contexto.SaveChanges();
            }
        }

        public void Modificar(tipo_vehiculos_Cls modelo)
        {
            tipo_vehiculos modelo_new = new tipo_vehiculos();

            modelo_new.id_tipo_vehiculo = modelo.id_tipo_vehiculo;
            modelo_new.txt_tipo_vehiculo = modelo.txt_tipo_vehiculo;

            if (modelo.sn_activo == true)
            {
                modelo_new.sn_activo = 1;
            }
            else
            {
                modelo_new.sn_activo = 0;
            }

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo_new).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(tipo_vehiculos_Cls modelo)
        {
            tipo_vehiculos modelo_new = new tipo_vehiculos();

            modelo_new.id_tipo_vehiculo = modelo.id_tipo_vehiculo;
            modelo_new.txt_tipo_vehiculo = modelo.txt_tipo_vehiculo;

            if (modelo.sn_activo == true)
            {
                modelo_new.sn_activo = 1;
            }
            else
            {
                modelo_new.sn_activo = 0;
            }

            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo_new).State=EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

    }
}