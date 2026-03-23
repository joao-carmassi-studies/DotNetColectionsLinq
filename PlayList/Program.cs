using System.Text.Json;
using PlayList;

var metalCore = new Playlist
{
  new Musica("1. Amen", "BMTH", 325),
  new Musica("2. Sleepwalking", "BMTH", 211),
  new Musica("3. Shadow Moses", "BMTH", 244),
  new Musica("4. Antivist", "BMTH", 238),
  new Musica("5. Doomed", "BMTH", 241),
};

Playlist.ListaMusicas(metalCore);

var musicaBuscada = metalCore.Find(musica => musica.Contains("Sleepwalking"));
if (musicaBuscada != null)
{
  Console.WriteLine($"\nMusica removida: {musicaBuscada}\n");
  metalCore.Remove(musicaBuscada);
  Playlist.ListaMusicas(metalCore);
}
else
{
  Console.WriteLine("\nMusica não encontrada\n");
}

Console.WriteLine("\nMusicas aleatorias: ");
var listaAleatoria = Playlist.SequenciaAleatoria(metalCore);
Playlist.ListaMusicas(listaAleatoria);

Console.WriteLine("\nMusicas ordenadas por tempo: ");
var listOrdenadaPorTempo = Playlist.OrdenaPorTempo(listaAleatoria);
Playlist.ListaMusicas(listOrdenadaPorTempo);

Console.WriteLine("\nTesta musicas repetidas: ");
metalCore.Add(new Musica("1. Amen", "BMTH", 325));
Playlist.ListaMusicas(metalCore);

var nomeDoArquivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "musicas.json");
using (var arquivo = new FileStream(nomeDoArquivo, FileMode.Create, FileAccess.Write))
{
  JsonSerializer.Serialize(arquivo, metalCore.ToList());
}
Console.WriteLine("\nArquivo serializado com sucesso!!!");

Console.ReadKey();