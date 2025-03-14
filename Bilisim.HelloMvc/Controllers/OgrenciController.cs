﻿using Bilisim.HelloMvc.Models;
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
    }
}

//Controllerdan->View'e veri taşıma
//1-ViewData: Koleksiyondur.Anahtar-Değer çiftinden oluşur. (Key-Value Pair)
// Keyler tekil olmalıdır. Keyler string, Value'lar object'dir.
//2-ViewBag: Dynamic bir yapıdır ve taşıdığı verinin türü, runtime sırasında belirlenir.
//3-Model
