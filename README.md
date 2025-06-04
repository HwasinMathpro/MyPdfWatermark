# MyPdfWatermark

이 프로젝트는 Classic ASP 환경에서 C# DLL(COM)로 PDF 파일에 한글 워터마크를 백그라운드로 삽입하는 기능을 제공합니다.

## 기능
- 기존 PDF 파일을 열어 복사본 생성
- 모든 페이지에 동적으로 한글 워터마크 삽입
- 워터마크는 흐릿하게 배경에 표시됨

## 기술 스택
- ASP (Classic)
- C# DLL (.NET Framework 4.7.2)
- iText 7.1.13 (AGPL License)

## 사용법
1. Visual Studio에서 DLL 빌드
2. `regasm`으로 COM 등록
3. ASP에서 DLL 호출

## 예제
```asp
Set obj = Server.CreateObject("MyPdfWatermark.WatermarkProcessor")
result = obj.AddWatermark("C:\input.pdf", "C:\output.pdf", "워터마크에 들어갈 TEXT")
