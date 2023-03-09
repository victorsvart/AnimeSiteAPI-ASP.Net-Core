using AnimeAPI.Models;
using AnimeAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace AnimeAPI.Controllers
{
    public class AnimeController : ControllerBase
    {
        private readonly ILogger<AnimeController> _logger;

        private Service _Services;

        public AnimeController(ILogger<AnimeController> logger)
        {
            _logger = logger;
            _Services = new Service();
        }

        [HttpPost]
        [Route("AddAnime")]
        public string AddAnimeEndPoint([FromForm] Anime anime)
        {
            try
            {
                _Services.AddAnime(anime);
                return "Anime adicionado com sucesso!";
            }
            catch (Exception)
            {

                return "Erro ao adicionar anime";
            }
        }

        [HttpDelete]
        [Route("RemoveAnime")]
        public string RemoveAnimeEndpoint(int id)
        {
            try
            {
                _Services.DeleteAnime(id);
                return "Anime removido!";
            }
            catch (Exception)
            {

                return "Erro ao remover anime";
            }
        }

        [HttpGet]
        [Route("GetAnime")]
        public Anime GetAnimeEndpoint(int id)
        {
            try
            {
                return _Services.GetAnime(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("UpdateAnime")]
        public Anime UpdateAnimeEndpoint([FromBody] Anime anime)
        {
            try
            {
                return _Services.UpdateAnime(anime);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet]
        [Route("GetAll")]
        public List<Anime> GetAll()
        {
            var AnimeList = _Services.GetAll();
            return  AnimeList;
        }
    }
}
