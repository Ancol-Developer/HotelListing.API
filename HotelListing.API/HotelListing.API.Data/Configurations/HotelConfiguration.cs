using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.API.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Sandals Resort and Spa",
                    Address = "Negril",
                    CountryID = 1,
                    Rating = 4.5
                },
               new Hotel
               {
                   ID = 2,
                   Name = "Comfort Suites",
                   Address = "George Town",
                   CountryID = 3,
                   Rating = 4.3
               },
               new Hotel
               {
                   ID = 3,
                   Name = "Grand Palldium",
                   Address = "Nassua",
                   CountryID = 2,
                   Rating = 4
               }
            );
        }
    }
}
