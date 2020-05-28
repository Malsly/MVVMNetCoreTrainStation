using DAl.Impl.EFCore;
using DAl.Impl.Repositories;
using DAL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.Mappers
{
    public class TrainMapper : IMapper<Train, TrainDTO, GenericRepository<Train>>
    {
        public GenericRepository<Train> repo;
        private UnitOfWork.UnitOfWork UoW;
        public List<RoutePropereties> routePropListEntity;
        public List<RouteProperetiesDTO> routePropListDTO;
        
        public TrainMapper(GenericRepository<Train> repo)
        {
            this.repo = repo;
        }

        public Train DeMap(TrainDTO dto)
        {
            Train entity = repo.GetByID(dto.Id);
            routePropListEntity = new List<RoutePropereties>();
            if (entity == null) {
                foreach (RouteProperetiesDTO rpd in dto.RoutePropereties) routePropListEntity.Add(new RoutePropereties() { Id = rpd.Id, Price = rpd.Price, Place = rpd.Place, Date = rpd.Date });
                return new Train()
                {
                    StationId = dto.StationId,
                    PlaceDeparture = dto.PlaceDeparture,
                    PlaceArrival = dto.PlaceArrival,
                    Name = dto.Name,
                    RoutePropereties = routePropListEntity,
                    Id = dto.Id
                };
            }
            entity.PlaceDeparture = dto.PlaceDeparture;
            entity.PlaceArrival = dto.PlaceArrival;
            entity.Name = dto.Name;
            entity.StationId = dto.StationId;
            foreach (RouteProperetiesDTO rpd in dto.RoutePropereties) entity.RoutePropereties.Add(new RoutePropereties() { Id = rpd.Id, Price = rpd.Price, Place = rpd.Place, Date = rpd.Date });
            entity.Id = dto.Id;
            return entity;
        }

        public TrainDTO Map(Train entity)
        {
            UoW = new UnitOfWork.UnitOfWork();
            routePropListDTO = new List<RouteProperetiesDTO>();
            foreach (RoutePropereties rpd in UoW.RoutePropereties.Get()) {
                if (rpd.TrainId == entity.Id) 
                {
                    routePropListDTO.Add(new RouteProperetiesDTO() { Id = rpd.Id, Price = rpd.Price, Place = rpd.Place, Date = rpd.Date });
                }
            }
            return new TrainDTO()
            {
                StationId = entity.StationId,
                PlaceDeparture = entity.PlaceDeparture,
                PlaceArrival = entity.PlaceArrival,
                RoutePropereties = routePropListDTO,
                Name = entity.Name,
                Id = entity.Id
            };
        }
    }
}
