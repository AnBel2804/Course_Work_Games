using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    abstract class Game_object
    {
        public Game_object_Place game_Object_Place { get; set; }
        public char Figure { get; set; }
        public Game_object_Type game_object_Type { get; set; }
    }
}
