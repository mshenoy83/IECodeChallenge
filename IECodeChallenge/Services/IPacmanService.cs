using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public interface IPacmanService
    {
        void Simulate();
        PacmanType ServiceType { get; }
    }
}