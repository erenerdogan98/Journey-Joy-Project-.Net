using AutoMapper;
using JourneyJoy.BLL.Abstract;
using JourneyJoy.DAL.Abstract;
using JourneyJoy.DTO.ReservationDtos;
using JourneyJoy.Entities;

namespace JourneyJoy.BLL.Concrete
{
    public class ReservationManager(IReservationDAL ReservationDAL, IMapper mapper) : GenericManager<Reservation, CreateReservationDto, UpdateReservationDto, ResultReservationDto>(ReservationDAL, mapper), IReservationService
    {
    }
}
