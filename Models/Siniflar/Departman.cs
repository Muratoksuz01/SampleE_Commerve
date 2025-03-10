using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_ticaret.Models.Sınıflar
{
    public class Departman
    {
        [Key]
        public int DepartmanID { get; set; }
        
        [Required]
        [StringLength(100)]
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; }
        public ICollection<Personel> Personels  { get; set; }
    }
}
