using E_ticaret.Models.Sınıflar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Controllers
{
    public class SatisController : Controller
    {
        private readonly Context _context;

        public SatisController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var degerler = _context.SatisHarekets
            // .Where(x => x.Durum == true)
              .Include(x => x.Cariler)
                .Include(x => x.Personel)
                .Include(x => x.Urun)
            .ToList();
            return View(degerler);
        }
        public IActionResult SatisEkle()
        {
            List<SelectListItem> deger1 = (from x in _context.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            List<SelectListItem> deger2 = (from x in _context.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            List<SelectListItem> deger3 = (from x in _context.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public IActionResult SatisEkle(SatisHareket s)
        {
            // Ürünü veritabanından getir
            var urun = _context.Uruns.FirstOrDefault(x => x.UrunID == s.Urun.UrunID);
            if (urun == null)
            {
                ModelState.AddModelError("", "Seçilen ürün bulunamadı.");
                System.Console.WriteLine("Secilen urun bulunamadı");
                return View(s);
            }

            // Seçilen cariyi getir
            var cari = _context.Carilers.FirstOrDefault(x => x.CariID == s.Cariler.CariID);
            if (cari == null)
            {
                ModelState.AddModelError("", "Seçilen cari bulunamadı.");
                System.Console.WriteLine("secilen cari bulunamadı");
                return View(s);
            }

            // Seçilen personeli getir
            var personel = _context.Personels.FirstOrDefault(x => x.PersonelID == s.Personel.PersonelID);
            if (personel == null)
            {
                ModelState.AddModelError("", "Seçilen personel bulunamadı.");
                System.Console.WriteLine("secilen personel bulunamadı");
                return View(s);
            }

            // Stok kontrolü yap
            // if (urun.Stok < s.Adet)
            // {
            //     ModelState.AddModelError("", $"Yetersiz stok! Mevcut stok: {urun.Stok}");
            //     return View(s);
            // }

            // Stoktan düş
            //  urun.Stok -= s.Adet;

            // Satış işlemi için sadece ID'leri set et
            var yeniSatis = new SatisHareket
            {
                Urun = urun,
                Cariler = cari,
                Personel = personel,
                Adet = s.Adet,
                Fiyat = s.Fiyat,
                Toplam = s.Adet * s.Fiyat,
                ToplamTutar = s.Fiyat * s.Adet,
                Tarih = DateTime.Now
            };

            // Satışı kaydet
            _context.SatisHarekets.Add(yeniSatis);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult SatisGetir(int id)
        {
            var satis = _context.SatisHarekets
                .Include(s => s.Urun)
                .Include(s => s.Cariler)
                .Include(s => s.Personel)
                .FirstOrDefault(s => s.Satisid == id);

            if (satis == null)
            {
                return NotFound();
            }

            ViewBag.Urunler = _context.Uruns
                .Select(u => new SelectListItem { Text = u.UrunAd, Value = u.UrunID.ToString() })
                .ToList();

            ViewBag.Cariler = _context.Carilers
                .Select(c => new SelectListItem { Text = c.CariAd + " " + c.CariSoyad, Value = c.CariID.ToString() })
                .ToList();

            ViewBag.Personeller = _context.Personels
                .Select(p => new SelectListItem { Text = p.PersonelAd + " " + p.PersonelSoyad, Value = p.PersonelID.ToString() })
                .ToList();

            return View(satis);
        }

        [HttpPost]
        public IActionResult SatisGuncelle(SatisHareket satis)
        {
            var mevcutSatis = _context.SatisHarekets
                .Include(s => s.Urun)
                .Include(s => s.Cariler)
                .Include(s => s.Personel)
                .FirstOrDefault(s => s.Satisid == satis.Satisid);

            if (mevcutSatis == null)
            {
                return NotFound();
            }

            // Güncellenen değerleri atama
            mevcutSatis.Urun = _context.Uruns.Find(satis.Urun.UrunID);
            mevcutSatis.Cariler = _context.Carilers.Find(satis.Cariler.CariID);
            mevcutSatis.Personel = _context.Personels.Find(satis.Personel.PersonelID);
            mevcutSatis.Adet = satis.Adet;
            mevcutSatis.Fiyat = satis.Fiyat;
            mevcutSatis.ToplamTutar = satis.Adet * satis.Fiyat;  // Otomatik hesaplama
            mevcutSatis.Toplam = satis.Adet * satis.Fiyat;  // Otomatik hesaplama
            mevcutSatis.Tarih = satis.Tarih;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult SatisDetay(int id)
        {
            System.Console.WriteLine("buradayım");
            var satislar = _context.SatisHarekets
                .Include(s => s.Urun)
                .Include(s => s.Cariler)
                .Include(s => s.Personel)
                .Where(s => s.Personel.PersonelID == id) // Personelin yaptığı satışları getir
                .ToList();

              


            return View(satislar);
        }


    }
}