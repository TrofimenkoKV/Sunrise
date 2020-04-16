using System.Collections.Generic;
using Sunrise.Database.Model;
using System.Linq;
using Sunrise.Config;

namespace Sunrise.Database.Dao 
{
    public class CityDao {

        private DaoContext context = new DaoContext();

        public void SaveCity(City city) 
        {
            context.Cities.Add(city);
            context.SaveChanges();    
        }

        public City GetCityById(int id) 
        {
            return context.Cities.Find(id);
        }

        public void Delete(City city) 
        {
            context.Cities.Remove(city);
            context.SaveChanges();
        }

        public virtual City GetCityByName(string cityName) 
        {
            var query = from c in context.Cities where c.CityName == cityName select c;
            var city = query.FirstOrDefault<City>();
            return city;
        }

        public virtual List<City> GetAll() 
        {
            var query = from c in context.Cities select c;
            return query.ToList();
        }
        
    }

}