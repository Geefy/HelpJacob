using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpJacob
{
    class MessageHandler
    {
        MessageSender messageSender;

        void HandleMessage(Message m, bool isHTML, MessageCarrier carrier)
        {
            SetMessageSender(carrier);

            if (isHTML)
                m.Body = HtmlConverter.ConvertBodyToHTML(m.Body);

            messageSender.sendMessage(m);
        }
        void HandleMessage(string[] to, Message m, bool isHTML, MessageCarrier carrier)
        {
            SetMessageSender(carrier);

            if (isHTML)
                m.Body = HtmlConverter.ConvertBodyToHTML(m.Body);

            foreach (string person in to)
            {
                m.To = person;
                messageSender.sendMessage(m);
            }
        }
        public void SetMessageSender(MessageCarrier carrier)
        {

            switch (carrier)
            {
                case MessageCarrier.Smtp:
                    messageSender = new SMTPSender();
                    break;
                case MessageCarrier.VMessage:
                    messageSender = new SMTPSender();
                    break;
                default:
                    break;
            }
        }

    }
}
