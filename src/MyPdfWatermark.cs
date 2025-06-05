using System;
using System.Runtime.InteropServices;
using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.IO.Font;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;
using System.IO;

namespace MyPdfWatermark
{
    [ComVisible(true)]
    [Guid("D2F7A392-B0A5-4E6C-9426-0B27BDEEFB22")]
    [ClassInterface(ClassInterfaceType.None)]
    public class WatermarkProcessor : IWatermarkProcessor
    {      

        public string AddWatermark(string inputPdf, string outputPdf, string watermarkText)
        {

            string _result = "N";

            try
            {

                if (string.IsNullOrEmpty(inputPdf) || string.IsNullOrEmpty(outputPdf))
                {
                    //원본파일 또는 대상파일 존재하지않음
                }

                else
                {

                    PdfReader reader = new PdfReader(inputPdf);
                    PdfWriter writer = new PdfWriter(outputPdf);
                    PdfDocument pdfDoc = new PdfDocument(reader, writer);

                    PdfFont font = PdfFontFactory.CreateFont("C:/Windows/Fonts/UnDotum.ttf", PdfEncodings.IDENTITY_H, true);

                    for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                    {
                        var page = pdfDoc.GetPage(i);
                        Rectangle pageSize = page.GetPageSize();

                        // 워터마크를 페이지 마지막 레이어에 추가
                        PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamAfter(), page.GetResources(), pdfDoc);

                        // 투명도 설정 (불투명도 20%)
                        PdfExtGState gs1 = new PdfExtGState().SetFillOpacity(0.2f);
                        pdfCanvas.SaveState();
                        pdfCanvas.SetExtGState(gs1);

                        // 텍스트 설정
                        pdfCanvas.BeginText();
                        pdfCanvas.SetFontAndSize(font, 48);
                        pdfCanvas.SetColor(new DeviceRgb(120, 120, 120), true);

                        // 가운데 위치 계산
                        float textWidth = font.GetWidth(watermarkText, 48);
                        float x = (pageSize.GetWidth() - textWidth) / 2;
                        float y = pageSize.GetHeight() / 2;

                        // 텍스트 출력
                        pdfCanvas.MoveText(x, y);
                        pdfCanvas.ShowText(watermarkText);
                        pdfCanvas.EndText();

                        pdfCanvas.RestoreState();
                    }

                    pdfDoc.Close();

                    _result = "Y";

                }
            }
            catch (Exception ex)
            {
                //예외처리
            }            
           
            return _result;
        }
    }

}
