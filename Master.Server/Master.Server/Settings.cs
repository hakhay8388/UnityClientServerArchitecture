using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Server
{
    public class Settings
    {
        public static int GamePlayerCount = 2;
        public static string GameServerPath = "..\\..\\..\\..\\..\\Game.Server\\Game.Server\\bin\\Debug\\net7.0\\Game.Server.exe";
        public static string MongoConnectionUri = "mongodb+srv://hakhay8388:#$Rq8!tur#dcn!2@cluster0.yncs2u6.mongodb.net/?retryWrites=true&w=majority";
        public static int ListenPort = 1235;
    }
}
