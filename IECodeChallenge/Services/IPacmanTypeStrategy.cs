using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public interface IPacmanTypeStrategy
    {
        IPacmanService GetPacmanService(PacmanType serviceType);
    }
}