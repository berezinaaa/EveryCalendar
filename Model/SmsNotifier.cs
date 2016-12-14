using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace Model
{
    public class SmsNotifier: IEventNotifier
    {
        public void Notify()
        {
            var client = new TwilioRestClient("AC82d123e1c9a93a9e227319c99d3b5072", "a2d72679907147f5d9ab1139f3a1c354");
            var message = client.SendMessageWithService("MG36acbb3450052e429a34569808ad6bcf", "+79153193112", "hello from c# app");
        }
    }
}
