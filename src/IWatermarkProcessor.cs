using System.Runtime.InteropServices;

namespace MyPdfWatermark
{
    [ComVisible(true)]
    [Guid("F27B05C4-91F1-4086-B9D2-60B4C01EFA9C")]
    public interface IWatermarkProcessor
    {
        string AddWatermark(string inputPdf, string outputPdf, string watermarkText);
    }
}
