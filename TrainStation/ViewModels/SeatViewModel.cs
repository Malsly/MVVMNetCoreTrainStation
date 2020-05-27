using BL.Abstract;
using BL.Impl;
using Entities;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ViewModels
{
    public class SeatViewModel
    {
        ISeatService seatService;
        
        public ObservableCollection<SeatDTO> Students
        {
            get;
            set;
        }

        public void LoadSeats()
        {
            seatService = new SeatService();
            ObservableCollection<SeatDTO> students = new ObservableCollection<SeatDTO>();

            foreach (SeatDTO seat in seatService.GetAll().Data.ToList<SeatDTO>()) students.Add(seat);

            Students = students;
        }
    }
}
