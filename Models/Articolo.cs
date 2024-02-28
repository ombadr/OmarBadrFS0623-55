namespace ScarpeCoEpicode.Models {
    public class Articolo {
        public int Id {get; set;}
        public string Nome {get; set;}

        public decimal Prezzo {get; set;}
        public string Descrizione {get; set;}
        // public string ImmagineCopertinaUrl {get; set;}
        // public string ImmagineAggiuntivaUrl1 {get; set;}
        // public string ImmagineAggiuntivaUrl2 {get; set;}

        public bool VisibileInHomePage {get; set;}
    }
}