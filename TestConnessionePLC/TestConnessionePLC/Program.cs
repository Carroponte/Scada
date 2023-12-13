
using S7.Net;

using var plc = new Plc(CpuType.S71500, "192.168.2.111", 0, 0);

try
{

    plc.Open();

    if(!plc.IsConnected)
    {
        throw new Exception("Failed connection to plc");
    }
    Console.WriteLine("connected");


}
catch(Exception e)
{
    Console.Error.WriteLine(e);
}

Console.ReadKey();
