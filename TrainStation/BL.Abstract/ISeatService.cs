using BL.Abstract.ResultWrappers;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface ISeatService : IGenericService<SeatDTO>
    {
        IDataResult<List<SeatDTO>> GetAll();
        IDataResult<SeatDTO> Get(int id);
        IResult Add(SeatDTO dto);
        IResult Update(SeatDTO dto);
        IResult Delete(int id);
    }
}
