using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AIYunNet.CMS.Common.Utility
{
	public class TextLogger
	{
		private static string _logPath = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "Logs\\Log\\");
		private static string _errorPath = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "Logs\\Error\\");
		private static string _warningPath = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "Logs\\Warning\\");
		private static string _hubPath = Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, "Logs\\Hub\\");
		private System.Timers.Timer _clearLogTimer = null;
		private static TextLogger _instance = null;
		private static bool _debug = false;

		public static TextLogger Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new TextLogger();
				}
				return _instance;
			}
		}

		public TextLogger()
		{
			if (!Directory.Exists(_logPath))
			{
				Directory.CreateDirectory(_logPath);
			}
			if (!Directory.Exists(_errorPath))
			{
				Directory.CreateDirectory(_errorPath);
			}
			if (!Directory.Exists(_warningPath))
			{
				Directory.CreateDirectory(_warningPath);
			}
			if (!Directory.Exists(_hubPath))
			{
				Directory.CreateDirectory(_hubPath);
			}
			if (_clearLogTimer == null)
			{
				_clearLogTimer = new System.Timers.Timer();
				_clearLogTimer.Interval = 60 * 1000 * 60 * 24;
				_clearLogTimer.Elapsed += clearLogTimer_Elapsed;
				_clearLogTimer.Start();
			}
			bool.TryParse(ConfigurationManager.AppSettings["Debug"], out _debug);
		}

		void clearLogTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			try
			{
				ClearLog(_logPath);
				ClearLog(_errorPath);
				ClearLog(_warningPath);
				ClearLog(_hubPath);
			}
			catch (Exception ex)
			{
				WriteError(ex.ToString());
			}
		}

		private void ClearLog(string logFolder)
		{
			string[] files = Directory.GetFiles(logFolder, "*.log");
			foreach (string file in files)
			{
				string fileName = Path.GetFileNameWithoutExtension(file);
				DateTime fileDate = DateTime.MinValue;
				if (DateTime.TryParse(fileName, out fileDate))
				{
					if (fileDate.AddDays(10) < DateTime.Today)
					{
						File.Delete(file);
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void WriteLog(string message, bool debug = false)
		{
			if ((debug && _debug) || !debug)
			{
				try
				{
					using (StreamWriter sw = new StreamWriter(_logPath + DateTime.Today.ToString("yyyy-MM-dd") + ".log", true))
					{
						sw.WriteLine(DateTime.Now.ToString("HH:mm:ss.fffff") + "\t" + message);
					}
				}
				catch
				{
				}
			}
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void WriteHub(string message)
		{
			try
			{
				using (StreamWriter sw = new StreamWriter(_hubPath + DateTime.Today.ToString("yyyy-MM-dd") + ".log", true))
				{
					sw.WriteLine(DateTime.Now.ToString("HH:mm:ss.fffff") + "\t" + message);
				}
			}
			catch
			{
			}
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void WriteError(string message)
		{
			try
			{
				using (StreamWriter sw = new StreamWriter(_errorPath + DateTime.Today.ToString("yyyy-MM-dd") + ".log", true))
				{
					sw.WriteLine(DateTime.Now.ToString("HH:mm:ss.fffff") + "\t" + message);
				}
			}
			catch
			{
			}
		}

		[MethodImpl(MethodImplOptions.Synchronized)]
		public void WriteWarning(string message)
		{
			try
			{
				using (StreamWriter sw = new StreamWriter(_warningPath + DateTime.Today.ToString("yyyy-MM-dd") + ".log", true))
				{
					sw.WriteLine(DateTime.Now.ToString("HH:mm:ss.fffff") + "\t" + message);
				}
			}
			catch
			{
			}
		}
	}
}
