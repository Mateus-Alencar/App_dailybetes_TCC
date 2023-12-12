using ProjetoBase.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;




namespace App_dailybetes3.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Configuracoes : ContentPage
    {
        Usuario User = new Usuario();
        public Configuracoes()
        {
            InitializeComponent();
            label_nome.Text = "" + Usuario.Email.ToString();
        }

        private void Tb_visaogeral(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VisaoGeral());
        }
        private void Tb_calendario(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Agenda());
        }
        private void Tb_sintomas(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Notas());
        }
        private void Tb_glicemia(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Glicemia());
        }
        private void Tb_conteudo(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Conteudo());
        }
        //Menu
        private void Btn_VisaoGeral(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VisaoGeral());
        }
        private void Btn_Agenda(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Agenda());
        }
        private void Btn_Glicemia(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Glicemia());
        }
        private void Btn_Conteudo(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Conteudo());
        }
        private void Btn_Refeicoes(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Refeicoes());
        }
        private void Btn_Uploads(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Uploads());
        }
        private void Btn_Sintomas(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Notas());
        }
        private void Btn_Insulina(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insulina());
        }
        private void Btn_AjudaEFeedback(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AjudaEFeedback());
        }
        private void Btn_Perfil(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Configuracoes());
        }
        private void Btn_sair(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
        private void Abrir_menu(object sender, EventArgs e)
        {
            frame_menu.IsVisible = true;
            coverLayout.IsVisible = true;
        }
        private void Fechar_menu(object sender, EventArgs e)
        {
            frame_menu.IsVisible = false;
            coverLayout.IsVisible = false;
        }

        private void Gerar_pdf_glicemia(object sender, EventArgs e)
        {
            //itext
            //string nomeArquivo = @"\teste.pdf";
            //FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create);
            //Document doc = new Document(PageSize.A4);
            //PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF);
            //
            //doc.Close();
            //doc.Close();

            //Aspose.pdf
            //     Document doc = new Document(PageSize.A4);
            //     doc.SetMargins(40, 40, 40, 80);
            //     doc.AddCreationDate();
            //     string caminho = @"C:\Users\anton\Desktop\Projetos\projeto
            //     Borsari&Borsari\x\Relatorios\" + "CONTRATO.pdf";
            // PdfWriter writer = PdfWriter.GetInstance(doc, new
            // FileStream(caminho, FileMode.Create));
            //

            //itext2
            //Document document = new Document(PageSize.A4);
            //document.SetMargins(3, 2, 3, 2);
            //PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(
            //    Directory.GetCurrentDirectory() + "\\NomeArquivo.pdf", FileMode.Create));
            //document.Open();
            //document.Close();

            //SyncFusion.xamarin.Pdf
            //Create a new PDF document.
            //     PdfDocument document = new PdfDocument();
            //     //Add a page to the document.
            //     PdfPage page = document.Pages.Add();
            //     //Create PDF graphics for the page.
            //     PdfGraphics graphics = page.Graphics;
            //     //Set the standard font.
            //     PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            //     //Draw the text.
            //     graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));
            //     //Save the document to the stream.
            //     MemoryStream stream = new MemoryStream();
            //     document.Save(stream);
            //     //Close the document.
            //     document.Close(true);
            //     //Save the stream as a file in the device and invoke it for viewing.
            //     Xamarin.Forms.DependencyService.Get<SaveAndroid>().SaveAndView("Output.pdf", "application / pdf", stream);

            Navigation.PushAsync(new Relatorio_glicemia());
        }

        private void Gerar_pdf_refeicoes(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Relatorio_refeicoes());
        }

        private void Gerar_pdf_insulina(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Relatorio_insulina());
        }
    }
}