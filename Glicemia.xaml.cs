using ProjetoBase.Models;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_dailybetes3.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Glicemia : ContentPage
    {
        Usuario User = new Usuario();
        public Glicemia()
        {
            InitializeComponent();

            User.Consulta_tabela_glicemia_diariamente();

            entry_glicemia_jejum.Text = User.valores_glicemia_diariamente[0].ToString();
            entry_glicemia_manha.Text = User.valores_glicemia_diariamente[1].ToString();
            entry_glicemia_an_almoco.Text = User.valores_glicemia_diariamente[2].ToString();
            entry_glicemia_dp_almoco.Text = User.valores_glicemia_diariamente[3].ToString();
            entry_glicemia_an_jantar.Text = User.valores_glicemia_diariamente[4].ToString();
            entry_glicemia_dormir.Text = User.valores_glicemia_diariamente[5].ToString();

     
            if (entry_glicemia_jejum.Text != "0")
            {
                status_glicemia_jejum.Background = Color.Green;
            }
            if (entry_glicemia_manha.Text != "0")
            {
                status_glicemia_manha.Background = Color.Green;
            }
            if (entry_glicemia_an_almoco.Text != "0")
            {
                status_glicemia_an_almoco.Background = Color.Green;
            }
            if (entry_glicemia_dp_almoco.Text != "0")
            {
                status_glicemia_dp_almoco.Background = Color.Green;
            }
            if (entry_glicemia_an_jantar.Text != "0")
            {
                status_glicemia_an_jantar.Background = Color.Green;
            }
            if (entry_glicemia_dormir.Text != "0")
            {
                status_glicemia_dormir.Background = Color.Green;
            }
        }

        private void Bt_jejum(object sender, EventArgs e)
        {
            if (entry_glicemia_jejum.Text == "0") { }
            else
            {
                int result_glicemia_jejum = Int32.Parse(entry_glicemia_jejum.Text);

                var date_now = DateTime.Now;
                string data_glicemia = "" + date_now.Year + "-" + date_now.Month + "-" + date_now.Day;
                string hora_glicemia = "08:00";

                User.Cadastrar_resultado_glicemia(hora_glicemia, data_glicemia, result_glicemia_jejum);
                if (entry_glicemia_jejum.Text != null)
                {
                    status_glicemia_jejum.Background = Color.Green;
                }
            }

        }
        private void Bt_cafe(object sender, EventArgs e)
        {
            if (entry_glicemia_manha.Text == "0") { }
            else
            {
                int result_glicemia_manha = Int32.Parse(entry_glicemia_manha.Text);

                var date_now = DateTime.Now;
                string data_glicemia = "" + date_now.Year + "-" + date_now.Month + "-" + date_now.Day;
                string hora_glicemia = "10:00";

                User.Cadastrar_resultado_glicemia(hora_glicemia, data_glicemia, result_glicemia_manha);
                if (entry_glicemia_manha.Text != null)
                {
                    status_glicemia_manha.Background = Color.Green;
                }
            }
        }
        private void Bt_an_almoco(object sender, EventArgs e)
        {
            if (entry_glicemia_an_almoco.Text == "0") { }
            else
            {
                int result_glicemia_an_almoco = Int32.Parse(entry_glicemia_an_almoco.Text);

                var date_now = DateTime.Now;
                string data_glicemia = "" + date_now.Year + "-" + date_now.Month + "-" + date_now.Day;
                string hora_glicemia = "11:30";

                User.Cadastrar_resultado_glicemia(hora_glicemia, data_glicemia, result_glicemia_an_almoco);
                if (entry_glicemia_an_almoco.Text != null)
                {
                    status_glicemia_an_almoco.Background = Color.Green;
                }
            }
        }
        private void Bt_dp_almoco(object sender, EventArgs e)
        {
            if (entry_glicemia_dp_almoco.Text == "0") { }
            else
            {
                int result_glicemia_dp_almoco = Int32.Parse(entry_glicemia_dp_almoco.Text);

                var date_now = DateTime.Now;
                string data_glicemia = "" + date_now.Year + "-" + date_now.Month + "-" + date_now.Day;
                string hora_glicemia = "12:30";

                User.Cadastrar_resultado_glicemia(hora_glicemia, data_glicemia, result_glicemia_dp_almoco);
                if (entry_glicemia_dp_almoco.Text != null)
                {
                    status_glicemia_dp_almoco.Background = Color.Green;
                }
            }
        }
        private void Bt_an_jantar(object sender, EventArgs e)
        {
            if (entry_glicemia_an_jantar.Text == "0") { }
            else
            {
                int result_glicemia_an_jantar = Int32.Parse(entry_glicemia_an_jantar.Text);

                var date_now = DateTime.Now;
                string data_glicemia = "" + date_now.Year + "-" + date_now.Month + "-" + date_now.Day;
                string hora_glicemia = "18:30";

                User.Cadastrar_resultado_glicemia(hora_glicemia, data_glicemia, result_glicemia_an_jantar);
                if (entry_glicemia_an_jantar.Text != null)
                {
                    status_glicemia_an_jantar.Background = Color.Green;
                }
            }
        }
        private void Bt_an_dormir(object sender, EventArgs e)
        {
            if (entry_glicemia_dormir.Text == "0") { }
            else
            {
                int result_glicemia_dormir = Int32.Parse(entry_glicemia_dormir.Text);

                var date_now = DateTime.Now;
                string data_glicemia = "" + date_now.Year + "-" + date_now.Month + "-" + date_now.Day;
                string hora_glicemia = "22:00";

                User.Cadastrar_resultado_glicemia(hora_glicemia, data_glicemia, result_glicemia_dormir);
                if (entry_glicemia_dormir.Text != null)
                {
                    status_glicemia_dormir.Background = Color.Green;
                }
            }
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
    }
}