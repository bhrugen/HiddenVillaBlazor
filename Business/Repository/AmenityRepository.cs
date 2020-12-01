using AutoMapper;
using Business.Repository.IRepository;
using DataAcesss.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class AmenityRepository : IAmenityRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AmenityRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HotelAmenityDTO> CreateHotelAmenity(HotelAmenityDTO hotelAmenity)
        {
            var amenity = _mapper.Map<HotelAmenityDTO, HotelAmenity>(hotelAmenity);
            amenity.CreatedBy = "";
            amenity.CreatedDate = DateTime.UtcNow;
            var addedHotelAmenity = await _context.HotelAmenities.AddAsync(amenity);
            await _context.SaveChangesAsync();
            return _mapper.Map<HotelAmenity, HotelAmenityDTO>(addedHotelAmenity.Entity);
        }

        public async Task<HotelAmenityDTO> UpdateHotelAmenity(int amenityId, HotelAmenityDTO hotelAmenity)
        {
            var amenityDetails = await _context.HotelAmenities.FindAsync(amenityId);
            var amenity = _mapper.Map<HotelAmenityDTO, HotelAmenity>(hotelAmenity, amenityDetails);
            amenity.UpdatedBy = "";
            amenity.UpdatedDate = DateTime.UtcNow;
            var updatedamenity = _context.HotelAmenities.Update(amenity);
            await _context.SaveChangesAsync();
            return _mapper.Map<HotelAmenity, HotelAmenityDTO>(updatedamenity.Entity);
        }

        public async Task<int> DeleteHotelAmenity(int amenityId, string userId)
        {
            var amenityDetails = await _context.HotelAmenities.FindAsync(amenityId);
            if (amenityDetails != null)
            {
                _context.HotelAmenities.Remove(amenityDetails);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<HotelAmenityDTO>> GetAllHotelAmenity()
        {
            return _mapper.Map<IEnumerable<HotelAmenity>, IEnumerable<HotelAmenityDTO>>(await _context.HotelAmenities.ToListAsync());
        }

        public async Task<HotelAmenityDTO> GetHotelAmenity(int amenityId)
        {
            var amenityData = await _context.HotelAmenities
                .FirstOrDefaultAsync(x => x.Id == amenityId);

            if (amenityData == null)
            {
                return null;
            }
            return _mapper.Map<HotelAmenity, HotelAmenityDTO>(amenityData);
        }

        public async Task<HotelAmenityDTO> IsSameNameAmenityAlreadyExists(string name)
        {
            try
            {
                var amenityDetails =
                    await _context.HotelAmenities.FirstOrDefaultAsync(x => x.Name.ToLower().Trim() == name.ToLower().Trim()
                    );
                return _mapper.Map<HotelAmenity, HotelAmenityDTO>(amenityDetails);
            }
            catch (Exception ex)
            {

            }
            return new HotelAmenityDTO();
        }
    }
}
