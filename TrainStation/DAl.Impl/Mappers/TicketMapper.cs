using DAl.Impl.EFCore;
using DAL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.Mappers
{
    public class TicketMapper : IMapper<Ticket, TicketDTO, TicketRepository>
    {
        public TicketRepository repo;
        public PassangerMapper passangwerMapper;
        public VanMapper vanMapper;
        public TrainMapper trainMapper;
        public SeatMapper seatMapper;
        public RouteProperetiesMapper routeProperetiesMapper;


        public TicketMapper(TicketRepository repo, PassangerMapper passangwerMapper, VanMapper vanMapper, TrainMapper trainMapper, SeatMapper seatMapper, RouteProperetiesMapper routeProperetiesMapper)
        {
            this.repo = repo;
            this.passangwerMapper = passangwerMapper;
            this.vanMapper = vanMapper;
            this.trainMapper = trainMapper;
            this.seatMapper = seatMapper;
            this.routeProperetiesMapper = routeProperetiesMapper;
        }

        public Ticket DeMap(TicketDTO dto)
        {
            Ticket entity = repo.Get(dto.Id).Result;
            if (entity == null)
                return new Ticket()
                {
                    Id = dto.Id,
                    Price = dto.Price,
                    Passanger = passangwerMapper.DeMap(dto.Passanger),
                    Van = vanMapper.DeMap(dto.Van),
                    Train = trainMapper.DeMap(dto.Train),
                    Seat = seatMapper.DeMap(dto.Seat),
                    RoutePropereties = routeProperetiesMapper.DeMap(dto.RoutePropereties)
                };
            entity.Id = dto.Id;
            entity.Price = dto.Price;
            entity.Passanger = passangwerMapper.DeMap(dto.Passanger);
            entity.Van = vanMapper.DeMap(dto.Van);
            entity.Train = trainMapper.DeMap(dto.Train);
            entity.Seat = seatMapper.DeMap(dto.Seat);
            entity.RoutePropereties = routeProperetiesMapper.DeMap(dto.RoutePropereties);
            return entity;
        }   

        public TicketDTO Map(Ticket entity)
        {
            return new TicketDTO()
            {
                Id = entity.Id,
                Price = entity.Price,
                Passanger = passangwerMapper.Map(entity.Passanger),
                Van = vanMapper.Map(entity.Van),
                Train = trainMapper.Map(entity.Train),
                Seat = seatMapper.Map(entity.Seat),
                RoutePropereties = routeProperetiesMapper.Map(entity.RoutePropereties)
            };
        }
    }
}
