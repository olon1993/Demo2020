using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Commons.ViewModels;
using Demo2020.Commons.Windows;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Demo2020
{
    public class MessageListener
    {
        public MessageListener()
        {
            RegiserCommonMessages();
        }

        private void RegiserCommonMessages()
        {
            Messenger.Default.Register<MessageWindowConfiguration>(this, msg => 
            {
                MessageWindow win = new MessageWindow
                {
                    DataContext = new MessageWindowViewModel(msg)
                };
                win.Show();
            });

            Messenger.Default.Register<CloseWindowMessage>(this, msg => 
            {
                foreach(Window window in Application.Current.Windows)
                {
                    if(window.DataContext == null)
                    {
                        continue;
                    }

                    if(window.DataContext == msg.DataContext)
                    {
                        window.Close();
                    }
                }
            });
        }

        public bool BindableProperty { get; set; } = true;
    }

}
