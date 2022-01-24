using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.ViewModels
{
    public class CategoriesViewModel : EditImageViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
