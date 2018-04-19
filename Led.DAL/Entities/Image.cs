using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Led.DAL.Entities
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        // +content/uploads/2018/03/
        [Display(Name = "Картинка")]
        [Required]
        public string file_Name { get; set; }

        [Display(Name = "Заголовок")]
        public string title { get; set; }

        [Display(Name = "Подпись")]
        public string caption { get; set; }

        [Display(Name = "Атрибут alt")]
        public string alt { get; set; }

        [Display(Name = "Описание")]
        public string description { get; set; }

        // ToDo::
        //Тип файла: image/jpeg
        //Загружен: 15.03.2018
        //Размер файла: 59 KB
        //Размеры: 1601 × 700
    }
}