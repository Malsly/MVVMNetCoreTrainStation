using DAl.Impl.EFCore;
using DAL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.Mappers
{
    public class VanMapper : IMapper<Van, VanDTO, VanRepository>
    {
        public VanRepository repo;
        public ClassProperetiesMapper classPropsMapper;

        public VanMapper(VanRepository repo, ClassProperetiesMapper classPropsMapper)
        {
            this.repo = repo;
            this.classPropsMapper = classPropsMapper;
        }

        public Van DeMap(VanDTO dto)
        {
            Van entity = repo.Get(dto.Id).Result;
            if (entity == null)
                return new Van()
                {
                    Number = dto.Number,
                    ClassPropereties = classPropsMapper.DeMap(dto.ClassPropereties),
                    Id = dto.Id,
                };
            entity.Number = dto.Number;
            entity.ClassPropereties = classPropsMapper.DeMap(dto.ClassPropereties);
            entity.Id = dto.Id;
            return entity;
        }

        public VanDTO Map(Van entity)
        {
            return new VanDTO()
            {
                Number = entity.Number,
                ClassPropereties = classPropsMapper.Map(entity.ClassPropereties),
                Id = entity.Id
            };
        }
    }
}
