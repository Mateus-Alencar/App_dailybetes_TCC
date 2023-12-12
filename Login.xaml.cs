using App_dailybetes3.Models;
using ProjetoBase.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_dailybetes3.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        //Iniciar a conexão com o bamco (workbench)
        Conexao Cn = new Conexao();
        Usuario User = new Usuario();

        public string Usuario_online;
        public Login()
        {
            InitializeComponent();

            if (Cn.Conecta()) //Verificar a conexao
            {
                msg_erro.Text = "Conexão realizada com sucesso";
            }
            else
            {
                msg_erro.Text = Cn.StatusConexao;
            }
        }

        private void Btn_tela_cadastro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Cadastro());
        }

        private void Btm_entrar(object sender, EventArgs e)
        {
            Animacao();

            Usuario_online = entry_nome.Text.ToString();

            if (User.Consulta(Usuario_online.ToString(), entry_senha.Text.ToString()))
            {
                Usuario.Email = Usuario_online;
                User.Pesquisar_id_usuario();

                Navigation.PushAsync(new VisaoGeral());
            }
            else
            {
                msg_erro.Text = "erro";
                DisplayAlert("Erro", "Ocorreu um erro, tente novamente", "OK");
            }
        }
        public async void Animacao()
        {
            if (entry_nome.Text == null || entry_senha.Text == null) // animação (verificar se os campos estão preenchidos)
            {
                entry_nome.Placeholder = "Email(*)";
                entry_senha.Placeholder = "Senha(*)";
                uint timeout = 50;
                await botao_entrar.TranslateTo(-15, 0, timeout);
                await botao_entrar.TranslateTo(15, 0, timeout);
                await botao_entrar.TranslateTo(-10, 0, timeout);
                await botao_entrar.TranslateTo(10, 0, timeout);
                await botao_entrar.TranslateTo(-5, 0, timeout);
                await botao_entrar.TranslateTo(5, 0, timeout);
                botao_entrar.TranslationX = 0;
            }
        }
    }
}