using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLogic.Entities
{
    public class Basket
    {
        private List<BasketLine> lineCollection =
                        new List<BasketLine>();  

        public void Add(Cake cake, int amount)
        {
            BasketLine line = lineCollection
                .Where(c => c.Cake.Id == cake.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new BasketLine
                {
                    Cake = cake,
                    Amount = amount
                });
            }
            else
            {
                line.Amount += amount;
            }
        }

        public void RemoveLine(Cake cake)
        {
            lineCollection.RemoveAll(c => c.Cake.Id == cake.Id);
        }

        public decimal CountTotal()
        {
            return lineCollection.Sum(c => c.Cake.Price * c.Amount);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<BasketLine> Show
        {
            get { return lineCollection; }
        }
    }

    public class BasketLine
    {
        public Cake Cake{ get; set; }
        public int Amount { get; set; }
    }
}
