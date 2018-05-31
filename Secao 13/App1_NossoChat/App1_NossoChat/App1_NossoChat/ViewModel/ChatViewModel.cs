using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using App1_NossoChat.Model;
using Xamarin.Forms;
using System.Linq;
using App1_NossoChat.Service;

namespace App1_NossoChat.ViewModel
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private List<Chat> _chats;
        public List<Chat> Chats { get { return _chats; } set { _chats = value; OnPropertyChanged("Chats"); } }

        private Chat _selectItemChat;
        public Chat SelectItemChat { get { return _selectItemChat; } set { _selectItemChat = value; OnPropertyChanged("SelectItemChat"); GoPaginaMensagem(value); } }

        public Command AdicionarCommand { get; set; }
        public Command OrdenarCommand { get; set; }
        public Command AtualizarCommand { get; set; }

        public ChatViewModel()
        {
            Chats = ServicoWS.GetChats();
            AdicionarCommand = new Command(Adicionar);
            OrdenarCommand = new Command(Ordernar);
            AtualizarCommand = new Command(Atualizar);
        }

        private void Adicionar()
        {
            ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.CadastrarChat());
        }
        private void Ordernar()
        {
            Chats = Chats.OrderBy(a => a.nome).ToList();
        }
        private void Atualizar()
        {
            Chats = ServicoWS.GetChats();
        }
         
        private void GoPaginaMensagem(Chat chat)
        {
            if (chat != null)
            {
                SelectItemChat = null;
                ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.Mensagem(chat));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }


    }
}
