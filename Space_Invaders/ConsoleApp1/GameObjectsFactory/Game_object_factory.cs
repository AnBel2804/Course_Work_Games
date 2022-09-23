using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    abstract class Game_object_factory
    {
        public GameSettings GameSettings { get; set; }
        public abstract Game_object GetGameObject(Game_object_Place game_Object_Place);
        public Game_object_factory(GameSettings gameSettings)
        {
            GameSettings = gameSettings;
        }
    }
}
