using MtgPodium.Infrastructure;
using MtgPodium.Models.Entities;

namespace MtgPodium.Repositories;

public class FormatRepository : Repository<Format>, IFormatRepository
{
    public FormatRepository(ApplicationDBContext context) : base(context)
    {
    }
}