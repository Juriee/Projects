using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using System.Drawing;


namespace OCR_test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var image = new Bitmap (@"C:\\Users\\E566281\\Documents\\2007_AEB_E-pdf-1.pdf");
            var ocr = new Tesseract.TesseractEngine("C:\\Users\\E566281\\Documents\\2007_AEB_E-pdf-1.pdf", "eng");
            var result = ocr.Process(image, null);
            foreach (var s in result.GetHOCRText(1,false))
            {
                Console.WriteLine(s);
            }
            //var result = ocr          ( image, Rectangle.Empty);
            //foreach (tessnet2.Word word in result)
            //{
            //    Console.writeline(word.text);
            //}
        }
    }
}
