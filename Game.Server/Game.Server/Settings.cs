using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Server
{
    public class Settings
    {
        public static int GamePlayerCount = 2;
        public static string MongoConnectionUri = "mongodb+srv://hakhay8388:#$Rq8!tur#dcn!2@cluster0.yncs2u6.mongodb.net/?retryWrites=true&w=majority";

        public const float TICKS_PER_SEC = 30;
        public const float MS_PER_TICK = 1000f / TICKS_PER_SEC;
    }
}
