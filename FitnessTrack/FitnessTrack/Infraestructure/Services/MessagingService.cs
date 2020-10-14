using System;
using Xamarin.Forms;

namespace FitnessTrack.Infraestructure.Services
{

    public interface IMessagingService
    {
        void Subscribe<TSender, TArg>(object subscriber, string eventName, Action<TSender, TArg> callback) where TSender : class;
        void Subscribe<TSender>(object subscriber, string eventName, Action<TSender> callback) where TSender : class;
        void Unsubscribe<TSender>(object subscriber, string eventName) where TSender : class;
        void Send<TSender, TArg>(TSender sender, string eventName, TArg argument) where TSender : class;
        void Send<TSender>(TSender sender, string eventName) where TSender : class;
    }

    public class MessagingService : IMessagingService
    {
        public void Subscribe<TSender, TArg>(object subscriber, string eventName, Action<TSender, TArg> callback) where TSender : class 
            => Xamarin.Forms.MessagingCenter.Subscribe<TSender, TArg>(subscriber, eventName, callback);
        

        public void Subscribe<TSender>(object subscriber, string eventName, Action<TSender> callback) where TSender : class 
            => Xamarin.Forms.MessagingCenter.Subscribe<TSender>(subscriber, eventName, callback);
        

        public void Unsubscribe<TSender>(object subscriber, string eventName) where TSender : class 
            => Xamarin.Forms.MessagingCenter.Unsubscribe<TSender>(subscriber, eventName);

        public void Send<TSender, TArg>(TSender sender, string eventName, TArg argument) where TSender : class
            => MessagingCenter.Send<TSender, TArg>(sender, eventName, argument);

        public void Send<TSender>(TSender sender, string eventName) where TSender : class
            => MessagingCenter.Send<TSender>(sender, eventName);
        
    }
}
