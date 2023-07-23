# Bu proje Panteon Games için geliştirilmiştir

## Proje indirildikten sonra yapılması gerekenler
GameClient projesi Unity projesi olduğundan dolayı kütüphanesi çok büyük ve Github'ın ücretsiz versiyonunda limiti aşıyor.
Bu sebepden dolayı GameClient projesi içerisinde sıkıştırılmış bir Library.rar dosyası bulunmakta. Projeyi github'dan çektikten sonra,
Library.rar dosyasını yine GameClient klasörünün içine açmanız gerekmektedir. Klasörü buraya açtıkdan sonra Library klasörünün altında başka bir Library
klasörünün olmamasına dikkat ederek bu sıkıştırılmış dosyanın açılması gerekiyor. Sıkıştırma programlarının seçeneklerine göre sıkıştırılmış dosya açılırken
iç içe klasörler oluşturabiliyor. Bunun olmamasına dikkat edilmeli.

## Projeler ve geliştirildikleri platformlar
Master.Server projesi ve Game.Server projeleri .Net Core 7.0 ile geliştirildi.
GameClient projesi dökümanda belirtildiği üzere Unity 2021.3.15f1 ile geliştirildi

## Proje bağlantı şekli
Tüm proje TCP ve UDP bağlantıyı destekleyecek şekilde geliştirildi. Şuanda bağlantının başarılı olup olmadığı TCP üzerinden ve endpoint'lerin doğruluğu netleştikden sonra
tüm iletişim UDP üzerinden gerçekleşiyor.

## Master.Server
Master.Server projesi içerisinde Settings.cs dosyasında çeşitli ayarlar bulunmaktadır.

ListenPort 			: Bu Master.Server projesinin hangi protu dinleyeceğini belirten ayardır. Şuanda "1235" dinleyecek şekilde ayarlandı.

GameServerPath  	: Bu dosya yolu bizim "Game.Server"'ımızın'ın exe sinin olduğu yolu gösteriyor. Her yarış için loby otomatik bir şekilde oyun sunucusu ayağa kaldırılıyor ve
oyun bitiminde uygulama durduruluyor. Her oyun sunucusu 2000 ile 3000 portu arasında ayağa kalkıyor. Hangi prottan ayağa kalkacağı ve kaç oyuncuyu bekleyeceği
uygulama ayağa kalkarken parametre olarak bildiriliyor.

GamePlayerCount    	: Bu ayara oyuna kaç kişi katılabileceğini belirtiyor.

MongoConnectionUri 	: Şuanda mongodb'nin cloud free olarak atlas'ı kullanıldı ve bu değişken ilgili veritabanı bağlantı linkini içeriyor.


## Game.Server
Game.Server projesi içerisinde Settings.cs dosyasında çeşitli ayarlar bulunmaktadır.

GamePlayerCount    	: Dışarıdan gelen oyuncu sayısı parametresi buraya setleniyor. 

MongoConnectionUri 	: Şuanda mongodb'nin cloud free olarak atlas'ı kullanıldı ve bu değişken ilgili veritabanı bağlantı linkini içeriyor.

TICKS_PER_SEC 		: Oyun sunucusu içerisinde küçük bir update mekanızması bulunuyor. Bu update mekanizmasının saniyede kaçkere yenileneceğini bu parametre belirliyor.
					  şuanda bu parametre "30" setlenmiş durumda. Bu parametre ile GameClient içerisindeki FixedUpdate paramteresi arasında şu formüle göre akış belirleniyor.
					  1 / TICKS_PER_SEC = 0.033333 -> bu formule göre GameClient tarafındaki FixedUpdate parametresi 0.033333 setlenmiş durumda. Yukarıda bahsettiğim update
					  mekanizması saniyede 30 kere GameClient tarafına anlık bilgi gönderiyor.
					  
MS_PER_TICK 		: Bu parametre "1000f / TICKS_PER_SEC" bu formüle göre iki tick arasına kaç milisaniye bekleyeceğini belirtiyor.

## GameClient
GameClient projesi içerisinde Settings.cs dosyasında çeşitli ayarlar bulunmaktadır.

MasterServerIP 		: Master.Game sunucusunun IP adresini burada belirtiyoruz. Şuanda "127.0.0.1" e setlenmiş durumda.
MasterServerPort 	: Master.Game sunucusuna hangi porttan giriş yapacağını buradan belirtiyoruz. Şuanda "1235" e setlenmiş durumda.