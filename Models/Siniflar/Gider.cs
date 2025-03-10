using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_ticaret.Models.Sınıflar
{
    public class Gider
    {
        [Key]
        public int GiderID { get; set; }
        
        [StringLength(500)]
        public string Aciklama { get; set; }
        
        [Required]
        public DateTime Tarih { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        public decimal Tutar { get; set; }
    }
}
