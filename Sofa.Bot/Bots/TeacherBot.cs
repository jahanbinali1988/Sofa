using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Schema;
using Sofa.Teacher.States;
using Sofa.Teacher.Mapper;
using Sofa.Teacher.ApplicationService.Service;
using Sofa.Teacher.ApplicationService;
using Sofa.SharedKernel.Enum;

namespace Sofa.Teacher.Bots
{
    public class TeacherBot : ActivityHandler
    {
        private IUserService _userService;
        private BotState _conversationState;
        private BotState _userState;
        public TeacherBot(IUserService userService, ConversationState conversationState, UserState userState)
        {
            _userService = userService;
            _conversationState = conversationState;
            _userState = userState;
        }

        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.OnTurnAsync(turnContext, cancellationToken);

            // Save any state changes that might have occured during the turn.
            await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
            await _userState.SaveChangesAsync(turnContext, false, cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            UserProfile userProfile = new UserProfile();
            //Get user data from chat
            ChannelAccount userAccont = turnContext.Activity.From;
            var userId = Guid.Parse(userAccont.Id);
            var userPhoneNumber = userAccont.Name;
            var existenceResponse = await _userService.ExistedUser(new ExistedUserRequest() { PhoneNumber = userPhoneNumber });

            if (existenceResponse.IsSuccess && !existenceResponse.Existed)
            {
                //if user is not existed in our DB, we should add user to DB
                var addUserRequest = new AddUserRequest()
                {
                    CommanderID = userId,
                    UserName = userAccont.Name,
                    PhoneNumber = userAccont.Name,
                    Level = LevelEnum.Begginer
                };
                await _userService.AddUser(addUserRequest);
            }

            // get user data from DB to Register in user state
            var userGetResponse = await _userService.GetByPhoneNumber(new GetUserByPhoneNumberRequest() { PhoneNumber = userPhoneNumber });
            userProfile = userGetResponse.User.Convert();

            //Set user identifierData in begining
            var userStateAccessors = _userState.CreateProperty<UserProfile>(nameof(UserProfile));
            userProfile = await userStateAccessors.GetAsync(turnContext, () => new UserProfile());
            userProfile = userGetResponse.User.Convert();
            await userStateAccessors.SetAsync(turnContext, userProfile);

            await turnContext.SendActivityAsync("Hi " + userProfile.Name);
            await turnContext.SendActivityAsync("Welcome to Sofa Bot, it's a bot targeted to learn you English");
            await turnContext.SendActivityAsync("Of course now it's a sample, but making learning easier is an aim to us");
            await turnContext.SendActivityAsync("Are you Ready to start?");
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            // Get the state properties from the turn context.
            var conversationStateAccessors = _conversationState.CreateProperty<ConversationData>(nameof(ConversationData));
            var conversationData = await conversationStateAccessors.GetAsync(turnContext, () => new ConversationData());

            var userStateAccessors = _userState.CreateProperty<UserProfile>(nameof(UserProfile));
            var userProfile = await userStateAccessors.GetAsync(turnContext, () => new UserProfile());

            if (conversationData.Text == null)
            {
                var messageTimeOffset = (DateTimeOffset)turnContext.Activity.Timestamp;
                var localMessageTime = messageTimeOffset.ToLocalTime();
                conversationData.Timestamp = localMessageTime.ToString();
                conversationData.ChannelId = turnContext.Activity.ChannelId.ToString();
                conversationData.Text = turnContext.Activity.Text;
            }
            else
            {
                if (conversationData.LastConversation is null)
                {
                    conversationData.LastConversation = new List<Model.LastConversation>();
                }
                conversationData.LastConversation.Add(conversationData.Convert());

                var messageTimeOffset = (DateTimeOffset)turnContext.Activity.Timestamp;
                var localMessageTime = messageTimeOffset.ToLocalTime();
                conversationData.Timestamp = localMessageTime.ToString();
                conversationData.ChannelId = turnContext.Activity.ChannelId.ToString();
                conversationData.Text = turnContext.Activity.Text;
            }
            // Display state data.
            if (conversationData.LastConversation != null)
                await turnContext.SendActivityAsync($"Previously {userProfile.Name} sent: {conversationData.LastConversation.Last().Text}");
            await turnContext.SendActivityAsync($"{userProfile.Name} sent: {turnContext.Activity.Text}");
            await turnContext.SendActivityAsync($"Message received at: {conversationData.Timestamp}");
            await turnContext.SendActivityAsync($"Message received from: {conversationData.ChannelId}");

        }
    }
}
