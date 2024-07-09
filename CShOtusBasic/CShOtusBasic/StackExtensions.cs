using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShOtusBasic
{
    internal static class StackExtensions
    {
        internal static void Merge(this Stack stack, Stack newStack)
        {
            List<string> items = new List<string>();

            for (int i = newStack.Size; i > 0; i--)
            {
                items.Add(newStack.Pop());
            }
            foreach (var item in items)
            {
                stack.Add(item);
            }
        }
    }
}
