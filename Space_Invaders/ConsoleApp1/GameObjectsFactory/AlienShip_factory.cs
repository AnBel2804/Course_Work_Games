using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class AlienShip_factory : Game_object_factory
    {
        public AlienShip_factory(GameSettings gameSettings) : base(gameSettings) { }
        public override Game_object GetGameObject(Game_object_Place Object_Place)
        {
            Game_object alienShip = new AlienShip() { Figure = GameSettings.AlienShip, game_Object_Place = Object_Place, game_object_Type = Game_object_Type.AllienShip };
            return alienShip;
        }
        public List<Game_object> GetAliens()
        {
            List<Game_object> aliens = new List<Game_object>();
            int startX = GameSettings.XStartAliens;
            int startY = GameSettings.YStartAliens;
            for (int y = 0; y < GameSettings.RowsAliens; y++)
            {
                for (int x = 0; x < GameSettings.ColumnsAliens; x++)
                {
                    Game_object_Place objectPlace = new Game_object_Place() { X = startX + x, Y = startY + y };
                    Game_object alienShip = GetGameObject(objectPlace);
                    aliens.Add(alienShip);
                }
            }

            return aliens;
        }
    }
}
