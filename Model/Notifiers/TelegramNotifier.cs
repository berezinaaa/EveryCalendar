using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLSharp;
using TLSharp.Core;
using TeleSharp.TL;

namespace Model
{
    [Serializable]
    public class TelegramNotifier: IEventNotifier
    {
        public void Notify(Event calendarEvent)
        {
            var telegram = TelegramManager.GetInstance();
            telegram.SendMessage(calendarEvent.NotificationMessage);
        }
    }

    public class TelegramManager
    {
        private static TelegramManager manager;

        private TelegramClient client;
        private TLUser user;
        private string phone;
        private string hash;

        public static TelegramManager GetInstance()
        {
            if (manager == null)
            {
                manager = new TelegramManager();
            }
            return manager;
        }

        private TelegramManager()
        {
            var store = new FileSessionStore();
            //this.client = new TelegramClient(80415, "96eafd6fc118d9cc520147a841aa5a93");
            //this.Connect();
        }

        private async void Connect()
        {
            await client.ConnectAsync();
        }

        public async void CodeRequest(string phone, Action<bool, string> callback)
        {
            try
            {
                this.client = new TelegramClient(80415, "96eafd6fc118d9cc520147a841aa5a93");
                await client.ConnectAsync();
                this.phone = phone;
                this.hash = await client.SendCodeRequestAsync(phone);
                callback(true, null);
            }
            catch (Exception ex)
            {
                callback(false, ex.Message);
            }
        }

        public async void Auth(string code, Action<bool, string> callback)
        {
            try
            {
                user = await client.MakeAuthAsync(phone, hash, code);
                callback(true, null);
            }
            catch (Exception ex)
            {
                callback(false, ex.Message);
            }
        }

        public async void SendMessage(string message)
        {
            await client.SendMessageAsync(new TLInputPeerUser() { user_id = user.id }, message);
        }
    }
}
