
public class Deportista
{

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Country { get; set; }
}


public class Resultado
{

    public int Id { get; set; }
    public int DeportistaId { get; set; }
    public string? Modalid { get; set; }
    public int Peso { get; set; }

    public virtual Deportista? Deportista { get; set; }
}