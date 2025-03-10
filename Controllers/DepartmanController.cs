using Microsoft.AspNetCore.Mvc;
using E_ticaret.Models.Sınıflar;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;
namespace E_Ticaret.Controllers
{
    public class DepartmanController : Controller
    {
        private readonly Context _context;
        public DepartmanController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var degerler = _context.Departmans.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DepartmanEkle(Departman d)
        {
            _context.Departmans.Add(d);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DepartmanSil(int id)
        {
            var departman = _context.Departmans.Find(id);
            departman.Durum = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DepartmanGetir(int id)
        {
            var departman = _context.Departmans.Find(id);
            return View("DepartmanGetir", departman);
        }

        [HttpPost]
        public IActionResult DepartmanGuncelle(Departman d)
        {
            var departman = _context.Departmans.Find(d.DepartmanID);
            departman.DepartmanAd = d.DepartmanAd;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DepartmanDetay(int id)
        {
            var degerler = _context.Personels.Where(x => x.Departman.DepartmanID == id).ToList();
            var dpt = _context.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(degerler);
        }

        public IActionResult DepartmanPersonelSatis(int id)
        {
            // Personel, Cariler ve Urun ile birlikte SatisHareketleri çekiyoruz
            var degerler = _context.SatisHarekets
                                   .Include(s => s.Personel)  // Personel ilişkisini dahil ediyoruz
                                   .Include(s => s.Cariler)   // Cariler ilişkisini dahil ediyoruz
                                   .Include(s => s.Urun)      // Urun ilişkisini dahil ediyoruz
                                   .Where(x => x.Personel.PersonelID == id)
                                   .ToList();

            // Personelin adını ve soyadını alıyoruz
            var per = _context.Personels
                              .Where(x => x.PersonelID == id)
                              .Select(y => y.PersonelAd + " " + y.PersonelSoyad)
                              .FirstOrDefault();

            // Personel bilgilerini ViewBag'e aktarıyoruz
            ViewBag.dpers = per;

            return View(degerler);
        }
    }
}
