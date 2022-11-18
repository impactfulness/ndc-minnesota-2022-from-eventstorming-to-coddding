namespace CinemaAllocations.Adapters.RestApi.Dto;

public class Seat
{
    public string RowName { get; }
    public uint Number { get; }
    public string SeatName { get; set; }

    public Seat(Domain.Seat seat)
    {
        RowName = seat.RowNameOld;
        Number = seat.Number;
        SeatName = seat.ToString();
    }
}