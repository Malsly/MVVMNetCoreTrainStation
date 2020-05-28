using BL.Abstract.ResultWrappers;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface ITicketService : IGenericService<TicketDTO>
    {
        IDataResult<List<TicketDTO>> GetAll();
        IDataResult<TicketDTO> Get(int id);
        IResult Add(TicketDTO dto);
        IResult Update(TicketDTO dto);
        IResult Delete(int id);
        void Save();
    }
}
