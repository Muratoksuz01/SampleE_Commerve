using Microsoft.AspNetCore.Mvc;
using E_ticaret.Models.Sınıflar;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;
namespace E_Ticaret.Controllers
{
    public class FaturaController : Controller
    {
        private readonly Context _context;
        public FaturaController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var degerler = _context.Faturas.ToList();
            return View(degerler);
        }
        public IActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FaturaEkle(Faturalar f)
        {
            _context.Faturas.Add(f);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult FaturaGetir(int id)
        {
            var deger = _context.Faturas.Find(id);
            return View(deger);
        }
        public IActionResult FaturaGuncelle(Faturalar f)
        {
            _context.Faturas.Update(f);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult FaturaDetay(int id)
        {
            var degerler = _context.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }

        public IActionResult FaturaKalemEkle()
        {
            ViewData["Faturalar"] = _context.Faturas.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult FaturaKalemEkle(FaturaKalem f)
        {
            _context.FaturaKalems.Add(f);
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}