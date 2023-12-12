using App_dailybetes3.Classes;
using ProjetoBase.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_dailybetes3.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Agenda : ContentPage
    {
        Usuario User = new Usuario();
        ObservableCollection<Compromissos_objects> tarefa = new ObservableCollection<Compromissos_objects>();
        public string data_selecionada = "0000-00-00";
        public string hora;

        public Agenda()
        {
            InitializeComponent();
            User.Consulta_num_compromissos_hoje();
            num_compromissos_hoje.Text = Usuario.Num_compromissos + " compromissos";
            BindingContext = this;
            CarregarLista();
        }
        public void CarregarLista()
        {
            User.Consulta_compromissos();

            CVLista.ItemsSource = tarefa;
            for (int i = 0; i < User.tarefas.Count; i++)
            {
                tarefa.Add(new Compromissos_objects { Tarefa = User.tarefas[i].ToString(), Hora = (User.tarefas_data[i] + " " + User.tarefas_hora[i]).ToString().Substring(0, 16) });
            }
        }

        private void Frame_add_compromisso(object sender, EventArgs e)
        {
            frame_compromisso.IsVisible = true;
            coverLayout2.IsVisible = true;
        }
        private void Fechar_frame_compromisso(object sender, EventArgs e)
        {
            frame_compromisso.IsVisible = false;
            coverLayout2.IsVisible = false;
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
        public void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            data_selecionada = e.NewDate.Year + "-" + e.NewDate.Month + "-" + e.NewDate.Day;
        }
        private void Btm_Salvar_compromisso(object sender, EventArgs e)
        {
            if (entry_hora.Text == null || entry_compromisso.Text == null)
            {
                DisplayAlert("Aviso", "Inserir os dados corretamente", "OK");
            }
            else
            {
                if (entry_hora.Text != null)
                {
                    hora = entry_hora.Text.ToString().Substring(0, 2) + ":" + entry_hora.Text.ToString().Substring(2, 2) + ":00";
                }
                else
                {
                    hora = "00:00:00";
                }

                string data = data_selecionada;
                string compromisso = entry_compromisso.Text.ToString();
                User.Cadastrar_compromisso(hora, data, compromisso);
                User.Consulta_num_compromissos_hoje();
                num_compromissos_hoje.Text = Usuario.Num_compromissos + " compromissos";
                Fechar_frame_compromisso(sender, e);
                entry_compromisso.Text = null;
                entry_hora.Text = null;
                Navigation.PushAsync(new Agenda());
            }
        }
    }
}