using BL.Abstract;
using BL.Abstract.ResultWrappers;
using BL.Impl.ResultWrappers;
using DAl.Impl.EFCore;
using DAl.Impl.Mappers;
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
        readonly TicketRepository Repo;

        public TicketService(ReposirotyAPIContext context, PassangerMapper passangerMapper, VanMapper vanMapper, TrainMapper trainMapper, SeatMapper seatMapper, RouteProperetiesMapper routeProperetiesMapper)
        {
            Repo = new TicketRepository(context);
            Mapper = new TicketMapper(Repo, passangerMapper, vanMapper, trainMapper, seatMapper, routeProperetiesMapper);
        }

        public IDataResult<List<TicketDTO>> GetAll()
        {
            return new DataResult<List<TicketDTO>>()
            {
                Data = Repo.GetAll().Result.Select(e => Mapper.Map(e)).ToList(),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IDataResult<TicketDTO> Get(int id)
        {
            return new DataResult<TicketDTO>()
            {
                Data = Mapper.Map(Repo.Get(id).Result),
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Add(TicketDTO dto)
        {
            Repo.Add(Mapper.DeMap(dto)).Wait();
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Update(TicketDTO dto)
        {
            Repo.Update(Mapper.DeMap(dto)).Wait();
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }

        public IResult Delete(int id)
        {
            Repo.Delete(id).Wait();
            return new Result()
            {
                Message = ResponseMessageType.None,
                ResponseStatusType = ResponseStatusType.Successed
            };
        }
    }
}
