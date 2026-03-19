namespace PlayList;

internal class Musica
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
}