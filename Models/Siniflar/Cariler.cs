using System.ComponentModel.DataAnnotations;
using E_ticaret.Models.Sınıflar;

public class Cariler
{
    [Key]
    public int CariID { get; set; }

    [Required(ErrorMessage = "Cari adı zorunludur.")]
    [StringLength(50, ErrorMessage = "Cari adı en fazla 50 karakter uzunluğunda olmalıdır.")]
    public string CariAd { get; set; }

    [StringLength(50, ErrorMessage = "Cari soyadı en fazla 50 karakter uzunluğunda olmalıdır.")]
    public string CariSoyad { get; set; }

    [StringLength(50, ErrorMessage = "Cari şehir en fazla 50 karakter uzunluğunda olmalıdır.")]
    public string CariSehir { get; set; }

    [StringLength(100, ErrorMessage = "Cari mail adresi en fazla 100 karakter uzunluğunda olmalıdır.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
    public string CariMail { get; set; }

    public bool Durum { get; set; }
    public ICollection<SatisHareket> SatisHarekets { get; set; }
}
