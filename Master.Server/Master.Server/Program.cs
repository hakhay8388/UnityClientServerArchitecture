﻿using Bootstrapper.Core.nHandlers.nProcessHandler;
using Master.Server;
using Master.Server.nDatabase;
using NewClientServerSampleWithUdp;
using System.Text;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Master Server Started...");
        Mongo.Init();
        cServer __TestServer = new cServer(Settings.ListenPort);

        /*cTcpServer __Test = new cTcpServer(1234, null);
       __Test.StartListening();

       cUdpServer __Test2 = new cUdpServer(__Test, null);*/

        /*        cTcpClient __Client = new cTcpClient(null);
                __Client.TryToConnect("127.0.0.1", 1234);

                __Client.Send("Test");
                __Client.Send("Test");
                __Client.Send("Test");
                __Client.Send("Test");*/

        /*cTestUdpServer __Test = new cTestUdpServer();

        cTestUdpClient __Client = new cTestUdpClient();


        */

        string read;
        do
        {
            read = Console.ReadLine();
            //client.Send(read);
        } while (read != "quit");



        Console.WriteLine("Master Server End.");
    }
}
