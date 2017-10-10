using System.Collections.Generic;
using taller.Model;

namespace taller.Services
{
public interface IStarWarsService
{
 IEnumerable<Films> GetFilms();
  IEnumerable<Films> GetFilmsByName(string name);
  IEnumerable<Characters> GetCharacters();

    IEnumerable<Characters> GetCharactersByName(string name);
}
    

}