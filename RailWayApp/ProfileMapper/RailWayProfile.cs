using AutoMapper;
using RailWayAppLibrary.Commands;
using RailWayAppLibrary.Response;
using RailWayModelLibrary.Entities;
using static RailWayAppLibrary.Utility.Process;
namespace RailWayAppLibrary.ProfileMapper
{
    public class RailWayProfile : Profile
    {
        public RailWayProfile()
        {
            CreateMap<BookedTrip, BookedTripResponse>()
                .ForMember(dst => dst.PickupStation,
                opt => opt.MapFrom(src => src.PickupStation.StationName))
                .ForMember(dst => dst.pickupStationLocation, opt => opt
                .MapFrom(src => src.PickupStation.Location))
                .ForMember(dst => dst.DestinationStation, opt => opt
                  .MapFrom(src => src.DestinationStation.StationName))
                .ForMember(dst => dst.IsActive, op => op.
                  MapFrom(s => s.Payment == null ? false : s.Payment.IsAprove))
                .ForMember(d => d.Cost, op => op.MapFrom(s =>
                    GetUnitCost(s.PickupStation.Track, s.PickupStation.Index, s.DestinationStation.Index) * s.NumberOfSeat))
                .ForMember(d => d.TripDate, op => op
                  .MapFrom(s => ArriverTimeOnTripDay(s.TripDate, s.PickupStation.TrainArriverTime)))
                .ForMember(d => d.PassengerId, op => op.MapFrom(s => s.Passenger.Id))
                .ForMember(d => d.DestinationTripArriverTime, op => op.MapFrom(s => s.DestinationStation.TrainArriverTime))
                .ForMember(d => d.PickUpTime, op => op.MapFrom(s => s.PickupStation.TrainArriverTime));

            CreateMap<CreateBookedTrip, BookedTrip>()
                .ForMember(d => d.CreatedDate, op => op.MapFrom(s => DateTime.Now));

            CreateMap<Passenger, PassengerResponse>();
            CreateMap<CreatePassenger, Passenger>();

            CreateMap<Staff, StaffResponse>();
            CreateMap<CreateStaff, Staff>();


            CreateMap<Station, StationResponse>()
                .ForMember(d => d.StationPhoneNo, op => op.MapFrom(s => s.StationAdmin.PhoneNo))
                .ForMember(d => d.NextStation, op => op.MapFrom(s => GetNestStation(s.Track, s.Index)))
                .ForMember(d => d.TrackName, op => op.MapFrom(s => s.Track.TrackName))
                .ForMember(d => d.StationAdmin, op => op.MapFrom(s => s.StationAdmin.Name));

            CreateMap<CreateStation, Station>()
                .ForMember(d => d.Index, op => op.MapFrom(s => s.PrevousStationIndex));

            CreateMap<CreateTrack, Track>();
            CreateMap<Track, TrackResponse>()
                .ForMember(d => d.NStation, op => op.MapFrom(s => s.Stations.Count));

            CreateMap<Train, TrainResponse>()
                . ForMember(d => d.TrackName, op => op.MapFrom(s => s.Track.TrackName))
                .ForMember(d => d.TrailEngineer, op => op.MapFrom(s => s.TrailEngineer.Name))
                .ForMember(d => d.DepartedStation, op => op.MapFrom(s => s.DepartedStation.StationName));


            CreateMap<CreateTrain, Train>()
                .ForMember(d=>d.IsOnTrack, opt=>opt.MapFrom(s=> true));

            CreateMap<Payment, PaymentResponse>()
                .ForMember(d => d.PassengerName, op => op.MapFrom(s => s.BookedTrip.Passenger.Name))
                .ForMember(d => d.TripDate, op => op
                .MapFrom(s => ArriverTimeOnTripDay(s.BookedTrip.TripDate, s.BookedTrip.PickupStation.TrainArriverTime)));

            CreateMap<CreatePayment, Payment>();

        }
    }
}