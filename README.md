# Simple Generate report

- [ASP.NET MVC](https://www.asp.net/mvc)

**Require Developer Tool**

- [WKhtmltopdf](https://wkhtmltopdf.org/)

- [Codaxy.WkHtmlToPdf](https://github.com/codaxy/wkhtmltopdf)

- [Pechkin](https://github.com/gmanny/Pechkin)

*Please make sure it is installed.* 

## Using Codaxy.WkHtmlToPdf
```
        public void PDFConvertHelper()
        {
            PdfConvert.ConvertHtmlToPdf(new PdfDocument
            {
                Url = " http://localhost:25401/Home/SummaryApproveReport",
                HeaderLeft = "[title]",
                HeaderRight = "[date] [time]",
                FooterCenter = "Page [page] of [topage]"
            }, new PdfOutput
            {
                OutputFilePath = "C:\\Users\\aemitez\\Desktop\\1.pdf"
            });
        }
```       
## Using Pechkin WkHtmlToPdf
```
        //// Generate simple PDF from a HTML string
        public byte[] PDFFormTitle()
        {
            byte[] pdfContent = new SimplePechkin(new GlobalConfig()).Convert("<html><body><h1>Hello world!</h1></body></html>");

            return pdfContent;
        }

        ////  Generate PDF from a Website
        public byte[] PDFFormWeb(string url)
        {
            // create global configuration object
            GlobalConfig gc = new GlobalConfig();

            // set it up using fluent notation
            // Remember to import the following type:
            //     using System.Drawing.Printing;
            //
            // a new instance of Margins with 1-inch margins.
            gc.SetMargins(new Margins(30, 30, 50, 50))
                .SetDocumentTitle("Test document")
                .SetPaperSize(PaperKind.Letter)
            // Set to landscape
            //.SetPaperOrientation(true)
            ;

            // Create converter
            IPechkin pechkin = new SynchronizedPechkin(gc);

            // Create document configuration object
            ObjectConfig configuration = new ObjectConfig();

            // and set it up using fluent notation too
            configuration.SetCreateExternalLinks(false)
                .SetFallbackEncoding(Encoding.ASCII)
                .SetLoadImages(true)
             .SetPageUri(url);
            // Generate the PDF with the given configuration
            // The Convert method will return a Byte Array with the content of the PDF
            // You will need to use another method to save the PDF (mentioned on step #3)
            byte[] pdfContent = pechkin.Convert(configuration);

            return pdfContent;
        }

        //// Generate PDF from a local HTML file
        public void PDFFormLocalFile()
        {
            // create global configuration object
            GlobalConfig gc = new GlobalConfig();

            // set it up using fluent notation
            // Remember to import the following type:
            //     using System.Drawing.Printing;
            //
            // a new instance of Margins with 1-inch margins.
            gc.SetMargins(new Margins(100, 100, 100, 100))
                .SetDocumentTitle("Test document")
                .SetPaperSize(PaperKind.Letter);

            // Create converter
            IPechkin pechkin = new SynchronizedPechkin(gc);

            // Create document configuration object
            ObjectConfig configuration = new ObjectConfig();

            string HTML_FILEPATH = "C:/Users/sdkca/Desktop/example.html";

            // and set it up using fluent notation too
            configuration
            .SetAllowLocalContent(true)
            .SetPageUri(@"file:///" + HTML_FILEPATH);

            // Generate the PDF with the given configuration
            // The Convert method will return a Byte Array with the content of the PDF
            // You will need to use another method to save the PDF (mentioned on step #3)
            byte[] pdfContent = pechkin.Convert(configuration);
        }

        //// Save File
        public bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {
                // Open file for reading
                FileStream _FileStream = new FileStream(_FileName, FileMode.Create, FileAccess.Write);
                // Writes a block of bytes to this stream using data from  a byte array.
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);

                // Close file stream
                _FileStream.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                Console.WriteLine("Exception caught in process while trying to save : {0}", _Exception.ToString());
            }

            return false;
        }
```
