using E_ticaret.Models.Sınıflar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret.Controllers
{
    public class PersonelController : Controller
    {
        private readonly Context _context;

        public PersonelController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var degerler = _context.Personels
            // .Where(x => x.Durum == true)
            .Include(x=>x.Departman)
            .ToList();
            return View(degerler);
        }
  
        public IActionResult PersonelEkle()
        {
            var degerler = _context.Departmans.ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult PersonelEkle(Personel p)
        {
            _context.Personels.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult PersonelGetir(int id)
        {
            var per = _context.Personels.Find(id);
            var departman = _context.Departmans.ToList();
            ViewBag.dgr = departman;
            System.Console.WriteLine(per.PersonelAd);
            return View(per);
        }
        public IActionResult PersonelGuncelle(Personel p)
        {
            var per = _context.Personels.Include(x => x.Departman) // Departman bilgisini de getir
                      .FirstOrDefault(x => x.PersonelID == p.PersonelID);
            per.PersonelAd = p.PersonelAd;
            per.PersonelSoyad = p.PersonelSoyad;
            per.PersonelGorsel = p.PersonelGorsel;
            per.DepartmanID = p.DepartmanID;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}