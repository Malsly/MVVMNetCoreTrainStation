using BL.Abstract.ResultWrappers;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface IRouteProperetiesService : IGenericService<RouteProperetiesDTO>
    {
        IDataResult<List<RouteProperetiesDTO>> GetAll();
        IDataResult<RouteProperetiesDTO> Get(int id);
        IResult Add(RouteProperetiesDTO dto);
        IResult Update(RouteProperetiesDTO dto);
        IResult Delete(int id);
    }
}
