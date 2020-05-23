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
    public class RouteProperetiesRepository : BaseRepository<RoutePropereties, ReposirotyAPIContext>
    {
        public RouteProperetiesRepository(ReposirotyAPIContext context) : base(context)
        {

        }
    }
}