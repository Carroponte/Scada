using S7.Net;

namespace CarroponteAPI;

public static class CarroponteInterface
{
    private static readonly Plc Plc = new(CpuType.S71500, "192.168.2.111", 0, 0);

    private static readonly CarroponteState CarroponteState = new();

    private static bool TryConnect()
    {
        if (Plc.IsConnected)
        {
            return true;
        }

        try
        {
            Plc.Open();

            if (!Plc.IsConnected)
            {
                throw new Exception("unable to connect");
            }

            Console.WriteLine("connected");
            return true;
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            return false;
        }
    }


    private static bool ReadStatus()
    {
        if(!Plc.IsConnected)
        {
            return false;
        }

        // read from plc
        try
        {
            CarroponteState.Manuale = Convert.ToBoolean(Plc.Read("DB1.DBX0.2"));
            CarroponteState.Emergenza = Convert.ToBoolean(Plc.Read("DB1.DBX0.1"));

            CarroponteState.Indietro = Convert.ToBoolean(Plc.Read("DB1.DBX0.4"));
            CarroponteState.Avanti = Convert.ToBoolean(Plc.Read("DB1.DBX0.3"));
            CarroponteState.Destra = Convert.ToBoolean(Plc.Read("DB1.DBX0.5"));
            CarroponteState.Sinistra = Convert.ToBoolean(Plc.Read("DB1.DBX0.6"));
            CarroponteState.Sale = Convert.ToBoolean(Plc.Read("DB1.DBX1.0"));
            CarroponteState.Scende = Convert.ToBoolean(Plc.Read("DB1.DBX0.7"));

            CarroponteState.FineCorsaX = Convert.ToBoolean(Plc.Read("DB2.DBX0.7"));
            CarroponteState.InizioCorsaX = Convert.ToBoolean(Plc.Read("DB2.DBX1.1"));
            CarroponteState.FineCorsaY = Convert.ToBoolean(Plc.Read("DB2.DBX1.0"));
            CarroponteState.InizioCorsaY = Convert.ToBoolean(Plc.Read("DB2.DBX1.2"));
            CarroponteState.MovimentoX = Convert.ToBoolean(Plc.Read("DB2.DBX1.3"));
            CarroponteState.MovimentoY = Convert.ToBoolean(Plc.Read("DB2.DBX1.4"));
            CarroponteState.Movimento = Convert.ToBoolean(Plc.Read("DB2.DBX1.5"));

            CarroponteState.Posizione = Convert.ToInt32(Plc.Read("DB3.DBX4.0"));
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            return false;
        }

        return true;

    }

    public static CarroponteState GetStatus()
    {
        TryConnect();

        ReadStatus();

        return CarroponteState;
    }

    public static void ToggleSale()
    {
        TryConnect();

        CarroponteState.Sale = !CarroponteState.Sale;

        Plc.Write("DB1.DBX1.0", CarroponteState.Sale);
    }

    public static void ToggleScende()
    {
        TryConnect();

        CarroponteState.Scende = !CarroponteState.Scende;

        Plc.Write("DB1.DBX0.7", CarroponteState.Scende);
    }

    public static void ToggleAvanti()
    {
        TryConnect();

        CarroponteState.Avanti = !CarroponteState.Avanti;

        Plc.Write("DB1.DBX0.3", CarroponteState.Avanti);
    }

    public static void ToggleIndietro()
    {
        TryConnect();

        CarroponteState.Indietro = !CarroponteState.Indietro;

        Plc.Write("DB1.DBX0.4", CarroponteState.Indietro);
    }

    public static void ToggleSinistra()
    {
        TryConnect();

        CarroponteState.Sinistra = !CarroponteState.Sinistra;

        Plc.Write("DB1.DBX0.6", CarroponteState.Avanti);
    }

    public static void ToggleDestra()
    {
        TryConnect();

        CarroponteState.Destra = !CarroponteState.Destra;

        Plc.Write("DB1.DBX0.5", CarroponteState.Avanti);
    }

    private static void Disconnect()
    {
        if(Plc.IsConnected)
        {
            Plc.Close();
        }
    }
}