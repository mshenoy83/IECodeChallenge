using IECodeChallenge.Services;

namespace IECodeChallenge
{
    public class App
    {
        private readonly SimulationLoader _simLoader;
        private readonly IConsoleService _consoleService;

        public App(SimulationLoader simLoader, IConsoleService consoleService)
        {
            _simLoader = simLoader;
            _consoleService = consoleService;
        }

        public void Start()
        {
            _consoleService.WriteLine("Welcome to Pacman Simulator.");
            _consoleService.WriteLine("Typing 'exit' at anytime will exit the simulation.");
            _simLoader.InitializeSimulation();
            _consoleService.ReadKey();
        }
    }
}
