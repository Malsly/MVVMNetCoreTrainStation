using DAl.Impl.EFCore;
using DAL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.Mappers
{
    public class TrainMapper : IMapper<Train, TrainDTO, TrainRepository>
    {
        public TrainRepository repo;
        public RouteProperetiesMapper routeProperetiesMapper;
        public List<RoutePropereties> routePropListEntity;
        public List<RouteProperetiesDTO> routePropListDTO;

        public TrainMapper(TrainRepository repo, RouteProperetiesMapper routeProperetiesMapper)
        {
            this.repo = repo;
            this.routeProperetiesMapper = routeProperetiesMapper;
            this.routePropListEntity = new List<RoutePropereties>();
            this.routePropListDTO = new List<RouteProperetiesDTO>();
        }

        public Train DeMap(TrainDTO dto)
        {
            Train entity = repo.Get(dto.Id).Result;
            if (entity == null) {
                foreach (RouteProperetiesDTO rpd in dto.RoutePropereties) routePropListEntity.Add(routeProperetiesMapper.DeMap(rpd));
                return new Train()
                {
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
            foreach (RouteProperetiesDTO rpd in dto.RoutePropereties) entity.RoutePropereties.Add(routeProperetiesMapper.DeMap(rpd));
            entity.Id = dto.Id;
            return entity;
        }

        public TrainDTO Map(Train entity)
        {
            foreach (RoutePropereties rpd in entity.RoutePropereties) routePropListDTO.Add(routeProperetiesMapper.Map(rpd));
            return new TrainDTO()
            {
                PlaceDeparture = entity.PlaceDeparture,
                PlaceArrival = entity.PlaceArrival,
                RoutePropereties = routePropListDTO,
                Name = entity.Name,
                Id = entity.Id
            };
        }
    }
}
