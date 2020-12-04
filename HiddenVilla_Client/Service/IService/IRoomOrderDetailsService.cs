using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiddenVilla_Client.Service.IService
{
    public interface IRoomOrderDetailsService
    {
        public Task<RoomOrderDetailsDTO> SaveRoomOrderDetails(RoomOrderDetailsDTO details);
        public Task<RoomOrderDetailsDTO> MarkPaymentSuccessful(RoomOrderDetailsDTO details);
    }
}
