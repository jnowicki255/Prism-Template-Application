using Prism.Events;
using PTA.Contracts.Entities.Common.Users;

namespace PTA.Core.Events
{
    public class UserLoginEvent : PubSubEvent<User>
    {
    }
}
