using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using System.Text.RegularExpressions;
using UnityEngine.Localization.Settings;




public class SendEmail : MonoBehaviour
{
    #region Inspector
    [Header("Sender")]
    [SerializeField] private EmailCredentialsSo _credentials;

    [Header("Recipient")]
    [Space(30)]
    [SerializeField] string subject = "Test Unity Email Sender";
    [SerializeField] TMP_InputField msg;
    [SerializeField] string recipientEmail = "newslettermanchangingideas@gmail.com";

    [Header("Status Text")]
    [Space(30)]
    [SerializeField] GameObject sucessStatusTxt;
    [SerializeField] GameObject faliedStatusTxt;


    bool sucess;
    #endregion

    #region My Functions
    public void Send() // Called by button
    {
        if(IsValidEmail(msg.text) == true && !msg.text.Contains(" ") && !sucess)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Timeout = 10000;
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Port = 587;

            mail.From = new MailAddress(_credentials.Email);
            mail.To.Add(new MailAddress(recipientEmail));

            mail.Subject = subject;
            mail.Body = msg.text;


            SmtpServer.Credentials = new System.Net.NetworkCredential(_credentials.Email, _credentials.Password) as ICredentialsByHost; SmtpServer.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            SmtpServer.Send(mail);



            sucess = true;
            sucessStatusTxt.SetActive(true);
            faliedStatusTxt.SetActive(false);


            msg.enabled = false;
        }
        else 
        {
            sucessStatusTxt.SetActive(false);
            faliedStatusTxt.SetActive(true);
        }
    }
    bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    #endregion
}
