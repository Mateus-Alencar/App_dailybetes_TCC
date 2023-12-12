using App_dailybetes3.Classes;
using App_dailybetes3.Models;
using ProjetoBase.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace App_dailybetes3.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Relatorio_glicemia : ContentPage
    {
        Usuario User = new Usuario();
        ObservableCollection<Obj_relatorio_glicemia> relatorio = new ObservableCollection<Obj_relatorio_glicemia>();
        public Relatorio_glicemia()
        {
            InitializeComponent();
            User.Consulta_tabela_glicemia();
            CVLista.ItemsSource = relatorio;
            for (int i = 0; i < User.vl_glicemia.Count; i++)
            {
                relatorio.Add(new Obj_relatorio_glicemia { nivel_glicemia = User.vl_glicemia[i].ToString(), data = User.vl_data_glicemia[i], hora = User.vl_hora_glicemia[i] });
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
                for (int i = 0; i < User.vl_glicemia.Count; i++)
                {
                    document.Add(new Paragraph("         " + User.vl_glicemia[i] + "                      " + User.vl_data_glicemia[i] + "           " + User.vl_hora_glicemia[i]));
                }

                document.Close();

                // Salve o PDF em um local temporário
                string tempFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Relatório_glicemia.pdf");
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