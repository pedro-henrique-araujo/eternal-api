using Eternal.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Eternal.Business
{
    public class PdfService : IPdfService
    {
        public byte[]? GenerateInstalmentsPdf(ContractDetailDto contract)
        {
            if (contract?.Instalments is null)
                return null;

            using (var stream = new MemoryStream())
            {
                using (var document = new Document())
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();
                    foreach (var instalment in contract.Instalments)
                    {
                        PdfPTable firstTable, secondTable;
                        GenerateTables(out firstTable, out secondTable, contract, instalment);

                        var content = new PdfPTable(new float[] { 27, 3, 70});
                        var firstColumnCell = new PdfPCell(firstTable);
                        firstColumnCell.Border = 0;
                        content.AddCell(firstColumnCell);
                        var secondColumnCell = new PdfPCell(secondTable);
                        var middleCell = new PdfPCell(new Phrase("\n"));
                        middleCell.Border = 0;
                        content.AddCell(middleCell);
                        content.AddCell(secondColumnCell);
                        content.WidthPercentage = 100;
                        document.Add(content);
                        document.Add(new Phrase("\n"));

                    }
                    document.Close();
                    return stream.ToArray();
                }
            }
        }

        private static void GenerateTables(
            out PdfPTable firstTable, 
            out PdfPTable secondTable, 
            ContractDetailDto contract, 
            InstalmentDetailDto instalment)
        {
            var id = instalment.Id;
            var expirationFormated = instalment.Expiration?.ToString("dd/MM/yyyy");
            var clientName = contract.Client.Name;
            var documentValue = instalment.Value;
            var referenceMonth = $"{instalment.Expiration.Value.ToString("MMMM")} {instalment.Expiration.Value.Year}";
            var companyName = "Resplendor Eterno";

            firstTable = new PdfPTable(1);
            firstTable.AddCell(NewCell("Nº Documento", id));
            firstTable.AddCell(NewCell("Vencimento", expirationFormated));
            firstTable.AddCell(NewCell("Pagador", clientName));
            firstTable.AddCell(NewCell("Bairro", "Chácara da Prainha"));
            firstTable.AddCell(NewCell("Cidade", "Aquiraz-CE"));
            firstTable.AddCell(NewCell("Valor do documento", documentValue));
            firstTable.AddCell(NewCell("Mês de referência", referenceMonth));
            firstTable.AddCell(NewCell(null, null));

            secondTable = new PdfPTable(3);
            secondTable.AddCell(NewCell("Local de pagamento", "Pagável somente na funerária " + companyName, 2, rightBorder: true));
            secondTable.AddCell(NewCell("Vencimento", expirationFormated, rightBorder: true));
            secondTable.AddCell(NewCell("Cedente", companyName, 2, rightBorder: true));
            secondTable.AddCell(NewCell("Valor do documento", documentValue, rightBorder: true));
            secondTable.AddCell(NewCell("Nº do documento", id, rightBorder: true));
            secondTable.AddCell(NewCell("Data da geração", DateTime.Now.ToString("dd/MM/yyyy"), rightBorder: true));
            secondTable.AddCell(NewCell("Mês de referência", referenceMonth, rightBorder: true));
            secondTable.AddCell(NewCell("Instruções (texto de responsabilidade do cedente)", "", 3, fixedHeight: 50, rightBorder: true));
            secondTable.AddCell(NewCell("Pagador", clientName, 2, rightBorder: true));
            secondTable.AddCell(NewCell("CPF", contract.Client.Cpf, rightBorder: true));
            secondTable.AddCell(NewCell("Endereço", "Av. Airton Sena, 22", 2, rightBorder: true));
            secondTable.AddCell(NewCell("RG", "2005342892-9", rightBorder: true));
            secondTable.AddCell(NewCell("Bairro e cidade", "Chácara da Prainha, Aquiraz-CE", 3, rightBorder: true));
        }

        private static PdfPCell NewCell(string title, object value, int colspan = 1, float? fixedHeight = null, bool? rightBorder = null)
        {
            var miniTable = new PdfPTable(1);
            var cell1 = new PdfPCell(new Phrase(title, new Font(Font.FontFamily.HELVETICA, 5)));
            cell1.Border = 0;
            miniTable.AddCell(cell1);
            var cell2 = new PdfPCell(new Phrase(value?.ToString(), new Font(Font.FontFamily.HELVETICA, 9)));
            cell2.Border = 0;
            miniTable.AddCell(cell2);

            var cell = new PdfPCell(miniTable);
            cell.Border = 0;
            cell.BorderWidthBottom = 1;
            if (fixedHeight.HasValue)
            {
                cell.FixedHeight = fixedHeight.Value;
            }

            if (rightBorder == true)
            {                
                cell.BorderWidthRight = 1;
            }

            cell.Padding = 1;
            cell.Colspan = colspan;
            return cell;
        }
    }
}
