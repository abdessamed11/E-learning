using E_LEARNING.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.ViewModels
{
    public class TitreViewModel : EditImageViewModel
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        public string Article_art { get; set; }

        [Required]
        public string video_art { get; set; }
        
        [ForeignKey("formationId")]
        public int formationId { get; set; }
        public formation formation { get; set; }
    }
}
