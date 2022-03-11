using Projekt_Biblioteka.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Projekt_Biblioteka.Data.Static;

namespace Projekt_Biblioteka.Data
{
    public class AppDbInitializer
    {
        public static void SeedAuthors(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<AppDbContext>();

                db.Database.EnsureCreated();

                if (!db.Authors.Any())
                {
                    db.Authors.AddRange(new List<Author>()
                    {
                       new Author()
                        {
                            FullName = "Sarah J. Maas",
                            ImageURL = "https://s.lubimyczytac.pl/upload/authors/74122/249050-140x200.jpg",
                            Bio = "Amerykańska pisarka powieści fantasy. Zadebiutowała w 2012 powieścią Szklany tron opublikowaną przez Bloomsbury. Książka zajęła pierwsze miejsce na liście bestsellerów New York Timesa."
                        },
                        new Author()
                        {
                            FullName = "Samantha Shannon",
                            ImageURL = "https://s.lubimyczytac.pl/upload/authors/81732/766091-140x200.jpg",
                            Bio = "Urodziła się w zachodnim Londynie w 1991 roku. Zaczęła pisać w wieku piętnastu lat. W latach 2010–2013 studiowała angielską literaturę i literaturę powszechną w college’u Świętej Anny w Oxfordzie."
                        },
                        new Author()
                        {
                            FullName = "Stephen King",
                            ImageURL = "https://s.lubimyczytac.pl/upload/authors/13997/849814-140x200.jpg",
                            Bio = "Amerykański powieściopisarz, głównie literatury grozy. W przeszłości publikował pod pseudonimem Richard Bachman, raz jako John Swithen."
                        },
                        new Author()
                        {
                            FullName = "Waris Dirie",
                            ImageURL = "https://s.lubimyczytac.pl/upload/authors/25959/210-140x200.jpg",
                            Bio = "Somalijska modelka i pisarka. Najbardziej znana, obok Iman, Somalijka na świecie."
                        },
                        new Author()
                        {
                            FullName = "Cathleen Miller",
                            ImageURL = "https://static.wixstatic.com/media/74fe5e_875afcbb206947a29c302a4b584059ef.jpg/v1/fill/w_451,h_548,al_c,lg_1,q_80/74fe5e_875afcbb206947a29c302a4b584059ef.webp",
                            Bio = "Cathleen Miller to najlepiej sprzedająca się na świecie amerykańska pisarka non-fiction, która mieszka w Kalifornii."
                        },

                    });
                    db.SaveChanges();
                }
            }
        }
        public static void SeedPublishers(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<AppDbContext>();

                db.Database.EnsureCreated();

                if (!db.Publishers.Any())
                {
                    db.Publishers.AddRange(new List<Publisher>()
                    {
                       new Publisher()
                        {
                            Name = "Urobors",
                            ImageURL = "https://s.lubimyczytac.pl/upload/publishers/9466/9466-b.jpg",
                            Description = "Uroboros wchodzi w skład Grupy Wydawniczej Foksal, specjalizuje się w wydawaniu fantastyki dla dorosłych i młodzieży."
                       },
                       new Publisher()
                        {
                            Name = "Sine Qua Non",
                            ImageURL = "https://s.lubimyczytac.pl/upload/publishers/8256/8256-b.jpg",
                            Description = "Wydawnictwo literackie powstałe w 2010 roku, wydające przede wszystkim książki o sporcie oraz beletrystykę, biografię, kryminały czy powieści historyczne."
                       },
                       new Publisher()
                        {
                            Name = "Prószyński i S-ka",
                            ImageURL = "https://s.lubimyczytac.pl/upload/publishers/7576/7576-b.jpg",
                            Description = "PRÓSZYŃSKI I S-KA to marka jednego z największych wydawnictw książkowych w Polsce. Dzięki nim co roku na księgarskie półki trafia blisko 200 tytułów sygnowanych logo Prószyński i S-ka, adresowanych do ludzi o bardzo różnych zainteresowaniach, z praktycznie wszystkich grup wiekowych."
                       },
                       new Publisher()
                        {
                            Name = "Świat Książki",
                            ImageURL = "https://s.lubimyczytac.pl/upload/publishers/8831/8831-b.jpg",
                            Description = "Wydawnictwo Świat Książki działa na polskim rynku od 1994 roku. Na początku stanowiło część Bertelsmann Media sp. z o.o., którego w roku 2011 właścicielem stała się grupa wydawnicza Weltbild. W roku 2013 w związku z zakończeniem przez Weltbild działalności w Polsce powstał Świat Książki sp. z o.o., w którym 100 % udziałów należy obecnie do \"Dressler Sp. z o. o.\" Dublin Sp. komandytowo-akcyjna. Wyłącznym dystrybutorem oferty wydawniczej Świata Książki jest FK Olesiejuk."
                       },
                    });
                    db.SaveChanges();
                }
            }
        }
        public static void SeedBookCategories(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<AppDbContext>();

                db.Database.EnsureCreated();

                if (!db.Categories.Any())
                {
                    db.Categories.AddRange(new List<Category>()
                    {
                       new Category()
                        {
                            Name = "Fantasy i Sci-fi",
                      },
                       new Category()
                        {
                            Name = "Horror",
                        },
                       new Category()
                        {
                            Name = "Biografia",
                       },
                    });
                    db.SaveChanges();
                }
            }
        }
        public static void SeedBooks(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<AppDbContext>();

                db.Database.EnsureCreated();

                if (!db.Books.Any())
                {
                    db.Books.AddRange(new List<Book>()
                    {
                       new Book()
                        {
                            Title = "Dwór cierni i róż",
                            ImageURL = "https://s.lubimyczytac.pl/upload/books/295000/295801/611382-170x243.jpg",
                            Description = "Dziewiętnastoletnia Feyre jest łowczynią – musi polować, by wykarmić i utrzymać rodzinę. Podczas srogiej zimy zapuszcza się w poszukiwaniu zwierzyny coraz dalej, w pobliże muru, który oddziela ludzkie ziemie od Prythian – krainy zamieszkanej przez czarodziejskie istoty. To rasa obdarzonych magią i śmiertelnie niebezpiecznych stworzeń, która przed wiekami panowała nad światem. \n Kiedy podczas polowania Feyre zabija ogromnego wilka, nie wie, że tak naprawdę strzela do faerie.Wkrótce w drzwiach jej chaty staje pochodzący z Wysokiego Rodu Tamlin, w postaci złowrogiej bestii, żądając zadośćuczynienia za ten czyn.Feyre musi wybrać – albo zginie w nierównej walce, albo uda się razem z Tamlinem do Prythian i spędzi tam resztę swoich dni. \n Pozornie dzieli ich wszystko – wiek, pochodzenie, ale przede wszystkim nienawiść, która przez wieki narosła między ich rasami. Jednak tak naprawdę są do siebie podobni o wiele bardziej, niż im się wydaje.Czy Feyre będzie w stanie pokonać swój strach i uprzedzenia? \n Pełna namiętności i pasji, romantyczna, brutalna i okrutna. Jedno jest pewne: Dwór cierni i róż to z pewnością nie cukierkowa baśń w stylu Disneya…",
                            RelaseDate = new DateTime(2016, 4, 27),
                            IsBorrowed = false,
                            CategoryId = 1,
                            PublisherId = 1,
                            ISBN = "9788328021419"
                       },
                       new Book()
                        {
                            Title = "Czas Żniw",
                            ImageURL = "https://s.lubimyczytac.pl/upload/books/195000/195128/190869-170x243.jpg",
                            Description = "Sajon.\n Nie ma bezpieczniejszego miejsca. \n „Może nie wiesz, ale Żniwa nazywane są też dobrymi zbiorami. Wciąż mówią tak na ulicach: Dobre Żniwa, Zbiory Obfitości. Rozumieją to jako odbieranie nagrody, podstawowy warunek ich negocjacji z Sajonem. Ludzie oczywiście postrzegają je inaczej. Dla nich są symbolem nieszczęścia. Oznaczają głód. Śmierć. Dlatego nazywają nas kosiarzami. Ponieważ pomagamy prowadzić ludzi na śmierć”. \n Rok 2059. Dziewiętnastoletnia Paige Mahoney pracuje w kryminalnym podziemiu Sajonu Londyn. Jej szefem jest Jaxon Hall, na którego zlecenie pozyskuje informacje, włamując się do ludzkich umysłów. Paige jest sennym wędrowcem i w świecie, w którym przyszło jej żyć, zdradą jest już sam fakt, że oddycha. \n Pewnego dnia jej życie zmienia się na zawsze. Na skutek fatalnego splotu okoliczności zostaje przetransportowana do Oksfordu – tajemniczej kolonii karnej, której istnienie od dwustu lat utrzymywane jest w tajemnicy.Kontrolę nad nią sprawuje potężna, pochodząca z innego świata rasa Refaitów. Paige trafia pod protektorat tajemniczego Naczelnika – staje się on jej panem i trenerem, jej naturalnym wrogiem.Jeśli Paige chce odzyskać wolność, musi poddać się zasadom panującym w miejscu, w którym została przeznaczona na śmierć.",
                            RelaseDate = new DateTime(2013, 11, 6),
                            IsBorrowed = true,
                            CategoryId = 1,
                            PublisherId = 2,
                            ISBN = "9788379240821"
                       },
                       new Book()
                        {
                            Title = "Smętarz dla zwierzaków",
                            ImageURL = "https://s.lubimyczytac.pl/upload/books/4882000/4882388/732529-170x243.jpg",
                            Description = "Czasami martwe jest lepsze. \n Zazwyczaj przeprowadzka to początek nowego życia, ale dla rodziny Creedów stała się początkiem ich końca. Mistrz horroru Stephen King zaprasza czytelników na wycieczkę do piekła i z powrotem! \n Na świecie istnieją dobre i złe miejsca.Nowy dom rodziny Creedów w Ludlow był niewątpliwie dobrym miejscem -przytulną, przyjazną wiejską przystanią po zgiełku i chaosie Chicago. Cudowne otoczenie Nowej Anglii, łąki, las to idealna siedziba dla młodego lekarza, jego żony, dwójki dzieci i kota. Wspaniała praca, mili sąsiedzi i droga, po której nieustannie przetaczają się ciężarówki. Droga i miejsce za domem, w lesie, pełne wzniesionych dziecięcymi rękami nagrobków -to tam dzieci z miasteczka zakopują swe martwe zwierzaki. Ci, którzy nie znają przeszłości, zwykle ją powtarzają... i nie chcą słuchać ostrzeżeń.",
                            RelaseDate = new DateTime(2019, 4, 23),
                            IsBorrowed = false,
                            CategoryId = 2,
                            PublisherId = 3,
                            ISBN = "9788381690584"
                       },
                       new Book()
                        {
                            Title = "Kwiat pustyni. Z namiotu Nomadów do Nowego Jorku",
                            ImageURL = "https://s.lubimyczytac.pl/upload/books/47000/47775/170x243.jpg",
                            Description = "Waris urodziła się w Somalii, w plemieniu pustynnych wędrowców, wychowała się pośród kóz, bydła i wielbłądów.\nW wieku 13 lat dziewczęta z tego plemienia są poddawane rytuałowi obrzezania i wydawane za mąż. Jednak bohaterka książki została poddana obrzezaniu w wieku około 5 lat, a miała być wydana za mąż dopiero w wieku 13 lat\nTe dwa wydarzenia zaważyły na całym przyszłym życiu Waris.",
                            RelaseDate = new DateTime(2002, 1, 1),
                            IsBorrowed = true,
                            CategoryId = 3,
                            PublisherId = 4,
                            ISBN = "8372272808"
                       },
                       new Book()
                        {
                            Title = "Dwór srebrnych płomieni część 1",
                            ImageURL = "https://s.lubimyczytac.pl/upload/books/4965000/4965132/960268-170x243.jpg",
                            Description = "Nesta Archeron od zawsze była dumna, wybuchowa i niezbyt skłonna do wybaczania. Odkąd zmuszono ją do wejścia do Kotła i została Fae wbrew swojej woli, walczy o znalezienie własnego miejsca dla siebie w zabójczym i niebezpiecznym świecie. Co gorsza, wojna i wszystko, co w niej straciła, wypaliły w jej duszy niezatarte piętno.Jedyną osobą, która rozpala ją bardziej niż ktokolwiek inny, jest Kasjan, tajemniczy i twardy wojownik na Dworze Nocy Rhysanda i Feyry. Między Nestą a Kasjanem płonie prawdziwy ogień. Żar jednak może spalić lub oczyścić.Tymczasem zdradzieckie ludzkie królowe, które powróciły na kontynent podczas ostatniej wojny, zawarły nowy niebezpieczny sojusz, zagrażający kruchemu pokojowi, który zapanował w królestwach. Klucz do powstrzymania kolejnej wojny dzierżą wspólnie właśnie Nesta i Kasjan. By jednak ocalenie pokoju było możliwe, te dwa żywioły muszą zacząć ze sobą współpracować. Czy będzie to możliwe?",
                            RelaseDate = new DateTime(2021, 11, 10),
                            IsBorrowed = false,
                            CategoryId = 1,
                            PublisherId = 1,
                            ISBN = "9788328092839"
                       },
                       new Book()
                        {
                            Title = "Dom ziemi i krwi. Część 1",
                            ImageURL = "https://s.lubimyczytac.pl/upload/books/4923000/4923601/809192-170x243.jpg",
                            Description = "Bryce Quinlan jest dziewczyną, która w połowie jest człowiekiem, a w połowie Fae. W świecie pełnym magii, niebezpieczeństw i ognistych romansów poszukuje zemsty! Bryce Quinlan kocha swoje życie. W dzień pracuje dla handlarza antyków, sprzedając nie do końca legalne magiczne artefakty, a nocą imprezuje razem z przyjaciółmi, delektując się każdą przyjemnością jaką Lunathion – znane również jako Crescent City – ma do zaoferowania.Ale gdy bezwzględne morderstwo wstrząsa miastem, wszystko zaczyna się rozpadać – również świat Bryce.",
                            RelaseDate = new DateTime(2020, 5, 20),
                            IsBorrowed = false,
                            CategoryId = 1,
                            PublisherId = 1,
                            ISBN = "9788328052062"
                       },
                       new Book()
                        {
                            Title = "Catwoman. Złodziejka dusz",
                            ImageURL = "https://s.lubimyczytac.pl/upload/books/4899000/4899214/769808-170x243.jpg",
                            Description = "Selina Kyle to złodziejka. Dwa lata po ucieczce ze slumsów Gotham City Selina Kyle wraca jako tajemnicza i bogata Holly Vanderhees. Szybko odkrywa, że Batman wyjechał z ważną misją i Gotham City czeka, żeby je oskubać. Luke Fox jest bohaterem. Luke pragnie dowieść, że Batwing jest w stanie pomóc ludziom. Bierze na cel nową złodziejkę, która sprzymierzyła się z Poison Ivy i Harley Quinn. Razem rozpętują chaos. Catwoman jest cwana. Może zniszczyć Batwinga. W Gotham City nie każdy jest tym, na kogo wygląda. Selina prowadzi rozpaczliwą grę w kotka i myszkę, zawiązując nieoczekiwane sojusze, wikłając się w skomplikowaną relację z Batwingiem nocą i swoim diabelnie przystojnym sąsiadem Luke’iem Foxem za dnia. Jednak kiedy własna niebezpieczna przeszłość depcze jej po piętach, czy zdoła przeprowadzić ostatni skok, którego cel jest najbliższy jej sercu?",
                            RelaseDate = new DateTime(2019, 11, 27),
                            IsBorrowed = false,
                            CategoryId = 1,
                            PublisherId = 1,
                            ISBN = "9788366409415"
                       }

                    });
                    db.SaveChanges();
                }
            }
        }
        public static void SeedAuthorsBook(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<AppDbContext>();

                db.Database.EnsureCreated();

                if (!db.Authors_Books.Any())
                {
                    db.Authors_Books.AddRange(new List<Author_Book>()
                    {
                       new Author_Book()
                        {
                            AuthorId = 1,
                            BookId = 1
                       },
                       new Author_Book()
                        {
                            AuthorId = 2,
                            BookId = 2
                       },
                       new Author_Book()
                        {
                            AuthorId = 3,
                            BookId = 3
                       },
                       new Author_Book()
                        {
                            AuthorId = 4,
                            BookId = 4
                       },
                       new Author_Book()
                        {
                            AuthorId = 5,
                            BookId = 4
                       },
                       new Author_Book()
                        {
                            AuthorId = 1,
                            BookId = 5
                       },
                       new Author_Book()
                        {
                            AuthorId = 1,
                            BookId = 6
                       },
                       new Author_Book()
                        {
                            AuthorId = 1,
                            BookId = 7
                       }
                    });
                    db.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Reader))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Reader));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string adminEmail = "admin@admin.com";

                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        FirstName = "Admin",
                        Surname = "Admin",
                        Address = "AdminAdress",
                        PostalCode = "00-000",
                        City = "AdminCity",
                        PESEL = "0000000000",
                        UserName = "Admin",
                        Email = adminEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin123!");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string readerEmail = "reader@reader.com";

                var readerUser = await userManager.FindByEmailAsync(readerEmail);
                if (readerUser == null)
                {
                    var newReaderUser = new AppUser()
                    {
                        FirstName = "Reader",
                        Surname = "Reader",
                        Address = "ReaderAdress",
                        PostalCode = "00-000",
                        City = "ReaderCity",
                        PESEL = "0000000000",
                        UserName = "Reader",
                        Email = readerEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newReaderUser, "Reader123!");
                    await userManager.AddToRoleAsync(newReaderUser, UserRoles.Reader);
                }
            }
        }
    }
}





