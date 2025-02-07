using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public class InMemGamesRepository : IGamesRepository
{
    private readonly List<Game> games = new()
    {
        new Game()
        {
            Id = 1,
            Name = "The Legend of Zelda: Breath of the Wild",
            Genre = "Action-adventure",
            Price = 59.99m,
            ReleaseDate = new DateTime(2017, 3, 3),
            ImageUri = "https://placehold.co/100"
        },
        new Game()
        {
            Id = 2,
            Name = "Super Mario Odyssey",
            Genre = "Platformer",
            Price = 59.99m,
            ReleaseDate = new DateTime(2017, 10, 27),
            ImageUri = "https://placehold.co/100"
        },
        new Game()
        {
            Id = 3,
            Name = "Mario Kart 8 Deluxe",
            Genre = "Racing",
            Price = 59.99m,
            ReleaseDate = new DateTime(2017, 4, 28),
            ImageUri = "https://placehold.co/100"
        },
    };

    public IEnumerable<Game> GetAll()
    {
        return games;
    }

    public Game? Get(int id)
    {
        return games.Find(game => game.Id == id);
    }

    public void Create(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }

    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
    }

    public void Delete(int id)
    {
        var index = games.FindIndex(game => game.Id == id);
        games.RemoveAt(index);
    }
}
