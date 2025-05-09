using Bilisim.HelloMvc.Models;
using Bilisim.HelloMvc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bilisim.HelloMvc.Controllers
{
    public class OgrenciController : Controller
    {
        public ViewResult Index()//Action
        {
            return View("AnaSayfa");
        }
        public ViewResult OgrenciDetay(int id)
        {
            Ogrenci ogrenci = null;
            Ogretmen ogrt = null;

            if (id == 1)
            {
                ogrenci = new Ogrenci { Ogrenciid = 1, Ad = "Ali", Soyad = "Veli" };
                ogrt = new Ogretmen { Id = 1, Ad = "Osman", Soyad = "Demir" };
            }
            else if (id == 2)
            {
                ogrenci = new Ogrenci { Ogrenciid = 2, Ad = "Ahmet", Soyad = "Mehmet" };
                ogrt = new Ogretmen { Id = 2, Ad = "Cafer", Soyad = "Gündüz" };

            }
            ViewData["ogr"] = ogrenci;
            ViewBag.student = ogrenci;
            ViewBag.ogretmen = ogrt;

            var dto = new OgrenciDetayDTO { Ogrenci = ogrenci, Ogretmen = ogrt };
            return View(dto);
        }

        public ViewResult OgrenciListe()
        {
            //2 adet öğrenci nesnesi oluştur
            //Liste oluştur
            //Öğrencileri listeye ekle
            //Listeyi View'e gönder



            //Ogrenci ogrenci = new Ogrenci { Ogrenciid = 1, Ad = "Ali", Soyad = "Veli" };
            //Ogrenci ogrenci1 = new Ogrenci { Ogrenciid = 2, Ad = "Ahmet", Soyad = "Mehmet" };

            //List<Ogrenci> list = new List<Ogrenci>();
            //list.Add(ogrenci);
            //list.Add(ogrenci1);

            var lst = new List<Ogrenci>
            {
                new Ogrenci { Ogrenciid = 1, Ad = "Ali", Soyad = "Veli" },
                new Ogrenci { Ogrenciid = 2, Ad = "Ahmet", Soyad = "Mehmet" }
            };
            //ViewBag.ogrenciler = list;
            return View(lst);
        }

        [HttpGet]
        public ViewResult OgrenciEkle()
        {
            return View();
        }

        [HttpPost]
        public ViewResult OgrenciEkle(Ogrenci ogr)
        {
            using (var ctx=new OkulDbContext())
            {
                ctx.Ogrenciler.Add(ogr);
                ctx.SaveChanges();
            }
            return View();
        }
    }
}

//Controllerdan->View'e veri taşıma
//1-ViewData: Koleksiyondur.Anahtar-Değer çiftinden oluşur. (Key-Value Pair)
// Keyler tekil olmalıdır. Keyler string, Value'lar object'dir.
//2-ViewBag: Dynamic bir yapıdır ve taşıdığı verinin türü, runtime sırasında belirlenir.
//3-Model
