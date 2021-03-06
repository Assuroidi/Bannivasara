using System;
using System.Threading.Tasks;

namespace Api.Models
{
    public class PlayerProcessor
    {
        IRepository myRepository;

        public PlayerProcessor(IRepository repository)

        {
            myRepository = repository;
        }

        public Task<Player> Get(Guid id)
        {
            return myRepository.GetPlayer(id);
        }
        public Task<Player[]> GetAll()
        {
            return myRepository.GetAllPlayers();
        }
        public Task<Player> Create(NewPlayer player)
        {
            Player forwarded = new Player();
            forwarded.Name = player.Name;
            forwarded.CreationTime = DateTime.Now;
            forwarded.IsBanned = false;
            forwarded.Score = 0;
            forwarded.Id = Guid.NewGuid();
            return myRepository.CreatePlayer(forwarded);
        }
        public Task<Player> Modify(Guid playerId, ModifiedPlayer player)
        {
            Player replacePlayer = myRepository.GetPlayer(playerId).Result;
            replacePlayer.Score = player.Score;
            return myRepository.UpdatePlayer(playerId, replacePlayer);
        }

        public Task<Player> BanPlayer(Guid id, BannedPlayer player)
        {
            Player replacePlayer = myRepository.GetPlayer(id).Result;
            replacePlayer.IsBanned = player.IsBanned;
            return myRepository.UpdatePlayer(id, replacePlayer);
        }

        public Task<Player> Delete(Guid id)
        {
            return myRepository.DeletePlayer(id);
        }

        public Task<Player> GetFriend (Guid playerId, Guid friendId)
        {
            return myRepository.GetFriend(playerId, friendId);
        }

        public Task<Player[]> GetAllFriends(Guid playerId)
        {
            return myRepository.GetAllFriends(playerId);
        }

        public Task<Player> AddFriend(Guid playerId, Guid friendId)
        {
            return myRepository.AddFriend(playerId, friendId);
        }

        public Task<Player> RemoveFriend(Guid playerId, Guid friendId)
        {
            return myRepository.RemoveFriend(playerId, friendId);
        }

        public Task<Player> GetBlocked(Guid playerId, Guid blockedId)
        {
            return myRepository.GetBlocked(playerId, blockedId);
        }

        public Task<Player[]> GetAllBlocked(Guid playerId)
        {
            return myRepository.GetAllBlocked(playerId);
        }

        public Task<Player> AddBlocked(Guid playerId, Guid blockedId)
        {
            return myRepository.AddBlocked(playerId, blockedId);
        }

        public Task<Player> RemoveBlocked(Guid playerId, Guid blockedId)
        {
            return myRepository.RemoveBlocked(playerId, blockedId);
        }

    }
}