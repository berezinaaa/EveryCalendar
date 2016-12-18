using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace Model
{
    [Serializable]
    public class SmsNotifier: IEventNotifier
    {

        public void Notify(Event calendarEvent)
        {
            var client = new TwilioRestClient("AC82d123e1c9a93a9e227319c99d3b5072", "a2d72679907147f5d9ab1139f3a1c354");
            var message = calendarEvent.NotificationMessage;
            client.SendMessageWithService("MG36acbb3450052e429a34569808ad6bcf", "+79858980732", message);
        }
    }
}
