using System;
using TwitchLib;
using TwitchLib.Models.API.v5.Users;
using TwitchLib.Events.Client;
using TwitchLib.Models.Client;

namespace TwitchChatBot {
    internal class ChatBot {
        //ao enviar as mensagems o nome do bot é Hurtares quando devia de ser Escravo
        readonly ConnectionCredentials cardenciais = new ConnectionCredentials(Cardenciais.BotUsername, Cardenciais.BotToken);
        TwitchClient client;

        internal void Connect() {
            Console.WriteLine("Connecting");
            
            client = new TwitchClient(cardenciais, "HumphreyMedia",logging:true);

            client.ChatThrottler = new TwitchLib.Services.MessageThrottler(10, TimeSpan.FromSeconds(30));
            client.OnLog += Client_OnLog;
            client.OnConnectionError += Client_OnConnectionError;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnConnected += Client_OnConnected;
            client.Connect();
            
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e) {
            //client.SendMessage($"Hello my name is {client.TwitchUsername} or {e.Username}");
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e) {
            //client.SendMessage($"Hello my name is {client.TwitchUsername} and wellcome: {e.Username}");
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e) {
            
            Console.WriteLine(e.ChatMessage.Message);
            if (e.ChatMessage.Message.Equals("!hello", StringComparison.InvariantCultureIgnoreCase)) {
                client.SendMessage($"Hello and Wellcome {e.ChatMessage.DisplayName}");
            }
            if(e.ChatMessage.Message.Equals("!friend", StringComparison.InvariantCultureIgnoreCase)) {
                client.SendMessage($"I'm your friend {e.ChatMessage.DisplayName} <3");
            }
        }

        private void Client_OnConnectionError(object sender, OnConnectionErrorArgs e) {
            Console.WriteLine($"Error :{e.Error}");
        }

        private void Client_OnLog(object sender, OnLogArgs e) {
           //Console.WriteLine(e.Data);
        }

        internal void Disconnect() {
            Console.WriteLine("Disconecting");
        }
    }
}