using Application.DTO;

namespace Application.Services
{
    public interface IJournalService
    {
        Task<MRange> GetJournalRange(int skip, int take, VJournalFilter filter);
        Task<MJournalInfo> GetSingleJournalInfo(long id);
    }
}
