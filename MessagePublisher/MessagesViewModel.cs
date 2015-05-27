using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;

namespace MessagePublisher
{
    /// <summary>
    /// Your TODO: please follow insstruction 
    /// </summary>
    public class MessagesViewModel : IMessagesViewModel
    {
        private readonly IDispatcher _dispatcher;

        public MessagesViewModel(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;     
            ToDate = DateTime.Now;
            FromDate = DateTime.Now.AddYears(-1);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public string UserName
        {
            get; private set; }
        public UserQueue SelectedUser { get; set; }
        public IEnumerable<UserQueue> ObservedUsers { get; private set; }
        public string NewMessageText { get; set; }

        public ICommand PublishCommand
        {
            get
            {
            Message mess = new Message();
                mess.Author = this.UserName;
                mess.Content = this.NewMessageText;
                mess.PublishedOn = DateTime.Now;
                return this.PublishCommand;
            }
        }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string TextFilter { get; set; }
        public ICommand FilterCommand {  get
        {
                if (string.IsNullOrEmpty(TextFilter)
                    && SelectedUser != null
                    && SelectedUser.Messages != null
                    && SelectedUser.Messages.Count > 0)
                {
                    DateMessageSearcher dms = new DateMessageSearcher(this.FromDate, this.ToDate);
                    TextMessageSearcher tms = new TextMessageSearcher(TextFilter);
                }

                return null;

            } 
            private set { this.FilterCommand = value; } }

        public IEnumerable<Message> FilteredMessages
        {
            get; private set; }

        public ICommand SaveCommand { get;
            private set;
        }
    }

}
