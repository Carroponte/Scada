
using S7.Net;

using var plc = new Plc(CpuType.S7200, "192.168.2.111", 0, 0);

try
{

    plc.Open();

    if(!plc.IsConnected)
    {
        throw new Exception("Failed connection to plc");
    }

    

}
catch(Exception e)
{
    Console.Error.WriteLine(e);
}
