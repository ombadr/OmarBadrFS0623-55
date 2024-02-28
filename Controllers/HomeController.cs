using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ScarpeCoEpicode.Models;

namespace ScarpeCoEpicode.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() {
        if(!FakeDB.Articoli.Any()) {
            FakeDB.AggiungiArticolo(new Articolo {Nome = "Articolo 1", Prezzo = 100, Descrizione = "Descrizione articolo 1", VisibileInHomePage = true});
            FakeDB.AggiungiArticolo(new Articolo {Nome = "Articolo 2", Prezzo = 100, Descrizione = "Descrizione articolo 2", VisibileInHomePage = true});
            FakeDB.AggiungiArticolo(new Articolo {Nome = "Articolo 3", Prezzo = 100, Descrizione = "Descrizione articolo 3", VisibileInHomePage = true});
            FakeDB.AggiungiArticolo(new Articolo {Nome = "Articolo 4", Prezzo = 100, Descrizione = "Descrizione articolo 4", VisibileInHomePage = true});
            FakeDB.AggiungiArticolo(new Articolo {Nome = "Articolo 5", Prezzo = 100, Descrizione = "Descrizione articolo 5", VisibileInHomePage = false});
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
