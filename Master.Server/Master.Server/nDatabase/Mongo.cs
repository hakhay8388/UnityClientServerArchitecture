using MongoDB.Driver;
using MongoDB.Bson;
using Master.Server.nDatabase.nEntities;
using System.Collections;

namespace Master.Server.nDatabase
{
    public static class Mongo
    {
        public static MongoClient Client { get; set; }
        public static IMongoDatabase GameDatabase { get; set; }

        public static string CollectionName = "Users";
        public static void Init()
        {
            var __Settings = MongoClientSettings.FromConnectionString(Settings.MongoConnectionUri);
            __Settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            Client = new MongoClient(__Settings);
            try
            {
                GameDatabase = Client.GetDatabase("admin");
                var __Result = GameDatabase.RunCommand<BsonDocument>(new BsonDocument("ping", 1));
                Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");

                GameDatabase = Client.GetDatabase("GameDB"); 

                

                // Veritabanında koleksiyonun var olup olmadığını kontrol edin.
                var __CollectionList = GameDatabase.ListCollectionNames().ToList();
                if (!__CollectionList.Contains(CollectionName))
                {
                    // Veritabanında koleksiyon yoksa yeni bir koleksiyon oluşturun.
                    GameDatabase.CreateCollection(CollectionName);
                    Console.WriteLine("Collection Created");
                }
                else
                {
                    Console.WriteLine("Collection Exists");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void UpdateUser(cUser _User)
        {
            IMongoCollection<cUser> __GameCollection = GameDatabase.GetCollection<cUser>(CollectionName);
            var __Filter = Builders<cUser>.Filter.Eq(x => x.Name, _User.Name);
            var __Update = Builders<cUser>.Update.Set(x => x.Puan, _User.Puan);
            var __Result = __GameCollection.UpdateOne(__Filter, __Update);
        }

        public static bool IsUserExists(string _UserName)
        {
            IMongoCollection<cUser> __GameCollection = GameDatabase.GetCollection<cUser>(CollectionName);

            var __Filter = Builders<cUser>.Filter.Eq(x => x.Name, _UserName);

            return __GameCollection.CountDocuments(__Filter) > 0;
        }


        public static cUser GetUserByName(string _UserName)
        {
            IMongoCollection<cUser> __GameCollection = GameDatabase.GetCollection<cUser>(CollectionName);

            var __Filter = Builders<cUser>.Filter.Eq(x => x.Name, _UserName);
            var __LargestDocument = __GameCollection.Find(__Filter).FirstOrDefault();
            return __LargestDocument;
        }

        public static cUser AddUser(string _UserName)
        {
            IMongoCollection<cUser> __GameCollection = GameDatabase.GetCollection<cUser>(CollectionName);


            var __Filter = Builders<cUser>.Filter.Empty;
            var __Sort = Builders<cUser>.Sort.Descending("id");
            var __LargestDocument = __GameCollection.Find(__Filter).Sort(__Sort).FirstOrDefault();

            cUser __User = null;
            if (__LargestDocument != null)
            {
                __User = new cUser()
                {
                    Name = _UserName,
                    Puan = 0,
                    id= __LargestDocument.id + 1,
                };

                __GameCollection.InsertOne(__User);
            }
            else
            {
                __User = new cUser()
                {
                    Name = _UserName,
                    Puan = 0,
                    id = 1,
                };

                __GameCollection.InsertOne(__User);
            }
            return __User;
        }
    }
}
