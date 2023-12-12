using App_dailybetes3.Models;
using ProjetoBase.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_dailybetes3.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        Usuario User = new Usuario();
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Btm_voltar_login(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }

        public async void Btm_cadastrar_usuario(object sender, EventArgs e)
        {
            if (entry_senha_cadastrar.Text == entry_senha_confirm.Text)
            {
                User.CadastrarUsuarios(entry_nome_cadastrar.Text, entry_senha_cadastrar.Text);

                if (User.Usuario_existente > 0)
                {
                    await DisplayAlert("Aviso", "Usuário já existente", "OK");
                    User.Usuario_existente = 0;
                }
                else
                {
                    await Navigation.PushAsync(new Login());
                }

            }
            else
            {
                uint timeout = 50;
                await botao.TranslateTo(-15, 0, timeout);
                await botao.TranslateTo(15, 0, timeout);
                await botao.TranslateTo(-10, 0, timeout);
                await botao.TranslateTo(10, 0, timeout);
                await botao.TranslateTo(-5, 0, timeout);
                await botao.TranslateTo(5, 0, timeout);
                botao.TranslationX = 0;
                entry_senha_cadastrar.Placeholder = "Email(*)";
                entry_senha_confirm.Placeholder = "Senha(*)";
            }
        }
    }
}