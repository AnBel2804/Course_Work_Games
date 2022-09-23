using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class DeffenderShip_factory : Game_object_factory
    {
        public DeffenderShip_factory(GameSettings gameSettings) : base(gameSettings) { }
        public Game_object GetGameObject()
        {
            Game_object_Place objectPlace = new Game_object_Place() { X = GameSettings.XStartDefender, Y = GameSettings.YStartDefender };
            Game_object game_Object = GetGameObject(objectPlace);
            return game_Object;
        }
        public override Game_object GetGameObject(Game_object_Place game_object_Place)
        {
            Game_object game_Object = new DeffenderShip() { Figure = GameSettings.DefenderShip, game_Object_Place = game_object_Place, game_object_Type = Game_object_Type.DefenderShip };
            return game_Object;
        }
    }
}
