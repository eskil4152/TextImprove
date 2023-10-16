using System;
using System.IO;
using Xceed.Words.NET;

namespace TextImprove.Tools
{
	public class ExtractText
    {
        public static string ExtractDocx(string path)
		{
            using DocX doc = DocX.Load(path);
            return doc.Text;
        }
	}
}

