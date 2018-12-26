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


        public void SaveChange(Cake cake)
        {
            if (cake.Id == 0)
            {   
                context.Cakes.Add(cake);
            }
            else
            {   //find position in tab by id
                Cake dbEntity = context.Cakes.Find(cake.Id);
                if (dbEntity != null)
                {   
                    //following changes
                    dbEntity.Name = cake.Name;
                    dbEntity.Description = cake.Description;
                    dbEntity.Price = cake.Price;
                    dbEntity.Category= cake.Category;
                }
            }
            //save
            context.SaveChanges();

        }

        public Cake Delete(Cake cake)
        {   
            //find by id
            Cake dbEntity = context.Cakes.Find(cake.Id);
            if (dbEntity != null)
            {   
                //Removing position from tab and save
                context.Cakes.Remove(dbEntity);
                context.SaveChanges();
            }
            //returning product
            return dbEntity;

        }

    }
}
