using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace PostingInstructionsApp.Domain
{
    public class WordDoc
    {
        public void CreateSampleDocument()
        {
            // Modify to suit your machine:
            string fileName = @"C:\Users\johng\Desktop\New Posting Instructions doc.docx";

            // Create a document in memory:
            var doc = DocX.Create(fileName);

            // Insert a paragrpah:
            doc.InsertParagraph("This is my first paragraph");

            // Save to the output directory:
            doc.Save();

            // Open in Word:
            Process.Start("WINWORD.EXE", fileName);
        }
    }
}
