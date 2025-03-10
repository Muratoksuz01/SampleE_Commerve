using E_ticaret.Models.Sınıflar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Controllers
{
    public class CariController : Controller
    {
        private readonly Context _context;

        public CariController(Context context)
        {
            _context = context;
        }

        // Cari Listesi
        public IActionResult Index()
        {
            var degerler = _context.Carilers.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }

        // Yeni Cari Ekleme (GET)
        [HttpGet]
        public IActionResult CariEkle()
        {
            return View();
        }

        // Yeni Cari Ekleme (POST)
        [HttpPost]
        public IActionResult CariEkle(Cariler c)
        {
            if (ModelState.IsValid)
            {
                c.Durum = true;
                _context.Carilers.Add(c);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }

        // Cari Silme
        public IActionResult CariSil(int id)
        {
            var cari = _context.Carilers.Find(id);
            if (cari != null)
            {
                cari.Durum = false;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Cari Güncelleme - GET
        [HttpGet]
        public IActionResult CariGetir(int id)
        {
            System.Console.WriteLine("CariGetir");
            var cari = _context.Carilers.Find(id);
            if (cari == null)
            {
                return NotFound();
            }
            return View("CariGetir", cari);
        }

        // Cari Güncelleme - POST
        [HttpPost]
        public IActionResult CariGuncelle(Cariler c)
        {   
            ModelState.Remove("SatisHarekets");
            if (ModelState.IsValid)
            {
                var cari = _context.Carilers.Find(c.CariID);
                if (cari != null)
                {
                    cari.CariAd = c.CariAd;
                    cari.CariSoyad = c.CariSoyad;
                    cari.CariSehir = c.CariSehir;
                    cari.CariMail = c.CariMail;
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                // Hataları konsola yazdırıyoruz
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("Error: " + error.ErrorMessage);
                }

                return View("CariGetir", c);
            }
        }


        // Cari Detay
        public IActionResult CariSatisGecmisi(int id)
        {
            var satisHareketleri = _context.SatisHarekets
                                          .Include(s => s.Urun)
                                          .Include(s => s.Personel)
                                          .Where(x => x.Cariler.CariID == id)
                                          .ToList();

            var cariAdSoyad = _context.Carilers
                                      .Where(x => x.CariID == id)
                                      .Select(y => y.CariAd + " " + y.CariSoyad)
                                      .FirstOrDefault();

            ViewBag.cariAdSoyad = cariAdSoyad;
            return View(satisHareketleri);
        }
    }
}
