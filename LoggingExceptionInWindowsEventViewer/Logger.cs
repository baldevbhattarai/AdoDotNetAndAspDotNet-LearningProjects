using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

namespace LoggingExceptionInWindowsEventViewer
{
    public class Logger
    {
        public static void Log(Exception exception)
        {
            Log(exception, EventLogEntryType.Error);
        }
        //  public static void Log(Exception exception, EventLogEntryType eventLogEntryType)
        public static void Log(Exception exception, EventLogEntryType eventLogEntryType)
        {
            StringBuilder sbExceptionMessage = new StringBuilder();

            do
            {
                sbExceptionMessage.Append("Exception Type" + Environment.NewLine);
                sbExceptionMessage.Append(exception.GetType().Name);
                sbExceptionMessage.Append(Environment.NewLine + Environment.NewLine);
                sbExceptionMessage.Append("Message" + Environment.NewLine);
                sbExceptionMessage.Append(exception.Message + Environment.NewLine + Environment.NewLine);
                sbExceptionMessage.Append("Stack Trace" + Environment.NewLine);
                sbExceptionMessage.Append(exception.StackTrace + Environment.NewLine + Environment.NewLine);

                exception = exception.InnerException;
            }
            while (exception != null);

            string logProvider = ConfigurationManager.AppSettings["LogProvider"];
            if (logProvider.ToLower() == "both")
            {
                LogToDB(sbExceptionMessage.ToString());
                LogToEventViewer(sbExceptionMessage.ToString());
            }
            else if (logProvider.ToLower() == "database")
            {
                LogToDB(sbExceptionMessage.ToString());
            }
            else if (logProvider.ToLower() == "eventviewer")
            {
                LogToEventViewer(sbExceptionMessage.ToString());
            }

            string sendEmail = ConfigurationManager.AppSettings["SendEmail"];
            if (sendEmail.ToLower() == "true")
            {
               // SendEmail(sbExceptionMessage.ToString());
            }
        }
        //--------Logging into windows Event Viewer------------------------


        private static void LogToEventViewer(string log)
        {
            if (EventLog.SourceExists("CheckingEventLog.com"))
            {
                // Create an instance of the eventlog
                EventLog eventLog = new EventLog("CheckingEventLog");
                // set the source for the eventlog
                eventLog.Source = "CheckingEventLog.com";
                // Write the exception details to the event log as an error
                eventLog.WriteEntry(log, EventLogEntryType.Error);
            }
        }
        //------------Logging into Database-------------------
        private static void LogToDB(string log)
        {
            // ConfigurationManager class is in System.Configuration namespace
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            // SqlConnection is in System.Data.SqlClient namespace
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spInsertLog", con);
                // CommandType is in System.Data namespace
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@ErrorMessage", log);
                cmd.Parameters.Add(parameter);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        //----------------Sending Email-------
        public static void SendEmail(string emailbody)
        {
            // Specify the from and to email address
            MailMessage mailMessage = new MailMessage("bhattarai.baldev@gmail.com", "bhattarai.baldev@gmail.com");
            // Specify the email body
            mailMessage.Body = emailbody;
            // Specify the email Subject
            mailMessage.Subject = "Exception";

            // Specify the SMTP server name and post number

            SmtpClient smtpClient = new SmtpClient();

//----This commented part can also be written in <system.net><MailSetting> in web.xml file. 
            //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            // Specify your gmail address and password
            //smtpClient.Credentials = new System.Net.NetworkCredential()
            //{
            //    UserName = "bhattarai.baldev@gmail.com",
            //    Password = "Test"
            //};
            // Gmail works on SSL, so set this property to true
            //smtpClient.EnableSsl = true;
            // Finall send the email message using Send() method
            smtpClient.Send(mailMessage);
        }


    }
}