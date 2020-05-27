using BL.Impl;
using Entities;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ViewModels
{
    public class SeatViewModel
    {

        public ObservableCollection<SeatDTO> Students
        {
            get;
            set;
        }

        public void LoadSeats()
        {
            ObservableCollection<SeatDTO> students = new ObservableCollection<SeatDTO>();

            var seatService = new SeatService();

            foreach (SeatDTO seat in seatService.GetAll().Data.ToList<SeatDTO>()) students.Add(seat);

            Students = students;
        }
    }
}
