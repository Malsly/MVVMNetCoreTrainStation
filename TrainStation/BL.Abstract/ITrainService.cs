using BL.Abstract.ResultWrappers;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface ITrainService : IGenericService<TrainDTO>
    {
        IDataResult<List<TrainDTO>> GetAll();
        IDataResult<TrainDTO> Get(int id);
        IResult Add(TrainDTO dto);
        IResult Update(TrainDTO dto);
        IResult Delete(int id);
    }
}
