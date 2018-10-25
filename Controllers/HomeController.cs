using Codaxy.WkHtmlToPdf;
using Pechkin;
using Pechkin.Synchronized;
using SimpleWKReport.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace SimpleWKReport.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult SummaryApproveReport()
        {
            var mockupData = new List<SummaryApproveAmountReport>
            {
                new SummaryApproveAmountReport(){No = 1, MarketingCode = "201803001" ,MarketingName = "Jirayu Na-On",AgentCode = "A001",AgentName = "Honda LadKrabung",ApproveDate = "15/08/2018",Amount = 400000},
                new SummaryApproveAmountReport(){No = 2, MarketingCode = "201803001" ,MarketingName = "Jirayu Na-On",AgentCode = "A002",AgentName = "Honda Rama2",ApproveDate = "25/08/2019",Amount = 150000},
                new SummaryApproveAmountReport(){No = 3, MarketingCode = "201803001" ,MarketingName = "Jirayu Na-On",AgentCode = "A003",AgentName = "Honda Rama3",ApproveDate = "25/08/2020",Amount = 200000},
                new SummaryApproveAmountReport(){No = 4, MarketingCode = "201803002" ,MarketingName = "Wichuda Nakprok",AgentCode = "A004",AgentName = "Honda Bang sue",ApproveDate = "25/08/2021",Amount = 300000},
                new SummaryApproveAmountReport(){No = 5, MarketingCode = "201803002" ,MarketingName = "Wichuda Nakprok",AgentCode = "A005",AgentName = "Honda Rama9",ApproveDate = "25/08/2022",Amount = 200000},
                new SummaryApproveAmountReport(){No = 6, MarketingCode = "201803002" ,MarketingName = "Wichuda Nakprok",AgentCode = "A006",AgentName = "Honda Chatuchak",ApproveDate = "25/08/2023",Amount = 200000}
            };
            return View(mockupData);
        }

        public ActionResult SummaryResult()
        {
            var mockupData = new List<SummaryReport>
            {
                new SummaryReport(){No = 1,MarketingCode = "20180501",MarketingName = "Jirayu Na-On",AgentCode = "A001",AgentName = "Honda LadKrabung",Transaction = "Chack NCB (10) FULL REGISTER (5)",CheckNCBReqMoreDoc = 0,
                                    CheckNCBPass = 8,CheckNCBNotpass =2,FullRegisterReqMoreDoc = 2,FullRegisterPending = 1,FullRegisterCancelByCustomer = 1,
                                    FullRegisterCancelByJDM = 1,FullRegisterApprove = 1,FullRegisterReject = 0 },

                 new SummaryReport(){No = 2,MarketingCode = "20180501",MarketingName = "Jirayu Na-On",AgentCode = "A002",AgentName = "Honda Rama2",Transaction = "Chack NCB (12) FULL REGISTER (10)",CheckNCBReqMoreDoc = 0,
                                    CheckNCBPass = 1,CheckNCBNotpass =1,FullRegisterReqMoreDoc = 1,FullRegisterPending = 1,FullRegisterCancelByCustomer = 1,
                                    FullRegisterCancelByJDM = 1,FullRegisterApprove = 1,FullRegisterReject = 1 },

                  new SummaryReport(){No = 3,MarketingCode = "20180501",MarketingName = "Jirayu Na-On",AgentCode = "A003",AgentName = "Honda Rama3",Transaction = "Chack NCB (5) FULL REGISTER (5)",CheckNCBReqMoreDoc = 0,
                                    CheckNCBPass = 1,CheckNCBNotpass =1,FullRegisterReqMoreDoc = 1,FullRegisterPending = 1,FullRegisterCancelByCustomer = 1,
                                    FullRegisterCancelByJDM = 1,FullRegisterApprove = 1,FullRegisterReject = 1 },

                   new SummaryReport(){No = 4,MarketingCode = "20180504",MarketingName = "Jirayu Na-On",AgentCode = "A001",AgentName = "Honda Bang sue",Transaction = "Chack NCB (20) FULL REGISTER (18)",CheckNCBReqMoreDoc = 1,
                                    CheckNCBPass = 1,CheckNCBNotpass =1,FullRegisterReqMoreDoc = 1,FullRegisterPending = 1,FullRegisterCancelByCustomer = 1,
                                    FullRegisterCancelByJDM = 1,FullRegisterApprove = 1,FullRegisterReject = 1 },

                    new SummaryReport(){No = 5,MarketingCode = "20180504",MarketingName = "Wichuda Nakprok",AgentCode = "A005",AgentName = "Honda Taopoon",Transaction = "Chack NCB (13) FULL REGISTER (6)",CheckNCBReqMoreDoc = 1,
                                    CheckNCBPass = 1,CheckNCBNotpass =1,FullRegisterReqMoreDoc = 1,FullRegisterPending = 1,FullRegisterCancelByCustomer = 1,
                                    FullRegisterCancelByJDM = 1,FullRegisterApprove = 1,FullRegisterReject = 1 },

                     new SummaryReport(){No = 6,MarketingCode = "20180501",MarketingName = "Wichuda Nakprok",AgentCode = "A006",AgentName = "Honda Chatuchak",Transaction = "Chack NCB (20) FULL REGISTER (18)",CheckNCBReqMoreDoc = 1,
                                    CheckNCBPass = 1,CheckNCBNotpass =1,FullRegisterReqMoreDoc = 1,FullRegisterPending = 1,FullRegisterCancelByCustomer = 1,
                                    FullRegisterCancelByJDM = 1,FullRegisterApprove = 1,FullRegisterReject = 1 },

                      new SummaryReport(){No = 7,MarketingCode = "20180501",MarketingName = "Wichuda Nakprok",AgentCode = "A006",AgentName = "Honda Phyathai",Transaction = "Chack NCB (13) FULL REGISTER (6)",CheckNCBReqMoreDoc = 1,
                                    CheckNCBPass = 1,CheckNCBNotpass =1,FullRegisterReqMoreDoc = 1,FullRegisterPending = 1,FullRegisterCancelByCustomer = 1,
                                    FullRegisterCancelByJDM = 1,FullRegisterApprove = 1,FullRegisterReject = 1 },
            };
            return View(mockupData);
        }

        [HttpGet]
        public ActionResult Report()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Report(string reportname)
        {
            //SummaryApproveReport
            //SummaryApproveReport
            string url = $"http://localhost:25401/Home/{reportname}";
            ByteArrayToFile($"C:\\Users\\pailinn\\Desktop\\{reportname}.pdf", PDFFormWeb(url));
            return RedirectToAction("Report");
        }

        #region Using Codaxy.WkHtmlToPdf

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
                OutputFilePath = "C:\\Users\\pailinn\\Desktop\\1.pdf"
            });
        }

        #endregion Using Codaxy.WkHtmlToPdf

        #region Using Pechkin WkHtmlToPdf

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

        #endregion Using Pechkin WkHtmlToPdf
    }
}