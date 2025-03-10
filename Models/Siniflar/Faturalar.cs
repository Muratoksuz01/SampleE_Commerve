using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_ticaret.Models.Sınıflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaID { get; set; }
        
        [StringLength(10)]
        public string FaturaSeriNo { get; set; }
        
        [StringLength(20)]
        public string FaturaSıraNo { get; set; }
        
        public DateTime Tarih { get; set; }
        
        [StringLength(100)]
        public string VergiDairesi { get; set; }
        
        public string Saat { get; set; }
        
        [StringLength(50)]
        public string TeslimEden { get; set; }
        
        [StringLength(50)]
        public string TeslimAlan { get; set; }
        public int Toplam { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}
