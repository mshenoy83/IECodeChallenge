using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public interface IReportGenerator
    {
        void GeneratePacmanReport(PacmanModel model);
    }
}