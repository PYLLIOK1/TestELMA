using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestELMA.Models
{
    public class ModelView
    {
        public string ID { get; set; }
        [Display(Name = "Цифр. код")]
        public string NumCode { get; set; }
        [Display(Name = "Букв. код")]
        public string CharCode { get; set; }
        [Display(Name = "Единиц")]
        public int Nominal { get; set; }
        [Display(Name = "Валюта")]
        public string Name { get; set; }
        [Display(Name = "Курс")]
        public double Value { get; set; }
        [Display(Name = "Предыдущий курс")]
        public double Previous { get; set; }
    }
}