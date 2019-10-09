using Hra.Colas.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra.Colas.Negocio
{
   public  class TvBL:Repositorio<Tv>
    {
        public static List<Tv> ListarTv(int bloqueId)
        {

            using (var db = new COLASEntities())
            {
                return db.Tv.Where(x => x.BloqueId== bloqueId)
                    .OrderByDescending(x => x.Fecha).Take(4).ToList();
            }

        }
    }
}
