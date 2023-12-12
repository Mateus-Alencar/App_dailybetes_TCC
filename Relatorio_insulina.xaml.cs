using App_dailybetes3.Classes;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using ProjetoBase.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using iText.Layout;

namespace App_dailybetes3.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Relatorio_insulina : ContentPage
    {
        Usuario User = new Usuario();
        ObservableCollection<Obj_relatorio_insulina> relatorio = new ObservableCollection<Obj_relatorio_insulina>();
        public Relatorio_insulina()
        {
            InitializeComponent();
            User.Consulta_tabela_insulina_relatorio();
            CVLista.ItemsSource = relatorio;
            for (int i = 0; i < User.vl_insulina.Count; i++)
            {
                relatorio.Add(new Obj_relatorio_insulina { nivel_insulina = User.vl_insulina[i].ToString(), data = User.vl_data_insulina[i] });
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
                document.Add(new Paragraph("   Resultado              Data                  "));
                // Adicione conteúdo ao PDF (dados fictícios)
                for (int i = 0; i < User.vl_insulina.Count; i++)
                {
                    document.Add(new Paragraph("         " + User.vl_insulina[i] + "                      " + User.vl_data_insulina[i] + "           "));
                }

                document.Close();

                // Salve o PDF em um local temporário
                string tempFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Relatório_insulina.pdf");
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