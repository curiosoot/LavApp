using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Proyecto_LavApp.Datos
{
    public class tipo_documento_Admin
    {
        public IEnumerable<tipo_documento> Consultar()
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.tipo_documento.AsNoTracking().ToList();
            }
        }
        public tipo_documento Consultar(int id)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.tipo_documento.AsNoTracking().FirstOrDefault(c => c.id_tipo_documento == id);
            }
        }

        public void Guardar(tipo_documento modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.tipo_documento.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Modificar(tipo_documento modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(tipo_documento modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}