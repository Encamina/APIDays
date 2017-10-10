using System.Collections.Generic;
using System.Linq;
using taller.Model;
using taller.Data;

namespace taller.Data
{
    public sealed class DbInitializer
    {
        private EFCoreWebDemoContext _context;

        public DbInitializer(EFCoreWebDemoContext context)
        {
            _context = context;
        }
        public void SeedData()
        {
            if (!_context.Characters.Any())
            {
                _context.Characters.Add(new Characters{Name = "Maestro",SurName ="Yoda",Clan ="Jedi"});
                _context.Characters.Add(new Characters{Name = "Obi",SurName ="One",Clan ="Jedi"});
                _context.Characters.Add(new Characters{Name = "Luk",SurName ="SkyWalker",Clan ="Jedi"});
                _context.Characters.Add(new Characters{Name = "Anakin",SurName ="SkyWalker",Clan ="Jedi"});
                _context.Characters.Add(new Characters{Name = "Darth",SurName ="Vader",Clan ="Lord Sith"});
                _context.Characters.Add(new Characters{Name = "Darth",SurName ="Pleguis",Clan ="Lord Sith"});
                _context.Characters.Add(new Characters{Name = "Darth",SurName ="Sidious",Clan ="Lord Sith"});
                _context.SaveChanges();
            }
            if (!_context.Films.Any())
            {
                _context.Films.Add(new Films(){Name ="Star Wars: Episode IV - A New Hope",Year="1977"});
                _context.Films.Add(new Films(){Name ="Star Wars: Episode V - The Empire Strikes Back",Year="1980"});
                _context.Films.Add(new Films(){Name ="Star Wars: Episode VI - Return of the Jedi",Year="1983"});
                _context.Films.Add(new Films(){Name ="Star Wars: Episode I - The Phantom Menace",Year="1999"});
                _context.Films.Add(new Films(){Name ="Star Wars: Episode II - Attack of the Clones",Year="2002"});
                _context.Films.Add(new Films(){Name ="Star Wars: Episode III - Revenge of the Sith",Year="2005"});
                _context.SaveChanges();
            }
        }
    }
}