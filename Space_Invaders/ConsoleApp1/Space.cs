using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class Space
    {
        public List<Game_object> aliens;
        public List<Game_object> ground;
        public Game_object defender;
        public List<Game_object> rockets;
        GameSettings _settings;

        private static Space _space;
        private Space()
        {

        }
        private Space(GameSettings gameSettings)
        {
            _settings = gameSettings;
            aliens = new AlienShip_factory(_settings).GetAliens();
            ground = new Ground_factory(_settings).GetGround();
            defender = new DeffenderShip_factory(_settings).GetGameObject();
            rockets = new List<Game_object>();
        }
        public static Space GetScene(GameSettings gameSettings)
        {
            if (_space == null)
            {
                _space = new Space(gameSettings);
            }

            return _space;
        }
        
    }
}
