using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Impl.EFCore
{
    class EfCoreSeatRepository : EfCoreRepository<Seat, TrainStationContext>
    {
        public EfCoreSeatRepository(TrainStationContext context) : base(context)
        {

        }
        // We can add new methods specific to the movie repository here in the future
    }
}
