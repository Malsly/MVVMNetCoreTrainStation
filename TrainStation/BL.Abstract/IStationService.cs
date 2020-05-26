using BL.Abstract.ResultWrappers;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface IStationService : IGenericService<StationDTO>
    {
        IDataResult<List<StationDTO>> GetAll();
        IDataResult<StationDTO> Get(int id);
        IResult Add(StationDTO dto);
        IResult Update(StationDTO dto);
        IResult Delete(int id);
    }
}
