using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_CERTSAMPLE
{
    public static class FileType
    {
        public const string PDF = "application/pdf";
    }
    class CustomFontResolver : IFontResolver
    {
        public byte[] GetFont(string faceName)
        {
            string fontPath = $"./Fonts/{faceName}/{faceName}.TTF"; // Adjust the path as needed

            if (File.Exists(fontPath))
            {
                return File.ReadAllBytes(fontPath);
            }
            else
            {
                throw new InvalidOperationException($"Font file not found: {fontPath}");
            }
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            return new FontResolverInfo(familyName, isBold, isItalic);
        }
    }
    public interface IPdfGenerator
    {
        byte[] GenerateCertificate(string name, string course, DateTime receivedDate);
    }
    public class PdfGenerator : IPdfGenerator
    {
        public byte[] GenerateCertificate(string name, string course, DateTime receivedDate)
        {
            try
            {
                // Set the custom font resolver
                GlobalFontSettings.FontResolver = new CustomFontResolver();

                using (var stream = new MemoryStream())
                {
                    // Open the source PDF document
                    using (var sourcePdfDocument = PdfReader.Open("./DiplomaCertificate.pdf", PdfDocumentOpenMode.Import))
                    {
                        // Create a new PDF document
                        using (var destinationPdfDocument = new PdfDocument())
                        {
                            // Iterate through pages in the source document
                            for (int pageIndex = 0; pageIndex < sourcePdfDocument.PageCount; pageIndex++)
                            {
                                // Add the page directly from the source document to the destination document
                                var newPage = destinationPdfDocument.AddPage(sourcePdfDocument.Pages[pageIndex]);

                                // Draw receiver name
                                using (var gfx = XGraphics.FromPdfPage(newPage))
                                {
                                    var font = new XFont("TIMES", 48);
                                    var brush = new XSolidBrush(XColor.FromArgb(191, 146, 55));
                                    var center_X = (newPage.Width.Point - gfx.MeasureString(name, font).Width) / 2;
                                    gfx.DrawString(name, font, brush, new XRect(center_X, 220, newPage.Width.Point, newPage.Height.Point), XStringFormats.TopLeft);
                                }

                                // Draw course name
                                using (var gfx = XGraphics.FromPdfPage(newPage))
                                {
                                    var font = new XFont("TIMES", 36, XFontStyleEx.Bold);
                                    var brush = new XSolidBrush(XColor.FromArgb(191, 146, 55));
                                    var center_X = (newPage.Width.Point - gfx.MeasureString(course, font).Width) / 2;
                                    gfx.DrawString(course, font, brush, new XRect(center_X, 330, newPage.Width.Point, newPage.Height.Point), XStringFormats.TopLeft);
                                }

                                // Draw received date
                                using (var gfx = XGraphics.FromPdfPage(newPage))
                                {
                                    var font = new XFont("CALIBRI", 16);
                                    var brush = new XSolidBrush(XColor.FromArgb(89, 89, 89));
                                    var formattedReceivedDate = receivedDate.ToString("dd-MMM-yyyy");
                                    var center_X = (newPage.Width.Point - gfx.MeasureString(formattedReceivedDate, font).Width) / 2;
                                    gfx.DrawString(formattedReceivedDate, font, brush, new XRect(center_X, 380, newPage.Width.Point, newPage.Height.Point), XStringFormats.TopLeft);
                                }
                            }

                            // Save the new PDF document to the memory stream
                            destinationPdfDocument.Save(stream);
                        }
                    }

                    // Return the byte array of the modified PDF
                    return stream.ToArray();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
