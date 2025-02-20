#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.XlsIO;

namespace MVCSampleBrowser.Controllers
{
    public partial class XlsIOController : Controller
    {
        //
        // GET: /Tables/

        public ActionResult Tables(string button, string checkbox)
        {
            if (button == null)
                return View();

            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2016;

            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet worksheet = workbook.Worksheets[0];

            #region Create Table
            // Create table
            IListObject table1 = worksheet.ListObjects.Create("Table1", worksheet["A1:E7"]);


            # region Table data
            // Fill table data
            worksheet[1, 1].Text = "Products";
            worksheet[1, 2].Text = "Qtr1";
            worksheet[1, 3].Text = "Qtr2";
            worksheet[1, 4].Text = "Qtr3";
            worksheet[1, 5].Text = "Qtr4";

            worksheet[2, 1].Text = "Alfreds Futterkiste";
            worksheet[2, 2].Number = 744.6;
            worksheet[2, 3].Number = 162.56;
            worksheet[2, 4].Number = 5079.6;
            worksheet[2, 5].Number = 1249.2;

            worksheet[3, 1].Text = "Antonio Moreno Taqueria";
            worksheet[3, 2].Number = 5079.6;
            worksheet[3, 3].Number = 1249.2;
            worksheet[3, 4].Number = 943.89;
            worksheet[3, 5].Number = 349.6;

            worksheet[4, 1].Text = "Around the Horn";
            worksheet[4, 2].Number = 1267.5;
            worksheet[4, 3].Number = 1062.5;
            worksheet[4, 4].Number = 744.6;
            worksheet[4, 5].Number = 162.56;

            worksheet[5, 1].Text = "Bon app";
            worksheet[5, 2].Number = 1418;
            worksheet[5, 3].Number = 756;
            worksheet[5, 4].Number = 1267.5;
            worksheet[5, 5].Number = 1062.5;

            worksheet[6, 1].Text = "Eastern Connection";
            worksheet[6, 2].Number = 4728;
            worksheet[6, 3].Number = 4547.92;
            worksheet[6, 4].Number = 1418;
            worksheet[6, 5].Number = 756;

            worksheet[7, 1].Text = "Ernst Handel";
            worksheet[7, 2].Number = 943.89;
            worksheet[7, 3].Number = 349.6;
            worksheet[7, 4].Number = 4728;
            worksheet[7, 5].Number = 4547.92;
            # endregion

            // Create style for table number format
            IStyle style1 = workbook.Styles.Add("CurrencyFormat");
            style1.NumberFormat = "_($* #,##0.00_);_($* (#,##0.00);_($* \" - \"??_);_(@_)";

            // Apply number format
            worksheet["B2:E8"].CellStyleName = "CurrencyFormat";
            if (checkbox == "Apply custom style")
            {
                //Apply custom table style
                table1.TableStyleName = CreateCustomStyle(workbook).Name;
            }
            else
            {
                //Apply builtin table style
                table1.BuiltInTableStyle = TableBuiltInStyles.TableStyleMedium9;
            }

            table1.ShowTotals = true;
            table1.ShowFirstColumn = true;
            table1.ShowTableStyleColumnStripes = true;
            table1.ShowTableStyleRowStripes = true;
            table1.Columns[0].TotalsRowLabel = "Total";
            table1.Columns[1].TotalsCalculation = ExcelTotalsCalculation.Sum;
            table1.Columns[2].TotalsCalculation = ExcelTotalsCalculation.Sum;
            table1.Columns[3].TotalsCalculation = ExcelTotalsCalculation.Sum;
            table1.Columns[4].TotalsCalculation = ExcelTotalsCalculation.Sum;

            #endregion
            worksheet.UsedRange.AutofitColumns();
            worksheet.SetColumnWidth(2, 12.43);
            worksheet.SetColumnWidth(4, 12.43);

            try
            {
                //Saving the workbook to disk.
                return excelEngine.SaveAsActionResult(workbook, "Tables.xlsx", HttpContext.ApplicationInstance.Response, ExcelDownloadType.PromptDialog, ExcelHttpContentType.Excel2016);
            }
            catch (Exception)
            {
            }

            workbook.Close();
            excelEngine.Dispose();
            return View();
        }
        //Create custom table styles
        private ITableStyle CreateCustomStyle(IWorkbook workbook)
        {
           
            string tableStyleName = "Table Style 1";

            ITableStyles tableStyles = workbook.TableStyles;
            ITableStyle tableStyle = tableStyles.Add(tableStyleName);
            ITableStyleElements tableStyleElements = tableStyle.TableStyleElements;
            ITableStyleElement tableStyleElement = tableStyleElements.Add(ExcelTableStyleElementType.SecondColumnStripe);
            tableStyleElement.BackColorRGB = Color.FromArgb(217, 225, 242);

            ITableStyleElement tableStyleElement1 = tableStyleElements.Add(ExcelTableStyleElementType.FirstColumn);
            tableStyleElement1.FontColorRGB = Color.FromArgb(128, 128, 128);

            ITableStyleElement tableStyleElement2 = tableStyleElements.Add(ExcelTableStyleElementType.HeaderRow);
            tableStyleElement2.Bold = true;
            tableStyleElement2.FontColor = ExcelKnownColors.White;
            tableStyleElement2.BackColorRGB = Color.FromArgb(0, 112, 192);

            ITableStyleElement tableStyleElement3 = tableStyleElements.Add(ExcelTableStyleElementType.TotalRow);
            tableStyleElement3.BackColorRGB = Color.FromArgb(0, 112, 192);
            tableStyleElement3.Bold = true;
            tableStyleElement3.FontColor = ExcelKnownColors.White;
           

            return tableStyle;
        }
    }
}
