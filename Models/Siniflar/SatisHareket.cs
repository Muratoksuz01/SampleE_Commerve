using System;
using System.ComponentModel.DataAnnotations;

namespace E_ticaret.Models.Sınıflar
{
    public class SatisHareket
    {

        /*
        urun cari personel*/
        [Key]
        public int Satisid { get; set; }

        public DateTime Tarih { get; set; }

        public int Adet { get; set; }

        public int Fiyat { get; set; }

        public int Toplam { get; set; }
        public int ToplamTutar { get; set; }
        //public int UrunID { get; set; }
        public Urun Urun { get; set; }
      //  public int CariID { get; set; }
        public Cariler Cariler { get; set; }
      //  public int PersonelID { get; set; }
        public Personel Personel { get; set; }
    }
}
