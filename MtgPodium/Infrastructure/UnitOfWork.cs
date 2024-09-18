using MtgPodium.Infrastructure;
using MtgPodium.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDBContext _context;
 
    public IFormatRepository Formats { get; private set; }
    public IEventRepository Events { get; private set; }
    public IPlayerRepository Players { get; private set; }
    public IPlayerDeckRepository PlayerDecks { get; private set; }
    public ICardRepository Cards { get; private set; }
    public IRankingRepository Rankings { get; private set; }
 
    public UnitOfWork(ApplicationDBContext context)
    {
        _context = context;
 
        Formats = new FormatRepository(_context);
        Events = new EventRepository(_context);
        Players = new PlayerRepository(_context);
        PlayerDecks = new PlayerDeckRepository(_context);
        Cards = new CardRepository(_context);
        Rankings = new RankingRepository(_context);
    }
 
    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }
 
    public void Dispose()
    {
        _context.Dispose();
    }
}