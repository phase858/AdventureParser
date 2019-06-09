using System;
using System.Collections.Generic;
using System.Text;
using AdventureParser.Loader;
using Newtonsoft.Json;

namespace AdventureParser.ParserCore
{
    class Parser
    {
        DataLoader loader = new DataLoader();
        GameData game;

        List<string> commands = new List<string>{ "use", "take", "look" };
        string[] ignoreWords = { "at", "the" };

        public void LoadFile(string file)
        {
            game = loader.Load(file);
        }
        public void Test()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(game.Name);
            sb.AppendLine(game.IntroText);
            sb.AppendLine(game.WinText);

            foreach (KeyValuePair<String,Item> item in game.Items)
            {
                string name = item.Key;
                Item data = item.Value;
                string itemData = JsonConvert.SerializeObject(data);
                sb.AppendLine("\"" + name + "\"" + ":" + itemData);
            }

            foreach (KeyValuePair<String, Room> room in game.Rooms)
            {
                string name = room.Key;
                Room data = room.Value;
                string roomData = JsonConvert.SerializeObject(data);
                sb.AppendLine("\"" + name + "\"" + ":" + roomData);
            }
            string testOut = sb.ToString();
            Console.WriteLine(testOut);
        }
    }
}
