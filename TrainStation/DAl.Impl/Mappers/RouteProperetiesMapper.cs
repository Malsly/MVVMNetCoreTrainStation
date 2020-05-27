using DAl.Impl.EFCore;
using DAl.Impl.Repositories;
using DAL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.Mappers
{
    public class RouteProperetiesMapper : IMapper<RoutePropereties, RouteProperetiesDTO, GenericRepository<RoutePropereties>>
    {
        public GenericRepository<RoutePropereties> repo;

        public RouteProperetiesMapper(GenericRepository<RoutePropereties> repo)
        {
            this.repo = repo;
        }

        public RoutePropereties DeMap(RouteProperetiesDTO dto)
        {
            RoutePropereties entity = repo.GetByID(dto.Id);
            if (entity == null)
                return new RoutePropereties()
                {
                    TrainId = dto.TrainId,
                    Price = dto.Price,
                    Place = dto.Place,
                    Date = dto.Date,
                    Id = dto.Id,
                };
            entity.TrainId = dto.TrainId;
            entity.Price = dto.Price;
            entity.Place = dto.Place;
            entity.Id = dto.Id;
            entity.Date = dto.Date;
            return entity;
        }

        public RouteProperetiesDTO Map(RoutePropereties entity)
        {
            return new RouteProperetiesDTO()
            {
                TrainId = entity.TrainId,
                Price = entity.Price,
                Place = entity.Place,
                Date = entity.Date,
                Id = entity.Id
            };
        }
    }
}
