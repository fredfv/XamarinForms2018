using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            //+= CONCATENAR E ATRIBUIR
            //SOMENTE ASSIM ELE NAO ATENDE OS PADROES DE UM EVENT HANDLER 
            BOTAO.Clicked += BuscarCEP;

		}

        private void BuscarCEP(object sender, EventArgs args)
        {
            //TODO Logia do programa.
            //No Momento em que ele clicar ele precisa validar
            //Verifica se foi digitado algum valor, depois verifica o via cep service passando o cep que foi digitado

            //validar
            string cep = CEP.Text.Trim();


            if (isValidCEP(cep))
            {
                //Chamando o via CEP Assim pq foi criado como static
                //. text é o que esta na tela do cara;
                //.trim() remove os epacos tanto do inicio quanto do fim

                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        //As exceptions podem vir daqui, pode dar varios erros nesse caso
                        //usando o string format
                        RESULTADO.Text = string.Format("Endereço: {2} de {3} {0},{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "Endereço não encontrado, CEP: "+cep, "OK!");
                    }
                }
                catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK!");
                }
            }
        }

        private bool isValidCEP(string cep)
        {

            bool valido = true;
            //verificar se tem 8 caracteres desconsiderando a mascara
            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter 8 caracteres", "OK!");
                valido = false;
            }
            int NovoCEP = 0;
            //TENTE converter passa um valor, e um resultado caso obtnha sucesso
            //OUT no caso obtenha sucesso a variavel NovoCEP vai estar toda em numerico
            //SE NAO OCORRER ESSA CONVERSAO
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve ser composto apenas por numeros", "OK!");
                valido = false;
            }

            return valido;
        }
	}
}
