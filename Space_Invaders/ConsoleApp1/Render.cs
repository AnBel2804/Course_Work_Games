using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class Render
    {
        int _screanWidth;
        int _screanHeight;
        char[,] _screanMatrix;
        public Render(GameSettings gameSettings)
        {
            _screanWidth = gameSettings.ConsoleWidth;
            _screanHeight = gameSettings.ConsoleHight;
            _screanMatrix = new char[gameSettings.ConsoleHight, gameSettings.ConsoleWidth];

            Console.WindowHeight = gameSettings.ConsoleHight;
            Console.WindowWidth = gameSettings.ConsoleWidth;


            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
        }
        public void Show(Space space)
        {
            Console.SetCursorPosition(0, 0);
            AddListForRender(space.aliens);
            AddListForRender(space.ground);
            AddListForRender(space.rockets);
            AddGameObjectForRender(space.defender);
            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < _screanHeight; y++)
            {
                for (int x = 0; x < _screanWidth; x++)
                {
                    stringBuilder.Append(_screanMatrix[y, x]);
                }

                stringBuilder.Append(Environment.NewLine);
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.SetCursorPosition(0, 0);
        }
        public void AddGameObjectForRender(Game_object gameObject)
        {
            if (gameObject.game_Object_Place.Y < _screanMatrix.GetLength(0) &&
               gameObject.game_Object_Place.X < _screanMatrix.GetLength(1))
            {
                _screanMatrix[gameObject.game_Object_Place.Y, gameObject.game_Object_Place.X] = gameObject.Figure;
            }
            else
            {
                _screanMatrix[gameObject.game_Object_Place.Y, gameObject.game_Object_Place.X] = ' ';
            }
        }
        public void AddListForRender(List<Game_object> game_Objects)
        {
            foreach (Game_object gameObject in game_Objects)
                AddGameObjectForRender(gameObject);
        }
        public void Clean()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int y = 0; y < _screanHeight; y++)
            {
                for (int x = 0; x < _screanWidth; x++)
                    _screanMatrix[y, x] = ' ';
            }
            Console.WriteLine(stringBuilder.ToString());
        }
        public void GameOver()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Game Over!");
            Console.Clear();
            Console.SetCursorPosition(_screanWidth/2, _screanHeight/2);
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
