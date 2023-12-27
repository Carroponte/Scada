using S7.Net;

namespace CarroponteAPI;

public static class CarroponteInterface
{
    private static Plc _plc = new(CpuType.S71500, "192.168.2.111", 0, 0);

    private static CarroponteState _carroponteState = new();

    private static bool TryConnect()
    {
        try
        {
            _plc.Open();

            if(!_plc.IsConnected)
            {
                throw new Exception("Failed connection to plc");
            }
            
            Console.WriteLine("connected");
            return true;
        }
        catch(Exception e)
        {
            Console.Error.WriteLine(e);
            return false;
        }
    }
    
    
    private static bool ReadStatus()
    {
        // read from plc
        try
        {
            _carroponteState.Indietro = Convert.ToBoolean(_plc.Read("DB1.DBX0.2"));
            _carroponteState.Avanti = Convert.ToBoolean(_plc.Read("DB1.DBX0.3"));
            _carroponteState.Destra = Convert.ToBoolean(_plc.Read("DB1.DBX0.4"));
            _carroponteState.Sinistra = Convert.ToBoolean(_plc.Read("DB1.DBX0.5"));
            _carroponteState.Sale = Convert.ToBoolean(_plc.Read("DB1.DBX0.6"));
            _carroponteState.Scende = Convert.ToBoolean(_plc.Read("DB1.DBX0.7"));
            
            // // read _carroponteState from _plc
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            return false;
        }

        return true;
        
    }

    public static CarroponteState GetStatus() => _carroponteState;

    public static void ToggleSale()
    {
        _carroponteState.Sale = !_carroponteState.Sale;
        
        
    }

    public static void ToggleScende()
    {
        _carroponteState.Scende = !_carroponteState.Scende;
        
        
    }

    public static void ToggleAvanti()
    {
        _carroponteState.Avanti = !_carroponteState.Avanti;
        
        
    }

    public static void ToggleIndietro()
    {
        _carroponteState.Indietro = !_carroponteState.Indietro;
        
        
    }

    public static void ToggleSinistra()
    {
        _carroponteState.Sinistra = !_carroponteState.Sinistra;
        
        
    }

    public static void ToggleDestra()
    {
        _carroponteState.Destra = !_carroponteState.Destra;

        
    }


    private static void Disconnect()
    {
        _plc.Close();
    }
}