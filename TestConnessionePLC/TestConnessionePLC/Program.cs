
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
        Sale = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 1, startByteAdr: 9, VarType.Bit, 1)),
        Scende = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 1, startByteAdr: 8, VarType.Bit, 1)),
        Avanti = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 1, startByteAdr: 5, VarType.Bit, 1)),
        Indietro = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 1, startByteAdr: 4, VarType.Bit, 1)),
        Destra = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 1, startByteAdr: 6, VarType.Bit, 1)),
        Sinistra = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 1, startByteAdr: 7, VarType.Bit, 1)),
        FineCorsaX = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 2, startByteAdr: 7, VarType.Bit, 1)),
        FineCorsaY = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 2, startByteAdr: 8, VarType.Bit, 1)),
        InizioCorsaX = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 2, startByteAdr: 9, VarType.Bit, 1)),
        InizioCorsaY = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 2, startByteAdr: 10, VarType.Bit, 1)),
        MovimentoX = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 2, startByteAdr: 11, VarType.Bit, 1)),
        MovimentoY = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 2, startByteAdr: 12, VarType.Bit, 1)),
        Movimento = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 2, startByteAdr: 13, VarType.Bit, 1)),
        Manuale = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 1, startByteAdr: 3, VarType.Bit, 1)),
        Automatico = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 1, startByteAdr: 11, VarType.Bit, 1)),
        AvviaAutomatico = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 1, startByteAdr:13, VarType.Bit, 1)),
        StopAutomatico = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 1, startByteAdr: 14, VarType.Bit, 1)),
        ResetAutomatico = Convert.ToBoolean(plc.Read(DataType.DataBlock, db: 1, startByteAdr: 13, VarType.Bit, 1)),
    };

    Console.WriteLine(state);
}
catch(Exception e)
{
    Console.Error.WriteLine(e);
}

Console.ReadKey();
