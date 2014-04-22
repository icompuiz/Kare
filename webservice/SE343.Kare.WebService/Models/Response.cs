using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SE343.Kare.WebService.Models
{
    public class Response
    {
        private Question _question;
        public Question Question
        {
            get { return _question; }
            set { _question = value; }
        }

        private String _content;
        public String Content
        {
            get { return _content; }
            set { _content = value; }
        }
    }
}