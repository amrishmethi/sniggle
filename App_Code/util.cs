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
namespace util
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
                mail.From = new MailAddress(ConfigurationManager.AppSettings["frommailaddress"].ToString(), "SNIGGLE!");
                mail.Subject = _subject;
                mail.Body = _message;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["smtp"].ToString(); //Or Your SMTP Server Address

                smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["userid"].ToString(), ConfigurationManager.AppSettings["pwd"].ToString());
                //Or your Smtp Email ID and Password

               smtp.EnableSsl = false;
                smtp.Send(mail);
            }
            catch(Exception ex)
            {
                string aa = ex.ToString();
            }
        }
        public string sendMailAdmin()
        {
            string ststus = "";
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(_to);
                mail.From = new MailAddress(ConfigurationManager.AppSettings["frommailaddress"].ToString(), "SNIGGLE!");
                mail.Subject = _subject;
                mail.Body = _message;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["smtp"].ToString(); //Or Your SMTP Server Address

                smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["userid"].ToString(), ConfigurationManager.AppSettings["pwd"].ToString());
                //Or your Smtp Email ID and Password

                smtp.EnableSsl = true;
                smtp.Send(mail);
                ststus = "success";
            }
            catch (Exception ex)
            {
                string aa = ex.ToString();
                ststus = "Fail";
            }

            return ststus;
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


    public class CurrToWord
    {
        public string ConvertNumberToWord(string MyNumber)
        {
            string DecimalPart, DecimalPartWord, RealPart, RealPartWord;
            int k, RealPartLength;
            //string Place2=" Thousand ", Place3=" Lakh ", Place4=" Crore ", Place5=" Billion ", Place6=" Trillion ";
            MyNumber = MyNumber.Trim();
            //////////////////////////////// Split MyNumber into RealPart and DecimalPart ///////////////////////////////////////
            k = MyNumber.IndexOf(".");
            if (k < 0)
            {
                DecimalPart = ""; //There is no decimal part
                RealPart = MyNumber.Replace(",", ""); //Remove all coma if any
            }
            else if (k == 0)
            {
                DecimalPart = MyNumber.Substring(k, 2);
                RealPart = ""; //There is no real part
            }
            else
            {
                DecimalPart = MyNumber.Substring(k + 1, 2);
                RealPart = MyNumber.Remove(k);
                RealPart = RealPart.Replace(",", ""); //Remove all coma if any
            }
            ////////////////////////////////// Convert DecimalPart into DecimalPartWord ///////////////////////////////////////////////////
            if (DecimalPart != "")
                DecimalPartWord = ConvertDoubleDigit(DecimalPart);
            else
                DecimalPartWord = "";
            ////////////////////////////////////// Convert RealPart into Word /////////////////////////////////////////////////
            RealPartLength = RealPart.Length;
            if (RealPartLength == 1)
                RealPartWord = ConvertSingleDigit(RealPart);
            else if (RealPartLength == 2)
                RealPartWord = ConvertDoubleDigit(RealPart);
            else if (RealPartLength == 3)
                RealPartWord = ConvertHundred(RealPart);
            else if (RealPartLength > 3 && RealPartLength < 6)
                RealPartWord = ConvertThousand(RealPart, RealPartLength);
            else if (RealPartLength > 5 && RealPartLength < 8)
                RealPartWord = ConvertLakh(RealPart, RealPartLength);
            else
                RealPartWord = ConvertCrore(RealPart, RealPartLength);
            // ////////////////Return /////////////////////////
            if (RealPartWord == "" && DecimalPartWord == "")
                return "";
            else if (RealPartWord != "" && DecimalPartWord != "")
                return " " + RealPartWord + " Rupees and " + DecimalPartWord+" Paisa";
            else if (RealPartWord != "" && DecimalPartWord == "")
                return "" + RealPartWord + " Rupees";
            else
                return " " + DecimalPartWord + " Paisa";

        }
        ///////////////////////////////////////// Convert Hundred Part into Word ///////////////////////////////////////////////
        private string ConvertHundred(string MyNumber)
        {
            string Result;
            if (MyNumber.Remove(1, 2) != "0")
            {
                if (ConvertSingleDigit(MyNumber.Remove(1, 2)) == "")
                    Result = "";
                else
                    Result = ConvertSingleDigit(MyNumber.Remove(1, 2)) + " Hundred ";
            }
            else
                Result = "";
            Result = Result + ConvertDoubleDigit(MyNumber.Remove(0, 1));
            return Result;
        }
        ///////////////////////////////////////// Convert Thousand Part into Word ///////////////////////////////////////////////
        private string ConvertThousand(string MyNumber, int Ln)
        {
            string Result;
            if (Ln >= 5)
            {
                if (ConvertDoubleDigit(MyNumber.Remove(2, 3)) == "")
                    Result = "";
                else
                    Result = ConvertDoubleDigit(MyNumber.Remove(2, 3)) + " Thousand ";
                Result = Result + ConvertHundred(MyNumber.Remove(0, 2));
            }
            else
            {
                if (ConvertSingleDigit(MyNumber.Remove(1, 3)) == "")
                    Result = "";
                else
                    Result = ConvertSingleDigit(MyNumber.Remove(1, 3)) + " Thousand ";
                Result = Result + ConvertHundred(MyNumber.Remove(0, 1));
            }
            return Result;
        }
        ///////////////////////////////////////// Convert Lakh Part into Word ///////////////////////////////////////////////
        private string ConvertLakh(string MyNumber, int Ln)
        {
            string Result;
            if (Ln >= 7)
            {
                if (ConvertDoubleDigit(MyNumber.Remove(2, 5)) == "")
                    Result = "";
                else
                    Result = ConvertDoubleDigit(MyNumber.Remove(2, 5)) + " Lakh ";
                Result = Result + ConvertThousand(MyNumber.Remove(0, 2), 7);
            }
            else
            {
                if (ConvertSingleDigit(MyNumber.Remove(1, 5)) == "")
                    Result = "";
                else
                    Result = ConvertSingleDigit(MyNumber.Remove(1, 5)) + " Lakh ";
                Result = Result + ConvertThousand(MyNumber.Remove(0, 1), 6);
            }
            return Result;
        }
        ///////////////////////////////////////// Convert Crore Part into Word ///////////////////////////////////////////////
        private string ConvertCrore(string MyNumber, int Ln)
        {
            string Result;
            if (Ln >= 9)
            {
                if (ConvertDoubleDigit(MyNumber.Remove(2, 7)) == "")
                    Result = "";
                else
                    Result = ConvertDoubleDigit(MyNumber.Remove(2, 7)) + " Crore ";
                Result = Result + ConvertLakh(MyNumber.Remove(0, 2), 9);
            }
            else
            {
                if (ConvertSingleDigit(MyNumber.Remove(1, 7)) == "")
                    Result = "";
                else
                    Result = ConvertSingleDigit(MyNumber.Remove(1, 7)) + " Crore ";
                Result = Result + ConvertLakh(MyNumber.Remove(0, 1), 8);
            }
            return Result;
        }
        /////////////////////////////////////////// Convert Double Digit into Word ////////////////////////////////////////////////////
        private string ConvertDoubleDigit(string MyNumber)
        {
            string Result;
            if (MyNumber.Remove(1, 1) == "0")
                Result = ConvertSingleDigit(MyNumber.Remove(0, 1));
            else
            {
                if (MyNumber.Remove(1, 1) == "1") // Is Decimal part between 11 & 19
                {
                    switch (Convert.ToInt16(MyNumber))
                    {
                        case 10: Result = "Ten"; break;
                        case 11: Result = "Eleven"; break;
                        case 12: Result = "Twelve"; break;
                        case 13: Result = "Thirteen"; break;
                        case 14: Result = "Fourteen"; break;
                        case 15: Result = "Fifteen"; break;
                        case 16: Result = "Sixteen"; break;
                        case 17: Result = "Seventeen"; break;
                        case 18: Result = "Eighteen"; break;
                        default: Result = "Nineteen"; break;
                    }
                }
                else //otherwise its between 20 & 99
                {
                    switch (Convert.ToInt16(MyNumber.Remove(1, 1)))
                    {
                        case 2: Result = " Twenty "; break;
                        case 3: Result = " Thirty "; break;
                        case 4: Result = " Fourty "; break;
                        case 5: Result = " Fifty "; break;
                        case 6: Result = " Sixty "; break;
                        case 7: Result = " Seventy "; break;
                        case 8: Result = " Eighty "; break;
                        case 9: Result = " Ninety "; break;
                        default: Result = " "; break;
                    }
                    Result = Result + ConvertSingleDigit(MyNumber.Remove(0, 1)); //Convert one's place digit
                }
            }
            return Result;
        }
        /////////////////////////////////////// Convert Single Digit into Word /////////////////////////////////////////////////////
        private string ConvertSingleDigit(String MyNumber)
        {
            string Result;
            switch (Convert.ToInt16(MyNumber))
            {
                case 1: Result = "One"; break;
                case 2: Result = "Two"; break;
                case 3: Result = "Three"; break;
                case 4: Result = "Four"; break;
                case 5: Result = "Five"; break;
                case 6: Result = "Six"; break;
                case 7: Result = "Seven"; break;
                case 8: Result = "Eight"; break;
                case 9: Result = "Nine"; break;
                default: Result = ""; break;
            }
            return Result;
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