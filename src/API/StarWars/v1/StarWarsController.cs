using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using taller.Model;
using taller.Services;

namespace taller.Controllers.StarWars.v1
{

   [Route("api/StarWars/")]
    [ApiVersion("1.0")]
    public class StarWarsController : Controller
    {
       private readonly IStarWarsService service;
        public StarWarsController(IStarWarsService service){
            this.service=service;
        }
        [HttpGet("films")]
        public IEnumerable<Films> GetFilms()
        {
            return this.service.GetFilms();
           
        }
         [HttpGet("films/{name}")]
        public IEnumerable<Films>GetFilmsByName(string name)
        {
            return this.service.GetFilmsByName(name);
        }
         [HttpGet("character")]
        public IEnumerable<Characters> GetCharacters()
        {
            return this.service.GetCharacters();
        }
           [HttpGet("character/{name}")]
        public IEnumerable<Characters> GetCharactersByName(string name)
        {
            return this.service.GetCharactersByName(name);
        }
    
  
    }
}
