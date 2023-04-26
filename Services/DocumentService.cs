using sharpPDF.Enumerators;
using sharpPDF;
using System.Collections.Generic;
using GAG.Models;
namespace GAG.Services
{
    internal class DocumentService
    {
        public void CreateGrafcetListReport(string pathString, IEnumerable<Grafcet> items)
        {
            pdfDocument myDoc = new pdfDocument("Liste de grafcets", "GAG", false);
            pdfPage myFirstPage = myDoc.addPage();
            myFirstPage.addText("Liste de grafcets", 100, 760, predefinedFont.csHelveticaOblique, 20, new pdfColor(predefinedColor.csBlack));
            /*Table's creation*/
            pdfTable myTable = new pdfTable();
            //Set table's border
            myTable.borderColor = new pdfColor(predefinedColor.csBlack);
            /*Create table's header*/
            myTable.tableHeader.addColumn(new pdfTableColumn("Nom", predefinedAlignment.csRight, 80));
            myTable.tableHeader.addColumn(new pdfTableColumn("Titre", predefinedAlignment.csCenter, 250));
            myTable.tableHeader.addColumn(new pdfTableColumn("Serveur", predefinedAlignment.csLeft, 60));
            myTable.tableHeader.addColumn(new pdfTableColumn("Phase", predefinedAlignment.csLeft, 60));
            /*Create table's rows*/
            foreach (var grafcet in items)
            {
                pdfTableRow myRow = myTable.createRow();
                myRow[0].columnValue = grafcet.Nom;
                myRow[1].columnValue = grafcet.Titre;
                myRow[2].columnValue = grafcet.Serveur.ToString();
                myRow[3].columnValue = grafcet.Phase.ToString();
                myTable.addRow(myRow);
            }

            /*Set Header's Style*/
            myTable.tableHeaderStyle = new pdfTableRowStyle(predefinedFont.csCourierBoldOblique, 12, new pdfColor(predefinedColor.csWhite), new pdfColor("248FFC"));
            /*Set Row's Style*/
            myTable.rowStyle = new pdfTableRowStyle(predefinedFont.csCourier, 8, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csWhite));
            /*Set Alternate Row's Style*/
            //myTable.alternateRowStyle = new pdfTableRowStyle(predefinedFont.csCourier, 8, new pdfColor(predefinedColor.csBlack), new pdfColor(predefinedColor.csLightYellow));
            /*Set Cellpadding*/
            myTable.cellpadding = 5;
            /*Put the table on the page object*/
            myFirstPage.addTable(myTable, 100, 720);
            myTable = null;
            myDoc.createPDF(pathString);
        }
    }
}
