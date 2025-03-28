using Aspose.Pdf;
using OutSystems.ExternalLibraries.SDK;

namespace AsposePDF;

[OSInterface(Name = "ODC_AsposePDF", Description = "This interface defines methods to generate, modify, and manipulate PDF documents, with an emphasis on creating PDF/A standard compliant documents, merging PDFs, and embedding XML data.", IconResourceName = "AsposePdf.resources.pdf-file.png")]
public interface IAsposePDF
{
    /// <summary>
    /// Generates a PDF/A standard compliant document from a given format.
    /// </summary>
    /// <param name="asposeLicenseData">The byte array containing the Aspose.Pdf license data.</param>
    /// <param name="pdfFile">The byte array containing the original PDF.</param>
    /// <param name="format">The desired PDF format (e.g., PDF_A_1A).</param>
    /// <returns>A byte array representing the generated PDF document.</returns>
    [OSAction(Description = "The SetPdfFormat method generates a PDF/A standard compliant document from a given format.")]
    byte[] SetPdfFormat(byte[] asposeLicenseData, byte[] pdfFile, string format);

    /// <summary>
    /// Appends one PDF to another.
    /// </summary>
    /// <param name="asposeLicenseData">The byte array containing the Aspose.Pdf license data.</param>
    /// <param name="pdfFile">The byte array containing the original PDF document.</param>
    /// <param name="mergePdfFile">The byte array containing the PDF file to merge with the original PDF.</param>
    /// <returns>A byte array representing the merged PDF document.</returns>
    [OSAction(Description = "The AppendingPDFs method appends one PDF document to another.")]
    byte[] AppendingPDFs(byte[] asposeLicenseData, byte[] pdfFile, byte[] mergePdfFile);

    /// <summary>
    /// Appends several PDF files to a single PDF document.
    /// </summary>
    /// <param name="asposeLicenseData">The byte array containing the Aspose.Pdf license data.</param>
    /// <param name="pdfFile">The byte array containing the original PDF document.</param>
    /// <param name="attachmentFiles">A list of file paths or byte arrays for additional PDFs to be appended.</param>
    /// <param name="pageCount">The total number of pages in the final merged PDF.</param>
    /// <returns>A byte array representing the merged PDF document.</returns>
    [OSAction(Description = "The AppendingSeveralPDFs method appends multiple PDFs to a single PDF document.")]
    byte[] AppendingSeveralPDFs(byte[] asposeLicenseData, byte[] pdfFile, List<string> attachmentFiles, out int pageCount);

    /// <summary>
    /// Embeds an XML file as an attachment in a PDF document.
    /// </summary>
    /// <param name="asposeLicenseData">The byte array containing the Aspose.Pdf license data.</param>
    /// <param name="filePdf">The byte array containing the original PDF document.</param>
    /// <param name="attachmentXML">The byte array containing the XML data to be embedded.</param>
    /// <param name="attachmentXMLFilename">The filename for the embedded XML attachment.</param>
    /// <param name="fileName">The name of the output PDF file.</param>
    /// <param name="description">Description for the attachment.</param>
    /// <param name="pageCount">The total number of pages in the final PDF.</param>
    /// <returns>A byte array representing the PDF document with the embedded XML.</returns>
    [OSAction(Description = "The EmbeddedXMLinPDF method embeds an XML file as an attachment in a PDF document.")]
    byte[] EmbeddedXMLinPDF(byte[] asposeLicenseData, byte[] filePdf, byte[] attachmentXML, string attachmentXMLFilename, string fileName, string description, out int pageCount);

}
