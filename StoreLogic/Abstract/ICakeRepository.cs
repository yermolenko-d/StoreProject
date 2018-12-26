using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreLogic.Entities;
using System.Threading.Tasks;

namespace StoreLogic.Abstract
{
    public interface ICakeRepository
    {
        IEnumerable<Cake> Cakes { get; }
        void SaveChange (Cake cake);
    }
}
