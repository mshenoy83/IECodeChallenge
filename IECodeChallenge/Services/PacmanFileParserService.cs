using System;
using System.Collections.Generic;
using System.Text;
using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public class PacmanFileParserService : IPacmanService
    {
        public PacmanType ServiceType => PacmanType.FileUpload;

        public void Simulate()
        {
            throw new NotImplementedException();
        }
    }
}
