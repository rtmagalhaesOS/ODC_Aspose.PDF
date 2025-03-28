using Aspose.Pdf;
using OutSystems.ExternalLibraries.SDK;

namespace AsposePDF;

[OSInterface(Name = "AsposePDF", Description = "This interface defines methods to generate, modify, and manipulate PDF documents, with an emphasis on creating PDF/A standard compliant documents, merging PDFs, and embedding XML data.", IconResourceName = "AsposePDF.resources.icon.png")]
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
    byte[] SetPdfFormat(
    [OSParameter(Description = "The license data for Aspose, used to authorize the conversion.")] byte[] asposeLicenseData,
    [OSParameter(Description = "The PDF file contents as byte array to be converted into PDF/A format.")] byte[] pdfFile,
    [OSParameter(Description = "The format to which the PDF file should be converted. Must match https://reference.aspose.com/pdf/net/aspose.pdf/pdfformat/")] string format);

    /// <summary>
    /// Appends one PDF to another.
    /// </summary>
    /// <param name="asposeLicenseData">The byte array containing the Aspose.Pdf license data.</param>
    /// <param name="pdfFile">The byte array containing the original PDF document.</param>
    /// <param name="mergePdfFile">The byte array containing the PDF file to merge with the original PDF.</param>
    /// <returns>A byte array representing the merged PDF document.</returns>
    [OSAction(Description = "The AppendingPDFs method appends one PDF to another based on the provided input.")]
    byte[] AppendingPDFs(
    [OSParameter(Description = "The license data for Aspose, used to authorize the appending process.")] byte[] asposeLicenseData,
    [OSParameter(Description = "The PDF file contents as byte array to which the second PDF will be appended.")] byte[] pdfFile,
    [OSParameter(Description = "The PDF file contents as byte array to be appended to the first PDF.")] byte[] mergePdfFile);


    /// <summary>
    /// Appends several PDF files to a single PDF document.
    /// </summary>
    /// <param name="asposeLicenseData">The byte array containing the Aspose.Pdf license data.</param>
    /// <param name="pdfFile">The byte array containing the original PDF document.</param>
    /// <param name="attachmentFiles">A list of file paths or byte arrays for additional PDFs to be appended.</param>
    /// <param name="pageCount">The total number of pages in the final merged PDF.</param>
    /// <returns>A byte array representing the merged PDF document.</returns>
    [OSAction(Description = "The AppendingSeveralPDFs method appends multiple PDFs to a single PDF document.")]
    byte[] AppendingSeveralPDFs(
    [OSParameter(Description = "The license data for Aspose, used to authorize the appending process.")] byte[] asposeLicenseData,
    [OSParameter(Description = "The PDF file contents as byte array to which the other PDFs will be appended.")] byte[] pdfFile,
    [OSParameter(Description = "A list of file paths or byte arrays of PDFs to be appended to the first PDF.")] List<string> attachmentFiles,
    [OSParameter(Description = "The total number of pages in the resulting PDF document after appending.")] out int pageCount);

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
    byte[] EmbeddedXMLinPDF(
        [OSParameter(Description = "The license data for Aspose, used to authorize the embedding process.")] byte[] asposeLicenseData,
        [OSParameter(Description = "The PDF file contents as byte array to which the XML will be embedded.")] byte[] filePdf,
        [OSParameter(Description = "The name of the output PDF file with the embedded XML.")] string fileName,
        [OSParameter(Description = "The XML data to be embedded into the PDF as an attachment.")] byte[] attachmentXML,
        [OSParameter(Description = "The filename for the embedded XML attachment.")] string attachmentXMLFilename,        
        [OSParameter(Description = "A description for the XML attachment.")] string description,
        [OSParameter(Description = "The total number of pages in the resulting PDF document.")] out int pageCount);

    /// <summary>
    /// Embeds a ZUGFeRD XML file as an attachment in a PDF document.
    /// </summary>
    /// <param name="asposeLicenseData">The byte array containing the Aspose.Pdf license data.</param>
    /// <param name="filePdf">The byte array containing the original PDF document.</param>
    /// <param name="fileName">The name of the output PDF file with the embedded ZUGFeRD XML.</param>
    /// <param name="attachmentXML">The byte array containing the ZUGFeRD XML data to be embedded.</param>
    /// <param name="attachmentXMLFilename">The filename for the embedded ZUGFeRD XML attachment.</param>
    /// <param name="pageCount">The total number of pages in the final PDF document after embedding the XML.</param>
    /// <returns>A byte array representing the PDF document with the embedded ZUGFeRD XML.</returns>
    [OSAction(Description = "The EmbeddedZUGFeRDinPDF method embeds a ZUGFeRD XML file as an attachment in a PDF document an converts to ZUGFeRD format.")]
    public byte[] EmbeddedZUGFeRDinPDF(
        [OSParameter(Description = "The license data for Aspose, used to authorize the embedding process.")] byte[] asposeLicenseData,
        [OSParameter(Description = "The PDF file contents as byte array to which the ZUGFeRD XML will be embedded.")] byte[] filePdf,
        [OSParameter(Description = "The name of the output PDF file with the embedded ZUGFeRD XML.")] string fileName,
        [OSParameter(Description = "The ZUGFeRD XML data to be embedded into the PDF as an attachment.")] byte[] attachmentXML,
        [OSParameter(Description = "The filename for the embedded ZUGFeRD XML attachment.")] string attachmentXMLFilename,
        [OSParameter(Description = "The total number of pages in the resulting PDF document.")] out int pageCount);

}
