using DAl.Impl.Repositories;
using DAL.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using ReposirotyAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAl.Impl.EFCore
{
    public class SeatRepository : BaseRepository<Seat, ReposirotyAPIContext>
    {
        public SeatRepository(ReposirotyAPIContext context) : base(context)
        {

        }
    }
}