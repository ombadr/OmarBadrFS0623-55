using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ScarpeCoEpicode.Models;


namespace ScarpeCoEpicode.Controllers;

public class AdminController : Controller {
    public IActionResult Index() {
        if(!FakeDB.Articoli.Any()) {
            FakeDB.AggiungiArticolo(new Articolo {Nome = "Articolo 1", Prezzo = 100, Descrizione = "Descrizione articolo 1", VisibileInHomePage = true});
            FakeDB.AggiungiArticolo(new Articolo {Nome = "Articolo 2", Prezzo = 100, Descrizione = "Descrizione articolo 2", VisibileInHomePage = true});
            FakeDB.AggiungiArticolo(new Articolo {Nome = "Articolo 3", Prezzo = 100, Descrizione = "Descrizione articolo 3", VisibileInHomePage = true});
            FakeDB.AggiungiArticolo(new Articolo {Nome = "Articolo 4", Prezzo = 100, Descrizione = "Descrizione articolo 4", VisibileInHomePage = true});
            FakeDB.AggiungiArticolo(new Articolo {Nome = "Articolo 5", Prezzo = 100, Descrizione = "Descrizione articolo 5", VisibileInHomePage = false});
        }

        return View(FakeDB.GetArticoli().ToList());
    }

    public IActionResult Dettaglio(int id) {
        var articolo = FakeDB.GetArticoloById(id);
        if(articolo != null) {
            return View(articolo);
        } else {
            return NotFound();
        }
    }

    [HttpPost]
    public IActionResult NascondiArticolo(int id) {
        FakeDB.HideShowArticolo(id);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult EliminaArticolo(int id) {
        FakeDB.DeleteArticolo(id);
        return RedirectToAction("Index");   
    }

    public IActionResult Aggiungi() {
        return View();
    }

    [HttpPost]
    public IActionResult Aggiungi(Articolo articolo) {

    if(ModelState.IsValid) {
        FakeDB.AggiungiArticolo(articolo);
        return RedirectToAction("Index");
    }

        return View(articolo);
    }

   public IActionResult Modifica(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var articolo = FakeDB.GetArticoloById(id.Value);
    if (articolo == null)
    {
        return NotFound();
    }
    return View(articolo);
}
    [HttpPost]
    public IActionResult Modifica(int id, [Bind("Id, Nome, Prezzo, Descrizione,VisibileInHomePage")] Articolo articolo) {
       if(id != articolo.Id) {
            return NotFound();
       } 

       if(ModelState.IsValid) {
        FakeDB.UpdateArticolo(articolo);
        return RedirectToAction(nameof(Index));
       }

       return View(articolo);
    }
}