using System;

namespace TamagotchiUserInterface
{
    [Serializable]
    public class Item
    {
        private int x;
        private string note;

        public int X { get => x; set => x = value; }
        public string Note { get => note; set => note = value; }

        public Item(int x, string note)
        {
            X = x;
            Note = note;
        }
        /// <summary>
        /// enables adding cells in datagrid
        /// required because there exists parameterized constructor
        /// </summary>
        public Item() { }
    }
}
