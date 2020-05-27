using BL.Abstract;
using BL.Abstract.ResultWrappers;
using BL.Impl.ResultWrappers;
using DAl.Impl.EFCore;
using DAl.Impl.Mappers;
using DAl.Impl.Repositories;
using DAl.Impl.UnitOfWork;
using Entities;
using ReposirotyAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Impl
{
    public class RouteProperetiesService : IRouteProperetiesService
    {

        readonly RouteProperetiesMapper Mapper;
        readonly GenericRepository<RoutePropereties> Repo;

        public RouteProperetiesService(UnitOfWork unitOfWork)
        {
            Repo = unitOfWork.RoutePropereties;
            Mapper = new RouteProperetiesMapper(Repo);
        }

        public IDataResult<List<RouteProperetiesDTO>> GetAll()
        {
            return new DataResult<List<RouteProperetiesDTO>>()
            {
                Data = Repo.Get().Select(e => Mapper.Map(e)).ToList(),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IDataResult<RouteProperetiesDTO> Get(int id)
        {
            return new DataResult<RouteProperetiesDTO>()
            {
                Data = Mapper.Map(Repo.GetByID(id)),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Add(RouteProperetiesDTO dto)
        {
            Repo.Insert(Mapper.DeMap(dto));
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Update(RouteProperetiesDTO dto)
        {
            Repo.Update(Mapper.DeMap(dto));
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Delete(int id)
        {
            Repo.Delete(id);
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }
    }
}
