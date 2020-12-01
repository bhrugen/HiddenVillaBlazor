using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IAmenityRepository
    {
        public Task<HotelAmenityDTO> CreateHotelAmenity(HotelAmenityDTO hotelAmenity);
        public Task<HotelAmenityDTO> UpdateHotelAmenity(int amenityId, HotelAmenityDTO hotelAmenity);
        public Task<int> DeleteHotelAmenity(int amenityId, string userId);
        public Task<IEnumerable<HotelAmenityDTO>> GetAllHotelAmenity();
        public Task<HotelAmenityDTO> GetHotelAmenity(int amenityId);
        public Task<HotelAmenityDTO> IsSameNameAmenityAlreadyExists(string name);
    }
}
