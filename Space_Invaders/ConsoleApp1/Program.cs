using System;
using System.ComponentModel.Design;
using System.Threading;

namespace Space_Invaders
{
    class Program
    {
        static GameEngine gameEngine;
        static GameSettings gameSettings;
        static Controller controller;
        static void Main(string[] args)
        {
            Initialize();
            gameEngine.Run();
        }
        public static void Initialize()
        {
            gameSettings = new GameSettings();
            gameEngine = GameEngine.GetGameEngine(gameSettings);
            controller = new Controller();
            controller.LeftMove += (obj, arg) => gameEngine.MoveLeft();
            controller.RightMove += (obj, arg) => gameEngine.MoveRight();
            controller.Shot += (obj, arg) => gameEngine.Shot();
            Thread ControllerThread = new Thread(controller.ControllerRead);
            ControllerThread.Start();
        }
    }
}
