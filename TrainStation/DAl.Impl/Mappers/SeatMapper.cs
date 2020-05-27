using DAl.Impl.EFCore;
using DAl.Impl.Repositories;
using DAL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.Mappers
{
    public class SeatMapper : IMapper<Seat, SeatDTO, GenericRepository<Seat>>
    {
        public GenericRepository<Seat> repo;

        public SeatMapper(GenericRepository<Seat> repo)
        {
            this.repo = repo;
        }

        public Seat DeMap(SeatDTO dto)
        {
            Seat entity = repo.GetByID(dto.Id);
            if (entity == null)
                return new Seat()
                {
                    Number = dto.Number,
                    Type = dto.Type,
                    IsOccupied = dto.IsOccupied,
                    Id = dto.Id
                };
            entity.Number = dto.Number;
            entity.Type = dto.Type;
            entity.IsOccupied = dto.IsOccupied;
            entity.Id = dto.Id;
            return entity;
        }

        public SeatDTO Map(Seat entity)
        {
            return new SeatDTO()
            {
                Number = entity.Number,
                Type = entity.Type,
                IsOccupied = entity.IsOccupied,
                Id = entity.Id
            };
        }
    }
}
