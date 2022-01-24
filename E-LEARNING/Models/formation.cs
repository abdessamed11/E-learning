using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_LEARNING.Models
{
    [Table("tblFormation")]
    public class formation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public string Status { get; set; }

        public string Cause { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string ProfilePicture { get; set; }

        [ForeignKey("StudentId,CategorieId")]        
        public string StudentId { get; set; }
        public Student Student { get; set; }

        public int CategorieId { get; set; }
        public Categorie categorie { get; set; }

    }
}
