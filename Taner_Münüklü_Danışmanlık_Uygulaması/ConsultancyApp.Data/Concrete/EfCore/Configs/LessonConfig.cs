using ConsultancyApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Concrete.EfCore.Configs
{
    public class LessonConfig : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();

            builder.Property(l => l.Name).IsRequired();
            builder.Property(l => l.About).IsRequired();

            builder.Property(l => l.Url).IsRequired();

            builder.Property(l => l.ModifiedDate).IsRequired();

            builder.Property(l => l.IsActive).IsRequired();
            builder.Property(l => l.IsDeleted).IsRequired();
            builder.Property(l => l.Price).IsRequired();
            builder.Property(l => l.Kontenjan).IsRequired();
            builder.Property(l => l.PeriodOfStudy).IsRequired();
            builder.Property(l => l.ImageUrl).IsRequired();
            builder.Property(l => l.Url).IsRequired();
            builder.HasOne(l => l.Agency).WithMany(l => l.Lessons).HasForeignKey(l => l.AgenciesId).OnDelete(DeleteBehavior.SetNull);
            


            builder.HasData(new Lesson
            {
                Id = 1,
                Name = "Full Stack Web Application",
                About = "Full stack developer olarak çalışan uzmanlar, yazılımların back-end (arka katman) ve front-end(ön katman) olarak nitelendirilen bölümlerinde rol almaktadırlar. Aynı zamanda veritabanı programlama alanlarında yetkinlikleri olup, geliştirilmekte olan projenin yazılımla ilgili bütün aşamalarında görev almaktadırlar. Full Stack Development, HTML, CSS, JavaScript, ReactJS, Node.JS gibi birçok dil barındırmaktadır. Doğası gereği geniş ilgi alanına sahip bir disiplindir. Back-End’den Front-End’e ve veritabanlarına kadar uzanan bu yetkinlik Türkiye’de en çok aranan yazılım programlama dallarından biridir.",
                Url = "full-stack-web-application.jpg",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl= "full-stack-web-application.jpg",
                Kontenjan = 15,
                Price = 70.000m,
                PeriodOfStudy = 165



            },
            new Lesson
            {
                Id = 2,
                Name = "Python ile Web Geliştirme",
                About = "Bilişim sektöründe yer almayı hedefleyen öğrenci ve mezunlar, bu dilde kendisini geliştirip uzmanlaşmak isteyen ve kariyerini bilişim sektöründe ilerletmek isteyenlerin tercih edebileceği bu eğitimde hızlı ve dinamik web uygulamaları geliştirmek, Python programlama dilinin artılarından yararlanmak için alabileceğiniz bu eğitim ile sıfırdan ileri seviyeye web geliştirici olma imkanını yakalayın.\r\n\r\n\r\n\r\nSektör tecrübesi yüksek uzman eğiticiler tarafından yapılacak online eğitimde katılımcılar alacakları teorik bilginin yanında edinecekleri uygulama deneyimi ile özelleştirilmiş ve hedefe yönelik bir eğitim alırlar.\r\n\r\n",
                Url = "python-ile-web-gelistirme",
                ImageUrl= "python-ile-web-gelistirme.jpg",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                
                Kontenjan = 15,
                Price = 30.000m,
                PeriodOfStudy = 85

            },
            new Lesson
            {
                Id = 3,
                Name = "Java Eğitimi (SE)",
                About = "Bilişim sektöründe yer almayı hedefleyen öğrenci ve mezunlar, bu dilde kendisini geliştirip uzmanlaşmak isteyen ve kariyerini bilişim sektöründe ilerletmek isteyenlerin tercih edebileceği bu eğitimde, katılımcıların dünyanın en popüler ve güçlü programlama dillerinden Java'yı tanımaları ve uygulama geliştirecek seviyeye gelmeleri amaçlanmaktadır. Java Eğitiminde, veritabanı yönetimi ve programlanması MySql ilişkisel veritabanı yönetim sistemi ile gerçekleştirilir.\r\n\r\n \r\n\r\nBu eğitimi alan katılımcılar, ayrıca Java programlama dili ile beraber, kodlaması yapılmış bir uygulamada MySql veritabanına JDBC gibi erişim teknikleriyle nasıl bağlanılacağını, veritabanı üzerinde nasıl işlem gerçekleştirilebileceğini çeşitli uygulamalarla öğrenirler.",
                Url = "java-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl= "java-ile-egitim.png",
                Kontenjan = 15,
                Price = 70.000m,
                PeriodOfStudy = 165 

            },
            new Lesson
            {
                Id = 4,
                Name = "Oyun Programlama",
                About = "Bilişim sektöründe yer almayı hedefleyen öğrenci ve mezunlar, bu dilde kendisini geliştirip uzmanlaşmak isteyen ve kariyerini bilişim sektöründe ilerletmek isteyenlerin tercih edebileceği bu eğitimde hızlı ve dinamik web uygulamaları geliştirmek, Python programlama dilinin artılarından yararlanmak için alabileceğiniz bu eğitim ile sıfırdan ileri seviyeye oyun geliştirici olma imkanını yakalayın.\r\n\r\n\r\n\r\nSektör tecrübesi yüksek uzman eğiticiler tarafından yapılacak online eğitimde katılımcılar alacakları teorik bilginin yanında edinecekleri uygulama deneyimi ile özelleştirilmiş ve hedefe yönelik bir eğitim alırlar.\r\n\r\n",
                Url = "oyun-programlama",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl= "oyun-programlama-ile-egitim.png",
                Kontenjan = 15,
                Price = 70.000m,
                PeriodOfStudy = 600

            },
            new Lesson
            {
                Id = 5,
                Name = "Php Eğitimi",
                About = "Bilişim sektöründe yer almayı hedefleyen öğrenci ve mezunlar, bu dilde kendisini geliştirip uzmanlaşmak isteyen ve kariyerini bilişim sektöründe ilerletmek isteyenlerin tercih edebileceği bu eğitimde katılımcıların, PHP ile web yazılıma giriş yapmaları sağlanır ayrıca nesne yönelimli programlamayı (OOP) etkin bir biçimde kullanarak katmanlı yapıdaki proje mimarisi ile birlikte servis alt yapısının da kullanıldığı modüler web projeleri geliştirilmeleri sağlanır.\r\n\r\n \r\n\r\nServer side yazılım dillerinden olan PHP öğrenmek günümüzde popüler olan ve nitelikli uzman eleman açığı bulunan Wordpress, Laravel gibi frameworkler için ciddi bir temel oluşturacaktır.\r\n\r\n \r\n\r\nBir web sitesinin sıfırdan nasıl oluşturulduğunu, MySQL veritabanı bağlantısının nasıl kurulduğunu, veritabanı sorgulamalarını, etkili ve işlevsel bir websitesi hazırlamanın inceliklerini bu eğitimde öğrenebilirsiniz.",
                Url = "php-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl= "php-ile-egitim.png",
                Kontenjan = 15,
                Price = 70.000m,
                PeriodOfStudy = 72  

            },
            new Lesson
            {
                Id = 6,
                Name = "Entity Framework Eğitimi",
                About = "Bilişim sektöründe yer almayı hedefleyen öğrenci ve mezunlar, bu dilde kendisini geliştirip uzmanlaşmak isteyen ve kariyerini bilişim sektöründe ilerletmek isteyenlerin tercih edebileceği bu eğitimde hedefimiz Sql Server Management Studio üzerinde az da olsa bilgi sahibi olan katılımcıların temel Sql bilgilerini arttırdıktan sonra trigger ve procedure gibi sektörde sık karşılaşacakları veritabanı nesneleri üzerinde çalışabilmelerini sağlamaktır.\r\n\r\n \r\n\r\nİkinci bölümde ise yazılımcının veritabanı bağımlılığını azaltan ve aynı zamanda bir ORM aracı olan Entity Framework Code First ile veritabanı tasarımı performans konusu ile birlikte güncel örnekler üzerinden anlatılır.",
                Url = "entity-framework-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
               ImageUrl= "entity-frameworkcore-ile-egitim.png",
                Kontenjan = 15,
                Price = 70.000m,
                PeriodOfStudy = 65 
            },
            new Lesson
            {
                Id = 7,
                Name = "C# Eğitimi",
                About = "Bilişim  sektöründe yer almayı hedefleyen öğrenci ve mezunlar, bu dilde kendisini geliştirip uzmanlaşmak isteyen ve kariyerini bilişim sektöründe ilerletmek isteyenlerin tercih edebileceği bu eğitimde, katılımcılara .Net 4.6 teknolojisi ile C# diline giriş yaparak temel ilkelerin öğretilmesi amaçlanmıştır. Bu eğitim ile katılımcılar modüler programlamanın alt yapısını oluşturan Nesne Yönelimli Programlama (OOP) ile birlikte windows ortamında çalışan uygulamalar yaparak Microsoft Visual Studio ile yazılım geliştirici olma yolunda ilk adımı atarlar.\r\n\r\n \r\n\r\nC# nedir sorusuna gelirsek; Microsoft tarafından Visual Studio.Net ile birlikte geliştirilen, bu platformun tüm özelliklerinden yararlanmanızı sağlayan nesne tabanlı bir programlama dilidir. Öğrenilmesi  kolay, esnek, güvenli, çok yönlü ve modern bir yapıya sahiptir. C# ile birbirinden farklı yazılım programları kolayca kodlanabilmektedir.\r\n\r\n \r\n\r\nGünümüzde yazılım uygulamaları veritabanından bağımsız düşünülemez. Bu eğitim ile Microsoft'un veritabanı yönetimi için geliştirmiş olduğu Microsoft Sql Server Management Studio ile veritabanı yönetiminin incelikleri öğretilir. Program sonunda veritabanı ile entegre işlemler yapabilen ve windows ortamında çalışan uygulamalar geliştirebilirsiniz.",
                Url = "c#-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl= "c-ile-egitim.png",
                Kontenjan = 15,
                Price = 70.000m,
                PeriodOfStudy = 165 

            },
            new Lesson
            {
                Id = 8,
                Name = "Mobil Uygulama Geliştirme",
                About = "Mobil uygulama geliştirme, kişisel dijital yardımcıları, kurumsal dijital yardımcıları veya cep telefonlarını içerebilen bir veya daha fazla mobil cihaz için bir mobil uygulamanın geliştirildiği eylem veya süreçtir.",
                Url = "mobil-uygulama-geliştirme-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
               ImageUrl= "mobil-uygulama-gelistirme-ile-egitim.png",
                Kontenjan = 15,
                Price = 70.000m,
                PeriodOfStudy = 115 

            },
            new Lesson
            {
                Id = 9,
                Name = "cyber security",
                About = "Bahçeşehir Üniversitesi | Wissen, Microsoft Gold Partner’i olarak Siber Güvenlik Uzmanlığı alanındaki eğitimlerini ileri seviye laboratuvarları ve uzman eğiticileri ile beraber gerçekleştirmektedir.Eğitim programımız başlamadan, kuralları bildiğinize ve kurallara uyacağınıza dair “Taahhütname” imzalamanız gerekmektedir.Doğru eğitim programını seçtiğinizden emin olunuz. Eğitim programlarımıza devamlılık zorunludur. Kurumun kabul edebileceği mazeretiniz olur ise Eğitim programlarının süresinin 1/10′ unu aşmamak üzere mazeret izni kullanabilirsiniz. Bu sürenin aşımı halinde, kursla ilişiğiniz kesilir.Eğitim programının başlangıcı itibariyle SGK, BAĞ-KUR veya Emekli Sandığı’ na bağlı olarak çalışıyorsanız eğitim programımıza katılamazsınız.Devam ettiğiniz her bir gün için 212.67 TL almaya hak kazanırsınız.Devam etmediğiniz günler için ödeme yapılmaz. Ödemeler açılacak banka hesabınıza aylık olarak yatırılır.İşsizlik sigortasından yararlanmakta iseniz kursa katılmanız halinde işsizlik sigortası ödemesi kesilmez (hak ettiğiniz kadar işsizlik ödeneğini ve kursa katıldığınız her gün için 212.67 TL‘yi almaya devam edersiniz).İşsizlik sigortasından yararlanmakta iken, geçerli bir gerekçe sunmadan katıldığınız kursu bırakmanız halinde bu tarihten itibaren işsizlik ödeneğiniz kesilir.Eğitim programı boyunca, ”Eğitim Maliyetleriniz” ile “İş Kazası ve Meslek Hastalığı Sigorta Priminiz” İŞKUR tarafından karşılanır.Eğitim aldığı programın uluslararası vendor sertifika sınavına bir defalığına ücretsiz katılım hakkı verilecektir.Eğitim aldığı programın uluslararası kitap ve materyali bir defalığına ücretsiz olarak verilecektir.",
                Url = "cyber-security-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl= "cyber-security-ile-egitim.png",
                Kontenjan = 15,
                Price = 70.000m,
                PeriodOfStudy = 600 

            },
            new Lesson
            {
                Id = 10,
                Name = "CCNA Cloud Yönetimi Eğitimi",
                About = "Bu eğitim katılımcılar Cloud yönetim ve işlemlerini gerçekleştirmek için gerekli bilgi ve yetenekleri,kazandırmak içindir. Katılımcılar Cloud yönetim yazılım çözümleri, Cloud alt yapısının temelleri, raporlama ve charge-back, Provision Clouds şablonları, Cloud yönetimi, izleme ve iyileştirme metodları, Cloud Özellikleri, kimlik denetimi, dağıtım modelleri hakkında bilgi sahibi olurlar.",
                Url = "cloud-yönetimi-egitimi",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl= "cyber-security-ile-egitim.png",
                Kontenjan = 15,
                Price = 70.000m,
                PeriodOfStudy = 72 

            },
            new Lesson
            {
                Id = 11,
                Name = "CCNP Route & Switching Eğitimi",
                About = " \r\n\r\nCCNP Route Switching sertifikası alan kişi, yerel ve geniş ağları planlama, kurma, doğrulama ve sorun tespit etme ve problemleri giderme yetkinliklerine sahip olduğunu ortaya koymaktadır.\r\n\r\nRouting eğitimi alanlar, routing protokolleri ile güvenli kurumsal yerel ve geniş alan ağlarını planlamayı, kurmayı, konfigüre etmeyi ve doğrulamayı öğrenmektedir. Switch eğitimleri ile kompleks kurumsal switching planlaması, konfigürasyonu ve kurulumun doğrulanması öğretilmektedir.",
                Url = "ccnp-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl= "cyber-security-ile-egitim.png",
                Kontenjan = 15,
                Price = 70.000m,
                PeriodOfStudy = 108 

            },
            new Lesson
            {
                Id = 12,
                Name = "CCNA Security Eğitimi",
                About = "Bu eğitim Cisco Router ve Cisco Security ürünleri üzerinde gerçek senaryolara dayalı güvenlik tekniklerinin kullanılması ve yapılandırılmasını kapsar. Bu eğitim sonunda katılımcılar temel network güvenlik kavramları, Router ve Switch güvenliği, Kimlik Doğrulama, Firewall servisleri, Remote Access, izinsiz girişler ve içerik güvenliği konularında bilgi ve deneyim sahibi olacaklardır.",
                Url = "ccna-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl= "cyber-security-ile-egitim.png",
                Kontenjan = 15,
                Price = 70.000m,
                PeriodOfStudy = 165 

            },
            new Lesson
            {
                Id = 13,
                Name = "Java ile Android Programlama",
                About = "Java İle Android programlama eğitiminin ana hedefi Android işletim sisteminde çalışabilecek uygulamaların Java dili kullanılarak geliştirilmesidir. Bu eğitimimizde Java programlama dilinin temelleri detaylarıyla anlatılarak Android Studio yardımıyla Android uygulama geliştirmesi yapabilmeniz hedeflenmektedir.\r\n\r\n\r\n\r\nJava ve Android yazılım eğitiminde başlangıç düzeyindeki bir kişinin dahi anlayabileceği bir anlatım ve plan takip edilir. Kodlama dili ve işletim sistemindeki (Java ile Android uygulama geliştirmek adına gerekli) tüm detaylar aktarılır.\r\n\r\nAşama aşama sürdürülen eğitimlerle; kullanılan programlar, araçlar, modüller, kullanılan kod yapıları, hata yakalama ve yazılım test etme süreçleri aktarılır ve böylece programın ilk aşamadan son aşamaya kadar tüm bölümlerinde tam denetim yapabilecek yetkinliğe ulaşılır.",
                Url = "java-ile-android-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl= "java-ile-android-egitim.png",
                Kontenjan = 15,
                Price = 70.000m,
                PeriodOfStudy = 165 

            },
            new Lesson
            {
                Id = 14,
                Name = "Swift ile iOS Mobil Programlama Eğitimi",
                About = "iOS işletim sistemi üzerinde çalışan mobil programların yazılmasında Swift programlama dili kullanılır. Bu programlama dili, zengin uygulama alanları kadar iş bulmayı kolaylaştırması açısından da yoğun ilgi görür. Açık kaynak olan Swift kodları, programcıların dikkatini çeker.\r\n\r\n \r\n\r\nSwift dersleri ve iOS programlama eğitimi ile mobil cihazlar için kodlama yapabilir, farklı alanlarda çalışabilirsiniz. Mobil programlama ile kendi firmanızın ihtiyacı olan spesifik bir uygulamayı ya da herkesin kullanabileceği genel bir programı kolayca geliştirebilirsiniz.\r\n\r\n \r\n\r\nSwift programlama dili, macOS, iOS, watchOS ve tvOS işletim sistemlerinde kullanılan sezgisel ve güçlü bir programlama dilidir. Kodlaması kolay ve keyifli bir dildir. Modern özellikler taşıyan Swift kodları, etkileşimli ve eğlenceli bir yapı sunar. Tasarımsal olarak güvenli bir yapıya sahip olan Swift kodu, oldukça hızlı çalışan programlar yazmaya olanak tanır.\r\n\r\n \r\n\r\nMobil programlama, küçük kablosuz cihazlar için kodlanan yazılımlardır. Bu programlar, yazıldıkları cihazlarda bulunan diğer bileşenleri kullanabilir. Örneğin; akıllı saat üzerinde çalışması düşünülen bir sağlık uygulaması, cihaz üzerinde bulunan sıcaklık sensörünü kullanabilir. Bu doğrultuda, mobil programlama dilleri; cihazda daha az yer tutan, daha az enerji harcayan ve hızlı çalışan kodları hedefleyerek geliştirilir.\r\n\r\n \r\n\r\nSwift programlama dili, jenerik yapısıyla güçlü ve kolay bir kullanım sunar. Protokol uzantıları sayesinde jenerik kodlar yazmak çok daha kolaylaşır. Swift, metodları, uzantıları ve protokolleri destekleyen bir yapıya sahiptir.\r\n\r\n \r\n\r\nSwift programlama dilini öğrenirken Swift oyun alanı (Swift playgrounds) iOS uygulamasında bulmacalar çözmek için gerçek Swift kodlarını kullanabilirsiniz. Böylece mobil programlamayı eğlenceli hale de getirebilirsiniz.",
                Url = "swift-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl= "Swift-ile-egitim.jpg",
                Kontenjan = 15,
                Price = 70.000m,
                PeriodOfStudy = 165 

            },
            new Lesson
            {
                Id = 15,
                Name = "Full Data Uzmanlık Eğitimi",
                About = "Modern zamanın petrolü olarak kabul edilen verinin yakalanması, güvenli olarak saklanması, depolanması, yönetilmesi, programlanması, analiz edilmesi ve raporlanması tüm işletmeler için çok önemli hale gelmiştir. Verinin artan hacmi, türü ve oluşma hızı nedeniyle geleneksel yöntemlere ek olarak yeni nesil veri tabanları ve bulut teknolojiler gibi farklı mecralarda çalışma ihtiyaçları doğmuştur. Bu bağlamda piyasada veri mühendisi, veri bilimcisi, veri analisti, raporlama uzmanı ve veri tabanı yöneticisi gibi roller her zamankinden daha fazla talep edilir olmuştur. Bu eğitimle veriyle ilgili tüm parçalara derinlemesine girilip hem geleneksel veri tabanlarına hem büyük veri sistemlerine hem de bulut tabanlı veri tabanlarına hakim olunması sağlanacak ve katılımcılara veri ile ilgili bütünsel bir uzmanlık kazandırılacaktır.",
                Url = "full-data-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl= "full-data-ile-egitim.png",
                Kontenjan = 15,
                Price = 70.000m,
                PeriodOfStudy = 400

            },
            new Lesson
            {
                Id = 16,
                Name = "Bulut Bilişim Uzmanlık Eğitimi",
                About = "Bulut bilişim, bilgi işlem hizmetlerinin (sunucu, depolama, veri tabanı, ağ, yazılım, analiz ve makine zekası dahil) internet -bulut- üzerinden sağlanarak daha hızlı inovasyon, esnek kaynaklar ve ekonomik ölçeklendirme sunulması anlamına gelir. Normalde yalnızca kullandığınız bulut hizmetleri için ödeme yaptığınızdan işletim maliyetlerinizi düşürebilir, altyapınızı daha verimli bir şekilde çalıştırabilir ve değişen iş gereksinimlerinize uygun şekilde ölçeklendirme yapabilirsiniz.\r\n\r\nGünümüzde birçok kurum bulut teknolojisini kullanır ve birçok uzman bu devrim niteliğindeki bilgi işlem eğiliminin konsepti ile ilgili geliştirmeler yapar. Bulut bilgi işlem, işletmelerin BT kaynaklarına bakış açısını önemli ölçüde değiştirdi. Kurumlar, maliyet, küresel ölçeklendirme, performans, hız ve verimlilik gibi avantajları nedeniyle bulut bilişim hizmetlerine oldukça ilgi duymaktadırlar.",
                Url = "bulut-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl= "bulut-ile-egitim.jpg",
                Kontenjan = 15,
                Price = 70.000m,
                PeriodOfStudy = 165 

            },
            new Lesson
            {
                Id = 17,
                Name = "Arama Motoru Optimizasyonu (SEO) Eğitimi",
                About = "İleri Düzey SEO Eğitimi ile web sitesi sahipleri için olmazsa olmaz olan Arama Motoru Optimizasyonu(SEO)' nun temellerini kazanmış olacaksınız.İleri düzey teknikler hakkında da bilgi sahibi olacaksınız. Böylece rakip internet siteleri arasından sıyrılarak bir web sitesini Google gibi arama motorlarında başarılı hale getirmenin yöntemlerini öğrenmiş olacaksınız. Seo uyumlu içerik üretimi konusunda bilgiler öğreneceksiniz.",
                Url = "seo-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl = "seo-ile-egitim.jpg",
                Kontenjan = 6,
                Price = 27.000m,
                PeriodOfStudy = 35 

            },
            new Lesson
            {
                Id = 18,
                Name = "Logo Tasarımı",
                About = "İleri Düzey SEO Eğitimi ile web sitesi sahipleri için olmazsa olmaz olan Arama Motoru Optimizasyonu(SEO)' nun temellerini kazanmış olacaksınız.İleri düzey teknikler hakkında da bilgi sahibi olacaksınız. Böylece rakip internet siteleri arasından sıyrılarak bir web sitesini Google gibi arama motorlarında başarılı hale getirmenin yöntemlerini öğrenmiş olacaksınız. Seo uyumlu içerik üretimi konusunda bilgiler öğreneceksiniz.",
                Url = "logo-tasarımı-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl= "logo-tasarımı-ile-egitim.jpg",
                Kontenjan = 6,
                Price = 16.000m,
                PeriodOfStudy = 27 

            },
            new Lesson
            {
                Id = 19,
                Name = "Html,Css,Js Eğitimi",
                About = "İleri Düzey SEO Eğitimi ile web sitesi sahipleri için olmazsa olmaz olan Arama Motoru Optimizasyonu(SEO)' nun temellerini kazanmış olacaksınız.İleri düzey teknikler hakkında da bilgi sahibi olacaksınız. Böylece rakip internet siteleri arasından sıyrılarak bir web sitesini Google gibi arama motorlarında başarılı hale getirmenin yöntemlerini öğrenmiş olacaksınız. Seo uyumlu içerik üretimi konusunda bilgiler öğreneceksiniz.",
                Url = "html-css-js-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                ImageUrl= "html-css-js-ile-egitim.png",
                Kontenjan = 12,
                Price = 55.000m,
                PeriodOfStudy = 65 

            },
            new Lesson
            {
                Id = 20,
                Name = "Node.js ile Web Programlama",
                About = "Bu eğitimin amacı mevcut javascript programlama dili bilginizle nodejs kullanarak sıfırdan dinamik web uygulamalarını geliştirebilecek bilgi ve beceriyi kazandırmaktır.",
                Url = "node-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                AgenciesId = 1,
                 ImageUrl= "node-ile-egitim.png",
                Kontenjan = 12,
                Price = 55.000m,
                PeriodOfStudy = 65

            }
            );



        }
    }
}
