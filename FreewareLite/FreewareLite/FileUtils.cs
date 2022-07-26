using System;
using System.IO;
using System.Security.Cryptography;

namespace FreewareLite
{
	class FileUtils
	{
		public static string GetUserDirectoryPath()
		{
			string text = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
			if (Environment.OSVersion.Version.Major >= 6)
			{
				text = Directory.GetParent(text).ToString();
			}
			return text;
		}

		public static string GetDrivePath()
		{
			string text = Path.GetPathRoot(Environment.SystemDirectory);
			return text;
		}

		public static string GetDownloadTempPath()
		{
			string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.sonoyuncu\\bootstrap\\temp\\";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text;
		}

		public static string GetAppPath()
		{
			string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.sonoyuncu\\";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text;
		}

		public static string GetLauncherPath()
		{
			string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.sonoyuncu\\launcher.jar";
			return text;
		}

		public static string GetExtractPath()
		{
			string text = FileUtils.GetAppPath() + "libraries\\extract";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text;
		}

		public static class Cryptography
		{
			public static string GetSHA1(string filePath)
			{
				string result = "";
				try
                {
					using (FileStream fileStream = File.OpenRead(filePath))
					{
						using (SHA1Managed sha1Managed = new SHA1Managed())
						{
							result = BitConverter.ToString(sha1Managed.ComputeHash(fileStream)).Replace("-", string.Empty);
						}
					}
				}
				catch
                {
					return "F7AB9BFC1CC59E1BAA357CBDBB965388964CEDA0";
                }
				
				return result;
			}
		}
	}
}
