using DAl.Impl.EFCore;
using DAL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.Mappers
{
    public class PassangerMapper : IMapper<Passanger, PassangerDTO, PassangerRepository>
    {
        public PassangerRepository repo;

        public PassangerMapper(PassangerRepository repo)
        {
            this.repo = repo;
        }

        public Passanger DeMap(PassangerDTO dto)
        {
            Passanger entity = repo.Get(dto.Id).Result;
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
