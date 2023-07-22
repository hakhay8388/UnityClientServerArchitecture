
using Game.Server.nDatabase.nEntities;
using Game.Server.nGameGraph.nWebApiGraph.nActionGraph;
using Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nCountDownAction;
using Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nOpenGameAction;
using Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nPlayerTransformActions;
using Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nReturnToLobbyAction;
using Game.Server.nGameGraph.nWebApiGraph.nActionGraph.nActions.nTestAction;
using Game.Server.nGameGraph.nWebApiGraph.nCommandGraph;
using Game.Server.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nDisconnectedCommand;
using Game.Server.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nIAmInGameCommand;
using Game.Server.nGameGraph.nWebApiGraph.nCommandGraph.nCommands.nKeyPressedCommand;
using Game.Server.nGameGraph.nWebApiGraph.nListenerGraph.nGameManagerListener.nPlayer;
using Game.Server.nSessionManager;
using System.Linq;
using System.Numerics;

namespace Game.Server.nGameGraph.nWebApiGraph.nListenerGraph.nGameManagerListener
{
    public class cGameManagerListener : cBaseListener
        , IDisconnectedReceiver
        , IIAmInGameReceiver
        , IKeyPressedReceiver
    {
        List<cPlayer> Players { get; set; }
        List<cSession> Sessions { get; set; }

        public cGameManagerListener(cBaseGraph _Graph)
          : base(_Graph)
        {
            Players = new List<cPlayer>();
        }

        public void GameStart()
        {
            Sessions = Players.Select(__Item => __Item.Session).ToList();
            Thread __Thread = new Thread(new ThreadStart(GameThread));
            __Thread.Start();


        }

        public void GameThread()
        {
            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(1000);
                Graph.ActionGraph.CountDownAction.Action(Sessions, new cCountDownProps() { Value = 3 - i });
            }

            Thread __RenderThread = new Thread(new ThreadStart(RenderThread));
            __RenderThread.Start();
        }

        public void RenderThread()
        {
            DateTime __UpdateTimer = DateTime.Now;
            while (true)
            {
                while (__UpdateTimer < DateTime.Now)
                {
                    Update();
                    __UpdateTimer.AddMilliseconds(Settings.MS_PER_TICK);

                    /*if (__UpdateTimer > DateTime.Now)
                    {
                        int __MiliSec = (__UpdateTimer - DateTime.Now).Milliseconds;
                        if (__MiliSec > 15) __MiliSec = __MiliSec - 10;
                        Thread.Sleep(__MiliSec);
                    }*/
                }
            }
        }

        public void Update()
        {
            for (int i = 0; i < Players.Count; i++)
            {
                Players[i].Update();
                Graph.ActionGraph.PlayerTransformAction.Action(Sessions, new cPlayerTransformProps() { UserID = Players[i].User.ID, Position = Players[i].Position });
            }
        }

        public void ReceiveDisconnectedData(cSession _Session, cListenerEvent _ListenerEvent, cDisconnectedCommandData _ReceivedData)
        {
            if (_Session.IsLogined)
            {
                cPlayer __Player = Players.Where(__Item => __Item.User.ID == _Session.User.ID).FirstOrDefault();
                Players.Remove(__Player);

                if (Players.Count < Settings.GamePlayerCount)
                {
                    Graph.ActionGraph.ReturnToLobbyAction.Action(Players.Select(__Item => __Item.Session).ToList(), new cReturnToLobbyProps());
                }
                Exit();
            }
        }

        public void Exit()
        {
            Thread __Thread = new Thread(new ThreadStart(ExitThread));
            __Thread.Start();
        }

        public void ExitThread()
        {
            Thread.Sleep(3000);
            System.Environment.Exit(1);
        }

        public void ReceiveIAmInGameData(cSession _Session, cListenerEvent _ListenerEvent, cIAmInGameCommandData _ReceivedData)
        {
            lock (_Session)
            {
                if (_Session.User == null)
                {
                    _Session.User = _ReceivedData.User;
                }

                if (Players.Count < Settings.GamePlayerCount)
                {
                    cPlayer __Player = Players.Where(__Item => __Item.User.ID == _ReceivedData.User.ID).FirstOrDefault();
                    if (__Player == null)
                    {
                        Players.Add(new cPlayer(_Session, _ReceivedData.User));
                    }
                }

                if (Players.Count >= Settings.GamePlayerCount)
                {
                    for (int i = 0; i < Players.Count; i++)
                    {
                        Players[i].Position = new Vector3(0, 0.53f, -3 + (float)((12f / (float)Players.Count) * i));
                    }

                    Graph.ActionGraph.OpenGameAction.Action(Players.Select(__Item => __Item.Session).ToList(), new cOpenGameProps() { Users = Players.Select(__Item => __Item.User).ToList() });
                    GameStart();
                }

            }
        }

        public void ReceiveKeyPressedData(cSession _Session, cListenerEvent _ListenerEvent, cKeyPressedCommandData _ReceivedData)
        {
            if (_Session.IsLogined)
            {
                cPlayer __Player = Players.Where(__Item => __Item.User.ID == _Session.User.ID).FirstOrDefault();
                if (__Player != null)
                {
                    __Player.SetInput(_ReceivedData.Keys);
                }
            }
        }
    }
}
