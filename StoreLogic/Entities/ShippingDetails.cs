using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StoreLogic.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Имя не может быть пустым")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите первый адрес доставки")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        //[Required(ErrorMessage = "Укажите город")]
        public string City { get; set; }

        [Required(ErrorMessage ="Укажите страну")]
        public string Country { get; set; }

        public bool Gift { get; set; }
    }
}
