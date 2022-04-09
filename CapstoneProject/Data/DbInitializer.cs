using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneProject.Models;

namespace CapstoneProject.Data
{
    public class DbInitializer
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var boots = new Boot[]
            {
                new Boot{TypeId=2,Brand="DC",Description="Judge",Size="Large"},
                new Boot{TypeId=2,Brand="DC",Description="Control",Size="Large"},
                new Boot{TypeId=2,Brand="thirtytwo",Description="JonesMTB",Size="Large"},
                new Boot{TypeId=2,Brand="thirtytwo",Description="TM-3XD",Size="Large"},
                new Boot{TypeId=2,Brand="Ride",Description="Trident",Size="Large"},
                new Boot{TypeId=2,Brand="Ride",Description="Insano",Size="Large"},
                new Boot{TypeId=2,Brand="Ride",Description="Anchor",Size="Large"},
                new Boot{TypeId=2,Brand="Adidas",Description="Samba",Size="Large"},
                new Boot{TypeId=2,Brand="Adidas",Description="Lexicon",Size="Large"},

                new Boot{TypeId=2,Brand="DC",Description="Judge",Size="Medium"},
                new Boot{TypeId=2,Brand="DC",Description="Control",Size="Medium"},
                new Boot{TypeId=2,Brand="thirtytwo",Description="JonesMTB",Size="Medium"},
                new Boot{TypeId=2,Brand="thirtytwo",Description="TM-3XD",Size="Medium"},
                new Boot{TypeId=2,Brand="Ride",Description="Trident",Size="Medium"},
                new Boot{TypeId=2,Brand="Ride",Description="Insano",Size="Medium"},
                new Boot{TypeId=2,Brand="Ride",Description="Anchor",Size="Medium"},
                new Boot{TypeId=2,Brand="Adidas",Description="Samba",Size="Medium"},
                new Boot{TypeId=2,Brand="Adidas",Description="Lexicon",Size="Medium"},

                new Boot{TypeId=2,Brand="DC",Description="Judge",Size="Small"},
                new Boot{TypeId=2,Brand="DC",Description="Control",Size="Small"},
                new Boot{TypeId=2,Brand="thirtytwo",Description="JonesMTB",Size="Small"},
                new Boot{TypeId=2,Brand="thirtytwo",Description="TM-3XD",Size="Small"},
                new Boot{TypeId=2,Brand="Ride",Description="Trident",Size="Small"},
                new Boot{TypeId=2,Brand="Ride",Description="Insano",Size="Small"},
                new Boot{TypeId=2,Brand="Ride",Description="Anchor",Size="Small"},
                new Boot{TypeId=2,Brand="Adidas",Description="Samba",Size="Small"},
                new Boot{TypeId=2,Brand="Adidas",Description="Lexicon",Size="Small"},
            };
            foreach (Boot b in boots)
            {
                context.Boots.Add(b);
            }
            context.SaveChanges();

            var coats = new Coat[]
            {
                new Coat{TypeId=3,Brand="DC",Description="Operative",Size="Large"},
                new Coat{TypeId=3,Brand="DC",Description="Servo",Size="Large"},
                new Coat{TypeId=3,Brand="Volcom",Description="Brighton",Size="Large"},
                new Coat{TypeId=3,Brand="Volcom",Description="BL Stretch",Size="Large"},
                new Coat{TypeId=3,Brand="Oakley",Description="Rc Jacket",Size="Large"},
                new Coat{TypeId=3,Brand="Oakley",Description="Bowls Pro",Size="Large"},

                new Coat{TypeId=3,Brand="DC",Description="Operative",Size="Medium"},
                new Coat{TypeId=3,Brand="DC",Description="Servo",Size="Medium"},
                new Coat{TypeId=3,Brand="Volcom",Description="Brighton",Size="Medium"},
                new Coat{TypeId=3,Brand="Volcom",Description="BL Stretch",Size="Medium"},
                new Coat{TypeId=3,Brand="Oakley",Description="Rc Jacket",Size="Medium"},
                new Coat{TypeId=3,Brand="Oakley",Description="Bowls Pro",Size="Medium"},

                new Coat{TypeId=3,Brand="DC",Description="Operative",Size="Small"},
                new Coat{TypeId=3,Brand="DC",Description="Servo",Size="Small"},
                new Coat{TypeId=3,Brand="Volcom",Description="Brighton",Size="Small"},
                new Coat{TypeId=3,Brand="Volcom",Description="BL Stretch",Size="Small"},
                new Coat{TypeId=3,Brand="Oakley",Description="Rc Jacket",Size="Small"},
                new Coat{TypeId=3,Brand="Oakley",Description="Bowls Pro",Size="Small"},
            };
            foreach (Coat c in coats)
            {
                context.Coats.Add(c);
            }
            context.SaveChanges();

            var snowboards = new Snowboard[]
            {
                new Snowboard{TypeId=1,Brand="Lib Tech",Description="Orca",Size="Large"},
                new Snowboard{TypeId=1,Brand="Lib Tech",Description="T.Rice Pro",Size="Large"},
                new Snowboard{TypeId=1,Brand="Lib Tech",Description="Cold Brew",Size="Large"},
                new Snowboard{TypeId=1,Brand="Burton",Description="Flying V",Size="Large"},
                new Snowboard{TypeId=1,Brand="Burton",Description="Custom X",Size="Large"},
                new Snowboard{TypeId=1,Brand="Burton",Description="Deep Thinker",Size="Large"},
                new Snowboard{TypeId=1,Brand="Bataleon",Description="Surfer",Size="Large"},
                new Snowboard{TypeId=1,Brand="Bataleon",Description="Goliath",Size="Large"},
                new Snowboard{TypeId=1,Brand="Bataleon",Description="Chaser",Size="Large"},

                new Snowboard{TypeId=1,Brand="Lib Tech",Description="Orca",Size="Medium"},
                new Snowboard{TypeId=1,Brand="Lib Tech",Description="T.Rice Pro",Size="Medium"},
                new Snowboard{TypeId=1,Brand="Lib Tech",Description="Cold Brew",Size="Medium"},
                new Snowboard{TypeId=1,Brand="Burton",Description="Flying V",Size="Medium"},
                new Snowboard{TypeId=1,Brand="Burton",Description="Custom X",Size="Medium"},
                new Snowboard{TypeId=1,Brand="Burton",Description="Deep Thinker",Size="Medium"},
                new Snowboard{TypeId=1,Brand="Bataleon",Description="Surfer",Size="Medium"},
                new Snowboard{TypeId=1,Brand="Bataleon",Description="Goliath",Size="Medium"},
                new Snowboard{TypeId=1,Brand="Bataleon",Description="Chaser",Size="Medium"},

                new Snowboard{TypeId=1,Brand="Lib Tech",Description="Orca",Size="Small"},
                new Snowboard{TypeId=1,Brand="Lib Tech",Description="T.Rice Pro",Size="Small"},
                new Snowboard{TypeId=1,Brand="Lib Tech",Description="Cold Brew",Size="Small"},
                new Snowboard{TypeId=1,Brand="Burton",Description="Flying V",Size="Small"},
                new Snowboard{TypeId=1,Brand="Burton",Description="Custom X",Size="Small"},
                new Snowboard{TypeId=1,Brand="Burton",Description="Deep Thinker",Size="Small"},
                new Snowboard{TypeId=1,Brand="Bataleon",Description="Surfer",Size="Small"},
                new Snowboard{TypeId=1,Brand="Bataleon",Description="Goliath",Size="Small"},
                new Snowboard{TypeId=1,Brand="Bataleon",Description="Chaser",Size="Small"},
            };
            foreach (Snowboard s in snowboards)
            {
                context.Snowboards.Add(s);
            }
            context.SaveChanges();

            var helmets = new Helmet[]
            {
                new Helmet{TypeId=4,Brand="Anon",Description="Invert",Size="Large"},
                new Helmet{TypeId=4,Brand="Anon",Description="Helo",Size="Large"},
                new Helmet{TypeId=4,Brand="Giro",Description="Spherical",Size="Large"},
                new Helmet{TypeId=4,Brand="Giro",Description="Trig Mips",Size="Large"},
                new Helmet{TypeId=4,Brand="Oakley",Description="Mod 3",Size="Large"},
                new Helmet{TypeId=4,Brand="Oakley",Description="Mod 1",Size="Large"},
                new Helmet{TypeId=4,Brand="Oakley",Description="Mod 5",Size="Large"},
                new Helmet{TypeId=4,Brand="Anon",Description="Logan WaveCel",Size="Large"},

                new Helmet{TypeId=4,Brand="Anon",Description="Invert",Size="Medium"},
                new Helmet{TypeId=4,Brand="Anon",Description="Helo",Size="Medium"},
                new Helmet{TypeId=4,Brand="Giro",Description="Spherical",Size="Medium"},
                new Helmet{TypeId=4,Brand="Giro",Description="Trig Mips",Size="Medium"},
                new Helmet{TypeId=4,Brand="Oakley",Description="Mod 3",Size="Medium"},
                new Helmet{TypeId=4,Brand="Oakley",Description="Mod 1",Size="Medium"},
                new Helmet{TypeId=4,Brand="Oakley",Description="Mod 5",Size="Medium"},
                new Helmet{TypeId=4,Brand="Anon",Description="Logan WaveCel",Size="Medium"},

                new Helmet{TypeId=4,Brand="Anon",Description="Invert",Size="Small"},
                new Helmet{TypeId=4,Brand="Anon",Description="Helo",Size="Small"},
                new Helmet{TypeId=4,Brand="Giro",Description="Spherical",Size="Small"},
                new Helmet{TypeId=4,Brand="Giro",Description="Trig Mips",Size="Small"},
                new Helmet{TypeId=4,Brand="Oakley",Description="Mod 3",Size="Small"},
                new Helmet{TypeId=4,Brand="Oakley",Description="Mod 1",Size="Small"},
                new Helmet{TypeId=4,Brand="Oakley",Description="Mod 5",Size="Small"},
                new Helmet{TypeId=4,Brand="Anon",Description="Logan WaveCel",Size="Small"},
            };
            foreach (Helmet h in helmets)
            {
                context.Helmets.Add(h);
            }
            context.SaveChanges();
        }
    }
}
