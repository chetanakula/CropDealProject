using CropDealProject.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CropDealProject.Controller
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailProcessController : ControllerBase
    {
        [HttpPost("EmailSendings")]
        public IActionResult EmailSending(List<Invoice> data_table)
        {
            double totalamount = 0;
            string textBody = "<p> Hello Dealer, </p> <p>Thank you for ordering from Crop deal Management system.</p> <p>Once the order is approved by admin, we will process it</p>";
            //textBody += " <table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'><td><b>Drug Name</b></td> <td> <b> Drug Quantity</b> </td> <td> <b> Unit Price</b> </td> <td> <b>Total Amount</b> </td></tr>";
            //for (int loopCount = 0; loopCount < data_table.Count; loopCount++)
            //{
            //    textBody += "<tr><td>" + data_table[loopCount].CropName + "</td><td> " + data_table[loopCount].CropQty + "</td><td> " + data_table[loopCount].CropType + "</td><td> " + Convert.ToInt32(data_table[loopCount].OrderTotal) + "</td> </tr>";
            //    totalamount += data_table[loopCount].OrderTotal;
            //}
            //textBody += "</table> <br>";
            //textBody += "<strong>Order Date :</strong>";
            //textBody += data_table[0].OrderDate.ToShortDateString();
            //textBody += "<br><strong>Total Order Amount :</strong>";
            //textBody += totalamount;
            //textBody += "<br>";
            textBody += "<br><i>If you have any questions, contact us here on <b>chetansatyatejaakula@gmail.com</b>! " +
            "We are here to help you! </i>";
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Crop Deal", "chetansatyatejaakula@gmail.com"));
            message.To.Add(new MailboxAddress("Dealer","satyaakula2328@gmail.com"));
            message.Subject = "Order Placed - Pharmacy Management System";
            message.Body = new TextPart("html")
            {
                Text = textBody
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("chetansatyatejaakula@gmail.com", "pzoqeauqbpyarcac");
                client.Send(message);
                client.Disconnect(true);
            }
            return Ok("Email sent Successfully");
        }
        [HttpPost("AdminEmail/OrderConfirmation")]
        public IActionResult AdminEmailSending(Invoice data_table)
        {
            //double totalamount = 0;
            string textBody = "<p> Hello Dealer, </p> <p>Thank you for ordering from Crop deal Management system.</p> <p>We’re happy to let you know that we’ve received your order.</p> <p>Your order was approved by admin, and you will receive your order shortly.</p>";
            //textBody += " <table border=" + 1 + " cellpadding=" + 1 + " cellspacing=" + 1 + " width = " + 600 + "><tr><td><b> Crop Name</b></td> <td> <b> Crop Type</b> </td> <td> <b> Crop Quantity</b> </td> <td> <b>Total Amount</b> </td></tr>";
            //textBody += "<tr><td>" + data_table.CropName + "</td><td> " + data_table.CropQty + "</td><td> " + data_table.CropType + "</td><td> " + Convert.ToInt32(data_table.OrderTotal) + "</td> </tr>";
            //totalamount += data_table.OrderTotal;
            //textBody += "</table> <br>";
            //textBody += "<strong>Order Date :</strong>";
            //textBody += data_table.OrderDate.ToShortDateString();
            //textBody += "<br><strong>Total Order Amount :</strong>";
            //textBody += totalamount;
            textBody += "<br><i>If you have any questions, contact us here on <b>chetansatyatejaakula@gmail.com</b>! ";
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Crop Deal", "chetansatyatejaakula@gmail.com"));
            message.To.Add(new MailboxAddress("Dealer", "satyaakula2328@gmail.com" ));
            message.Subject = "Order Confirmed - Crop Deal";
            message.Body = new TextPart("html")
            {
                Text = textBody
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("chetansatyatejaakula@gmail.com", "pzoqeauqbpyarcac");
                client.Send(message);
                client.Disconnect(true);
            }
            return Ok("Email sent Successfully");
        }        

 
        
    }
}

