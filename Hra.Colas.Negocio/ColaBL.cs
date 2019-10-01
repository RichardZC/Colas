using Hra.Colas.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra.Colas.Negocio
{
    public class ColaBL:Repositorio<Cola>
    {

        public static Cola LlamarCola(int servicioId) {

            using (var db = new COLASEntities())
            {
                return db.Cola.Where(x => x.ServicioId == servicioId && x.IndAtendido == false
                && x.Fecha.Year == DateTime.Now.Year
                && x.Fecha.Month == DateTime.Now.Month
                && x.Fecha.Day == DateTime.Now.Day).OrderBy(x => x.Fecha).FirstOrDefault();
            }
            
        }
    }
}
