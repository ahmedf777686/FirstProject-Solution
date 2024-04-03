using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace FirstProject_Mvc.Pl.Helpersprofile
{
	public static class DocumentSettins
	{


		public static string UploadFile(IFormFile file, string FolderName)
		{


			// -1 get located Folder path

		    //string folderpath = "C:\\Users\\infinity\\Desktop\\DemoSession05\\DemoSession04\\FirstProject Solution\\FirstProject Solution\\FirstProject Mvc.Pl\\wwwroot\\Files\\Images\\";

			string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);


			// -2 Get file Name  And make it unique

			string FileName = $"{Guid.NewGuid()}{file.FileName}";

			// -3 Get file path [FolderPath + FileName ]

			string FilePath = Path.Combine(FolderPath, FileName);

			// 4- Save File Streams 
			using var Fs = new FileStream(FilePath, FileMode.Create);

			file.CopyTo(Fs);

			// 5- Return File Name
			return FileName;
		}



		public static void DeleteFile(string FileName, string FolderName )
		{
			string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName , FileName);

			if(File.Exists(FilePath))

			File.Delete(FilePath);

		}
	}
}
