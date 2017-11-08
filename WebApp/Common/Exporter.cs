using System.Collections.Generic;
using System.Text;
using DataAccess.Entities;

namespace WebApp.Common
{
    public class Exporter
    {
        public static string ExportToHtml(List<Supply> items)
        {
            var strBuilder = new StringBuilder();
            strBuilder.Append(@"<h2> Справочник поставок </h2>");

            // Так никто не верстает в 2017 году, но лень писать стайлы.
            strBuilder.Append(@"<table border='1' borderColor='gray'");

                strBuilder.AppendFormat(
                    @"<tr><td><b>{0}</b></td><td><b>{1}</b></td><td><b>{2}</b></td><td><b>{3}</b></td></tr>",
                    "Ид",
                    "Дата",
                    "Поставщик",
                    "Продукт");

            foreach (var item in items)
            {
                strBuilder.AppendFormat(
                    
                    @"<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", 
                    item.Id, 
                    item.TimeStamp, 
                    item.Provisioner.Name, 
                    item.Product.Name);
            }
            strBuilder.Append(@"</table>");

            return strBuilder.ToString();            
        }      
    }
}