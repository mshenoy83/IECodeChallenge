using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public interface IReportGenerator
    {
        string GeneratePacmanReport(PacmanModel model);
        string GeneratePacmanPlaceCommand(PacmanModel model);
    }
}