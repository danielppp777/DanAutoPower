using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;




    namespace DanAutoPower.Models
    {
        public class Service
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Моля, въведете име на услугата.")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Моля, въведете описание.")]
            public string Description { get; set; }

            [Required(ErrorMessage = "Моля, въведете цена.")]
            [Range(0, 100000, ErrorMessage = "Цената трябва да бъде положително число.")]
            public decimal Price { get; set; }
        }
    }



