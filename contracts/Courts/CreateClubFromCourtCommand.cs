namespace Contracts.Courts
{
    public record CreateClubFromCourtCommand(Guid CollabTempId, string ClubName, TimeOnly StartTime, TimeOnly EndTime);
}