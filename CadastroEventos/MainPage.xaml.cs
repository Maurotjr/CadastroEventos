using CadastroEventos.Models;

namespace CadastroEventos
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new Evento();
            tpInicio.PropertyChanged += OnInicioTimeChanged;
        }

        private void OnInicioTimeChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TimePicker.Time) && dpInicio != null && dpTermino != null)
            {
                // Verifica se as datas de início e término são iguais
                if (dpInicio.Date == dpTermino.Date)
                {
                    // Ajusta o horário de término se estiver antes do início
                    if (tpTermino.Time < tpInicio.Time)
                    {
                        tpTermino.Time = tpInicio.Time;
                    }
                }
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var evento = (Evento)BindingContext;

            // Navegar para a página de resumo passando o evento como BindingContext
            var resumoPage = new ResumoEventoPage
            {
                BindingContext = evento
            };
            await Navigation.PushAsync(resumoPage);
        }
                               
    }
}