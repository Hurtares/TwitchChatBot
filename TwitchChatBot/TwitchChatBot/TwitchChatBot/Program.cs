using System;

namespace TwitchChatBot {
    class Program {
        static void Main(string[] args) {
            ChatBot bot = new ChatBot();
            bot.Connect();
            Console.ReadLine();
            bot.Disconnect();
        }
    }
}
