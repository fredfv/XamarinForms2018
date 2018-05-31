using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using App1_NossoChat.Model;
using App1_NossoChat.Service;
using Xamarin.Forms;
using App1_NossoChat.Util;

namespace App1_NossoChat.ViewModel
{
    public class MensagemViewModel : INotifyPropertyChanged
    {
        private string _txtmensagem;
        public string TxtMensagem
        {
            get { return _txtmensagem; }
            set
            {
                _txtmensagem = value;
                OnPropertyChanged("TxtMensagem");
            }
        }

        public Command BtnEnviar { get; set; }
        public Command AtualizarCommand { get; set; }

        private StackLayout SL;
        private Chat chat;

        private List<Mensagem> _mensagems;
        public List<Mensagem> Mensagems { get { return _mensagems; }
            set {
                _mensagems = value;
                OnPropertyChanged("Mensagems");
                if(value != null)
                {
                    ShowOnScreen();
                }
            } }


        public MensagemViewModel(Chat chat, StackLayout SLMensagemContainer)
        {
            this.chat = chat;
            SL = SLMensagemContainer;
            Atualizar();
            BtnEnviar = new Command(Enviar);
            AtualizarCommand = new Command(Atualizar);

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                Atualizar();
                return true;
            });
        }
        private void Atualizar()
        {
            Mensagems = ServicoWS.GetMensagemsChat(chat);

        }

        private void Enviar()
        {
            var msg = new Mensagem() {
                id_usuario = UsuarioUtil.GetUsuarioLogado().id,
                mensagem = TxtMensagem,
                id_chat = chat.id
            };

            ServicoWS.InsertMensagem(msg);
            Atualizar();
            TxtMensagem = string.Empty;
        }

        private void ShowOnScreen()
        {
            var usuario = UsuarioUtil.GetUsuarioLogado();

            SL.Children.Clear();
            foreach (var msg in Mensagems)
            {
                if (msg.usuario.id == usuario.id)
                {
                    SL.Children.Add(CriarMsgPropria(msg));
                }
                else
                {
                    SL.Children.Add(CriarMsgOutros(msg));
                }
            }
        }


        private Xamarin.Forms.View CriarMsgPropria(Mensagem msg)
        {
            var layout = new StackLayout() { Padding = 5, BackgroundColor = Color.FromHex("#5ED055"), HorizontalOptions = LayoutOptions.End };
            var label = new Label() { TextColor = Color.White, Text = msg.mensagem };

            layout.Children.Add(label);

            return layout;
        }
        private Xamarin.Forms.View CriarMsgOutros(Mensagem msg)
        {

            var labelNome = new Label() { Text = msg.usuario.nome, FontSize=10, TextColor = Color.FromHex("#5ED055") };
            var labelMsg = new Label() { Text = msg.mensagem, TextColor = Color.FromHex("#5ED055") };

            var SL = new StackLayout() { };
            SL.Children.Add(labelNome);
            SL.Children.Add(labelMsg); 

            var frame = new Frame() { OutlineColor = Color.FromHex("#5ED055"), CornerRadius = 0, HorizontalOptions = LayoutOptions.Start };
            frame.Content = SL;

            return frame;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string PropertyValue)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyValue));
            }
        }

    }
}
