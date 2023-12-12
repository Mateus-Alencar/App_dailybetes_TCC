using App_dailybetes3.Classes;
using ProjetoBase.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_dailybetes3.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insulina : ContentPage
    {
        Usuario User = new Usuario();
        ObservableCollection<Lista_insulina_obj> valores_insulina = new ObservableCollection<Lista_insulina_obj>();
        ObservableCollection<Lista_insulina_obj2> valores_insulina2 = new ObservableCollection<Lista_insulina_obj2>();
        public Insulina()
        {
            InitializeComponent();
            User.Consulta_insulina();
            User.Consulta_insulina_diaria();
            if (User.insulina1.Count > 0)
            {
                CVLista.ItemsSource = valores_insulina;

                for (int i = 0; i < User.insulina1.Count; i++)
                {
                    valores_insulina.Add(new Lista_insulina_obj { insulina = User.insulina1[i].ToString(), data_insulina = User.insulina_data[i].ToString() });
                }
            }
            else
            {
                stack_adicionadas_hoje.HeightRequest = 0;
            }

            if (User.insulina2.Count > 0)
            {
                CVLista2.ItemsSource = valores_insulina2;
                for (int i = 0; i < User.insulina2.Count; i++)
                {
                    valores_insulina2.Add(new Lista_insulina_obj2 { insulina2 = User.insulina2[i].ToString(), data_insulina2 = User.Insulina_data2[i].ToString() });
                }
            }
            else
            {
                stack_insulinas.HeightRequest = 0;
            }

        }
        //barra de navegação entre as páginas
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

        private void Sv_insulina(object sender, EventArgs e)
        {
            if (entry_insulina_manha.Text == null)
            {
                DisplayAlert("Aviso", "Inserir os dados corretamente", "OK");
            }
            else
            {
                User.Cadastrar_insulina(entry_insulina_manha.Text.ToString());
                entry_insulina_manha.Text = null;
                Navigation.PushAsync(new Insulina());
            }
        }
    }
}