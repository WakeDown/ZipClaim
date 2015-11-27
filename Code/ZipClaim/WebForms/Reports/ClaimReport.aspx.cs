using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using ZipClaim.Helpers;
using ZipClaim.Objects;

namespace ZipClaim.WebForms.Reports
{
    public partial class ClaimReport : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            if (!IsPostBack)
            {
                FillLists();
            }

            RegisterStartupScripts();
        }

        private void FillLists()
        {
            MainHelper.DdlFill(ref ddlContractor, Db.Db.Zipcl.GetContractorFilterSelectionList(),true, MainHelper.ListFirstItemType.SelectAll);
        }
        
protected void btnLoadClaimUnitExcel_OnClick(object sender, EventArgs e)
        {
            int? IdContractor = MainHelper.DdlGetSelectedValueInt(ref ddlContractor, true);
            DateTime? dateBegin = MainHelper.TxtGetTextDateTime(ref txtDateBegin, true);
            DateTime? dateEnd = MainHelper.TxtGetTextDateTime(ref txtDateEnd, true);

            DataTable dt = Db.Db.Zipcl.GetClaimUnitReport(IdContractor, dateBegin, dateEnd);

            byte[] file = CreateExcelClaimUnitFile(dt);
            Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.OutputStream.Write(file, 0, file.Length);
            string fileName = "ClaimUnitReport.xlsx";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            //Response.AddHeader("Content-Length", file.Length.ToString());
            Response.OutputStream.Write(file, 0, file.Length);
            Response.Flush();
            Response.End();
        }

        protected void btnLoadExcel_OnClick(object sender, EventArgs e)
        {
            int? IdContractor = MainHelper.DdlGetSelectedValueInt(ref ddlContractor, true);
            DateTime? dateBegin = MainHelper.TxtGetTextDateTime(ref txtDateBegin, true);
            DateTime? dateEnd = MainHelper.TxtGetTextDateTime(ref txtDateEnd, true);

            DataTable dt = Db.Db.Zipcl.GetClaimReport(IdContractor, dateBegin, dateEnd);

            byte[] file = CreateExcelFile(dt);
            Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.OutputStream.Write(file, 0, file.Length);
            string fileName = "ClaimReport.xlsx";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            //Response.AddHeader("Content-Length", file.Length.ToString());
            Response.OutputStream.Write(file, 0, file.Length);
            Response.Flush();
            Response.End();
        }

        
            private byte[] CreateExcelClaimUnitFile(DataTable dt)
        {
            XLWorkbook wb = new XLWorkbook();
            IXLWorksheet sheet = wb.AddWorksheet("Отчет");

            const int startCol = 1;
            const int startRow = 1;

            int row = startRow;
            int col = startCol;
            //Заголовок
            sheet.Cell(row, col).Value = "ID Заявки";
            sheet.Column(col).Width = 11;
            sheet.Cell(row, ++col).Value = "Дата Заявки";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Каталожный номер";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Наименование";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Количество";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Цена ВХОД";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Цена ВЫХОД";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Модель";
            sheet.Column(col).Width = 25;
            sheet.Cell(row, ++col).Value = "Серийный номер";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Контрагент";
            sheet.Column(col).Width = 30;
            sheet.Cell(row, ++col).Value = "№ SD Контрагента";
            sheet.Column(col).Width = 10;
            sheet.Cell(row, ++col).Value = "№ SD UN1T";
            sheet.Column(col).Width = 10;
            sheet.Cell(row, ++col).Value = "Город";
            sheet.Column(col).Width = 20;
            sheet.Cell(row, ++col).Value = "Адрес";
            sheet.Column(col).Width = 20;
            sheet.Cell(row, ++col).Value = "Инженер";
            sheet.Column(col).Width = 20;
            sheet.Cell(row, ++col).Value = "Сервисный администратор";
            sheet.Column(col).Width = 20;
            sheet.Cell(row, ++col).Value = "Оператор";
            sheet.Column(col).Width = 20;
            sheet.Cell(row, ++col).Value = "Менеджер";
            sheet.Column(col).Width = 20;
            sheet.Cell(row, ++col).Value = "Текущий статус заявки";
            sheet.Column(col).Width = 20;
            sheet.Cell(row, ++col).Value = "Состояние оборудования";
            sheet.Column(col).Width = 40;
            sheet.Cell(row, ++col).Value = "Количество ЗИП в данной заявке";
            sheet.Column(col).Width = 13;
            sheet.Cell(row, ++col).Value = "Передано";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Назначено";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Проставлены цены";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Согласованы цены";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Не согласованы цены";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Указан номер требования";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Завершена";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Заказано";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Оформлено";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Готово к отгрузке";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Отгружено";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Запрошены цены";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Номер требования";
            sheet.Cell(row, ++col).Value = "Причина отклонения";
            sheet.Column(col).Width = 40;
            // />Заголовок
            int lastCol = col;

            var header = sheet.Range(sheet.Cell(row, startCol), sheet.Cell(row, lastCol));
            header.Style.Font.SetBold();

            foreach (DataRow dr in dt.Rows)
            {
                row++;
                col = startCol;


                sheet.Cell(row, col).Value = dr["id_claim"].ToString();
                sheet.Cell(row, ++col).Value = String.Format("{0:dd.MM.yyyy}", dr["dattim1"]);
                sheet.Cell(row, ++col).Value = dr["catalog_num"].ToString();
                sheet.Cell(row, ++col).Value = dr["NAME"].ToString();
                sheet.Cell(row, ++col).Value = dr["COUNT"].ToString();
                sheet.Cell(row, ++col).Value = dr["price_in"].ToString();
                sheet.Cell(row, ++col).Value = dr["price_out"].ToString();
                sheet.Cell(row, ++col).Value = dr["device_model"].ToString();
                sheet.Cell(row, ++col).Value = dr["serial_num"].ToString();
                sheet.Cell(row, ++col).Value = dr["contractor"].ToString();
                sheet.Cell(row, ++col).Value = dr["contractor_sd_num"].ToString();
                sheet.Cell(row, ++col).Value = dr["service_desk_num"].ToString();
                sheet.Cell(row, ++col).Value = dr["city"].ToString();
                sheet.Cell(row, ++col).Value = dr["ADDRESS"].ToString();
                sheet.Cell(row, ++col).Value = dr["engeneer"].ToString();
                sheet.Cell(row, ++col).Value = dr["service_admin"].ToString();
                sheet.Cell(row, ++col).Value = dr["operator"].ToString();
                sheet.Cell(row, ++col).Value = dr["manager"].ToString();
                sheet.Cell(row, ++col).Value = dr["claim_state"].ToString();
                sheet.Cell(row, ++col).Value = dr["device_state"].ToString();
                sheet.Cell(row, ++col).Value = dr["zip_count"].ToString();
                sheet.Cell(row, ++col).Value = dr["SEND"].ToString();
                sheet.Cell(row, ++col).Value = dr["MANSEL"].ToString();
                sheet.Cell(row, ++col).Value = dr["PRICE"].ToString();
                sheet.Cell(row, ++col).Value = dr["PRICEOK"].ToString();
                sheet.Cell(row, ++col).Value = dr["PRICEFAIL"].ToString();
                sheet.Cell(row, ++col).Value = dr["REQUESTNUM"].ToString();
                sheet.Cell(row, ++col).Value = dr["DONE"].ToString();
                sheet.Cell(row, ++col).Value = dr["ETORDER"].ToString();
                sheet.Cell(row, ++col).Value = dr["ETDOCS"].ToString();
                sheet.Cell(row, ++col).Value = dr["ETPREP"].ToString();
                sheet.Cell(row, ++col).Value = dr["ETSHIP"].ToString();
                sheet.Cell(row, ++col).Value = dr["SUPPLY"].ToString();
                sheet.Cell(row, ++col).Value = dr["request_num"].ToString();
                sheet.Cell(row, ++col).Value = dr["cancel_comment"].ToString();
                //sheet.Cell(row, col).Style.Alignment.SetWrapText();
            }

            var all = sheet.Range(sheet.Cell(startRow, startCol), sheet.Cell(row, lastCol));
            all.Style.Font.SetFontSize(10);
            all.CreateTable();

            all.Style.Border.SetBottomBorder(XLBorderStyleValues.Thin);
            all.Style.Border.SetBottomBorderColor(XLColor.Gray);
            all.Style.Border.SetTopBorder(XLBorderStyleValues.Thin);
            all.Style.Border.SetTopBorderColor(XLColor.Gray);
            all.Style.Border.SetRightBorder(XLBorderStyleValues.Thin);
            all.Style.Border.SetRightBorderColor(XLColor.Gray);
            all.Style.Border.SetLeftBorder(XLBorderStyleValues.Thin);
            all.Style.Border.SetLeftBorderColor(XLColor.Gray);

            var ms = new MemoryStream();
            wb.SaveAs(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return ms.ToArray();
        }

        private byte[] CreateExcelFile(DataTable dt)
        {
            XLWorkbook wb = new XLWorkbook();
            IXLWorksheet sheet = wb.AddWorksheet("Отчет");

            const int startCol = 1;
            const int startRow = 1;

            int row = startRow;
            int col = startCol;
            //Заголовок
            sheet.Cell(row, col).Value = "ID Заявки"; //1
            sheet.Column(col).Width = 11;
            sheet.Cell(row, ++col).Value = "Дата Заявки";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Модель";
            sheet.Column(col).Width = 25;
            sheet.Cell(row, ++col).Value = "Серийный номер";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Контрагент";//5
            sheet.Column(col).Width = 30;
            sheet.Cell(row, ++col).Value = "№ SD Контрагента";
            sheet.Column(col).Width = 10;
            sheet.Cell(row, ++col).Value = "№ SD UN1T";
            sheet.Column(col).Width = 10;
            sheet.Cell(row, ++col).Value = "Город";
            sheet.Column(col).Width = 20;
            sheet.Cell(row, ++col).Value = "Адрес";
            sheet.Column(col).Width = 20;
            sheet.Cell(row, ++col).Value = "Инженер";
            sheet.Column(col).Width = 20;
            sheet.Cell(row, ++col).Value = "Сервисный администратор";
            sheet.Column(col).Width = 20;
            sheet.Cell(row, ++col).Value = "Оператор";//11
            sheet.Column(col).Width = 20;
            sheet.Cell(row, ++col).Value = "Менеджер";
            sheet.Column(col).Width = 20;
            sheet.Cell(row, ++col).Value = "Текущий статус заявки";
            sheet.Column(col).Width = 20;
            sheet.Cell(row, ++col).Value = "Состояние оборудования";
            sheet.Column(col).Width = 40;
            sheet.Cell(row, ++col).Value = "Количество ЗИП в данной заявке";
            sheet.Column(col).Width = 13;
            sheet.Cell(row, ++col).Value = "Передано";//16
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Назначено";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Проставлены цены";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Согласованы цены";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Не согласованы цены";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Указан номер требования";//21
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Завершена";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Заказано";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Оформлено";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Готово к отгрузке";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Отгружено";//26
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Запрошены цены";
            sheet.Column(col).Width = 15;
            sheet.Cell(row, ++col).Value = "Номер требования";
            sheet.Cell(row, ++col).Value = "Причина отклонения";
            sheet.Column(col).Width = 40;
            // />Заголовок
            int lastCol = col;

            var header = sheet.Range(sheet.Cell(row, startCol), sheet.Cell(row, lastCol));
            header.Style.Font.SetBold();

            foreach (DataRow dr in dt.Rows)
            {
                row++;
                col = startCol;


                sheet.Cell(row, col).Value = dr["id_claim"].ToString();
                sheet.Cell(row, ++col).Value = String.Format("{0:dd.MM.yyyy}", dr["dattim1"]);
                sheet.Cell(row, ++col).Value = dr["device_model"].ToString();
                sheet.Cell(row, ++col).Value = dr["serial_num"].ToString();
                sheet.Cell(row, ++col).Value = dr["contractor"].ToString();
                sheet.Cell(row, ++col).Value = dr["contractor_sd_num"].ToString();
                sheet.Cell(row, ++col).Value = dr["service_desk_num"].ToString();
                sheet.Cell(row, ++col).Value = dr["city"].ToString();
                sheet.Cell(row, ++col).Value = dr["ADDRESS"].ToString();
                sheet.Cell(row, ++col).Value = dr["engeneer"].ToString();
                sheet.Cell(row, ++col).Value = dr["service_admin"].ToString();
                sheet.Cell(row, ++col).Value = dr["operator"].ToString();
                sheet.Cell(row, ++col).Value = dr["manager"].ToString();
                sheet.Cell(row, ++col).Value = dr["claim_state"].ToString();
                sheet.Cell(row, ++col).Value = dr["device_state"].ToString();
                sheet.Cell(row, ++col).Value = dr["zip_count"].ToString();
                sheet.Cell(row, ++col).Value = dr["SEND"].ToString();
                sheet.Cell(row, ++col).Value = dr["MANSEL"].ToString();
                sheet.Cell(row, ++col).Value = dr["PRICE"].ToString();
                sheet.Cell(row, ++col).Value = dr["PRICEOK"].ToString();
                sheet.Cell(row, ++col).Value = dr["PRICEFAIL"].ToString();
                sheet.Cell(row, ++col).Value = dr["REQUESTNUM"].ToString();
                sheet.Cell(row, ++col).Value = dr["DONE"].ToString();
                sheet.Cell(row, ++col).Value = dr["ETORDER"].ToString();
                sheet.Cell(row, ++col).Value = dr["ETDOCS"].ToString();
                sheet.Cell(row, ++col).Value = dr["ETPREP"].ToString();
                sheet.Cell(row, ++col).Value = dr["ETSHIP"].ToString();
                sheet.Cell(row, ++col).Value = dr["SUPPLY"].ToString();
                sheet.Cell(row, ++col).Value = dr["request_num"].ToString();
                sheet.Cell(row, ++col).Value = dr["cancel_comment"].ToString();
                //sheet.Cell(row, col).Style.Alignment.SetWrapText();
            }

            var all = sheet.Range(sheet.Cell(startRow, startCol), sheet.Cell(row, lastCol));
            all.Style.Font.SetFontSize(10);
            all.CreateTable();
            
            all.Style.Border.SetBottomBorder(XLBorderStyleValues.Thin);
            all.Style.Border.SetBottomBorderColor(XLColor.Gray);
            all.Style.Border.SetTopBorder(XLBorderStyleValues.Thin);
            all.Style.Border.SetTopBorderColor(XLColor.Gray);
            all.Style.Border.SetRightBorder(XLBorderStyleValues.Thin);
            all.Style.Border.SetRightBorderColor(XLColor.Gray);
            all.Style.Border.SetLeftBorder(XLBorderStyleValues.Thin);
            all.Style.Border.SetLeftBorderColor(XLColor.Gray);

            var ms = new MemoryStream();
            wb.SaveAs(ms);
            ms.Seek(0, SeekOrigin.Begin);
            return ms.ToArray();
        }

        private void RegisterStartupScripts()
        {
            //<Фильтрация списка по вводимому тексту>
            string script = String.Format(@"$(function() {{$('#{0}').filterByText($('#{1}'), true);}});",
                ddlContractor.ClientID, txtContractorInn.ClientID);

            ScriptManager.RegisterStartupScript(this, GetType(), "filterContractorListByInn", script, true);
            //</Фильтрация списка>
        }
    }
}