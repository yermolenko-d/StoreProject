using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace StoreLogic.Entities
{
    public class Cake
    {   

        //Этот атрибут сообщает mvc что он должен визуализироваться в виде скрытого элемента формы
        [HiddenInput(DisplayValue=false)]
        public int Id { get; set; }

        //Этот атрибут показывает что отображать вместо имени
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Обойдёмся без философской полемики о необходимости наименований." +
            " Просто введите название. По-хорошему.")]
        public string Name { get; set; }

        //показывет каким образом значение будет представлено и как будет редактироваться
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, введите описание. Без него вы вряд ли продадите этот товар. " +
            "Задумайтесь. Как насчёт фантазии, подключать будем, не?")]
        public string Description { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Укажите категорию, иначе куда нам таки это деть?")]
        public string Category { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Только давайте без вот этих вот приколов. Почём реально?")]
        [Range(0.00, double.MaxValue,ErrorMessage ="Не самая подходящая цена. Я бы даже сказал НЕРЕАЛЬНАЯ!")]
        public decimal Price { get; set; }
    }
}
