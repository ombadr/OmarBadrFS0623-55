using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ScarpeCoEpicode.Models;
using Microsoft.AspNetCore.Http;

namespace ScarpeCoEpicode.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() {
        if(!FakeDB.Articoli.Any()) {
            // FakeDB.AggiungiArticolo(new Articolo {Nome = "Articolo 1", Prezzo = 100, Descrizione = "Descrizione articolo 1", VisibileInHomePage = true, ImmagineCopertinaUrl = "/images/prodotti/sheep-5.jpg", ImmagineAggiuntivaUrl1Url = "/images/prodotti/sheep-5.jpg", ImmagineAggiuntivaUrl2 = "/images/prodotti/sheep-5.jpg"});
            FakeDB.AggiungiArticolo(new Articolo {Nome = "Articolo 1", Prezzo = 100, Descrizione = "Descrizione articolo 1", VisibileInHomePage = true, ImmagineCopertinaUrl = "/images/prodotti/sheep-5.jpg"});
            
        }

        return View(FakeDB.GetArticoli().Where(a => a.VisibileInHomePage).ToList());
    }

    public IActionResult Dettaglio(int id) {
        var articolo = FakeDB.GetArticoloById(id);
        if(articolo != null) {
            return View(articolo);
        } else {
            return NotFound();
        }
    }
}
