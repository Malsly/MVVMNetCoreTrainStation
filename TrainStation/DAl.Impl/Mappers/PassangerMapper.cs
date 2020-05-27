using DAl.Impl.EFCore;
using DAl.Impl.Repositories;
using DAL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.Mappers
{
    public class PassangerMapper : IMapper<Passanger, PassangerDTO, GenericRepository<Passanger>>
    {
        public GenericRepository<Passanger> repo;

        public PassangerMapper(GenericRepository<Passanger> repo)
        {
            this.repo = repo;
        }

        public Passanger DeMap(PassangerDTO dto)
        {
            Passanger entity = repo.GetByID(dto.Id);
            if (entity == null)
                return new Passanger()
                {
                    Name = dto.Name,
                    Id = dto.Id,
                    Telephone = dto.Telephone,
                    Email = dto.Email
                };
            entity.Name = dto.Name;
            entity.Id = dto.Id;
            entity.Telephone = dto.Telephone;
            entity.Email = dto.Email;
            return entity;
        }   

        public PassangerDTO Map(Passanger entity)
        {
            return new PassangerDTO()
            {
                Name = entity.Name,
                Id = entity.Id,
                Telephone = entity.Telephone,
                Email = entity.Email
            };
        }
    }
}
