using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class GameSettings
    {
        public int ConsoleWidth { get; set; } = 85;
        public int ConsoleHight { get; set; } = 35;
        public int RowsAliens { get; set; } = 2;
        public int ColumnsAliens { get; set; } = 60;
        public int XStartAliens { get; set; } = 10;
        public int YStartAliens { get; set; } = 2;
        public char AlienShip { get; set; } = 'O';
        public int AlienSpeed { get; set; } = 20;
        public int XStartDefender { get; set; } = 40;
        public int YStartDefender { get; set; } = 19;
        public char DefenderShip { get; set; } = '@';
        public int XStartGround { get; set; } = 1;
        public int YStartGround { get; set; } = 20;
        public char Ground { get; set; } = 'n';
        public int RowsGround { get; set; } = 1;
        public int ColumnsGround { get; set; } = 80;
        public char Rocket = '^';
        public int RocketSpeed { get; set; } = 1;
        public int GameSpeed { get; set; } = 100;

    }
}
