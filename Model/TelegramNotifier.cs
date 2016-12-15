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
    public class TelegramNotifier
    {

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
            this.client = new TelegramClient(80415, "96eafd6fc118d9cc520147a841aa5a93");
            await client.ConnectAsync();

            try
            {
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
