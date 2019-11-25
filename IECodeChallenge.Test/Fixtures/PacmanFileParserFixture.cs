using System;
using System.Collections.Generic;
using System.Text;

using IECodeChallenge.Services;

using Moq;

namespace IECodeChallenge.Test.Fixtures
{
    public class PacmanFileParserFixture
    {
        public PacmanFileParserFixture()
        {
            var mockcmdparser = new Mock<IPacmanCommandParser>();
        }
        public IPacmanService Service { get; private set; }
    }
}
