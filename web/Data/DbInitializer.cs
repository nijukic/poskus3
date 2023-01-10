using aplikacija.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;

namespace aplikacija.Data
{
    public static class DbInitializer
    {
        public static void Initialize(smartbuyContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Osebe.Any())
            {
                return;   // DB has been seeded
            }

            var proizvajalci = new Proizvajalec[]{
                new Proizvajalec{/*ProizvajalecID=1,*/Naziv="Intel",Opis="Intel"},
                new Proizvajalec{/*ProizvajalecID=2,*/Naziv="Nesquik",Opis="Nesquik"}
            };

            foreach (Proizvajalec a in proizvajalci)
            {
                context.Proizvajalci.Add(a);
            }
            context.SaveChanges();

            var kategorije = new Kategorija[]{
                new Kategorija{/*KategorijaID=1,*/Naziv="CPE"},
                new Kategorija{/*KategorijaID=2,*/Naziv="Hrana"}
            };
            
            foreach (Kategorija a in kategorije)
            {
                context.Kategorije.Add(a);
            }
            context.SaveChanges();
            
            
            
            var artikli = new Artikel[]
            {
            new Artikel{KategorijaID=1,Naziv="avto",Cena=2323,Zaloga=5,Opis="sdsdsdsds",ProizvajalecID=1},
            new Artikel{KategorijaID=1,Naziv="pc",Cena=2345,Zaloga=5,Opis="asasadsd",ProizvajalecID=1},
            new Artikel{KategorijaID=1,Naziv="monitor",Cena=56434,Zaloga=5,Opis="asasdas",ProizvajalecID=1},
            new Artikel{KategorijaID=1,Naziv="vrata",Cena=233534,Zaloga=5,Opis="sasacsasa",ProizvajalecID=1},
            new Artikel{KategorijaID=1,Naziv="okno",Cena=2432,Zaloga=5,Opis="asfcdvd",ProizvajalecID=1},
            new Artikel{KategorijaID=1,Naziv="telefon",Cena=45423,Zaloga=5,Opis="asdsdxyad",ProizvajalecID=1},
            new Artikel{KategorijaID=1,Naziv="tipkovnica",Cena=233412,Zaloga=5,Opis="sadsfsfqs",ProizvajalecID=1}
            };
            foreach (Artikel a in artikli)
            {
                context.Artikli.Add(a);
            }
            context.SaveChanges();
            
            /*
            var ocene = new Ocena[]
            {
            new Ocena{OsebaID=1,ArtikelID=1,Vrednost=Vrednost.A,Opis="opsiujem oceno",potrjenNakup=true},
            new Ocena{OsebaID=1,ArtikelID=2,Vrednost=Vrednost.C,Opis="opsiujem oceno",potrjenNakup=true},
            new Ocena{OsebaID=1,ArtikelID=3,Vrednost=Vrednost.B,Opis="opsiujem oceno",potrjenNakup=true},
            new Ocena{OsebaID=2,ArtikelID=4,Vrednost=Vrednost.B,Opis="opsiujem oceno",potrjenNakup=true},
            new Ocena{OsebaID=2,ArtikelID=4,Vrednost=Vrednost.F,Opis="opsiujem oceno",potrjenNakup=true},
            new Ocena{OsebaID=2,ArtikelID=1,Vrednost=Vrednost.F,Opis="opsiujem oceno",potrjenNakup=true},
            new Ocena{OsebaID=3,ArtikelID=5,Vrednost=Vrednost.F,Opis="opsiujem oceno",potrjenNakup=true},
            new Ocena{OsebaID=4,ArtikelID=6,Vrednost=Vrednost.F,Opis="opsiujem oceno",potrjenNakup=true},
            new Ocena{OsebaID=4,ArtikelID=6,Vrednost=Vrednost.F,Opis="opsiujem oceno",potrjenNakup=true},
            new Ocena{OsebaID=5,ArtikelID=1,Vrednost=Vrednost.C,Opis="opsiujem oceno",potrjenNakup=true},
            new Ocena{OsebaID=6,ArtikelID=3,Vrednost=Vrednost.F,Opis="opsiujem oceno",potrjenNakup=true},
            new Ocena{OsebaID=7,ArtikelID=1,Vrednost=Vrednost.A,Opis="opsiujem oceno",potrjenNakup=true},
            };
            foreach (Ocena oc in ocene)
            {
                context.Ocene.Add(oc);
            }*/

            var tipprevzema = new TipPrevzema[]
            {
            new TipPrevzema{/*TipPrevzemaID=1,*/Naziv="Prevzem v prodajalni"},
            new TipPrevzema{/*TipPrevzemaID=2,*/Naziv="Dostava na dom"}
            };
            foreach (TipPrevzema tp in tipprevzema)
            {
                context.TipiPrevzema.Add(tp);
            }
            context.SaveChanges();

            var status = new Status[]
            {
            new Status{/*StatusID=1,*/Naziv="V dostavi"},
            new Status{/*StatusID=2,*/Naziv="Oddano"},
            new Status{/*StatusID=3,*/Naziv="Preklicano"},
            new Status{/*StatusID=4,*/Naziv="Plačano"},
            new Status{/*StatusID=5,*/Naziv="Se pripravlja"}
            };
            foreach (Status st in status)
            {
                context.Statusi.Add(st);
            }
            context.SaveChanges();

            var vrstaplacila = new VrstaPlacila[]
            {
            new VrstaPlacila{/*VrstaPlacilaID=1,*/Naziv="Gotovina"},
            new VrstaPlacila{/*VrstaPlacilaID=2,*/Naziv="Plačilna kartica"},
            new VrstaPlacila{/*VrstaPlacilaID=3,*/Naziv="Bančno nakazilo"}
            };
            foreach (VrstaPlacila vp in vrstaplacila)
            {
                context.VrstePlacila.Add(vp);
            }
            context.SaveChanges();


            var roles = new IdentityRole[]{
                new IdentityRole{Id = "1", Name = "Administrator"},
                new IdentityRole{Id = "2", Name = "Zaposlen"},
                new IdentityRole{Id = "3", Name = "Stranka"}
            };

            foreach (IdentityRole r in roles)
            {
                context.Roles.Add(r);
            }

            context.SaveChanges();

            var user = new ApplicationUser
            {
                Email = "admin@test.com",
                NormalizedEmail = "XXXX@TEST.COM",
                UserName = "admin@test.com",
                NormalizedUserName = "admin@test.com",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "Testni123!");
                user.PasswordHash = hashed;
                context.Users.Add(user);
            }

            context.SaveChanges();

            var UserRoles = new IdentityUserRole<string>[]{
                new IdentityUserRole<string>{RoleId = roles[0].Id, UserId = user.Id},
                new IdentityUserRole<string>{RoleId = roles[1].Id, UserId = user.Id}
            };

            foreach (IdentityUserRole<string> r in UserRoles)
            {
                context.UserRoles.Add(r);
            }


            context.SaveChanges();
        }
    }
}