using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Roles.Models;

namespace Roles.Controllers
{
    public class EmailController : Controller
    {
        public  async Task<IActionResult> Index(Email email)
        {
           
            if (ModelState.IsValid)
            {
                MailMessage mMessage = new MailMessage();
                mMessage.To.Add(email.To);
                mMessage.Subject = email.Subject;
                mMessage.Body = email.Body;
                mMessage.IsBodyHtml = false;
                mMessage.From = new MailAddress("era.camacho@gmail.com");
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                // smtp 
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("era.camacho@gmail.com", "Nickcolas1");
                
                await smtpClient.SendMailAsync(mMessage);
                ViewData["Message"] = "Message has been send Successfully";
            }
            return View();
        }
    }
}
