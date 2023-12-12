using App_dailybetes3.Classes;
using App_dailybetes3.Paginas;
using ProjetoBase.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_dailybetes3.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notas : ContentPage
    {
        Usuario User = new Usuario();
        ObservableCollection<Lista_notas> notas = new ObservableCollection<Lista_notas>();
        ObservableCollection<Lista_notas2> notas2 = new ObservableCollection<Lista_notas2>();
        public Notas()
        {
            InitializeComponent();
            User.Consulta_notas();
            User.Consulta_todas_notas();
            CarregarListaNotas();
        }
        public void CarregarListaNotas()
        {
            User.Consulta_notas();
            User.Consulta_todas_notas();

            if (User.titulo_nota.Count > 0)
            {
                CVLista.ItemsSource = notas;

                for (int i = 0; i < User.titulo_nota.Count; i++)
                {
                    notas.Add(new Lista_notas { adic_hoje = User.titulo_nota[i].ToString(), data1 = User.nota_data1[i].ToString() });
                }
            }
            else
            {
                stack_adicionadas_hoje.HeightRequest = 0;
            }

            if (User.titulo_nota2.Count > 0)
            {
                CVLista2.ItemsSource = notas2;
                for (int i = 0; i < User.titulo_nota2.Count; i++)
                {
                    notas2.Add(new Lista_notas2 { todas_notas = User.titulo_nota2[i].ToString(), data2 = User.nota_data2[i].ToString() });
                }
            }
            else
            {
                stack_notas.HeightRequest = 0;
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
        private void Salvar_nota(object sender, EventArgs e)
        {

            if (titulo_nota.Text == null || texto_nota.Text == null)
            {
                DisplayAlert("Aviso", "Inserir os dados corretamente", "OK");
            }
            else
            {
                string titulo = titulo_nota.Text.ToString();
                string texNota = texto_nota.Text.ToString();
                User.Cadastrar_notas(titulo, texNota);
                titulo_nota.Text = "";
                texto_nota.Text = "";
                Navigation.PushAsync(new Notas());
            }
        }



        private void Abrir_menu_nota1(object sender, EventArgs e)
        {

        }

        private void Abrir_menu_nota2(object sender, EventArgs e)
        {

        }
    }
}

//      if (User.titulo_nota.Count > 0)
//      {
//          var listaTitulosNotas = new List<string> { };
//          foreach (String strkey in User.titulo_nota)
//          {
//              listaTitulosNotas.Add(strkey);
//          }
//          Carousel.ItemsSource = listaTitulosNotas;
//      }
//      else
//      {
//          stack_adicionadas_hoje.HeightRequest = 0;
//      }
//
//      if (User.dic_titulo_nota2.Count > 0)
//      {
//          var listaTitulosNotas2 = new List<string> { };
//          foreach (String strkey in User.dic_titulo_nota2)
//          {
//              listaTitulosNotas2.Add(strkey);
//          }
//          Carousel.ItemsSource = listaTitulosNotas2;
//      }
//      else
//      {
//          stack_notas.HeightRequest = 0;
//      }




