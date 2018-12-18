using System;
using System.Collections.Generic;
using StoreLogic.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreLogic.Abstract;

namespace StoreLogic.Concrete
{
    public class EFCakeRepository : ICakeRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Cake> Cakes
        {
            get { return context.Cakes; }
        }
    }
}
