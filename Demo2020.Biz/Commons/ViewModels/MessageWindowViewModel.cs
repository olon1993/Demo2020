using Demo2020.Biz.Commons.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo2020.Biz.Commons.ViewModels
{
    public class MessageWindowViewModel : ObservableObject
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        #region Fiels
        private string _title;
        private string _message;
        private bool _isTrueFalseVisible;
        private bool _isOkVisible;
        #endregion

        public MessageWindowViewModel(MessageWindowConfiguration config)
        {
            Title = config.Title;
            Message = config.Message;
            IsTrueFalseVisible = config.IsTrueFalseVisible;
            IsOkVisible = config.IsOkVisible;
            Token = config.Token;

            OkCommand = new RelayCommand(Ok);
            TrueCommand = new RelayCommand(True);
            FalseCommand = new RelayCommand(False);
        }

        //**************************************************\\
        //******************** Methods *********************\\
        //**************************************************\\
        #region Methods
        private void Ok()
        {
            Close();
        }

        private void True()
        {
            // Send true message
            Messenger.Default.Send(new MessageWindowResponse 
            {
                Response = true,
                Token = Token
            });
            Close();
        }

        private void False()
        {
            // Send false message
            Messenger.Default.Send(new MessageWindowResponse
            {
                Response = false,
                Token = Token
            });
            Close();
        }

        private void Close()
        {
            Messenger.Default.Send(new CloseWindowMessage(this));
        }
        #endregion

        //**************************************************\\
        //******************* Properties *******************\\
        //**************************************************\\
        #region Properties
        public ICommand OkCommand { get; set; }
        public ICommand TrueCommand { get; set; }
        public ICommand FalseCommand { get; set; }

        public string Title 
        {
            get { return _title; }
            set
            {
                if(_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsTrueFalseVisible
        {
            get { return _isTrueFalseVisible; }
            set
            {
                if (_isTrueFalseVisible != value)
                {
                    _isTrueFalseVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsOkVisible
        {
            get { return _isOkVisible; }
            set
            {
                if (_isOkVisible != value)
                {
                    _isOkVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public object Token { get; set; }
        #endregion
    }
}
