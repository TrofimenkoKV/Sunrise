using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sunrise.Database.Model 
{

    [Table("city")]
    public class City {

        public City (string CityName, double Longitude, double Latitude) {
            this.CityName = CityName;
            this.Longitude = Longitude;
            this.Latitude = Latitude;
        }

        [Key]
        [Column("id")]
        public int Id {get;set;}
        
        [Index("city_name_UNIQUE", IsUnique=true)]
        [Column("city_name")]
        [Required]
        public string CityName { get; set; }
        
        [Column("longitude")]
        [Required]
        public double Longitude { get; set; }
        
        [Column("latitude")]
        [Required]
        public double Latitude { get; set; }

        public override string ToString()
    {
        return "Id: " + Id + " City: " + CityName + " Longitude: " + Longitude + " Latitude: " + Latitude;
    }

}

}
