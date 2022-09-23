using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class Ground_factory : Game_object_factory
    {
        public Ground_factory(GameSettings gameSettings) : base(gameSettings) { }
        public override Game_object GetGameObject(Game_object_Place Object_Place)
        {
            Game_object ground = new Ground() { Figure = GameSettings.Ground, game_Object_Place = Object_Place, game_object_Type = Game_object_Type.Ground };
            return ground;
        }
        public List<Game_object> GetGround()
        {
            List<Game_object> grounds = new List<Game_object>();
            int startX = GameSettings.XStartGround;
            int startY = GameSettings.YStartGround;
            for (int y = 0; y < GameSettings.RowsGround; y++)
                for (int x = 0; x < GameSettings.ColumnsGround; x++)
                {
                    Game_object_Place objectPlace = new Game_object_Place() { X = startX + x, Y = startY + y };
                    Game_object ground = GetGameObject(objectPlace);
                    grounds.Add(ground);
                }
            return grounds;
        }
    }
}
