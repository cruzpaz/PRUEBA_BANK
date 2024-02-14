using NetCoreAPIPostgreSQL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Repositories
{
    internal interface IDepartamentoRepository
    {
        Task<IEnumerable<departamento>> All();

    }
}
