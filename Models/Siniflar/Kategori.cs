using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_ticaret.Models.Sınıflar
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }
        
      
        public string KategoriAd { get; set; }
    
        public ICollection<Urun> Uruns  { get; set; }
    }
}
