using System;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Net.Mail;

namespace Common
{
    public static class CommonMethods
    {
        public static Int32 ConverToInt32(this string _obj)
        {
            Int32 val = 0;
            Int32.TryParse(_obj, out val);
            return val;
            //testby sreeja
        }

        /// <summary>
        /// to Deserialize Xml to Class Object
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Object Deserialize(string xml, Type type)
        {
            try
            {
                if (string.IsNullOrEmpty(xml)) throw new Exception("The XML can not be empty for deserialation");

                XmlSerializer _xs = new XmlSerializer(type);
                MemoryStream _memoryStream = new MemoryStream(stringToUTF8ByteArray(xml));
                XmlTextWriter _xmlTextWriter = new XmlTextWriter(_memoryStream, Encoding.UTF8);
                return _xs.Deserialize(_memoryStream);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// for Deserialize Function
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static Byte[] stringToUTF8ByteArray(string xmlString)
        {
            return new UTF8Encoding().GetBytes(xmlString);
        }


        /// <summary>
        /// Objects to XML unicode.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string ObjectToXmlUnicode(object obj)
        {

            try
            {
                string xmlString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(obj.GetType());
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.Unicode);
                xs.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                UnicodeEncoding encoding = new UnicodeEncoding();
                xmlString = encoding.GetString(memoryStream.ToArray());
                return xmlString.Replace("’", "'");
            }
            catch
            {
                return string.Empty;
            }
        }
         

        #region Send Mail

        public delegate void LongTimeTaskCC_Delegate(string toEmails, string reportingPersonEmail, string HREmail, string subject, String messageBody);
        public delegate void LongTimeTaskCCAttach_Delegate(string toEmails, string reportingPersonEmail, string HREmail, string subject, String messageBody, AlternateView avHtml);

        public static void SendEmailWithCC(string toEmails, string reportingPersonEmail, string HREmail, string subject, String messageBody)
        {
            LongTimeTaskCC_Delegate d = null;
            d = new LongTimeTaskCC_Delegate(SendEmailWithCCAsync);
            IAsyncResult R = null;
            R = d.BeginInvoke(toEmails, reportingPersonEmail, HREmail, subject, messageBody, null, null);

        }

        public static void SendEmailWithCC(string toEmails, string reportingPersonEmail, string HREmail, string subject, String messageBody, AlternateView avHtml)
        {
            LongTimeTaskCCAttach_Delegate d = null;
            d = new LongTimeTaskCCAttach_Delegate(SendEmailWithCCAsync);
            IAsyncResult R = null;
            R = d.BeginInvoke(toEmails, reportingPersonEmail, HREmail, subject, messageBody,avHtml, null, null);

        }

        public static void SendEmailWithCCAsync(string toEmails, string reportingPersonEmail, string HREmail, string subject, String messageBody, AlternateView avHtml)
        {
            try
            {
                string _server = "mail.thinkpalm.com";
                string fromEmail = "Stars@thinkpalm.com <noreply@thinkpalm.com>";
                string _password = "Think@007";
                int _port = 25; //587; //465

                //string _server = datatableEmail.Rows[0]["EmailServer"].ToString();
                //string fromEmail = datatableEmail.Rows[0]["FromEmail"].ToString();
                //string _password = datatableEmail.Rows[0]["EmailPassword"].ToString();
                //int _port = Convert.ToInt32(datatableEmail.Rows[0]["MailPort"]);
                bool _IsSSLEnabled = false;
                var smtp = new SmtpClient
                {
                    Host = _server,
                    Port = _port,
                    EnableSsl = _IsSSLEnabled,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new System.Net.NetworkCredential(fromEmail, _password)

                };

                

                //using (var message = new MailMessage(fromEmail, toEmails)
                //{
                //    Subject = subject,
                //    Body = messageBody,
                //    IsBodyHtml = true

                //})
                var message = new MailMessage(fromEmail, toEmails);
                message.AlternateViews.Add(avHtml);
                message.IsBodyHtml = true;
                message.Subject = subject;
                {
                    if (reportingPersonEmail != "")
                    {
                        message.CC.Add(new MailAddress(reportingPersonEmail));
                    }
                    if (HREmail != "")
                    {
                        message.CC.Add(new MailAddress(HREmail));
                    }
                    smtp.Send(message);
                    //str = "Message send Successfully.......";
                }
            }

            catch (Exception ex)
            {


            }
        }
        public static void SendEmailWithCCAsync(string toEmails, string reportingPersonEmail, string HREmail, string subject, String messageBody)
        {
            try
            {
                string _server = "mail.thinkpalm.com";
                string fromEmail = "Stars@thinkpalm.com <noreply@thinkpalm.com>";
                string _password = "Think@007";
                int _port = 25; //587; //465

                //string _server = datatableEmail.Rows[0]["EmailServer"].ToString();
                //string fromEmail = datatableEmail.Rows[0]["FromEmail"].ToString();
                //string _password = datatableEmail.Rows[0]["EmailPassword"].ToString();
                //int _port = Convert.ToInt32(datatableEmail.Rows[0]["MailPort"]);
                bool _IsSSLEnabled = false;
                var smtp = new SmtpClient
                {
                    Host = _server,
                    Port = _port,
                    EnableSsl = _IsSSLEnabled,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new System.Net.NetworkCredential(fromEmail, _password)

                };
                using (var message = new MailMessage(fromEmail, toEmails)
                {
                    Subject = subject,
                    Body = messageBody,
                    IsBodyHtml = true

                })
                {
                    if (reportingPersonEmail != "")
                    {
                        message.CC.Add(new MailAddress(reportingPersonEmail));
                    }
                    if (HREmail != "")
                    {
                        message.CC.Add(new MailAddress(HREmail));
                    }
                    smtp.Send(message);
                    //str = "Message send Successfully.......";
                }
            }

            catch (Exception ex)
            {


            }
        }
        //public static void SendEmailWithCC(string toEmails, string reportingPersonEmail, string HREmail, string subject, String messageBody)
        //{
        //    try
        //    {
        //        string _server = "mail.thinkpalm.com";
        //        string fromEmail = "noreply@thinkpalm.com";
        //        string _password = "Think@007";
        //        int _port = 25; //587; //465

        //        //string _server = datatableEmail.Rows[0]["EmailServer"].ToString();
        //        //string fromEmail = datatableEmail.Rows[0]["FromEmail"].ToString();
        //        //string _password = datatableEmail.Rows[0]["EmailPassword"].ToString();
        //        //int _port = Convert.ToInt32(datatableEmail.Rows[0]["MailPort"]);
        //        bool _IsSSLEnabled = false;
        //        var smtp = new SmtpClient
        //        {
        //            Host = _server,
        //            Port = _port,
        //            EnableSsl = _IsSSLEnabled,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            UseDefaultCredentials = true,
        //            Credentials = new System.Net.NetworkCredential(fromEmail, _password)

        //        };
        //        using (var message = new MailMessage(fromEmail, toEmails)
        //        {
        //            Subject = subject,
        //            Body = messageBody,
        //            IsBodyHtml = true

        //        })
        //        {
        //            if (reportingPersonEmail != "")
        //            {
        //                message.CC.Add(new MailAddress(reportingPersonEmail));
        //            }
        //            if (HREmail != "")
        //            {
        //                message.CC.Add(new MailAddress(HREmail));
        //            }
        //            smtp.Send(message);
        //            //str = "Message send Successfully.......";
        //        }
        //    }

        //    catch (Exception ex)
        //    {


        //    }
        //}
        //public static void SendEmail(string toEmails, string subject, String messageBody)
        //{
        //    try
        //    {
        //        string _server = "mail.thinkpalm.com";
        //        string fromEmail = "noreply@thinkpalm.com";
        //        string _password = "Think@007";
        //        int _port = 25; //587; //465

        //        //string _server = datatableEmail.Rows[0]["EmailServer"].ToString();
        //        //string fromEmail = datatableEmail.Rows[0]["FromEmail"].ToString();
        //        //string _password = datatableEmail.Rows[0]["EmailPassword"].ToString();
        //        //int _port = Convert.ToInt32(datatableEmail.Rows[0]["MailPort"]);
        //        bool _IsSSLEnabled = false;
        //        var smtp = new SmtpClient
        //        {
        //            Host = _server,
        //            Port = _port,
        //            EnableSsl = _IsSSLEnabled,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            UseDefaultCredentials = true,
        //            Credentials = new System.Net.NetworkCredential(fromEmail, _password)

        //        };
        //        using (var message = new MailMessage(fromEmail, toEmails)
        //        {
        //            Subject = subject,
        //            Body = messageBody,
        //            IsBodyHtml = true

        //        })
        //        {
        //            smtp.Send(message);
        //            //str = "Message send Successfully.......";
        //        }
        //    }

        //    catch (Exception ex)
        //    {


        //    }
        //}

        public static void SendEmail(string toEmails, string ccMails, string subject, String messageBody)
        {
            try
            {
                string _server = "mail.thinkpalm.com";
                string fromEmail = "Stars@thinkpalm.com <noreply@thinkpalm.com>";
                string _password = "Think@007";
                int _port = 25; //587; //465

                //string _server = datatableEmail.Rows[0]["EmailServer"].ToString();
                //string fromEmail = datatableEmail.Rows[0]["FromEmail"].ToString();
                //string _password = datatableEmail.Rows[0]["EmailPassword"].ToString();
                //int _port = Convert.ToInt32(datatableEmail.Rows[0]["MailPort"]);
                bool _IsSSLEnabled = false;
                var smtp = new SmtpClient
                {
                    Host = _server,
                    Port = _port,
                    EnableSsl = _IsSSLEnabled,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new System.Net.NetworkCredential(fromEmail, _password)

                };
                MailAddress ccAddress = new MailAddress(ccMails);
                using (var message = new MailMessage(fromEmail, toEmails)
                {
                    Subject = subject,
                    Body = messageBody,
                    IsBodyHtml = true,
                })
                {
                    message.CC.Add(ccAddress);
                    smtp.Send(message);
                    //str = "Message send Successfully.......";
                }
            }

            catch (Exception ex)
            {


            }
        }

        public delegate void LongTimeTask_Delegate1(string toEmails, string subject, String messageBody, AlternateView avHtml);
        public delegate void LongTimeTask_Delegate(string toEmails, string subject, String messageBody);
        public static void sendmail(string toEmails, string subject, String messageBody)
        {
            try
            {
                string _server = "mail.thinkpalm.com";
                string fromEmail = "Stars@thinkpalm.com <noreply@thinkpalm.com>";
                string _password = "Think@007";
                int _port = 25; //587; //465

                //string _server = datatableEmail.Rows[0]["EmailServer"].ToString();
                //string fromEmail = datatableEmail.Rows[0]["FromEmail"].ToString();
                //string _password = datatableEmail.Rows[0]["EmailPassword"].ToString();
                //int _port = Convert.ToInt32(datatableEmail.Rows[0]["MailPort"]);
                bool _IsSSLEnabled = false;
                var smtp = new SmtpClient
                {
                    Host = _server,
                    Port = _port,
                    EnableSsl = _IsSSLEnabled,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new System.Net.NetworkCredential(fromEmail, _password)

                };
                using (var message = new MailMessage(fromEmail, toEmails)
                {
                    Subject = subject,
                    Body = messageBody,
                    IsBodyHtml = true

                })
                {
                    smtp.Send(message);
                    //str = "Message send Successfully.......";
                }
            }

            catch (Exception ex)
            {


            }
        }
        public static void sendmail(string toEmails, string subject, String messageBody, AlternateView avHtml)
        {
            try
            {
                string _server = "mail.thinkpalm.com";
                string fromEmail = "Stars@thinkpalm.com <noreply@thinkpalm.com>";
                string _password = "Think@007";
                int _port = 25; //587; //465

                //string _server = datatableEmail.Rows[0]["EmailServer"].ToString();
                //string fromEmail = datatableEmail.Rows[0]["FromEmail"].ToString();
                //string _password = datatableEmail.Rows[0]["EmailPassword"].ToString();
                //int _port = Convert.ToInt32(datatableEmail.Rows[0]["MailPort"]);
                bool _IsSSLEnabled = false;
                var smtp = new SmtpClient
                {
                    Host = _server,
                    Port = _port,
                    EnableSsl = _IsSSLEnabled,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new System.Net.NetworkCredential(fromEmail, _password)

                };

                 var message = new MailMessage(fromEmail, toEmails);
                 message.AlternateViews.Add(avHtml);
                 message.IsBodyHtml = true; 
                 message.Subject = subject;
                
                //using (var message = new MailMessage(fromEmail, toEmails)
                //{
                //    message.AlternateViews.Add(avHtml);
                //    Subject = subject,
                //    Body = messageBody,
                //    IsBodyHtml = true

                //})
                {
                    smtp.Send(message);
                    //str = "Message send Successfully.......";
                }
            }

            catch (Exception ex)
            {


            }
        }

        public static void SendEmail(string toEmails, string subject, String messageBody, AlternateView avHtml)
        {

            LongTimeTask_Delegate1 d = null;
            d = new LongTimeTask_Delegate1(sendmail);
            IAsyncResult R = null;
            R = d.BeginInvoke(toEmails, subject, messageBody,avHtml, null, null);

            
        }

        public static void SendEmail(string toEmails, string subject, String messageBody)
        {

            LongTimeTask_Delegate d = null;
            d = new LongTimeTask_Delegate(sendmail);
            IAsyncResult R = null;
            if(toEmails!=null)
            R = d.BeginInvoke(toEmails, subject, messageBody, null, null);

            
        }
        #endregion Send Mail

    }
}
