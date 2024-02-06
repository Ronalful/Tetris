using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Counter
    {
        private int count;

        public Counter() 
        {
            this.reset();
        }

        public void reset()
        {
            count = 0;
        }

        public void add(int c)
        {
            count += c;
        }

        public int get()
        {
            return count;
        }
    }
}
