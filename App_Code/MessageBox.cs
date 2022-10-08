using System;
using System.Web.UI;
using System.Web;
using System.Text;
using System.Collections;
using System.Security.Cryptography;
//using System.ComponentModel;
using System.IO;


namespace RMG
{
	/// <summary>
	/// Summary description for MessageBox.
	/// </summary>
	public class Functions
	{
		private static Hashtable m_executingPages = new Hashtable();

		private Functions(){}

		public static void MsgBox( string sMessage)
		{

			// If this is the first time a page has called this method then
			if( !m_executingPages.Contains( HttpContext.Current.Handler ) )
			{
				// Attempt to cast HttpHandler as a Page.
				Page executingPage = HttpContext.Current.Handler as Page;

				if( executingPage != null )
				{
					// Create a Queue to hold one or more messages.
					Queue messageQueue = new Queue();

					// Add our message to the Queue
					messageQueue.Enqueue( sMessage );
            
					// Add our message queue to the hash table. Use our page reference
					// (IHttpHandler) as the key.
					m_executingPages.Add( HttpContext.Current.Handler, messageQueue );

					// Wire up Unload event so that we can inject some JavaScript for the alerts.
					executingPage.Unload += new EventHandler(ExecutingPage_Unload );
				}   
			}
			else
			{
				// If were here then the method has allready been called from the executing Page.
				// We have allready created a message queue and stored a reference to it in our hastable. 
				Queue queue = (Queue) m_executingPages[HttpContext.Current.Handler];
            
				// Add our message to the Queue
				queue.Enqueue( sMessage );
			}
		}


		// Our page has finished rendering so lets output the JavaScript to produce the alert's
		private static void ExecutingPage_Unload(object sender, EventArgs e)
		{
			// Get our message queue from the hashtable
			Queue queue = (Queue) m_executingPages[ HttpContext.Current.Handler ];
            
			if( queue != null )
			{
				StringBuilder sb = new StringBuilder();

				// How many messages have been registered?
				int iMsgCount = queue.Count;

				// Use StringBuilder to build up our client slide JavaScript.
				sb.Append( "<script language='javascript'>" );

				// Loop round registered messages
				string sMsg;
				while( iMsgCount-- > 0 )
				{
					sMsg = (string) queue.Dequeue();
					sMsg = sMsg.Replace( "\n", "\\n" );
					sMsg = sMsg.Replace( "\"", "'" );
					sb.Append( @"alert( """ + sMsg + @""" );" );
				}

				// Close our JS
				sb.Append( @"</script>" );

				// Were done, so remove our page reference from the hashtable
				m_executingPages.Remove( HttpContext.Current.Handler );

				// Write the JavaScript to the end of the response stream.
				HttpContext.Current.Response.Write( sb.ToString() );
			}
		}

		public static DateTime ConvertDateFormat(string str)
		{
			int dd,mm,yy;
			string [] strarr = new string[3];			
			strarr=str.Split(new char[]{'/'},str.Length);
			dd=Int32.Parse(strarr[0]);
			mm=Int32.Parse(strarr[1]);
			yy=Int32.Parse(strarr[2]);
			DateTime dt=new DateTime(yy,mm,dd);			
			return(dt);
		}
		public static string GetDatabase(string str)
		{
			string [] strarr = new string[6];			
			strarr=str.Split(new char[]{';'},str.Length);
			return strarr[1];
		}
		public static string Encrypt(string pswd)
		{
			RC2CryptoServiceProvider rc2CSP = new RC2CryptoServiceProvider();
			byte[]key=System.Text.ASCIIEncoding.ASCII.GetBytes(pswd);
			byte[]IV=System.Text.ASCIIEncoding.ASCII.GetBytes(pswd);
			MemoryStream msEncrypt = new MemoryStream();
			//CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(desKey, desIV), CryptoStreamMode.Write);
			CryptoStream csEncrypt = new CryptoStream(msEncrypt, rc2CSP.CreateEncryptor(key,IV), CryptoStreamMode.Write);			
			csEncrypt.Write(key,0,key.Length);
			csEncrypt.FlushFinalBlock();
			return System.Text.ASCIIEncoding.ASCII.GetString(msEncrypt.ToArray());
			//txtres.Text=System.Text.ASCIIEncoding.ASCII.GetString(msEncrypt.ToArray());
		}
		public static string Decrypt(byte[] arr)
		{
			RC2CryptoServiceProvider rc2CSP=new RC2CryptoServiceProvider();
			//byte[] arr=System.Text.ASCIIEncoding.ASCII.GetBytes(obj.ToString());
			//byte[]msg=arr;
			byte[]key=System.Text.ASCIIEncoding.ASCII.GetBytes("shashank");
			byte[]IV=System.Text.ASCIIEncoding.ASCII.GetBytes("shashank");
			MemoryStream msDecrypt=new MemoryStream(arr);
			CryptoStream csDecrypt=new CryptoStream(msDecrypt,rc2CSP.CreateDecryptor(key,IV),CryptoStreamMode.Read);
			byte[]encr=new byte[arr.Length];			
			csDecrypt.Read(encr,0,encr.Length);
			return System.Text.ASCIIEncoding.ASCII.GetString(encr,0,encr.Length);			
		}

		public static string GetCourseName(string CourseID)
		{
			if(CourseID=="01")
				return "B.E./ B. Tech Course";
			else if(CourseID=="02")
				return "B. Architecture Course";
			else if(CourseID=="03")
				return "B. Pharma Course";
			else if(CourseID=="04")
				return "BHM & Ct Course";
			else if(CourseID=="05")
				return "MCA Course";
			else if(CourseID=="06")
				return "MBA Course";
			else if(CourseID=="07")
				return "Diploma Course DET(Engg)";
			else if(CourseID=="08")
				return "Diploma Course DET(Pharma)";
			else if(CourseID=="09")
				return "Diploma Course DET(Mngt)";
			else if(CourseID=="10")
				return "LEET(Eng) Course";
			else if(CourseID=="11")
				return "LEET(Pharma) Course";
			else
				return "";
		}
		public static string GetConnectionString(string CourseID)
		{
			if(CourseID=="00")
				return "ConStr";
			else if(CourseID=="01")
				return "ConEng";
			else if(CourseID=="02")
				return "ConArch";
			else if(CourseID=="03")
				return "ConPharma";
			else if(CourseID=="04")
				return "ConBhm";
			else if(CourseID=="05")
				return "ConMCA";
			else if(CourseID=="06")
				return "ConMBA";
			else if(CourseID=="07")
				return "ConDetEng";
			else if(CourseID=="08")
				return "ConDetPharma";
			else if(CourseID=="09")
				return "ConDetMngt";
			else if(CourseID=="10")
				return "ConLeetEng";
			else if(CourseID=="11")
				return "ConLeetPharma";
			else
				return "";
		}
	}
}
