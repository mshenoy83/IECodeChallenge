using System.Collections.Generic;
using System.Linq;

using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public class PacmanTypeStrategy : IPacmanTypeStrategy
    {
        private readonly IEnumerable<IPacmanService> _pacmanServices;

        public PacmanTypeStrategy(IEnumerable<IPacmanService> pacmanServices)
        {
            _pacmanServices = pacmanServices;
        }

        public IPacmanService GetPacmanService(PacmanType serviceType)
        {
            return _pacmanServices.FirstOrDefault(x => x.ServiceType == serviceType);
        }
    }
}
