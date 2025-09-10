using MauiAppMinhasCompras.Models;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MauiAppMinhasCompras.Resources.Views
{
    public partial class Relatorio : ContentPage
    {
        ObservableCollection<Produto> lista = new ObservableCollection<Produto>();

        public Relatorio()
        {
            InitializeComponent();

            lst_relatorio.ItemsSource = lista;

           
            dt_inicio.Date = DateTime.Now.AddDays(-7);
            dt_fim.Date = DateTime.Now;
        }

        private async void BtnFiltrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                lista.Clear();

                DateTime inicio = dt_inicio.Date;
                DateTime fim = dt_fim.Date.AddDays(1).AddTicks(-1); 

                List<Produto> dados = await App.Db.GetByPeriod(inicio, fim);

                dados.ForEach(i => lista.Add(i));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}