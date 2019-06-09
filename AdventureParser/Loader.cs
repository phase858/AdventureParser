using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace AdventureParser.Loader
{
   public class Item
    {
        public string Name { get; set; }
        public List<string> RequiredItems { get; set; }
        public bool CanPickUp { get; set; }
        public string ItemOnUse { get; set; }
        public string Description { get; set; }
        public string UseText { get; set; }
        public string ToRoom { get; set; }
        public bool WinGame { get; set; }
    }

    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Items { get; set; }
    }
    //json data
    public class GameFile
    {
        public string GameName { get; set; }
        public string StartingRoom { get; }
        public string IntroText { get; set; }
        public string WinText { get; set; }
        public Item[] Items { get; set; }
        public Room[] Rooms { get; set; }
    }
    //converted a bit for main parser convenience
    public class GameData
    {
        public string Name { get; set; }
        public string IntroText { get; set; }
        public string WinText { get; set; }
        public Dictionary<string, Item> Items { get; set; }
        public Dictionary<string, Room> Rooms { get; set; }
    }

    class DataLoader
    {

        public GameData Load (string file)
        {
            GameFile gameFile = JsonConvert.DeserializeObject<GameFile>(file);
            GameData game = new GameData();

            game.Name = gameFile.GameName;
            game.IntroText = gameFile.IntroText;
            game.WinText = gameFile.WinText;

            var itemList = new Dictionary<string, Item>();
            var roomList = new Dictionary<string, Room>();

            foreach (Item item in gameFile.Items)
            {
                itemList.Add(item.Name, item);
            }
            foreach (Room room in gameFile.Rooms)
            {
                roomList.Add(room.Name, room);       
            }

            game.Items = itemList;
            game.Rooms = roomList;

            return game;
        }
    }
}
