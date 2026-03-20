using System.Collections;
using System.Net.NetworkInformation;

namespace PlayList;

internal class Playlist : ICollection<Musica>
{
  public HashSet<Musica> SetMusicas { get; private set; } = [];
  public List<Musica> Musicas { get; private set; } = [];

  public int Count => Musicas.Count;

  public bool IsReadOnly => false;

  public void Add(Musica item)
  {
    if (SetMusicas.Add(item))
    {
      Musicas.Add(item);
    }
  }

  public void Clear()
  {
    SetMusicas.Clear();
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
    if (SetMusicas.Remove(item))
    {
      return Musicas.Remove(item);
    }
    return false;
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

  public static IEnumerable<Musica> OrdenaPorTempo(IEnumerable<Musica> playlist)
  {
    var lista = playlist.ToList();
    lista.Sort();
    return lista;
  }
}