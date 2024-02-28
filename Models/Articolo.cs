using Microsoft.AspNetCore.Http;

namespace ScarpeCoEpicode.Models {
    public class Articolo {
        public int Id {get; set;}
        public string Nome {get; set;}

        public decimal Prezzo {get; set;}
        public string Descrizione {get; set;}
        public IFormFile ImmagineCopertinaFile {get; set;}
        public string ImmagineCopertinaUrl {get; set;}
        // public IFormFile ImmagineAggiuntivaUrl1File {get; set;}

        // public string ImmagineAggiuntivaUrl1Url {get; set;}
        // public IFormFile ImmagineAggiuntivaUrl2File {get; set;}
        // public string ImmagineAggiuntivaUrl2 {get; set;}



        public bool VisibileInHomePage {get; set;}
    }
}