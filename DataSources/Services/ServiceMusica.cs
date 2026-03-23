namespace DataSources.Services;

internal class ServiceMusica
{
  public static void ExibeMusicas(IEnumerable<Musica> musicas)
  {
    Console.WriteLine("Exibindo musicas");
    foreach (var musica in musicas)
    {
      Console.WriteLine($"\t- {musica.Nome} ({musica.Artista}) - {musica.Duracao}");
    }
  }

  public static IEnumerable<Musica> ObterMusicas(StreamReader stream)
  {
    var linha = stream.ReadLine();
    while (linha is not null)
    {
      var partes = linha.Split(";");
      var musica = new Musica(partes[0], partes[1], int.Parse(partes[2]));
      yield return musica;
      linha = stream.ReadLine();
    }
  }
}
