using DAl.Impl.EFCore;
using DAL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.Mappers
{
    public class StationMapper : IMapper<Station, StationDTO, StationRepository>
    {
        public StationRepository repo;

        public StationMapper(StationRepository repo)
        {
            this.repo = repo;
        }

        public Station DeMap(StationDTO dto)
        {
            Station entity = repo.Get(dto.Id).Result;
            if (entity == null)
                return new Station()
                {
                    Name = dto.Name,
                    Id = dto.Id
                };
            entity.Name = dto.Name;
            entity.Id = dto.Id;
            return entity;
        }   

        public StationDTO Map(Station entity)
        {
            return new StationDTO()
            {
                Name = entity.Name,
                Id = entity.Id
            };
        }
    }
}
