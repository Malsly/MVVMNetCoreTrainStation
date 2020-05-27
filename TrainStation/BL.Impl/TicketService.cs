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
    public class TicketService : ITicketService
    {

        readonly TicketMapper Mapper;
        readonly GenericRepository<Ticket> Repo;

        public TicketService()
        {
            Repo = new UnitOfWork().Tickets;
            Mapper = new TicketMapper(Repo);
        }

        public IDataResult<List<TicketDTO>> GetAll()
        {
            return new DataResult<List<TicketDTO>>()
            {
                Data = Repo.Get().Select(e => Mapper.Map(e)).ToList(),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IDataResult<TicketDTO> Get(int id)
        {
            return new DataResult<TicketDTO>()
            {
                Data = Mapper.Map(Repo.GetByID(id)),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Add(TicketDTO dto)
        {
            Repo.Insert(Mapper.DeMap(dto));
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Update(TicketDTO dto)
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
