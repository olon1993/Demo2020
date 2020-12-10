using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Commons.Models
{
    public class MessageWindowConfiguration
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool IsTrueFalseVisible { get; set; } = false;
        public bool IsOkVisible { get; set; } = true;

        public static MessageWindowConfiguration DefaultConfig(string message)
        {
            return new MessageWindowConfiguration
            {
                Title = string.Empty,
                Message = message,
                IsOkVisible = true,
                IsTrueFalseVisible = false
            };
        }
    }
}
