using System;
using System.Collections.Generic;
using System.Text;

using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public class PacmanConsoleService : IPacmanService
    {
        public void Simulate()
        {

        }

        public PacmanType ServiceType => PacmanType.Console;
    }
}
