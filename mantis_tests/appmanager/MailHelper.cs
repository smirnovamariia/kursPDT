﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpaqueMail;



namespace mantis_tests
{
    public class MailHelper : HelperBase
    {
        public MailHelper(ApplicationManager manager) : base(manager) { }

        public String GetLastMail(AccountData account)
        {
            Pop3Client pop3 = new Pop3Client("localhost", 110,account.Name, account.Password, false);
            pop3.Connect();
            pop3.Authenticate();
            int count = pop3.GetMessageCount();
            for (int i =0; i < 15; i++)
            {
                if(pop3.GetMessageCount()>0)
                {
                    MailMessage message = pop3.GetMessage(1);
                    return message.Body;
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                }
           
            }

            return null;
        }
    }
}
