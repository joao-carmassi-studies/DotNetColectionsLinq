namespace PlayList;

internal class Musica : IComparable<Musica>
{
  public string Nome { get; set; }
  public string Artista { get; set; }
  public int Duracao { get; set; }

  public Musica(string nome, string artista, int duracao)
  {
    Nome = nome;
    Artista = artista;
    Duracao = duracao;
  }

  public void MostraMusica()
  {
    Console.WriteLine(ToString());
  }

  public override string ToString()
  {
    return $"{Nome} ({Artista}) - {Duracao}";
  }

  public bool Contains(string nome)
  {
    return Nome.Contains(nome);
  }

  public int CompareTo(Musica? obj)
  {
    return obj == null ? 1 : Duracao.CompareTo(obj.Duracao);
  }

  public override bool Equals(object? obj)
  {
    return obj is Musica m &&
      Nome == m.Nome &&
      Duracao == m.Duracao;
  }

  public override int GetHashCode()
  {
    return HashCode.Combine(Nome, Artista, Duracao);
  }
}