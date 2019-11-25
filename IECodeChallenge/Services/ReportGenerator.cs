using System;

using IECodeChallenge.Models;

namespace IECodeChallenge.Services
{
    public class ReportGenerator : IReportGenerator
    {
        public string GeneratePacmanReport(PacmanModel model)
        {
            return model != null ? $"Output: {model.Position.X},{model.Position.Y},{Enum.GetName(typeof(Direction), model.DirectionFacing)}" 
                : "Output: Pacman has not been placed on the grid";
        }

        public string GeneratePacmanPlaceCommand(PacmanModel model)
        {
            return model != null
                ? $"PLACE {model.Position.X},{model.Position.Y},{Enum.GetName(typeof(Direction), model.DirectionFacing)}"
                : string.Empty;
        }
    }
}
