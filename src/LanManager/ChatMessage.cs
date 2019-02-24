using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ChatMessage
{
    public String Type;
    public String Destination;
    public String Source;
    public String Payload;

    public ChatMessage()
    {
        Type = "";
        Destination = "";
        Source = "";
        Payload = "";
    }

    public ChatMessage(String Type, String Destination, String Source, String Payload)
    {
        this.Type = Type;
        this.Destination = Destination;
        this.Source = Source;
        this.Payload = Payload;
    }

    public String EncodeMessage()
    {
        return String.Join(";", Type, Destination.Replace(";", "<:>"), Source.Replace(";", "<:>"), Payload.Replace(";", "<:>"));
    }

    public void DecodeMessage(String msg)
    {
        msg = msg.Replace("\u0013", "");
        this.Type = msg.Split(';')[0].Replace("<:>", ";");
        this.Destination = msg.Split(';')[1].Replace("<:>", ";");
        this.Source = msg.Split(';')[2].Replace("<:>", ";");
        this.Payload = msg.Split(';')[3].Replace("<:>", ";");
    }

    public ChatMessage Response(String txt)
    {
        return new ChatMessage("chat", Source, Destination, txt);
    }

    public String PrintChatMessage()
    {
        return String.Format("{0}: {1}", Source, Payload);
    }
}

// Typ & destination   &   source   &   payload

// Broadcast:
//chat;;Harry;Was willst du tun?

// private
//chat;Ulli;Harry;Hey Ulli wie gehts?



