namespace ScarpeCoEpicode.Models {
    public class FakeDB {
        public static List<Articolo> Articoli {get; set;} = new List<Articolo>();

        public static void AggiungiArticolo(Articolo nuovoArticolo) {
            nuovoArticolo.Id = !Articoli.Any() ? 1 : Articoli.Max(x => x.Id) + 1;
            Articoli.Add(nuovoArticolo);
        }

        public static List<Articolo> GetArticoli() {
            return Articoli;
        }

        public static Articolo GetArticoloById(int id) {
            return Articoli.FirstOrDefault(a => a.Id == id);
        }

        public static void UpdateArticolo(Articolo articoloAggiornato) {
            var indice = Articoli.FindIndex(a => a.Id == articoloAggiornato.Id);
            if(indice != -1) {
                Articoli[indice] = articoloAggiornato;
            }
        }   

        public static void DeleteArticolo(int id) {
            var articolo = Articoli.FirstOrDefault(a => a.Id == id);
            if(articolo != null){
                Articoli.Remove(articolo);
            }
        }

        public static void HideShowArticolo(int id) {
            var articolo = Articoli.FirstOrDefault(a => a.Id == id);
            if(articolo != null){
                articolo.VisibileInHomePage = !articolo.VisibileInHomePage;
      
        
            }
        }

    }
}