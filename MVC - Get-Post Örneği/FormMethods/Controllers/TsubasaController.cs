using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormMethods.Controllers
{
    public class TsubasaController : Controller
    {
        // GET: Home


        /*
          
         GET : QueryString olarak datayı gönderir.Bu nedenle tarayıcıya kaydedilebilir ve geçmişte görülebilir. Güvenli değildir.Cache'lenebilir.Güvenli değildir. Url'de gönderildiği için karakter sınırlaması vardır. Yalnızca ASCII karakterler gonderilebilir.
         
         
          POST : QueryString olarak gonderilmez.Haliyle Irl'de gorunmez.Bu nedenle tarayıcıya kaydedilemez, geçmişte görülemez Cache'lenemez, ama Güvenli. Her turlu data post ile gonderilebilir.
         

         
         */
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AraGet(string ifade, string birDigerIfade)
        {
            //arama işlemleri.....

            object result = ifade + " kelimesi GET yönetimi ile arandı. Diğer aranan kelime de : " + birDigerIfade;

            return View("Sonuc",result);
        }

        public ActionResult AraPost(string aranacakKelime)
        {
            //arama işlemleri.....

            object result = aranacakKelime + " kelimesi POST yöntemi ile arandı";

            return View("Sonuc", result);
        }
    }
}