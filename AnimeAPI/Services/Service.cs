using AnimeAPI.Models;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers;

namespace AnimeAPI.Services
{
    public class Service
    {
        public DataContext Db;
        public Service()
        {
            Db = new DataContext();
        }

        public bool AddAnime(Anime anime)
        {
            try
            {
                Db.Add(anime);
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteAnime(int Id) 
        {
            try
            {
                var anime = Db.Animes.FirstOrDefault(a => a.Id == Id);
                Db.Animes.Attach(anime);
                Db.Animes.Remove(anime);
                Db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Anime GetAnime(int Id)
        {
            var anime = Db.Animes.FirstOrDefault(a => a.Id == Id);
            if(anime == null) 
            {
                throw new Exception("Anime não encontrado");
            }

            return anime;
        }

        public Anime UpdateAnime(Anime AnimeUpdate)
        {
            try
            {
                var anime = Db.Animes.AsNoTracking().FirstOrDefault(x => x.Id == AnimeUpdate.Id);
                anime = AnimeUpdate;
                Db.Animes.Update(anime);
                Db.SaveChanges();

                return anime;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Anime> GetAll()
        {
            return Db.Animes.OrderBy(x =>  x.Id).ToList();
        }
    }
}
