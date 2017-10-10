using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using taller.Model;


namespace taller.Controllers.StarWars.v2
{
 
       [Route("api/StarWars/")]
       [ApiVersion("2.0")]
    public class StarWarsController : Controller
    {
        IEnumerable<Films> FilmsCollection;
        IEnumerable<Characters> CharactersCollection;
        public StarWarsController(){
            this.FilmsCollection= new List<Films>{
                new Films { Id=1, Name="A new hope"},
                new Films {Id=2,Name="The Empire Strikes Back"},
                new Films {Id=3, Name="The return of the Jedi"},
                new Films {Id=4, Name="The Phantom Menace"},
                new Films {Id=5, Name="Attack of the clones"},
                new Films {Id=6, Name="Revenge of the Sith"},
            };
            this.CharactersCollection= new List<Characters>{
                new Characters {Id=1, Name="Darth",SurName="Vader"},
                new Characters {Id=2, Name="Yoda",SurName=""},
                new Characters {Id=3, Name="Luke",SurName="Skywalker"},
                new Characters {Id=4, Name="Leia",SurName="Organa"},
                new Characters {Id=5, Name="Obi-Wan",SurName="Kenobi"},
            };
        }
        [HttpGet("films")]
        public IEnumerable<Films> GetFilms()
        {
            return this.FilmsCollection;
           
        }
         [HttpGet("films/{name}")]
        public IEnumerable<Films>GetFilmsByName(string name)
        {
            return this.FilmsCollection.Where(x=>x.Name.Contains(name));
        }
         [HttpGet("character")]
        public IEnumerable<Characters> GetCharacters()
        {
            return this.CharactersCollection;
        }
           [HttpGet("character/{name}")]
        public IEnumerable<Characters> GetCharactersByName(string name)
        {
            return this. CharactersCollection.Where(x=>x.Name.Contains(name));
        }
    
  
    }
}
