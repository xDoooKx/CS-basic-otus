using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CShOtusBasic
{
    public class Stack
    {
        private StackItem stackItems;


        public int Size { get; private set; } = 0;
        public string? Top { get; private set; } = null;


        public Stack()
        {
            if (stackItems != null) return;

            stackItems = new StackItem();
        }
        public Stack(params string[] values)
        {
            if (stackItems != null) return;

            stackItems = new StackItem();
            foreach (var item in values) this.Add(item);
        }


        public void Add(string value)
        {
            if (String.IsNullOrWhiteSpace(value)) return;
                
            stackItems.Add(value);
            Size++;
            Top = stackItems.GetTop();
        }
        public string Pop()
        {            
            var getPopValue = stackItems.Pop();  
            Top = stackItems.GetTop();

            Size--;

            return getPopValue;
        }
        public static Stack Concat(params Stack[] stacks)
        {
            Stack stack = new Stack();

            foreach (var item in stacks)
            {
                List<string> items = new List<string>();

                for (int i = item.Size; i > 0; i--)
                {
                    items.Add(item.Pop());
                }
                foreach (var itemStr in items)
                {
                    stack.Add(itemStr);
                }
            }

            return stack;
        }



        private class StackItem
        {
            public int Pointer { get; set; } = -1;
            public string PointerValue { get; set; }
            public Item PrevElement { get; set; } = new Item();
            public List<Item> Items { get; set; } = new List<Item>();

            public void Add(string value)
            {
                if (String.IsNullOrEmpty(value)) return;

                PointerValue = value;

                if (Items.Count() > 0) PrevElement = Items[Pointer];

                Items.Add(new Item { ItemValue = value });                

                Pointer++;
            }

            public string Pop()
            {
                Item _retItem = new Item();

                if (Pointer == -1)
                {
                    throw new Exception("Ошибка: стек пустой!");
                }

                _retItem.ItemValue = PointerValue;

                Items.RemoveAt(Pointer);
                --Pointer;

                if (Pointer == -1)
                {
                    PointerValue = null;
                    PrevElement = new Item();

                    return _retItem.ItemValue;
                }
                PointerValue = Items[Pointer].ItemValue;

                if (Pointer == 0)
                {
                    PrevElement = new Item();

                    return _retItem.ItemValue;
                }
                
                PrevElement = Items[Pointer - 1];

                return _retItem.ItemValue;
            }

            public string? GetTop()
            {
                if (Pointer == -1) return null;
                else return PointerValue;
            }

            public class Item
            {
                public string ItemValue { get; set; }
            }
        }        
    }
}
