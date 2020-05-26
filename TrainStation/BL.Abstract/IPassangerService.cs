using BL.Abstract.ResultWrappers;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface IPassangerService : IGenericService<PassangerDTO>
    {
        IDataResult<List<PassangerDTO>> GetAll();
        IDataResult<PassangerDTO> Get(int id);
        IResult Add(PassangerDTO dto);
        IResult Update(PassangerDTO dto);
        IResult Delete(int id);
    }
}
