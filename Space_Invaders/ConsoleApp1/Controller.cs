using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    class Controller
    {
        public event EventHandler LeftMove;
        public event EventHandler RightMove;
        public event EventHandler Shot;
        public void ControllerRead()
        {
            while(true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key.Equals(ConsoleKey.LeftArrow))
                    LeftMove?.Invoke(this, new EventArgs());
                else if (key.Key.Equals(ConsoleKey.RightArrow))
                    RightMove?.Invoke(this, new EventArgs());
                else if(key.Key.Equals(ConsoleKey.Spacebar))
                    Shot?.Invoke(this, new EventArgs());
            }
        }
    }
}
