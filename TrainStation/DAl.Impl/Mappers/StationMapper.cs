using DAl.Impl.EFCore;
using DAl.Impl.Repositories;
using DAL.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.Mappers
{
    public class StationMapper : IMapper<Station, StationDTO, StationRepository>
    {
        public GenericRepository<Station> repo;
        public UnitOfWork.UnitOfWork UoW;
        public List<Train> TrainsEntity;
        public List<TrainDTO> TrainsDTO;

        public StationMapper(GenericRepository<Station> repo)
        {
            this.repo = repo;
        }

        public Station DeMap(StationDTO dto)
        {
            Station entity = repo.GetByID(dto.Id);
            UoW = new UnitOfWork.UnitOfWork();
            var trains = UoW.Trains.Get();

            foreach (TrainDTO rpd in dto.Trains) TrainsEntity.Add(new Train() { Id = rpd.Id, Name = rpd.Name, PlaceDeparture = rpd.PlaceDeparture, PlaceArrival = rpd.PlaceArrival });
            if (entity == null)
                return new Station()
                {
                    Trains = TrainsEntity,
                    Name = dto.Name,
                    Id = dto.Id,
                };
            foreach (TrainDTO rpd in dto.Trains) entity.Trains.Add(new Train() { Id = rpd.Id, Name = rpd.Name, PlaceDeparture = rpd.PlaceDeparture, PlaceArrival = rpd.PlaceArrival });
            entity.Name = dto.Name;
            entity.Id = dto.Id;
            return entity;
        }   

        public StationDTO Map(Station entity)
        {
            UoW = new UnitOfWork.UnitOfWork();
            TrainsDTO = new List<TrainDTO>();
            foreach (Train train in UoW.Trains.Get())
            {
                if (train.StationId == entity.Id)
                {
                    TrainsDTO.Add(new TrainDTO() { Id = train.Id, Name = train.Name, PlaceDeparture = train.PlaceDeparture, PlaceArrival = train.PlaceArrival });
                }
            }
            return new StationDTO()
            {
                Trains = TrainsDTO,
                Name = entity.Name,
                Id = entity.Id
            };
        }
    }
}
