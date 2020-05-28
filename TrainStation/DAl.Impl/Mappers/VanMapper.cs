using DAl.Impl.EFCore;
using DAl.Impl.Repositories;
using DAL.Abstract;
using Entities;
using ReposirotyAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;
using DAl.Impl.UnitOfWork;


namespace DAl.Impl.Mappers
{
    public class VanMapper : IMapper<Van, VanDTO, GenericRepository<Van>>
    {
        public GenericRepository<Van> repo;
        private UnitOfWork.UnitOfWork UoW;

        public VanMapper(GenericRepository<Van> repo)
        {
            this.repo = repo;
        }

        public Van DeMap(VanDTO dto)
        {
            Van entity = repo.GetByID(dto.Id);
            UoW = new UnitOfWork.UnitOfWork();

            if (entity == null)
                return new Van()
                {
                    TrainId = dto.TrainId,
                    Number = dto.Number,
                    ClassPropereties = UoW.ClassPropereties.GetByID(dto.ClassProperetiesId),
                    ClassProperetiesId = dto.ClassProperetiesId,
                    Id = dto.Id,
                };
            entity.TrainId = dto.TrainId;
            entity.Number = dto.Number;
            entity.ClassPropereties = UoW.ClassPropereties.GetByID(dto.ClassProperetiesId);
            entity.ClassProperetiesId = dto.ClassProperetiesId;
            entity.Id = dto.Id;
            return entity;
        }

        public VanDTO Map(Van entity)
        {
            return new VanDTO()
            {
                TrainId = entity.TrainId,
                Number = entity.Number,
                ClassProperetiesId = entity.ClassProperetiesId,
                Id = entity.Id
            };
        }
    }
}
