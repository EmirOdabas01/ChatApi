Konuşarak Öğren Chat Api

Basitlik için N-layer architecture ile oluşturuldu. Azure ile Deploy edildi.
https://chatapiapi-g8cacedmf6b0gsdw.spaincentral-01.azurewebsites.net/api/ üzerinden istekleri alır.
Core, Data Access, Business logic, Presentation

Core katmanında Entityler yer almakta
Message, User

İkisi arasında 1-N ilişkisi yapıldı ve DataAccessde Ef Core ile DB modelleme işlemleri yapıldı.
Okuma ve yazma işlemleri Ef Core ile yürütüldü, manuel sorgu yazılmadı.

Repository classlarında sadece ihtiyaç duyulucak add,Get fonksiyonları tanımlandı.
Mesajları oluşturulma tarihlerine göre dbden getiricek şekilde ayarladım.

Busines katmanında Python servisine istek atarak gerçek zamanlı duygu analizi sağlandı.
Entityleri kullanmamak için Dto kullanıldı.

Presantaionda dışarıyla iletişimi sağlamak için iki entity için de controllerlar oluşturuldu.
ExceptionHandlingMiddleware ile exception fırlatılması durumunda uygulamanın çökmemesi sağlandı.
