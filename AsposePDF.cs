using Aspose.Pdf;

namespace AsposePDF;
public class AsposePDF : IAsposePDF
{
    public byte[] SetPdfFormat(byte[] asposeLicenseData, byte[] pdfFile, string format)
    {
        try
        {
            // set Aspose License key
            SetAsposeLicenseFromStream(asposeLicenseData);

            // Initialize document object
            using MemoryStream inputStream = new(pdfFile);
            using Document finalDocument = new(inputStream);
            using MemoryStream logStream = new();

            if (!Enum.TryParse(format, out PdfFormat pdfFormat))
            {
                throw new Exception($"Format not recognized: {format}");
            }           

            finalDocument.Convert(logStream, pdfFormat, ConvertErrorAction.Delete);

            // Return pdf content        
            using MemoryStream finalOutStream = new();
            finalDocument.Save(finalOutStream);
            return finalOutStream.ToArray();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message + " StackTrace: " + e.StackTrace + " : " + e.InnerException + " : " + e.Source + " : " + e.Data);
        }
    }

    public byte[] AppendingSeveralPDFs(byte[] asposeLicenseData, byte[] pdfFile, List<string> attachmentFiles, out int pageCount)
    {
        // set Aspose License key
        SetAsposeLicenseFromStream(asposeLicenseData);

        pageCount = new int();
        // Check if attachment files need to be merged
        if (attachmentFiles != null && attachmentFiles.Count > 0)
        {
            pdfFile = MergeListAttachmentFiles(pdfFile, attachmentFiles, out pageCount);
        }
        return pdfFile;
    }

    public byte[] AppendingPDFs(byte[] asposeLicenseData, byte[] pdfFile, byte[] mergePdfFile)
    {
        // set Aspose License key
        SetAsposeLicenseFromStream(asposeLicenseData);

        try
        {
            // Initialize document object for inputOne
            using MemoryStream inputStreamOne = new(pdfFile);
            using Document documentOne = new(inputStreamOne);

            // Initialize document object for inputTwo
            using MemoryStream inputStreamTwo = new(mergePdfFile);
            using Document documentTwo = new(inputStreamTwo);

            // Merge both documents into a single one
            documentOne.Pages.Add(documentTwo.Pages);

            // Return pdf content        
            using MemoryStream outStream = new();
            documentOne.Save(outStream);
            return outStream.ToArray();
        }
        catch (Exception e)
        {
            throw new Exception($"{e.Message}{Environment.NewLine} StackTrace: {e.StackTrace}: {Environment.NewLine}{e.InnerException}: {Environment.NewLine}{e.Source}: {Environment.NewLine}{e.Data}");
        }
    }
    private static byte[] MergeListAttachmentFiles(byte[] pdfFile, List<string> attachmentFiles, out int pageCount)
    {
        try
        {
            using (var baseStream = new MemoryStream(pdfFile))
            {
                baseStream.Position = 0; // Reset position
                using (var document = new Document(baseStream))
                {
                    // Process each base64-encoded attachment file
                    foreach (var attachmentBase64 in attachmentFiles)
                    {
                        // Decode the base64 string into a byte array
                        byte[] attachmentBytes = Convert.FromBase64String(attachmentBase64);

                        using (var attachmentStream = new MemoryStream(attachmentBytes))
                        {
                            attachmentStream.Position = 0; // Reset position
                            using (var attachmentDoc = new Document(attachmentStream))
                            {
                                // Add all pages from the attachment PDF to the main PDF
                                document.Pages.Add(attachmentDoc.Pages);
                            }
                        }
                    }

                    using (var outputStream = new MemoryStream())
                    {
                        // Get the number of pages
                        pageCount = document.Pages.Count;

                        // Save the merged PDF to a byte array
                        document.Save(outputStream);
                        return outputStream.ToArray();
                    }
                }
            }
        }
        catch (Exception e)
        {
            // Log detailed error for debugging
            string errorDetails = $"Exception Message: {e.Message}{Environment.NewLine}" +
                                  $"Stack Trace: {e.StackTrace}{Environment.NewLine}" +
                                  $"Inner Exception: {e.InnerException?.Message}{Environment.NewLine}" +
                                  $"Source: {e.Source}{Environment.NewLine}" +
                                  $"Data: {string.Join(", ", e.Data.Keys.Cast<object>().Select(key => $"{key}: {e.Data[key]}"))}";

            throw new Exception(errorDetails, e);
        }
    }

    public byte[] EmbeddedXMLinPDF(byte[] asposeLicenseData, byte[] filePdf, byte[] attachmentXML, string attachmentXMLFilename, string fileName, string description, out int pageCount)
    {
        try
        {
            // Set Aspose License key
            SetAsposeLicenseFromStream(asposeLicenseData);

            // Initialize document object
            using MemoryStream inputStream = new(filePdf);
            using Document finalDocument = new(inputStream);

            // Add file name as metadata
            finalDocument.Info.Title = fileName;

            // Attach XML file
            if (attachmentXML != null && attachmentXML.Length > 0)
            {
                AttachZUGFeRD(finalDocument, attachmentXML, attachmentXMLFilename);
            }
            // Get the number of pages
            pageCount = finalDocument.Pages.Count;

            // Return pdf content        
            using MemoryStream finalOutStream = new();
            finalDocument.Save(finalOutStream);
            return finalOutStream.ToArray();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message + " StackTrace: " + e.StackTrace + " : " + e.InnerException + " : " + e.Source + " : " + e.Data);
        }
    }

    private static void AttachZUGFeRD(Document document, byte[] xmlAttachment, string attachmentXMLfilename)
    {
        if (document == null)
            throw new ArgumentNullException(nameof(document));

        if (xmlAttachment == null || xmlAttachment.Length == 0)
            throw new ArgumentException("The XML attachment cannot be null or empty.", nameof(xmlAttachment));

        // Create a MemoryStream to hold the XML attachment
        using (var xmlStream = new MemoryStream())
        {
            // Write the XML attachment to the memory stream
            xmlStream.Write(xmlAttachment, 0, xmlAttachment.Length);
            xmlStream.Position = 0; // Reset the stream position to the beginning after writing

            // Setup new file to be added as an attachment
            var description = "Description";
            var fileSpecification = new FileSpecification(xmlStream, attachmentXMLfilename)
            {
                Description = description,
                MIMEType = "text/xml"
            };

            // Add the attachment to the document's attachment collection
            document.EmbeddedFiles.Add(fileSpecification);

            // Convert document into ZUGFeRD format
            document.Convert(xmlStream, PdfFormat.ZUGFeRD, ConvertErrorAction.Delete);
        }
    }



    ///-------------------------------------Helper Functions----------------------------------------

    /// <summary>
    /// Sets the Aspose license from a byte array containing the license data.
    /// </summary>
    /// <param name="licenseData">A byte array representing the Aspose license data.</param>
    public static void SetAsposeLicenseFromStream(byte[] licenseData)
    {
        // Check if licenseData is null or empty
        if (licenseData == null || licenseData.Length == 0)
        {
            return;
        }

        // Initialize a new Aspose.Pdf License object
        License license = new License();

        // Convert the byte array into a memory stream
        using (MemoryStream licenseStream = new MemoryStream(licenseData))
        {
            // Set the license using the memory stream
            license.SetLicense(licenseStream);
        }
    }


}
