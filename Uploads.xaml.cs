using App_dailybetes3.Classes;
using ProjetoBase.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace App_dailybetes3.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Uploads : ContentPage
    {
        public ImageSource Image { get; private set; }
        public string Text { get; private set; }
        Usuario User = new Usuario();
        ObservableCollection<Uploads_list_object> uploads_obj = new ObservableCollection<Uploads_list_object>();
        ObservableCollection<Uploads_list_object2> uploads_obj2 = new ObservableCollection<Uploads_list_object2>();
        public Uploads()
        {
            InitializeComponent();
            User.Consulta_arquivos_diarios();
            User.Consulta_arquivos();
            Function_init();

        }
        public void Function_init()
        {
            if (User.arquivos_diarios.Count > 0)
            {
                CVLista_uploads_diaria.ItemsSource = uploads_obj;

                for (int i = 0; i < User.arquivos_diarios.Count; i++)
                {
                    uploads_obj.Add(new Uploads_list_object { upload = User.arquivos_diarios[i], data = User.arquivos_diarios_data[i], link = User.caminho_arquivo1[i] });
                }
            }
            else
            {
                lista_up_h.HeightRequest = 0;
            }

            if (User.arquivos.Count > 0)
            {
                CVLista_uploads.ItemsSource = uploads_obj2;

                for (int i = 0; i < User.arquivos.Count; i++)
                {
                    uploads_obj2.Add(new Uploads_list_object2 { upload2 = User.arquivos[i], data2 = User.arquivos_data[i], link2 = User.caminho_arquivo2[i] });
                }
            }
            else
            {
                lista_up_h2.HeightRequest = 0;
            }
        }

        private void Selecionar_arquivo(object sender, EventArgs e)
        {

            var options = new PickOptions
            {
                PickerTitle = "Please select a file",
            };

            var resultado = PickAndShow(options);
        }
        private async Task<FileResult> PickAndShow(PickOptions options)
        {
            try
            {
                var result = await FilePicker.PickAsync(options);
                if (result != null)
                {
                    Text = result.FullPath;
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))

                    {
                        var stream = await result.OpenReadAsync();
                        Image = ImageSource.FromStream(() => stream);
                        Salvar_caminho_arquivo(Text.ToString(), result.FileName.ToString());
                        Function_init();
                    }
                }

                return result;
            }
            catch (Exception)
            {
                // The user canceled or something went wrong
            }

            return null;
        }
        public void Salvar_caminho_arquivo(string caminho, string nome_arquivo)
        {
            string curFile = caminho;
            Console.WriteLine(File.Exists(curFile) ? "File exists." : "File does not exist.");
            string arquivo_existente = curFile.ToString();
            User.Cadastrar_arquivos(arquivo_existente, nome_arquivo);
            Teste();
        }
        public void Teste()
        {
            Navigation.PushAsync(new Uploads());
        }

        private void Abrir_arquivo(object sender, EventArgs e)
        {

            Console.WriteLine(Button.CommandParameterProperty);
        }

        private void Tb_visaogeral(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VisaoGeral());
        }

        private void Tb_calendario(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Agenda());
        }

        private void Tb_notas(object sender, EventArgs e)
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

        private void AbrirImagemTelaCheia(object sender, EventArgs e)
        {
            TelaCheia.IsVisible = true;
            FrameImagemTelaCheia.IsVisible = true;
            ImagemTelaCheia.IsVisible = true;
            var tappedImage = (Image)sender;
            ImagemTelaCheia.Source = tappedImage.Source;
            ImagemTelaCheia.IsVisible = true;
        }

        private void FecharImagemTelaCheia(object sender, EventArgs e)
        {
            TelaCheia.IsVisible = false;
            FrameImagemTelaCheia.IsVisible = false;
            ImagemTelaCheia.IsVisible = false;
        }
    }
}

//Um arquivo de texto pode ser escrito usando o método File.WriteAllText:
//File.WriteAllText(fileName, text);

//Um arquivo de texto pode ser lido usando o método File.ReadAllText:
//string text = File.ReadAllText(fileName);

//Além disso, o método File.Exists determina se o arquivo especificado existe:
//bool doesExist = File.Exists(fileName);