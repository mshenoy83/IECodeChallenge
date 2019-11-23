using System;
using IECodeChallenge.Services;

namespace IECodeChallenge
{
    public class App
    {
        private readonly SimulationLoader _simLoader;

        public App(SimulationLoader simLoader)
        {
            _simLoader = simLoader;
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Pacman Simulator.");
            Console.WriteLine("Typing 'exit' at anytime will exit the simulation.");
            _simLoader.InitializeSimulation();
        }
    }
}
