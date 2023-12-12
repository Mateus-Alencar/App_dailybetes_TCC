using SkiaSharp;
using System;
using System.Collections.Generic;
using Entry = Microcharts.ChartEntry;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App_dailybetes3.Models;
using ProjetoBase.Models;
using System.Collections.ObjectModel;
using App_dailybetes3.Classes;

namespace App_dailybetes3.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VisaoGeral : ContentPage
    {
        ObservableCollection<Compromissos_objects2> compromissos_obj2 = new ObservableCollection<Compromissos_objects2>();
        ObservableCollection<Refeicoes_obj> refeicoes_obj = new ObservableCollection<Refeicoes_obj>();

        Usuario User = new Usuario();
        public int num_grafico = 0;

        public VisaoGeral()
        {
            InitializeComponent();
            User.Consulta_tabela_glicemia_diariamente();
            User.Consulta_compromissos_hoje();
            int contador = User.tarefas.Count;
            if (contador == 0)
            {
                stack_carousel1.HeightRequest = 0;
            }
            else
            {
                for (int i = 0; i < User.tarefas.Count; i++)
                {
                    compromissos_obj2.Add(new Compromissos_objects2 { Tarefa2 = ((User.tarefas[i].ToString())), Hora2 = User.tarefas_hora[i].ToString().Substring(0, 5) });
                }
            }

            Carousel1.ItemsSource = compromissos_obj2;

            User.Consulta_refeicoes();
            int contador2 = User.dic_data_refeicao.Count;
            if (contador2 == 0)
            {
                stack_carousel2.HeightRequest = 0;
            }
            else
            {
                for (int i = 0; i < User.refeicoes_descricao.Count; i++)
                {
                    refeicoes_obj.Add(new Refeicoes_obj { hora_ref = ((User.refeicoes_hora[i].ToString().Substring(0, 5))), descricao = User.refeicoes_descricao[i].ToString() });
                }
            }

            Carousel2.ItemsSource = refeicoes_obj;

            List<Entry> entries1 = new List<Entry>
            {
                new Entry(Int32.Parse(User.valores_glicemia_diariamente[0]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label ="8h",
                    ValueLabel = User.valores_glicemia_diariamente[0].ToString()
                },
                new Entry(Int32.Parse(User.valores_glicemia_diariamente[1]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label ="10h",
                    ValueLabel = User.valores_glicemia_diariamente[1].ToString()
                },
                new Entry(Int32.Parse(User.valores_glicemia_diariamente[2]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label ="11h",
                    ValueLabel = User.valores_glicemia_diariamente[2].ToString()
                },
                new Entry(Int32.Parse(User.valores_glicemia_diariamente[3]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label ="12h",
                    ValueLabel = User.valores_glicemia_diariamente[3].ToString()
                },new Entry(Int32.Parse(User.valores_glicemia_diariamente[4]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label ="18h",
                    ValueLabel = User.valores_glicemia_diariamente[4].ToString()
                },new Entry(Int32.Parse(User.valores_glicemia_diariamente[5]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label ="20h",
                    ValueLabel = User.valores_glicemia_diariamente[5].ToString()
                },
            };

            User.Consulta_tabela_glicemia_semanalmente();
            List<Entry> entries2 = new List<Entry>
            {
                new Entry(Int32.Parse(User.valores_glicemia_semanalmente[0]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label ="SEG",
                    ValueLabel = User.valores_glicemia_semanalmente[0].ToString()
                },
                new Entry(Int32.Parse(User.valores_glicemia_semanalmente[1]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label ="TER",
                    ValueLabel = User.valores_glicemia_semanalmente[1].ToString()
                },
                new Entry(Int32.Parse(User.valores_glicemia_semanalmente[2]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label ="QUA",
                    ValueLabel = User.valores_glicemia_semanalmente[2].ToString()
                },
                new Entry(Int32.Parse(User.valores_glicemia_semanalmente[3]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label ="QUI",
                    ValueLabel = User.valores_glicemia_semanalmente[3].ToString()
                },new Entry(Int32.Parse(User.valores_glicemia_semanalmente[4]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label ="SEX",
                    ValueLabel = User.valores_glicemia_semanalmente[4].ToString()

                },new Entry(Int32.Parse(User.valores_glicemia_semanalmente[5]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label ="SAB",
                    ValueLabel = User.valores_glicemia_semanalmente[5].ToString()
                },
            };

            User.Consulta_tabela_glicemia_mensalmente();
            List<Entry> entries3 = new List<Entry>
            {
                new Entry(Int32.Parse(User.valores_glicemia_mensalmente[0]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label = "7d",
                    ValueLabel = User.valores_glicemia_mensalmente[0].ToString()
                },
                new Entry(Int32.Parse(User.valores_glicemia_mensalmente[1]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label = "14d",
                    ValueLabel = User.valores_glicemia_mensalmente[1].ToString()
                },
                new Entry(Int32.Parse(User.valores_glicemia_mensalmente[2]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label = "21d",
                    ValueLabel = User.valores_glicemia_mensalmente[2].ToString()
                },
                new Entry(Int32.Parse(User.valores_glicemia_mensalmente[3]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label = "28d",
                    ValueLabel = User.valores_glicemia_mensalmente[3].ToString()
                },new Entry(Int32.Parse(User.valores_glicemia_mensalmente[4]))
                {
                    Color = SKColor.Parse("#DC143C"),
                    Label = "35d",
                    ValueLabel = User.valores_glicemia_mensalmente[4].ToString() 
                }
            };

            //         graficos_por_periodo = new ObservableCollection<Graficos_por_periodo>
            //         {
            //             new Graficos_por_periodo{periodo = "Diariamente"},
            //             new Graficos_por_periodo{periodo = "Semanalmente"},
            //             new Graficos_por_periodo{periodo = "Mensalmente"}
            //         };
            //
            //         Carrousel.ItemsSource = graficos_por_periodo;

            //label_gr1.Text = "8h";
            //label_gr2.Text = "10h";
            //label_gr3.Text = "11h";
            //label_gr4.Text = "12h";
            //label_gr5.Text = "18h";
            //label_gr6.Text = "20h";

            grafico1.Chart = new Microcharts.LineChart() { Entries = entries1, BackgroundColor = SKColors.Transparent, PointSize = 20, LabelOrientation = Microcharts.Orientation.Horizontal, ValueLabelOrientation = Microcharts.Orientation.Horizontal, LabelTextSize = 22, Margin = 30, LineMode = Microcharts.LineMode.Straight, MinValue = 0, MaxValue = 300 };
            grafico2.Chart = new Microcharts.LineChart() { Entries = entries2, BackgroundColor = SKColors.Transparent, PointSize = 20, LabelOrientation = Microcharts.Orientation.Horizontal, ValueLabelOrientation = Microcharts.Orientation.Horizontal, LabelTextSize = 22, Margin = 30, LineMode = Microcharts.LineMode.Straight, MinValue = 0, MaxValue = 300 };
            grafico3.Chart = new Microcharts.LineChart() { Entries = entries3, BackgroundColor = SKColors.Transparent, PointSize = 20, LabelOrientation = Microcharts.Orientation.Horizontal, ValueLabelOrientation = Microcharts.Orientation.Horizontal, LabelTextSize = 22, Margin = 30, LineMode = Microcharts.LineMode.Straight, MinValue = 0, MaxValue = 300 };

            //Grafico.Chart = new Microcharts.LineChart() { Entries = entries1, BackgroundColor = SKColors.Transparent, PointSize = 20, Margin = 3, LineMode = Microcharts.LineMode.Straight, MinValue = 0, MaxValue = 300 };
            var date_now = DateTime.Now;
            lb_data.Text = "Hoje " + date_now.Day + "/" + date_now.Month;
            lb_hora.Text = String.Format("Hoje {0:t}", date_now);
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

        private void Proximo_grafico(object sender, EventArgs e)
        {
            num_grafico++;
            if (num_grafico > 2)
            {
                num_grafico = 0;
            }

            if (num_grafico == 0)
            {
                periodo.Text = "Diariamente";
                Animation2();
                grafico1.IsVisible = true;
                grafico2.IsVisible = false;
                grafico3.IsVisible = false;
                //label_gr1.Text = "8h";
                //label_gr2.Text = "10h";
                //label_gr3.Text = "11h";
                //label_gr4.Text = "12h";
                //label_gr5.Text = "18h";
                //label_gr6.Text = "20h";

            }
            if (num_grafico == 1)
            {
                periodo.Text = "Semanalmente";
                Animation2();
                grafico1.IsVisible = false;
                grafico2.IsVisible = true;
                grafico3.IsVisible = false;
                //label_gr1.Text = "SEG";
                //label_gr2.Text = "";
                //label_gr3.Text = "QUA";
                //label_gr4.Text = "";
                //label_gr5.Text = "SEX";
                //label_gr6.Text = "";
            }
            if (num_grafico == 2)
            {
                periodo.Text = "Mensalmente";
                Animation2();
                grafico1.IsVisible = false;
                grafico2.IsVisible = false;
                grafico3.IsVisible = true;
                //label_gr1.Text = "7d";
                //label_gr2.Text = "14d";
                //label_gr3.Text = "21d";
                //label_gr4.Text = "28d";
                //label_gr5.Text = "35d";
                //label_gr6.Text = "";
            }
        }

        private void Ultimo_grafico(object sender, EventArgs e)
        {
            num_grafico--;
            if (num_grafico < 0)
            {
                num_grafico = 2;
            }

            if (num_grafico == 0)
            {
                periodo.Text = "Diariamente";
                Animation();
                grafico1.IsVisible = true;
                grafico2.IsVisible = false;
                grafico3.IsVisible = false;
                //label_gr1.Text = "8h";
                //label_gr2.Text = "10h";
                //label_gr3.Text = "11h";
                //label_gr4.Text = "12h";
                //label_gr5.Text = "18h";
                //label_gr6.Text = "20h";
            }
            if (num_grafico == 1)
            {
                periodo.Text = "Semanalmente";
                Animation();
                grafico1.IsVisible = false;
                grafico2.IsVisible = true;
                grafico3.IsVisible = false;
                //label_gr1.Text = "SEG";
                //label_gr2.Text = "";
                //label_gr3.Text = "QUA";
                //label_gr4.Text = "";
                //label_gr5.Text = "SEX";
                //label_gr6.Text = "";
            }
            if (num_grafico == 2)
            {
                periodo.Text = "Mensalmente";
                Animation();
                grafico1.IsVisible = false;
                grafico2.IsVisible = false;
                grafico3.IsVisible = true;
                //label_gr1.Text = "7d";
                //label_gr2.Text = "14d";
                //label_gr3.Text = "21d";
                //label_gr4.Text = "28d";
                //label_gr5.Text = "35d";
                //label_gr6.Text = "";
            }
        }
        public async void Animation()
        {
            uint timeout = 250;
            await frame_grafico.TranslateTo(-400, 0, timeout);

            frame_grafico.TranslationX = 0;
        }
        public async void Animation2()
        {
            uint timeout = 250;
            await frame_grafico.TranslateTo(400, 0, timeout);
            frame_grafico.TranslationX = 0;
        }

        private void Nv_agenda(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Agenda());
        }

        private void Nv_refeicoes(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Refeicoes());
        }
    }
}


//if (contador == 1) {
//    compromissos_obj2 = new ObservableCollection<Compromissos_objects2> {
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[0].ToString(), Hora2 = User.tarefas_hora[0].ToString() },
//
//    };
//};
//if (contador == 2) {
//    compromissos_obj2 = new ObservableCollection<Compromissos_objects2> {
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[0].ToString(), Hora2 = User.tarefas_hora[0].ToString() },
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[1].ToString(), Hora2 = User.tarefas_hora[1].ToString() }
//
//    };
//};if (contador == 3) {
//    compromissos_obj2 = new ObservableCollection<Compromissos_objects2> {
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[0].ToString(), Hora2 = User.tarefas_hora[0].ToString() },
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[1].ToString(), Hora2 = User.tarefas_hora[1].ToString() },
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[2].ToString(), Hora2 = User.tarefas_hora[2].ToString() }
//
//    };
//};if (contador == 4) {
//    compromissos_obj2 = new ObservableCollection<Compromissos_objects2> {
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[0].ToString(), Hora2 = User.tarefas_hora[0].ToString() },
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[1].ToString(), Hora2 = User.tarefas_hora[1].ToString() },
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[2].ToString(), Hora2 = User.tarefas_hora[2].ToString() },
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[3].ToString(), Hora2 = User.tarefas_hora[3].ToString() }
//
//    };
//};if (contador == 5) {
//    compromissos_obj2 = new ObservableCollection<Compromissos_objects2> {
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[0].ToString(), Hora2 = User.tarefas_hora[0].ToString() },
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[1].ToString(), Hora2 = User.tarefas_hora[1].ToString() },
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[2].ToString(), Hora2 = User.tarefas_hora[2].ToString() },
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[3].ToString(), Hora2 = User.tarefas_hora[3].ToString() },
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[4].ToString(), Hora2 = User.tarefas_hora[4].ToString() }
//
//    };
//};if (contador == 6) {
//    compromissos_obj2 = new ObservableCollection<Compromissos_objects2> {
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[0].ToString(), Hora2 = User.tarefas_hora[0].ToString() },
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[1].ToString(), Hora2 = User.tarefas_hora[1].ToString() },
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[2].ToString(), Hora2 = User.tarefas_hora[2].ToString() },
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[3].ToString(), Hora2 = User.tarefas_hora[3].ToString() },
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[4].ToString(), Hora2 = User.tarefas_hora[4].ToString() },
//        new Compromissos_objects2 { Tarefa2 = User.tarefas[5].ToString(), Hora2 = User.tarefas_hora[5].ToString() }
//
//    };