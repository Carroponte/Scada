
using S7.Net;
using TestConnessionePLC;

using var _plc = new Plc(CpuType.S71500, "192.168.2.111", 0, 0);

CarroponteState _carroponteState = new();

bool ReadStatus()
{

    _plc.Open();

    if (!_plc.IsConnected)
    {
        throw new Exception("Failed connection to plc");
    }

    Console.WriteLine("connected");

    // read from plc
    try
    {
        _carroponteState.Manuale = Convert.ToBoolean(_plc.Read("DB1.DBX0.2"));
        _carroponteState.Automatico = Convert.ToBoolean(_plc.Read("DB1.DBX1.2"));
        _carroponteState.Emergenza = Convert.ToBoolean(_plc.Read("DB1.DBX0.1"));

        _carroponteState.Indietro = Convert.ToBoolean(_plc.Read("DB1.DBX0.4"));
        _carroponteState.Avanti = Convert.ToBoolean(_plc.Read("DB1.DBX0.3"));
        _carroponteState.Destra = Convert.ToBoolean(_plc.Read("DB1.DBX0.5"));
        _carroponteState.Sinistra = Convert.ToBoolean(_plc.Read("DB1.DBX0.6"));
        _carroponteState.Sale = Convert.ToBoolean(_plc.Read("DB1.DBX1.0"));
        _carroponteState.Scende = Convert.ToBoolean(_plc.Read("DB1.DBX0.7"));

        _carroponteState.FineCorsaX = Convert.ToBoolean(_plc.Read("DB2.DBX0.7"));
        _carroponteState.InizioCorsaX = Convert.ToBoolean(_plc.Read("DB2.DBX1.1"));
        _carroponteState.FineCorsaY = Convert.ToBoolean(_plc.Read("DB2.DBX1.0"));
        _carroponteState.InizioCorsaY = Convert.ToBoolean(_plc.Read("DB2.DBX1.2"));
        _carroponteState.MovimentoX = Convert.ToBoolean(_plc.Read("DB2.DBX1.3"));
        _carroponteState.MovimentoY = Convert.ToBoolean(_plc.Read("DB2.DBX1.4"));
        _carroponteState.Movimento = Convert.ToBoolean(_plc.Read("DB2.DBX1.5"));

        _carroponteState.Posizione = Convert.ToInt32(_plc.Read("DB3.DBX4.0"));
        _carroponteState.Destinazione = Convert.ToInt32(_plc.Read("DB3.DBX2.0"));
    }
    catch (Exception e)
    {
        Console.Error.WriteLine(e);
        return false;
    }

    return true;

}

ReadStatus();

_plc.Write("DB1.DBX0.4", true);


Console.Read();