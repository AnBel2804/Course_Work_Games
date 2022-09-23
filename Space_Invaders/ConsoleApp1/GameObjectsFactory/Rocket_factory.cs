using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class Rocket_factory : Game_object_factory
    {
        public Rocket_factory(GameSettings gameSettings) : base(gameSettings) { }
        public override Game_object GetGameObject(Game_object_Place game_object_place)
        {
            Game_object_Place rocket_place = new Game_object_Place() { X = game_object_place.X, Y = game_object_place.Y - 1 };
            Game_object rocket = new Rocket() { Figure = GameSettings.Rocket, game_Object_Place = rocket_place, game_object_Type = Game_object_Type.Rocket }; ;
            return rocket;
        }
    }
}
