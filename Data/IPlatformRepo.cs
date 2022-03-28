using RedisApi.Models;

namespace RedisApi.Data{
    public interface IPlatformRepo{
        void CreatePlatform(Platform p);
        Platform? GetPlatformById(string id);
        IEnumerable<Platform?>? GetAllPlatforms();
    }
}