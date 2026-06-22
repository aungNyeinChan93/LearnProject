using Learn.D2.GameStoreDb.Models;
using Microsoft.EntityFrameworkCore;

namespace Learn.D2.api.Features.GameFeature
{
    public class GameService
    {
        private readonly GameStoreDbContext _gameStoreDbContext;

        public GameService( GameStoreDbContext gameStoreDbContext)
        {
            _gameStoreDbContext = gameStoreDbContext;
        }

        public async Task<List<Game>> GetALlGames()
        {
            var games = await _gameStoreDbContext.Games.AsNoTracking().ToListAsync();
            return games;
        }
    }
}
