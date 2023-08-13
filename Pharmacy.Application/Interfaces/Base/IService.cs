using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Interfaces.Base
{
    public interface IService<T> where T : class
    {
        void Add(T pharmacy);
        void Delete(int id);
    }
}
