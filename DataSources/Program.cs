
using DataSources.Services;

using var arquivo = new FileStream("musicas.csv", FileMode.Open, FileAccess.Read);
using var stream = new StreamReader(arquivo);

var musicas = ServiceMusica
  .ObterMusicas(stream)
  .Where(m => m.Artista == "The Weeknd" && m.Duracao >= 400)
  .Take(5);

ServiceMusica.ExibeMusicas(musicas);

Console.ReadKey();