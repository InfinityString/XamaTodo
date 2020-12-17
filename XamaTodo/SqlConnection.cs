using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XamaTodo
{
   public static class SqlConnection
    {
        public static string SqlPath
        {
            get
            {
                var sqliteFilename = "MyDatabase.db3";
//#if __ANDROID__
// Just use whatever directory SpecialFolder.Personal returns
  string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); 
/*#else*/
                // we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
                // (they don't want non-user-generated data in Documents)
 //               string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
 //               string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder instead
//#endif
                var path = Path.Combine(libraryPath, sqliteFilename);
                return path;
            }
            
        }
    }
}
