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
            if (entity == null)
                return new Ticket()
                {
                    Id = dto.Id,
                    Price = dto.Price,
                    Passanger = UoW.Passangers.GetByID(dto.PassangerId),
                    Van = UoW.Vans.GetByID(dto.VanId),
                    Train = UoW.Trains.GetByID(dto.TrainId),
                    Seat = UoW.Seats.GetByID(dto.SeatId),
                    RoutePropereties = UoW.RoutePropereties.GetByID(dto.RouteProperetiesId)
                };
            entity.Id = dto.Id;
            entity.Price = dto.Price;
            entity.Passanger = UoW.Passangers.GetByID(dto.PassangerId);
            entity.Van = UoW.Vans.GetByID(dto.VanId);
            entity.Train = UoW.Trains.GetByID(dto.TrainId);
            entity.Seat = UoW.Seats.GetByID(dto.SeatId);
            entity.RoutePropereties = UoW.RoutePropereties.GetByID(dto.RouteProperetiesId);
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
                SeatId = entity.SeatId,
                RouteProperetiesId = entity.RouteProperetiesId
            };
        }
    }
}
