using System.Collections;

namespace PlayList;

class Playlist : ICollection<Musica>
{
  public List<Musica> Musicas { get; private set; } = [];

  public int Count => Musicas.Count;

  public bool IsReadOnly => false;

  public void Add(Musica item)
  {
    Musicas.Add(item);
  }

  public void Clear()
  {
    Musicas.Clear();
  }

  public bool Contains(Musica item)
  {
    return Musicas.Contains(item);
  }

  public void CopyTo(Musica[] array, int arrayIndex)
  {
    Musicas.CopyTo(array, arrayIndex);
  }

  public IEnumerator<Musica> GetEnumerator()
  {
    return Musicas.GetEnumerator();
  }

  public bool Remove(Musica item)
  {
    return Musicas.Remove(item);
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    return GetEnumerator();
  }

  public Musica? Find(string musica)
  {
    return Musicas.Find(m => m.Nome == musica);
  }

  public static void ListaMusicas(IEnumerable<Musica> playlist)
  {
    foreach (var musica in playlist)
    {
      musica.MostraMusica();
    }
  }

  public static IEnumerable<Musica> SequenciaAleatoria(Playlist playlist)
  {
    var random = new Random();
    var lista = playlist.Musicas.ToList();

    while (lista.Count > 0)
    {
      var i = random.Next(lista.Count);
      yield return lista[i];
      lista.RemoveAt(i);
    }
  }

  internal Musica? Find(Func<Musica, bool> value)
  {
    return Musicas.Find(m => value(m));
  }
}