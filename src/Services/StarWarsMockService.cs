using System.Collections.Generic;
using System.Linq;
using taller.Model;

namespace taller.Services
{
    public class StarWarsMockService : IStarWarsService
    {
        IEnumerable<Films> FilmsCollection;
        IEnumerable<Characters> CharactersCollection;
        public StarWarsMockService()
        {
              this.FilmsCollection= new List<Films>{
                new Films { Id=1, Name="Una Nueva Esperanza"},
                new Films {Id=2,Name="El imperio contrataca"},
                new Films {Id=3, Name="El retorno del Jedi"},
                new Films {Id=4, Name="La amenza fantasma"},
                new Films {Id=5, Name="El ataque de los clones"},
                new Films {Id=6, Name="La venganza de los Sith"},
            };
            this.CharactersCollection= new List<Characters>{
                new Characters {Id=1, Name="Darth",SurName="Vader"},
                new Characters {Id=2, Name="Yoda",SurName=""},
                new Characters {Id=3, Name="Luke",SurName="Skywalker"},
                new Characters {Id=4, Name="Leia",SurName="Organa"},
                new Characters {Id=5, Name="Obi-Wan",SurName="Kenobi"},
            };
        }

        IEnumerable<Characters> IStarWarsService.GetCharacters()
        {
            return this.CharactersCollection;
        }

        IEnumerable<Characters> IStarWarsService.GetCharactersByName(string name)
        {
            return this.CharactersCollection.Where(x=>x.Name.Contains(name));
        }

        IEnumerable<Films> IStarWarsService.GetFilms()
        {
            return this.FilmsCollection;
        }

        IEnumerable<Films> IStarWarsService.GetFilmsByName(string name)
        {
            return this.FilmsCollection.Where(x=>x.Name.Contains(name));
        }
    }
}