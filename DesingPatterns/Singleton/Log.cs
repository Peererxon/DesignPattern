using System;
namespace DesingPatterns.Singleton
{
	public class Log
	{

		private readonly static Log _instance = new Log();
		private string path = "log.txt";
		public static Log Instance
		{
			get
			{
				return _instance;
			}
		}

		private Log()
		{
		}

		public void Save(string message)
		{
			File.AppendAllText(path, message + Environment.NewLine);
		}
	}
}

