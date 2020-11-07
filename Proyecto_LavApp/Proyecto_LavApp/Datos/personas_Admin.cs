using Proyecto_LavApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_LavApp.Datos
{
    public class personas_Admin
    {
        public IEnumerable<personas> Consultar()
        {
            //var persona = new personas();
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.personas.Include(x => x.tipo_documento).ToList();
            }
        }
        public personas Consultar(int id)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                return contexto.personas.Include(x => x.tipo_documento).FirstOrDefault(c => c.id_persona == id);
            }
        }

        public void Guardar(personas modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.personas.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Modificar(personas modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public void Eliminar(personas modelo)
        {
            using (LavApp_BDEntities contexto = new LavApp_BDEntities())
            {
                contexto.Entry(modelo).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}