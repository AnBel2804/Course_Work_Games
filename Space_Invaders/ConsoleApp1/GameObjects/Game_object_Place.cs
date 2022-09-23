using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class Game_object_Place
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override bool Equals(object obj)
        {
            Game_object_Place game_Object_Place = obj as Game_object_Place;
            if (game_Object_Place != null && this.X == game_Object_Place.X && this.Y == game_Object_Place.Y)
                return true;
            else { return false; }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
