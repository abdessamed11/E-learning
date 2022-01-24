using E_LEARNING.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.ViewModels
{
    public class FormationViewModel : EditImageViewModel
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [ForeignKey("StudentId,CategorieId")]
        public string StudentId { get; set; }
        public Student Student { get; set; }

        public int CategorieId { get; set; }
        public Categorie categorie { get; set; }

    }
}
