using System.Text.Json;
using System.Text.Json.Serialization;

namespace CarroponteAPI;

public sealed class CarroponteState
{
    public bool Sale { get; set; }
    public bool Scende { get; set; }
    public bool Avanti { get; set; }
    public bool Indietro { get; set; }
    public bool Sinistra { get; set; }
    public bool Destra { get; set; }
    
    public bool FineCorsaX { get; set; }
    
    public bool FineCorsaY { get; set; }
    
    public bool InizioCorsaX { get; set; }
    
    public bool InizioCorsaY { get; set; }
    
    public bool MovimentoX { get; set; }
    
    public bool MovimentoY { get; set; }
    
    public bool Movimento { get; set; }


    public override string ToString() => JsonSerializer.Serialize(this);
}
