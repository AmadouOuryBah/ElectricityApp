using Electricity.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity.DataAccess.Repositories.Interface
{
    public interface IResourceRepository : IGenericRepository<Resource>
    {
       Task<double> GetResourceQtity(int Year, int Month, string ResourceType);
    }
}
