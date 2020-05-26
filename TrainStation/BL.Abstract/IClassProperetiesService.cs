using BL.Abstract.ResultWrappers;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstract
{
    public interface IClassProperetiesService : IGenericService<ClassProperetiesDTO>
    {
        IDataResult<List<ClassProperetiesDTO>> GetAll();
        IDataResult<ClassProperetiesDTO> Get(int id);
        IResult Add(ClassProperetiesDTO dto);
        IResult Update(ClassProperetiesDTO dto);
        IResult Delete(int id);
    }
}
