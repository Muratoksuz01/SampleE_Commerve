using Microsoft.AspNetCore.Mvc;
using E_ticaret.Models.Sınıflar;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Ticaret.Controllers
{

    public class UrunController : Controller
    {
        private readonly Context _context;
        public UrunController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var degerler = _context.Uruns.Where(x => x.Durum == true).Include(x => x.Kategori).ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult UrunEkle()
        {
            ViewBag.Kategoriler = _context.Kategoris
                .Select(k => new SelectListItem
                {
                    Value = k.KategoriID.ToString(),
                    Text = k.KategoriAd
                }).ToList();

            return View();
        }
        [HttpPost]
        public IActionResult UrunEkle(Urun u)
        {

            System.Console.WriteLine("burada");
            if (!ModelState.IsValid)
            {
                // Hataları konsola yazdırma
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    System.Console.WriteLine($"Error: {error.ErrorMessage}");
                }
            }
            if (ModelState.IsValid)
            {
                _context.Uruns.Add(u);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Kategoriler = _context.Kategoris
                .Select(k => new SelectListItem
                {
                    Value = k.KategoriID.ToString(),
                    Text = k.KategoriAd
                }).ToList();

            return View(u);
        }

        public IActionResult UrunSil(int id)
        {
            var urun = _context.Uruns.Find(id);
            urun.Durum = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult UrunGetir(int id)
        {
            var urun = _context.Uruns.Find(id);
            ViewBag.Kategoriler = _context.Kategoris
                .Select(k => new SelectListItem
                {
                    Value = k.KategoriID.ToString(),
                    Text = k.KategoriAd
                }).ToList();
            return View("UrunGetir", urun);
        }
        public IActionResult UrunGuncelle(Urun u)
        {
            System.Console.WriteLine("burada");
            var urun = _context.Uruns.Find(u.UrunID);
            urun.UrunAd = u.UrunAd;
            urun.Marka = u.Marka;
            urun.Stok = u.Stok;
            urun.AlisFiyat = u.AlisFiyat;
            urun.SatisFiyat = u.SatisFiyat;
            urun.Durum = u.Durum;
            urun.UrunGorsel = u.UrunGorsel;
            urun.KategoriID = u.KategoriID;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UrunListesi()
        {
            var degerler = _context.Uruns.Where(x => x.Durum == true).Include(x => x.Kategori).ToList();
            return View(degerler);
        }
    }
}
