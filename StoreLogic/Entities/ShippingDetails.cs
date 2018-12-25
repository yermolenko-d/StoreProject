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

        [Required(ErrorMessage = "Введите адрес доставки")]
        public string Line1 { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        public string City { get; set; }

        [Required(ErrorMessage ="Укажите страну")]
        public string Country { get; set; }

        public bool Gift { get; set; }
    }
}
