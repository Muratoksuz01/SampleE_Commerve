using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_ticaret.Models.Sınıflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemID { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        [Required]
        public int Miktar { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int BirimFiyat { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int Tutar { get; set; }
        [ForeignKey("Faturalar")]
        public int Faturaid { get; set; }
        public Faturalar Faturalar { get; set; }
    }
}
