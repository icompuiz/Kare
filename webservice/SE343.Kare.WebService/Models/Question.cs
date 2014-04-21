using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE343.Kare.WebService.Models
{
    public class Question
    {
        private String _text;
        public String Text
        {
            get { return _text; }
            set { _text = value; }
        }

        private IResponseType _responseType;
        public Type ResponseType
        {
            get { return _responseType.GetType(); }
        }
    }
}