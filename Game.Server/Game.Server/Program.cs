using Game.Server.nDatabase;
using NewClientServerSampleWithUdp;
using System.Text;

public static class Program
{
    public static bool Exit = false;
    public static void Main(string[] _Args)
    {
        Console.WriteLine("Game Server Started...: Port : " + _Args[0]);
        Mongo.Init();
        cServer __TestServer = new cServer(Convert.ToInt32(_Args[0]));



        string read;
        do
        {
            read = Console.ReadLine();
            //client.Send(read);
        } while (read != "quit");



        Console.WriteLine("Game Server End.");
    }
}
