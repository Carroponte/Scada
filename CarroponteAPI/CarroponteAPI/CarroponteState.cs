using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CarroponteAPI;

public sealed class CarroponteState
{
    public bool Manuale { get; set; }
    public bool Automatico { get; set; }
    public bool Emergenza { get; set; }

    public bool Avanti { get; set; }
    public bool Indietro { get; set; }
    public bool Destra { get; set; }
    public bool Sinistra { get; set; }
    public bool Sale { get; set; }
    public bool Scende { get; set; }

    public bool FineCorsaX { get; set; }

    public bool FineCorsaY { get; set; }

    public bool InizioCorsaX { get; set; }

    public bool InizioCorsaY { get; set; }

    public bool MovimentoX { get; set; }

    public bool MovimentoY { get; set; }

    public bool Movimento { get; set; }

    public int Posizione { get; set; }
    public int Destinazione { get; set; }

    public override string ToString() => JsonConvert.SerializeObject(this);
}
