using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CinemaAllocations.Adapters.DataPersistence;

[Owned]
public sealed class Seat
{
    [Key]
    public uint Id { get; set; }

    public uint Number { get; set; }

    public string Availability { get; set; } = null!;

    [ForeignKey("RowId")]
    public Row? Row { get; set; }
}