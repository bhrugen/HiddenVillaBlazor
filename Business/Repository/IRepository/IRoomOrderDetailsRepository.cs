using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IRoomOrderDetailsRepository
    {
        public Task<RoomOrderDetailsDTO> Create(RoomOrderDetailsDTO details);
        public Task<RoomOrderDetailsDTO> MarkPaymentSuccessful(int id);
        public Task<RoomOrderDetailsDTO> GetRoomOrderDetail(int roomOrderId);
        public Task<IEnumerable<RoomOrderDetailsDTO>> GetAllRoomOrderDetails();
        public Task<bool> UpdateOrderStatus(int RoomOrderId, string status);

    }
}
