using Domain.Interfaces;

namespace Domain.Models;

public class Club : IClub
{
    public Guid Id { get; private set; }

    public Club(Guid id)
    {
        Id = id;
    }

    public Club() { }
}