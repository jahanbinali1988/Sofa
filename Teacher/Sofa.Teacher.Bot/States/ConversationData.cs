using Sofa.Teacher.Bot.Model;
using System.Collections.Generic;

namespace Sofa.Teacher.Bot.States
{
    public class ConversationData
    {
        public string Timestamp { get; set; }
        public string ChannelId { get; set; }
        public bool PromptedUserForName { get; set; } = false;
        public string Text { get; set; }
        public List<LastConversation> LastConversation { get; set; }
    }
}
