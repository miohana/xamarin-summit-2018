using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CabeleireiroAppMobile.Models;
using CabeleireiroAppMobile.Services;
using Xamarin.Forms;
using Application = Xamarin.Forms.PlatformConfiguration.AndroidSpecific.Application;

namespace CabeleireiroAppMobile.ViewModels
{
    public class CabeleireiroViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ConversationMessage> _messages;

        private string _textMessage;

        private bool _isRefreshing;

        private ICommand _sendMessageCommand;

        public ChatBotService _chatBotService = new ChatBotService();

        public CabeleireiroViewModel()
        {
            _messages = new ObservableCollection<ConversationMessage>();
            _messages.Add(new ConversationMessage
            {
                Message = "Seja bem-vindo ao salão Xamarin Summit!",
                FromUser = "Cabeleireira",
                UserImageUrl = "cabeleireira.jpg"
            });
        }

        public ObservableCollection<ConversationMessage> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                OnPropertyChanged("Messages");
            }
        }

        public string TextMessage
        {
            get { return _textMessage; }
            set
            {
                _textMessage = value;
                OnPropertyChanged("TextMessage");
            }
        }

        public ICommand SendMessageCommand
        {
            get
            {
                return _sendMessageCommand = _sendMessageCommand ?? new Command(async () =>
                {
                    Messages.Add(new ConversationMessage
                    {
                        FromUser = "Eu",
                        Message = TextMessage,
                        UserImageUrl = "groot.jpg"
                    });

                    IsRefreshing = true;

                    var reply = await _chatBotService.SendMessage(TextMessage);

                    TextMessage = "";

                    Messages.Clear();

                    foreach (var msgItem in reply.Messages)
                    {
                        Messages.Add(new ConversationMessage
                        {
                            FromUser = msgItem.From == "TalkToLuisBot" ? "CABELEIREIRA" : "EU",
                            Message = msgItem.Text,
                            UserImageUrl = msgItem.From == "TalkToLuisBot" ? "cabeleireira.png" : "groot.jpg"
                        });
                    }

                    IsRefreshing = false;
                });
            }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
