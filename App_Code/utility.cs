using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Text.RegularExpressions;
/// <summary>
/// Summary description for util
/// </summary>
namespace utility
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Collections.Specialized;
    public class mail
    {
        string _smtpClient;
        string _subject;
        string _message;
        string _from;
        string _to;
        public string SendMailFrom;
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        public string To
        {
            get { return _to; }
            set { _to = value; }
        }


        public void sendMail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_to);
                mail.From = new MailAddress(ConfigurationManager.AppSettings["frommailaddress"].ToString(), "TAAZI BHAAZI");
                mail.Subject = _subject;
                mail.Body = _message;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["smtp"].ToString(); //Or Your SMTP Server Address                
                smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["userid"].ToString(), ConfigurationManager.AppSettings["pwd"].ToString());
                //Or your Smtp Email ID and Password

                 smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception Ex)
            {
                string msg = Ex.Message;
            }
        }
    }

    public class Date
    {
        string _DateDDMMYYYY;
        string _DateMMDDYYYY;

        public Date(string DateString, bool isBritishFormat_DDMMYYYY)
        {
            if (isBritishFormat_DDMMYYYY)
            {
                _DateDDMMYYYY = DateString;
                _DateMMDDYYYY = getMMDDYYYY();
            }
            else
            {
                _DateMMDDYYYY = DateString;
                _DateDDMMYYYY = getDDMMYYYY();
            }
        }

        public string DateDDMMYYYY
        {
            get { return _DateDDMMYYYY; }
            set { _DateDDMMYYYY = value; }
        }

        public string DateMMDDYYYY
        {
            get { return _DateMMDDYYYY; }
            set { _DateMMDDYYYY = value; }
        }

        public string getMMDDYYYY()
        {
            string[] dt = _DateDDMMYYYY.Split('/');
            if (dt.Length == 3)
            {
                _DateMMDDYYYY = dt[1] + "/" + dt[0] + "/" + dt[2];
                return _DateMMDDYYYY;
            }
            else
                return "";
        }

        public string getDDMMYYYY()
        {
            string[] dt = _DateMMDDYYYY.Split('/');
            if (dt.Length == 3)
            {
                _DateDDMMYYYY = dt[1] + "/" + dt[0] + "/" + dt[2];
                return _DateDDMMYYYY;
            }
            else
                return "";
        }
    }

    public class utilFunction
    {
        static Regex _reg = new Regex("<.*?>", RegexOptions.Compiled);

        /// Optimized Regex method to remove all HTML tags from string with Regex.
        /// </summary>
        public static string StripTags(string text)
        {
            return _reg.Replace(text, string.Empty);
        }
    }

    public class PasswordGenerator
    {
        public PasswordGenerator()
        {
            this.Minimum = DefaultMinimum;
            this.Maximum = DefaultMaximum;
            this.ConsecutiveCharacters = false;
            this.RepeatCharacters = true;
            this.ExcludeSymbols = false;
            this.Exclusions = null;

            rng = new RNGCryptoServiceProvider();
        }

        protected int GetCryptographicRandomNumber(int lBound, int uBound)
        {
            // Assumes lBound >= 0 && lBound < uBound
            // returns an int >= lBound and < uBound
            uint urndnum;
            byte[] rndnum = new Byte[4];
            if (lBound == uBound - 1)
            {
                // test for degenerate case where only lBound can be returned
                return lBound;
            }

            uint xcludeRndBase = (uint.MaxValue -
                (uint.MaxValue % (uint)(uBound - lBound)));

            do
            {
                rng.GetBytes(rndnum);
                urndnum = System.BitConverter.ToUInt32(rndnum, 0);
            } while (urndnum >= xcludeRndBase);

            return (int)(urndnum % (uBound - lBound)) + lBound;
        }

        protected char GetRandomCharacter()
        {
            int upperBound = pwdCharArray.GetUpperBound(0);

            if (true == this.ExcludeSymbols)
            {
                upperBound = PasswordGenerator.UBoundDigit;
            }

            int randomCharPosition = GetCryptographicRandomNumber(
                pwdCharArray.GetLowerBound(0), upperBound);

            char randomChar = pwdCharArray[randomCharPosition];

            return randomChar;
        }

        public string Generate()
        {
            // Pick random length between minimum and maximum   
            int pwdLength = GetCryptographicRandomNumber(this.Minimum,
                this.Maximum);

            StringBuilder pwdBuffer = new StringBuilder();
            pwdBuffer.Capacity = this.Maximum;

            // Generate random characters
            char lastCharacter, nextCharacter;

            // Initial dummy character flag
            lastCharacter = nextCharacter = '\n';

            for (int i = 0; i < pwdLength; i++)
            {
                nextCharacter = GetRandomCharacter();

                if (false == this.ConsecutiveCharacters)
                {
                    while (lastCharacter == nextCharacter)
                    {
                        nextCharacter = GetRandomCharacter();
                    }
                }

                if (false == this.RepeatCharacters)
                {
                    string temp = pwdBuffer.ToString();
                    int duplicateIndex = temp.IndexOf(nextCharacter);
                    while (-1 != duplicateIndex)
                    {
                        nextCharacter = GetRandomCharacter();
                        duplicateIndex = temp.IndexOf(nextCharacter);
                    }
                }

                if ((null != this.Exclusions))
                {
                    while (-1 != this.Exclusions.IndexOf(nextCharacter))
                    {
                        nextCharacter = GetRandomCharacter();
                    }
                }

                pwdBuffer.Append(nextCharacter);
                lastCharacter = nextCharacter;
            }

            if (null != pwdBuffer)
            {
                return pwdBuffer.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        public string Exclusions
        {
            get { return this.exclusionSet; }
            set { this.exclusionSet = value; }
        }

        public int Minimum
        {
            get { return this.minSize; }
            set
            {
                this.minSize = value;
                if (PasswordGenerator.DefaultMinimum > this.minSize)
                {
                    this.minSize = PasswordGenerator.DefaultMinimum;
                }
            }
        }

        public int Maximum
        {
            get { return this.maxSize; }
            set
            {
                this.maxSize = value;
                if (this.minSize >= this.maxSize)
                {
                    this.maxSize = PasswordGenerator.DefaultMaximum;
                }
            }
        }

        public bool ExcludeSymbols
        {
            get { return this.hasSymbols; }
            set { this.hasSymbols = value; }
        }

        public bool RepeatCharacters
        {
            get { return this.hasRepeating; }
            set { this.hasRepeating = value; }
        }

        public bool ConsecutiveCharacters
        {
            get { return this.hasConsecutive; }
            set { this.hasConsecutive = value; }
        }

        private const int DefaultMinimum = 6;
        private const int DefaultMaximum = 7;
        private const int UBoundDigit = 61;

        private RNGCryptoServiceProvider rng;
        private int minSize;
        private int maxSize;
        private bool hasRepeating;
        private bool hasConsecutive;
        private bool hasSymbols;
        private string exclusionSet;
        private char[] pwdCharArray = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
    }
}