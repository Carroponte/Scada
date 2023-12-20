using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConnessionePLC;

public record CarroponteState
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
    public bool Manuale { get; set; }
    public bool Automatico { get; set; }
    public bool AvviaAutomatico { get; set; }
    public bool StopAutomatico { get; set; }
    public bool ResetAutomatico { get; set; }

}
