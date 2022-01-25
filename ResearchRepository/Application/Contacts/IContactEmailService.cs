﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResearchRepository.Application.Contacts
{
    public interface IContactEmailService
    {
        /// <summary>
        /// Send an email to a list of emails with reply-to 'toEmail'  and copy to 'toEmail' 
        /// </summary>
        /// Author: Roberto Mendez
        /// User Stories: ST-MM-10.8, ST-MM-10.9
        /// <param name="emailList"></param>
        /// <param name="toEmail"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendEmailAsync(List<string> emailList, string toEmail, string subject, string message);

        /// <summary>
        /// Send an email to user to have a reference copy of their message
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendReceivedEmailAsync(string userEmail, string subject, string message);
    }
}
