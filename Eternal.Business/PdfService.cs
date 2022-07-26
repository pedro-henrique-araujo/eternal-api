using Eternal.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Eternal.Business
{
    public class PdfService : IPdfService
    {
        public byte[]? GenerateInstalmentsPdf(Contract contract)
        {
            if (contract?.Instalments?.Any() is false || contract?.Client is null)
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

        public byte[]? GenerateContractPdf(Contract contract)
        {
            var client = contract?.Client;
            if (client is null)
                return null;

            using (var stream = new MemoryStream())
            {
                using (var document = new Document())
                {
                    PdfWriter.GetInstance(document, stream);
                    document.Open();

                    var tableFont = new Font(Font.FontFamily.HELVETICA, 8);
                    var clientTable = new PdfPTable(4);
                    clientTable.AddCell(new PdfPCell(new Phrase("CONTRATANTE", tableFont)));
                    clientTable.AddCell(new PdfPCell(new Phrase("CPF", tableFont)));
                    clientTable.AddCell(new PdfPCell(new Phrase("IDENTIDADE", tableFont)));
                    clientTable.AddCell(new PdfPCell(new Phrase("NASCIMENTO", tableFont)));
                    clientTable.AddCell(new PdfPCell(new Phrase(client.Name, tableFont)));
                    clientTable.AddCell(new PdfPCell(new Phrase(client.Cpf, tableFont)));
                    clientTable.AddCell(new PdfPCell(new Phrase("1234597895618", tableFont)));
                    clientTable.AddCell(new PdfPCell(new Phrase(client.BirthDate.ToString("dd/MM/yyyy"), tableFont)));
                    clientTable.WidthPercentage = 100;

                    var addressTable = new PdfPTable(2);
                    addressTable.AddCell(new PdfPCell(new Phrase("ENDEREÇO", tableFont)));
                    addressTable.AddCell(new PdfPCell(new Phrase("CIDADE", tableFont)));
                    addressTable.AddCell(new PdfPCell(new Phrase("rua tal tal", tableFont)));
                    addressTable.AddCell(new PdfPCell(new Phrase("aquiraz", tableFont)));
                    addressTable.WidthPercentage = 100;


                    var signaturesTable = new PdfPTable(1);
                    signaturesTable.WidthPercentage = 50;
                    foreach (var signature in new[] { "CONTRATANTE" , "VENDEDOR", "REPRESENTANTE" })
                    {
                        var spaceCell = new PdfPCell(new Phrase("\n", new Font(Font.FontFamily.UNDEFINED, 100)));
                        spaceCell.BorderWidth = 0;
                        signaturesTable.AddCell(spaceCell);
                        var signatureCell = new PdfPCell(new Phrase(signature, tableFont));
                        signatureCell.BorderWidth = 0;
                        signatureCell.BorderWidthTop = 1;
                        signatureCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        signaturesTable.AddCell(signatureCell);
                    }

                    document.Add(new Phrase(GetContractText(), new Font(Font.FontFamily.HELVETICA, 8)));
                    document.Add(new Phrase("\n"));
                    document.Add(clientTable);
                    document.Add(new Phrase("\n"));
                    document.Add(addressTable);
                    document.Add(new Phrase("\n"));
                    document.Add(new Phrase("\n"));
                    document.Add(new Phrase("\n"));
                    document.Add(signaturesTable);
                    document.Close();
                    return stream.ToArray();
                }
            }
        }

        private static void GenerateTables(
            out PdfPTable firstTable, 
            out PdfPTable secondTable, 
            Contract contract, 
            Instalment instalment)
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

        private static string GetContractText()
        {
            return @"
CONTRATO DE PRESTAÇÃO DE SERVIÇO
 1-DAS PARTES 
 Pelo presente instrumento particular de Contrato de Prestação de Serviços firmados de um lado por Funerária Resplendor 
Eterno, com sede na cidade de Aquiraz, Estado do Ceará, a Rua Tibúrcio Targino, 496, Centro, inscrita no Cadastro Nacional de 
Pessoas Jurídicas do Ministério da Fazenda, sob o nº 12.345.678/9089-12, Inscrição Estadual sob o nº 12345678-9, neste ato 
representado por sua Diretora Presidente infrafirmada, doravante designada CONTRATADA, e de outro lado, o (a) Titular, 
doravante designada CONTRATANTE, têm entre si justo e contratado o seguinte:
 
 II-DO OBJETIVO 
 A CONTRATADA, empresa especializada no atendimento de serviços funerários em geral, obriga-se a prestar ao (a) 
CONTRATANTE e aos seus beneficiários, os serviços enumerados no regulamento constante neste contrato mediante condições 
abaixo estabelecidas.
 
 III-DOS BENEFICIÁRIOS
 3.1-0(A) CONTRATANTE fornecerá a CONTRATADA à qualificação completa dos seus beneficiários (familiares), só sendo 
permitida a substituição dos mesmos em caso de falecimento. Dependentes e/ou familiares do contratante que não constarem no 
rol de beneficiários acima mencionados, poderão fazer uso dos serviços prestados pela contratada mediante a concessäo de 
desconto de 15% (quinze por cento) sobre o valor total das despesas realizadas com serviços porventura solicitados.
 3.2-Firmado o presente contrato, o (a) CONTRATANTE e seus beneficiários, somente teräo direito aos serviços prestados pela 
CONTRATADA, após um período de carência de 90 (noventa) dias. Durante o período de carência, caso o (a) CONTRATANTE 
necessite fazer uso dos serviços prestados pela CONTRATADA terá um desconto de 20% (vinte por cento) sobre o valor total 
das despesas realizadas, entretanto para gozar do mencionado benefício deverá estar quite com a tesouraria.
 
 IV-DA REMUNERAÇÃO 
 4.1-As mensalidades aqui contratadas tem como referência um percentual de 5% (cinco por cento) sobre o salário mínimo 
vigente na região conforme regulamento.
 4.2-O pagamento das referidas mensalidades será feito mediante apresentação de carnês nas lojas Funerária Resplendor Eterno 
ou em locais indicados pela contratada, sendo que tais valores não constituem fundos de reservas, como formação de poupança, 
presunção de sociedade que importe em devolução futura.
 4.3-Fica autorizado o (a) CONTRATANTE efetuar o pagamento da taxa de adesão ao vendedor da CONTRATADA, ficando 
terminantemente proibido ao CONTRATANTE efetuar qualquer outro tipo de pagamento aos vendedores.
 
 V-DO PRAZO DO CONTRATO 
 5.1-O presente contrato é por prazo determinado de 04 (quatro) anos, contado a partir da data de assinatura.
 5.2-O prazo será sucessivo e automaticamente renovado por igual período, sem qualquer ônus, desde que não seja denunciado 
por escrito por qualquer
 das partes, para sua rescisão.
 
 VI-DA RESCISÃO
 O presente contrato poderá ser rescindido, nas seguintes condições:
 a) Pelo contratante, caso não utilize os serviços oriundos deste contrato, mediante comunicação por escrito e sem restituição 
alguma.
 b) Pelo contratante, que utilizar os serviços oriundos deste contrato, mediante a quitação total das remunerações que irão vencer 
até o término do mesmo.
 c) Pelo contratante, que atrasar 03 (três) mensalidades consecutivas.
 
 VII-DAS CONDIÇÕES GERAIS 
 7.1-O contratante, que atrasar 03 (três) mensalidades consecutivas, terá todos os seus direitos suspensos (sem necessidade de 
comunicação formal por parte da empresa).
 7.2-A reabilitação do direito a prestação de serviços se produzirá logo depois de transcorrido 30 (trinta) dias contado a partir da 
data em que o(a) CONTRATANTE tenha pago a totalidade das remunerações mensais vencidas.
 7.3-Em caso de falecimento e sepultamento do (a) CONTRATANTE e/ou seus beneficiários a CONTRATADA não se 
responsabilizará com despesas realizadas com cemitério.
 7.4-Translado exclusivamente por via terrestre do carro fünebre, até o limite de 200 (duzentos) quilómetros rodadas, tomados 
como ponto de partida a Sede da CONTRATADA em Aquiraz -Ceará. Na hipótese da família do CONTRATANTE desejar 
transportar o corpo do (a) falecido (a) para fora de ação do Plano, ser-lhe-a cobrada à taxa de transporte excedente por km 
rodado, cujo preço terá por base a tabela de frete vigente à época do óbito.
 7.5-A área de abrangência do transporte para acompanhamento do funeral, em ônibus ou topic é de 50 (cinquenta) quilômetros 
rodados, caso ultrapasse a quilometragem ora pactuada o (a) CONTRATANTE pagará uma taxa adicional por quilometro 
rodado.
 7.6-Na hipótese de falecimento do (a) CONTRATANTE, o presente Contrato passará aos seus dependentes, devendo ser 
obedecida à ordem de sucessão legal.
 7.7-0 (a) CONTRATANTE e seus beneficiários, näo poderão em hipótese alguma ceder a terceiros, o serviço ora contratado.
 7.8-As partes elegem o Foro da Comarca de Aquiraz - Ceará, para dirimir quaisquer dúvidas emergentes do presente contrato, 
com renúncia expressa a qualquer outro por mais privilegiado que seja.
 7.9-E por estarem às partes aqui justas e contratadas, assinam o presente contrato em 02 (duas) vias de igual teor e forma.
 
 VIII-DISCRIMINAÇÃO DOS MATERIAIS UTILIZADOS NA PRESTAÇÃO DE SERVIÇO 
 Urna mortuária estilo sextavada, envernizada, com visor, varão ou alça parreira, babado e câmara ardente, tapete, aparatos, 
vestimenta, ornamentação, kit café, translado do ônibus 50 km e do carro fúnebre até 200 km percorridos
";
        }
    }
}
