using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2_ListaBrasil.Modelo;

namespace App2_ListaBrasil
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Municipios : ContentPage
	{
        //ARMAZENA A LISTA COMO UM TODO INDEPENDENTE DO FILTRO
        private List<Municipio> ListaInternaMunicipio { get; set; }
        //SO ARMAZENA A LISTA DA PESQUISA A LISTA DA BUSCA RAPIDA
        private List<Municipio> ListaFiltradaMunicipio { get; set; }

		public Municipios (Estado estado)
		{
			InitializeComponent ();
            //NO PRIMEIRO MOMENTO VAMOS CARREGAR E APRESENTAR A LISTA COMO UM TODO
            //AO DECORRER DAS BUSCAR, VAMOS COMPRAR E EXIBIR A LISTA FILTRADA
            ListaInternaMunicipio = Servico.Servico.GetMunicipio(estado.id);
            ListaMunicipios.ItemsSource = ListaInternaMunicipio;
		}

        private void BuscaRapida(object sender, TextChangedEventArgs args)
        {
            //TODA VEZ QUE O TERMO DO CAMPO FOR ALTERADO VAMOS FAZER UMA PESQUISA DENTRO DA LISTA
            //FAZENDO UMA PESQUISA USANDO O WHERE, e chama no ToList para uma nova lista
            //ListaFiltradaMunicipio.Clear();
            ListaFiltradaMunicipio = ListaInternaMunicipio.Where(a => a.nome.ToLower().Contains(args.NewTextValue.ToLower())).ToList();
            ListaMunicipios.ItemsSource = ListaFiltradaMunicipio;
        }
    }
}