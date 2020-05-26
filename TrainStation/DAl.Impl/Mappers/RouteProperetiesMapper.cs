using DAl.Impl.EFCore;
using DAL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.Mappers
{
    public class RouteProperetiesMapper : IMapper<RoutePropereties, RouteProperetiesDTO, RouteProperetiesRepository>
    {
        public RouteProperetiesRepository repo;

        public RouteProperetiesMapper(RouteProperetiesRepository repo)
        {
            this.repo = repo;
        }

        public RoutePropereties DeMap(RouteProperetiesDTO dto)
        {
            RoutePropereties entity = repo.Get(dto.Id).Result;
            if (entity == null)
                return new RoutePropereties()
                {
                    Price = dto.Price,
                    Place = dto.Place,
                    Date = dto.Date,
                    Id = dto.Id,
                };
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
                Price = entity.Price,
                Place = entity.Place,
                Date = entity.Date,
                Id = entity.Id
            };
        }
    }
}
