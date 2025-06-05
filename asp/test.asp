<%
Set obj = Server.CreateObject("MyPdfWatermark.WatermarkProcessor")
inputPath = Server.MapPath("input.pdf")
outputPath = Server.MapPath("output.pdf")
result = obj.AddWatermark(inputPath, outputPath, "테스트")

'If result = "Y" Then
    'Response.Write ""
'ElseIf result = "N" Then
    'Response.Write "실패: 워터마크 없음"
'Else
    'Response.Write "오류 발생"
'End If

Set obj = Nothing

response.write  result
%>
