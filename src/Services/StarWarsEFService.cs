using System.Collections.Generic;
using System.Linq;
using taller.Model;
using taller.Data;

namespace taller.Services
{
    public class StarWarsEFService : IStarWarsService
    {
        IEnumerable<Films> FilmsCollection;
        IEnumerable<Characters> CharactersCollection;

        private EFCoreWebDemoContext _context;


        public StarWarsEFService(EFCoreWebDemoContext context)
        {
            _context = context;
        }

        IEnumerable<Characters> IStarWarsService.GetCharacters()
        {      
          return _context.Characters.ToList();
        }

        IEnumerable<Characters> IStarWarsService.GetCharactersByName(string name)
        {     
         return _context.Characters.Where(c=> c.Name == name).ToList();
        }

        IEnumerable<Films> IStarWarsService.GetFilms()
        {
             return _context.Films.ToList();      
        }

        IEnumerable<Films> IStarWarsService.GetFilmsByName(string name)
        {         
          return _context.Films.Where(c=> c.Name == name).ToList();
        }
    }
}