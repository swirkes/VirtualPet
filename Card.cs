using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TamagotchiUserInterface
{

    public class Card
    {
        private const string fileName = @"c:\temp\firing.dat";

        [Serializable]
        public class Cell
        {
            /// <summary>
            /// card title
            /// </summary>
            public int Otsikko { get; set; }
            /// <summary>
            /// card content
            /// </summary>
            public ObservableCollection<Item> ListofItems { get; set; }
            /// <summary>
            /// constructor that calls default constructor
            /// </summary>
            /// <param name="list">card content</param>
            public Cell(List<Item> list) : this()
            {
                foreach (var v in list)
                {
                    ListofItems.Add(new Item(v.X, v.Note));
                    Otsikko += v.X;
                }
            }
            /// <summary>
            /// defualt constructor
            /// </summary>
            public Cell()
            {
                ListofItems = new ObservableCollection<Item>();
            }
        }

        /// <summary>
        /// tabcollection cards, serialised
        /// </summary>
        public ObservableCollection<Cell> Cells { get; set; }
        /// <summary>
        /// constructor that initializes from serialized content or static values 
        /// </summary>
        public Card()
        {
            Cells = new ObservableCollection<Cell>();
            if (!Deserialize())
            {
                Initialize();
            }
        }
        /// <summary>
        /// NewItemRequested kutsuu tätä, kun uusi tabcontrol kortti lisätään
        /// </summary>
        public void Lisaa()
        {
            Cells.Add(new Cell(new List<Item> { new Item(Cells.Count + 1, "") }));
        }
        /// <summary>
        /// if deserialization failes initialises cells
        /// </summary>
        public void Initialize()
        {
            Cells.Add(new Cell(new List<Item> { new Item(Cells.Count + 1, "") }));
            Cells.Add(new Cell(new List<Item> { new Item(Cells.Count + 1, "") }));
            Cells.Add(new Cell(new List<Item> { new Item(Cells.Count + 1, "") }));
        }
        /// <summary>
        /// serialize cells
        /// </summary>
        public void Serialize()
        {
            Stream FileStream = null;
            try
            {
                FileStream = File.Create(fileName);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(FileStream, Cells);
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Serialization failed");
            }
            finally
            {
                if (FileStream != null)
                {
                    FileStream.Close();
                }
            }
        }
        /// <summary>
        /// deserialize cells
        /// </summary>
        /// <returns></returns>
        public bool Deserialize()
        {
            bool result = false;
            Stream FileStream = null;
            try
            {
                if (File.Exists(fileName))
                {
                    FileStream = File.OpenRead(fileName);
                    BinaryFormatter deserializer = new BinaryFormatter();
                    object o = deserializer.Deserialize(FileStream);
                    if (o != null && o is ObservableCollection<Cell>)
                    {
                        Cells = (o as ObservableCollection<Cell>);
                        result = true;
                    }
                }
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Deserialization failed");

            }
            finally
            {
                if (FileStream != null)
                {
                    FileStream.Close();
                }
            }
            return result;
        }
    }
}

