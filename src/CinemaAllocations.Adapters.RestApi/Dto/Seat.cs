namespace CinemaAllocations.Adapters.RestApi.Dto;

public class Seat
{
    public string RowName { get; }
    public uint Number { get; }
    public string SeatName { get; }

    public Seat(Domain.Seat seat)
    {
        RowName = seat.RowName;
        Number = seat.Number;
        SeatName = seat.ToString();
    }
}