using Sofa.Teacher.Bot.Model;
using Sofa.Teacher.Bot.States;
using System.Collections.Generic;
using System.Linq;

namespace Sofa.Teacher.Bot.Mapper
{
    public static class ConversationDataConverter
    {
        public static LastConversation Convert(this ConversationData source)
        {
            if (source == null)
            {
                return null;
            }

            return new LastConversation
            {
                Text = source.Text,
                Timestamp = source.Timestamp,
            };
        }

        public static IEnumerable<LastConversation> Convert(this IEnumerable<ConversationData> source)
        {
            if (source == null)
            {
                return null;
            }

            return source
                .Select(x => Convert(x));
        }
    }
}
