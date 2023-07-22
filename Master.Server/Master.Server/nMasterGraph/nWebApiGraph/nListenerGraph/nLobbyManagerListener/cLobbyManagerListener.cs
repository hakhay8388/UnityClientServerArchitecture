
using Bootstrapper.Core.nHandlers.nProcessHandler;
using Master.Server.nDatabase.nEntities;
using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nJoinLobbyResultAction;
using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nLobbyUserListAction;
using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nLoginResultAction;
using Master.Server.nMasterGraph.nWebApiGraph.nActionGraph.nActions.nTestAction;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nDisconnectedCommand;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nGetLobbyUsersCommand;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nIAmInLobbyCommand;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nJoinLobbyCommand;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nLoginCommand;
using Master.Server.nMasterGraph.nWebApiGraph.nCommandGraph.nCommands.nTestCommand;
using Master.Server.nMasterGraph.nWebApiGraph.nListenerGraph.nLobbyManagerListener.nLobby;
using Master.Server.nSessionManager;
using System.Linq;

namespace Master.Server.nMasterGraph.nWebApiGraph.nListenerGraph.nLobbyManagerListener
{
    public class cLobbyManagerListener : cBaseListener
        , IGetLobbyUsersReceiver
        , IDisconnectedReceiver
        , IJoinLobbyReceiver
        , IIAmInLobbyReceiver
    {
        List<cLobbyItem> Lobbies { get; set; }

        List<cSession> GuestUsers { get; set; }
        int GameStartPort { get; set; }
        int GameStartEndPort { get; set; }
        int GameCurrentPort { get; set; }

        public cLobbyManagerListener(cBaseGraph _Graph)
          : base(_Graph)
        {
            Lobbies = new List<cLobbyItem>();
            GuestUsers = new List<cSession>();
            GameStartPort = 2000;
            GameStartEndPort = 3000;
            GameCurrentPort = GameStartPort;
        }

        public void ReceiveDisconnectedData(cSession _Session, cListenerEvent _ListenerEvent, cDisconnectedCommandData _ReceivedData)
        {
            if (_Session.IsLogined)
            {
                cLobbyItem __LobbyItem = Lobbies.Where(__Item => __Item.Users.Any(__Item => __Item.ID == _Session.User.ID) && !__Item.GameStarted).SingleOrDefault();
                if (__LobbyItem == null)
                {

                }
                else
                {
                    __LobbyItem.End();
                    __LobbyItem.Users.Remove(_Session.User);
                    GuestUsers.Remove(_Session);
                    List<cSession> __Sessions = _Session.Server.SessionManager.GetSessionByUserIDs(__LobbyItem.Users.Select(__Item => __Item.ID).ToList());
                    __Sessions = GuestUsers.Concat(__Sessions).ToList();
                    Graph.ActionGraph.JoinLobbyResultAction.Action(__Sessions, new cJoinLobbyResultProps() { Success = true, Users = __LobbyItem.Users });
                }
            }
        }

        public void ReceiveGetLobbyUsersData(cSession _Session, cListenerEvent _ListenerEvent, cGetLobbyUsersCommandData _ReceivedData)
        {
            if (_Session.IsLogined)
            {

                //Graph.ActionGraph.LobbyUserListAction.Action(_Session, new cLobbyUserListProps() { Users = new List<cUser>() { new cUser() { Name = "hayri", ID = 1 }, new cUser() { Name = "hayri2", ID = 2 }, new cUser() { Name = "hayri3", ID = 3 } } });
                cLobbyItem __LobbyItem = Lobbies.LastOrDefault();
                if (__LobbyItem == null)
                {
                    Graph.ActionGraph.LobbyUserListAction.Action(_Session, new cLobbyUserListProps() { Users = new List<cUser>() });
                }
                else
                {
                    Graph.ActionGraph.LobbyUserListAction.Action(_Session, new cLobbyUserListProps() { Users = __LobbyItem.Users });
                }
            }
        }

        public void ReceiveJoinLobbyData(cSession _Session, cListenerEvent _ListenerEvent, cJoinLobbyCommandData _ReceivedData)
        {
            if (_Session.IsLogined)
            {
                cLobbyItem __LobbyItem = Lobbies.Where(__Item => __Item.Users.Any(__Item => __Item.ID == _Session.User.ID)).SingleOrDefault();
                if (__LobbyItem == null)
                {
                    __LobbyItem = Lobbies.Where(__Item => __Item.Users.Count < Settings.GamePlayerCount).SingleOrDefault();
                    if (__LobbyItem == null)
                    {
                        __LobbyItem = new cLobbyItem(Guid.NewGuid().ToString());
                        __LobbyItem.Users.Add(_Session.User);
                        Lobbies.Add(__LobbyItem);

                        GuestUsers.Remove(_Session);
                        List<cSession> __Sessions = GuestUsers.Concat(new List<cSession>() { _Session }).ToList();

                        Graph.ActionGraph.JoinLobbyResultAction.Action(__Sessions, new cJoinLobbyResultProps() { Success = true, Users = __LobbyItem.Users });
                    }
                    else
                    {
                        GuestUsers.Remove(_Session);
                        __LobbyItem.Users.Add(_Session.User);
                        List<cSession> __Sessions = _Session.Server.SessionManager.GetSessionByUserIDs(__LobbyItem.Users.Select(__Item => __Item.ID).ToList());

                        if (__LobbyItem.Users.Count < Settings.GamePlayerCount)
                        {
                            __Sessions = __Sessions.Concat(GuestUsers).ToList();
                            Graph.ActionGraph.JoinLobbyResultAction.Action(__Sessions, new cJoinLobbyResultProps() { Success = true, Port=0, GameWillStart = false, Users = __LobbyItem.Users });
                        }
                        else
                        {
                            GameCurrentPort++;
                            Graph.ActionGraph.JoinLobbyResultAction.Action(__Sessions, new cJoinLobbyResultProps() { Success = true, Port = GameCurrentPort, GameWillStart = true, Users = __LobbyItem.Users });
                            Graph.ActionGraph.JoinLobbyResultAction.Action(GuestUsers, new cJoinLobbyResultProps() { Success = true, Port = 0, GameWillStart = false, Users = new List<cUser>() });

                            __LobbyItem.StartServer(GameCurrentPort);
                        }
                        
                    }
                }
            }
        }

        public void ReceiveIAmInLobbyData(cSession _Session, cListenerEvent _ListenerEvent, cIAmInLobbyCommandData _ReceivedData)
        {
            if (_Session.IsLogined)
            {
                lock(GuestUsers)
                {
                    GuestUsers.Add(_Session);
                    cLobbyItem __LobbyItem = Lobbies.LastOrDefault();
                    if (__LobbyItem == null)
                    {
                        Graph.ActionGraph.LobbyUserListAction.Action(_Session, new cLobbyUserListProps() { Users = new List<cUser>() });
                    }
                    else
                    {
                        Graph.ActionGraph.LobbyUserListAction.Action(_Session, new cLobbyUserListProps() { Users = __LobbyItem.Users });
                    }
                }               
            }
        }
    }
}
