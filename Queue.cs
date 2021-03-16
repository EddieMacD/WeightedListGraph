using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Queue<type>
    {
        private List<type> Contents;
        private int Count;

        public Queue ()
        {
            Count = 0;
            Contents = new List<type>();
        }

        public void Enqueue (type input)
        {
            Contents.Add(input);
            Count++;
        }

        public type Dequeue ()
        {
            type output = default(type);

            if (Count != 0)
            {
                output = Contents[0];
                Contents.RemoveAt(0);
                Count--;
            }

            return output;
        }

        public int GetCount ()
        {
            return Count;
        }
    }
}
