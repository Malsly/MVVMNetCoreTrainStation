using BL.Abstract.ResultWrappers;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface IVanService : IGenericService<VanDTO>
    {
        IDataResult<List<VanDTO>> GetAll();
        IDataResult<VanDTO> Get(int id);
        IResult Add(VanDTO dto);
        IResult Update(VanDTO dto);
        IResult Delete(int id);
    }
}
