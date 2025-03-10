using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_ticaret.Models.Sınıflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonelAd { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonelSoyad { get; set; }

        [StringLength(250)]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public int DepartmanID { get; set; }  // Bu alanı ekle

        public Departman Departman { get; set; }
    }
}
