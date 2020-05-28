using DAl.Impl.EFCore;
using DAl.Impl.Repositories;
using DAL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.Mappers
{
    public class TicketMapper : IMapper<Ticket, TicketDTO, GenericRepository<Ticket>>
    {
        public GenericRepository<Ticket> repo;
        public UnitOfWork.UnitOfWork UoW;
        
        public TicketMapper(GenericRepository<Ticket> repo)
        {
            this.repo = repo;
        }

        public Ticket DeMap(TicketDTO dto)
        {
            Ticket entity = repo.GetByID(dto.Id);
            UoW = new UnitOfWork.UnitOfWork();
            if (entity == null)
                return new Ticket()
                {
                    Id = dto.Id,
                    Price = dto.Price,
                    PassangerId = dto.PassangerId,
                    VanId = dto.VanId,
                    TrainId = dto.TrainId,
                    SeatId = dto.SeatId
        };
            entity.Id = dto.Id;
            entity.Price = dto.Price;
            entity.PassangerId = dto.PassangerId;
            entity.VanId = dto.VanId;
            entity.TrainId = dto.TrainId;
            entity.SeatId = dto.SeatId;
            return entity;
        }   

        public TicketDTO Map(Ticket entity)
        {
            return new TicketDTO()
            {
                Id = entity.Id,
                Price = entity.Price,
                PassangerId = entity.PassangerId,
                VanId = entity.VanId,
                TrainId = entity.TrainId,
                SeatId = entity.SeatId
            };
        }
    }
}
