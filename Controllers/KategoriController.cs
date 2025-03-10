using Microsoft.AspNetCore.Mvc;
using E_ticaret.Models.Sınıflar;
namespace E_Ticaret.Controllers
{
    public class KategoriController : Controller
    {
        private readonly Context _context;
        public KategoriController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var degerler = _context.Kategoris.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KategoriEkle(Kategori k)
        {
            _context.Kategoris.Add(k);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult KategoriSil(int id)
        {
            var kategori = _context.Kategoris.Find(id);
            _context.Kategoris.Remove(kategori);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult KategoriGetir(int id)
        {
            var kategori = _context.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }
        [HttpPost]
        public IActionResult KategoriGuncelle(Kategori k)
        {
            System.Console.WriteLine("burda");
            var kategori = _context.Kategoris.Find(k.KategoriID);
            kategori.KategoriAd = k.KategoriAd;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}