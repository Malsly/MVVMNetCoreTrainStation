using DAl.Impl.EFCore;
using DAl.Impl.Repositories;
using DAL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.Mappers
{
    public class ClassProperetiesMapper : IMapper<ClassPropereties, ClassProperetiesDTO, GenericRepository<ClassPropereties>>
    {
        public GenericRepository<ClassPropereties> repo;

        public ClassProperetiesMapper(GenericRepository<ClassPropereties> repo)
        {
            this.repo = repo;
        }

        public ClassPropereties DeMap(ClassProperetiesDTO dto)
        {
            ClassPropereties entity = repo.GetByID(dto.Id);
            if (entity == null)
                return new ClassPropereties()
                {
                    Price = dto.Price,
                    ClassName = dto.ClassName,
                    Id = dto.Id,
                };
            entity.Price = dto.Price;
            entity.ClassName = dto.ClassName;
            entity.Id = dto.Id;
            return entity;
        }

        public ClassProperetiesDTO Map(ClassPropereties entity)
        {
            return new ClassProperetiesDTO()
            {
                Price = entity.Price,
                ClassName = entity.ClassName,
                Id = entity.Id
            };
        }
    }
}
