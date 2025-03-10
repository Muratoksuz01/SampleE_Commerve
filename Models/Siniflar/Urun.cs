using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_ticaret.Models.Sınıflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string UrunAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Marka { get; set; }

        public short Stok { get; set; }

        public int AlisFiyat { get; set; }


        public int SatisFiyat { get; set; }

        public bool Durum { get; set; }


        public string UrunGorsel { get; set; }
          // ✅ Zorunlu alan olarak belirtiyoruz
        public int? KategoriID { get; set; }

        [ForeignKey("KategoriID")]
        public Kategori? Kategori { get; set; }

        public ICollection<SatisHareket>? SatisHarekets { get; set; }
    }
}
