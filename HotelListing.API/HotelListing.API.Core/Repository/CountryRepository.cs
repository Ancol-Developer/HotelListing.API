using AutoMapper;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using HotelListing.API.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountriesRepository
    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;

        public CountryRepository(HotelListingDbContext context,IMapper mapper) : base(context, mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        public async Task<Country> GetDetails(int id)
        {
            var country= await _context.Countries.Include(q => q.Hotels)
                .FirstOrDefaultAsync(q => q.Id == id);
            if(country == null)
            {
                throw new NotFoundException(nameof(GetDetails),id);
            }
            return country;
        }
    }
}
