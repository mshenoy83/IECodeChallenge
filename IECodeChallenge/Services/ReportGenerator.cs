using System;

using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public class ReportGenerator : IReportGenerator
    {
        public void GeneratePacmanReport(PacmanModel model)
        {
            if (model != null)
            {
                Console.WriteLine("Output: {0},{1},{2}", model.Position.X, model.Position.Y, Enum.GetName(typeof(Direction), model.DirectionFacing));
            }
            else
            {
                Console.WriteLine("Output: Pacman has not been placed on the grid");
            }
        }
    }
}
