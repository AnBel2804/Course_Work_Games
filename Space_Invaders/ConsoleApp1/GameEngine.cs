using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class GameEngine
    {
        private bool _isNotOver;
        private static GameEngine _gameEngine;
        private GameSettings _gameSettings;
        private Space _space;
        private Render _render;
        private GameEngine() { }
        private GameEngine(GameSettings gameSettings)
        {
            _gameSettings = gameSettings;
            _isNotOver = true;
            _space = Space.GetScene(gameSettings);
            _render = new Render(gameSettings);
        }
        public static GameEngine GetGameEngine(GameSettings gameSettings)
        {
            if (_gameEngine == null)
            {
                _gameEngine = new GameEngine(gameSettings);
            }
            return _gameEngine;
        }
        public void Run()
        {
            int AlienMoveCounter = 0;
            int RocketCounter = 0;
            do
            {
                _render.Clean();
                _render.Show(_space);
                Thread.Sleep(_gameSettings.GameSpeed);
                if (AlienMoveCounter == _gameSettings.AlienSpeed)
                { AlienMove(); AlienMoveCounter = 0; }
                AlienMoveCounter++;
                if (RocketCounter == _gameSettings.RocketSpeed)
                { RocketMove(); RocketCounter = 0; }
                RocketCounter++;
            } while (_isNotOver);
            Console.ForegroundColor = ConsoleColor.Green;
            _render.GameOver();
        }
        public void MoveRight()
        {
            if (_space.defender.game_Object_Place.X < _gameSettings.ConsoleWidth)
                _space.defender.game_Object_Place.X++;
        }
        public void MoveLeft()
        {
            if (_space.defender.game_Object_Place.X > 1)
                _space.defender.game_Object_Place.X--;
        }
        public void AlienMove()
        {
            for (int i = 0; i < _space.aliens.Count; i++)
            {
                Game_object alien = _space.aliens[i];
                alien.game_Object_Place.Y++;
                if (alien.game_Object_Place.Y == _space.defender.game_Object_Place.Y)
                {
                    _isNotOver = false;
                }
            }
        }
        public void Shot()
        {
            Rocket_factory rocket_Factory = new Rocket_factory(_gameSettings);
            Game_object rocket =  rocket_Factory.GetGameObject(_space.defender.game_Object_Place);
            _space.rockets.Add(rocket);
        }
        public void RocketMove()
        {
            if(_space.rockets.Count == 0) return;
            for(int i = 0; i < _space.rockets.Count; i++)
            {
                Game_object rocket = _space.rockets[i];
                if(rocket.game_Object_Place.Y == 1)
                    _space.rockets.RemoveAt(i);
                rocket.game_Object_Place.Y--;
                for (int j = 0; j < _space.aliens.Count; j++)
                {
                    Game_object alien = _space.aliens[j];
                    if (rocket.game_Object_Place.Equals(alien.game_Object_Place))
                    {
                        _space.aliens.RemoveAt(j);
                        _space.rockets.RemoveAt(i);
                        break;
                    }
                }
            }
        }
    }
}
