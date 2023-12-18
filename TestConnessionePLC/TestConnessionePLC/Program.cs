
using S7.Net;
using TestConnessionePLC;

using var plc = new Plc(CpuType.S71500, "192.168.2.111", 0, 0);

try
{

    plc.Open();

    if(!plc.IsConnected)
    {
        throw new Exception("Failed connection to plc");
    }
    Console.WriteLine("connected");

    var state = new CarroponteState
    {
        Sale = Convert.ToBoolean(plc.Read(DataType.DataBlock, 1, 0, VarType.Bit, 1)),
        Scende = Convert.ToBoolean(plc.Read(DataType.DataBlock, 1, 0, VarType.Bit, 1)),
        Avanti = Convert.ToBoolean(plc.Read(DataType.DataBlock, 1, 0, VarType.Bit, 1)),
        Indietro = Convert.ToBoolean(plc.Read(DataType.DataBlock, 1, 0, VarType.Bit, 1)),
        Destra = Convert.ToBoolean(plc.Read(DataType.DataBlock, 1, 0, VarType.Bit, 1)),
        Sinistra = Convert.ToBoolean(plc.Read(DataType.DataBlock, 1, 0, VarType.Bit, 1)),
        FineCorsaX = Convert.ToBoolean(plc.Read(DataType.DataBlock, 1, 0, VarType.Bit, 1)),
        FineCorsaY = Convert.ToBoolean(plc.Read(DataType.DataBlock, 1, 0, VarType.Bit, 1)),
        InizioCorsaX = Convert.ToBoolean(plc.Read(DataType.DataBlock, 1, 0, VarType.Bit, 1)),
        InizioCorsaY = Convert.ToBoolean(plc.Read(DataType.DataBlock, 1, 0, VarType.Bit, 1)),
        MovimentoX = Convert.ToBoolean(plc.Read(DataType.DataBlock, 1, 0, VarType.Bit, 1)),
        MovimentoY = Convert.ToBoolean(plc.Read(DataType.DataBlock, 1, 0, VarType.Bit, 1)),
        Movimento = Convert.ToBoolean(plc.Read(DataType.DataBlock, 1, 0, VarType.Bit, 1)),
    };

    Console.WriteLine(state);
}
catch(Exception e)
{
    Console.Error.WriteLine(e);
}

Console.ReadKey();
