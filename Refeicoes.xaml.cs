using ProjetoBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_dailybetes3.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Refeicoes : ContentPage
    {
        Usuario User = new Usuario();
        public string hora_refeicao;
        public Refeicoes()
        {
            InitializeComponent();
            User.Consulta_refeicoes();
            Selecionar_refeicoes_salvas();
        }
        public void Selecionar_refeicoes_salvas()
        {
            foreach (String strKey in User.dic_data_refeicao.Keys)
            {
                if (strKey == "08:00:00")
                {
                    cf.Text = User.dic_data_refeicao[strKey];
                }
                if (strKey == "10:00:00")
                {
                    lanche.Text = User.dic_data_refeicao[strKey];
                }
                if (strKey == "11:30:00")
                {
                    almoco.Text = User.dic_data_refeicao[strKey];
                }
                if (strKey == "16:30:00")
                {
                    ct.Text = User.dic_data_refeicao[strKey];
                }
                if (strKey == "20:00:00")
                {
                    jantar.Text = User.dic_data_refeicao[strKey];
                }

            }
        }
        //Tabbed Page
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

        private void Primeira_refeicao(object sender, EventArgs e)
        {
            if (cf.Text == "Adicionar refeição")
            {
                frame_refeicao.IsVisible = true;
                coverLayout2.IsVisible = true;
                hora_refeicao = "08:00";
                horario_refeicao.Text = hora_refeicao;
            }
        }
        private void Segunda_refeicao(object sender, EventArgs e)
        {
            if (lanche.Text == "Adicionar refeição")
            {
                frame_refeicao.IsVisible = true;
                coverLayout2.IsVisible = true;
                hora_refeicao = "10:00";
                horario_refeicao.Text = hora_refeicao;
            }
        }
        private void Terceira_refeicao(object sender, EventArgs e)
        {
            if (almoco.Text == "Adicionar refeição")
            {
                frame_refeicao.IsVisible = true;
                coverLayout2.IsVisible = true;
                hora_refeicao = "11:30";
                horario_refeicao.Text = hora_refeicao;
            }
        }
        private void Quarta_refeicao(object sender, EventArgs e)
        {
            if (ct.Text == "Adicionar refeição")
            {
                frame_refeicao.IsVisible = true;
                coverLayout2.IsVisible = true;
                hora_refeicao = "16:30";
                horario_refeicao.Text = hora_refeicao;
            }
        }
        private void Quinta_refeicao(object sender, EventArgs e)
        {
            if (jantar.Text == "Adicionar refeição")
            {
                frame_refeicao.IsVisible = true;
                coverLayout2.IsVisible = true;
                hora_refeicao = "20:00";
                horario_refeicao.Text = hora_refeicao;
            }
        }
        private void Fechar_frame_refeicao(object sender, EventArgs e)
        {
            frame_refeicao.IsVisible = false;
            coverLayout2.IsVisible = false;
        }

        private void Salvar_refeicao(object sender, EventArgs e)
        {
            if (entry_refeicao.Text == null)
            {
                DisplayAlert("Aviso", "Inserir os dados corretamente", "OK");
            }
            else
            {
                User.Cadastrar_refeicoes(hora_refeicao, entry_refeicao.Text.ToString());
                User.Consulta_refeicoes();
                Selecionar_refeicoes_salvas();
                frame_refeicao.IsVisible = false;
                coverLayout2.IsVisible = false;
                entry_refeicao.Text = null;
            }
        }
    }
}