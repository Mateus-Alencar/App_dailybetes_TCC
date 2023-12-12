using App_dailybetes3.Classes;
using ProjetoBase.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.IO;

namespace App_dailybetes3.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Relatorio_refeicoes : ContentPage
    {
        Usuario User = new Usuario();
        ObservableCollection<Obj_relatorio_refeicao> relatorio = new ObservableCollection<Obj_relatorio_refeicao>();
        public Relatorio_refeicoes()
        {
            InitializeComponent();
            User.Consulta_tabela_refeicoes_relatorio();
            CVLista.ItemsSource = relatorio;
            for (int i = 0; i < User.vl_refeicao.Count; i++)
            {
                relatorio.Add(new Obj_relatorio_refeicao { refeicao = User.vl_refeicao[i].ToString(), data = User.vl_data_refeicao[i], hora = User.vl_hora_refeicao[i] });
            }
        }

        private async void GeneratePDFButton_Clicked(object sender, EventArgs e)
        {

            // Gere o PDF em memória
            using (var ms = new MemoryStream())
            {
                var writer = new PdfWriter(ms);
                var pdf = new PdfDocument(writer);
                var document = new Document(pdf);
                document.Add(new Paragraph("   Resultado              Data                  Horário"));
                // Adicione conteúdo ao PDF (dados fictícios)
                for (int i = 0; i < User.vl_refeicao.Count; i++)
                {
                    document.Add(new Paragraph("        " + User.vl_hora_refeicao[i] + "             " + User.vl_data_refeicao[i] + "           " + User.vl_refeicao[i]));
                }

                document.Close();

                // Salve o PDF em um local temporário
                string tempFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Relatório_refeições.pdf");
                File.WriteAllBytes(tempFilePath, ms.ToArray());

                try
                {
                    // Compartilhe o PDF e depois exclua o arquivo temporário
                    await Share.RequestAsync(new ShareFileRequest
                    {
                        File = new ShareFile(tempFilePath),
                        Title = "Compartilhar PDF"
                    });

                    // Exclua o arquivo temporário
                    File.Delete(tempFilePath);
                }
                catch (Exception ex)
                {
                    // Lidar com erros de compartilhamento
                    await DisplayAlert("Erro", "Ocorreu um erro ao compartilhar o PDF: " + ex.Message, "OK");
                }
            }
        }
    }
}