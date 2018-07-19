using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using Pedidos.SqlServer.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace Pedidos.SqlServer.Service
{
    class ServiceWS
    {
        public static string EnderecoBase = "http://192.168.15.76/api";

        //----------------------------------------------------
        //PESSOAS
        //----------------------------------------------------
        public static List<Pessoa> GetPessoaPorId(int id)
        {
            var URL = EnderecoBase+"/pessoa/obterporid/{0}";
            string NewURL = string.Format(URL, id);

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(NewURL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    List<Pessoa> pessoa = JsonConvert.DeserializeObject<List<Pessoa>>(conteudo);
                    return pessoa;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async static Task<List<Pessoa>> Login(int id)
        {
            var URL = EnderecoBase + "/pessoa/obterporid/{0}";
            string NewURL = string.Format(URL, id);

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = await requisicao.GetAsync(NewURL);

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    List<Pessoa> pessoa = JsonConvert.DeserializeObject<List<Pessoa>>(conteudo);
                    return pessoa;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static List<Pessoa> GetPessoas()
        {
            var URL = EnderecoBase + "/pessoa/obtertodas";

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(URL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    List<Pessoa> pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(conteudo);
                    return pessoas;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        
        //----------------------------------------------------
        //MARCAS
        //----------------------------------------------------
        public static List<Marca> GetMarcaPorId(int id)
        {
            var URL = EnderecoBase + "/marca/obterporid/{0}";
            string NewURL = string.Format(URL, id);

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(NewURL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    List<Marca> marca = JsonConvert.DeserializeObject<List<Marca>>(conteudo);
                    return marca;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        //excluir depois de mudar no produtos
        public static List<Marca> GetMarcas()
        {
            var URL = EnderecoBase + "/marca/obtertodas";

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(URL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    List<Marca> marcas = JsonConvert.DeserializeObject<List<Marca>>(conteudo);
                    return marcas;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async static Task<List<Marca>> GetMarcasAsync()
        {
            var URL = EnderecoBase + "/marca/obtertodas";

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = await requisicao.GetAsync(URL);

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    List<Marca> marcas = JsonConvert.DeserializeObject<List<Marca>>(conteudo);
                    return marcas;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static bool InsertMarca(Marca marca, int idUsuarioInclusao)
        {
            var URL = EnderecoBase + "/marca/salvar";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("nome", marca.nome),
                new KeyValuePair<string, string>("codigo", marca.codigo.ToString()),
                new KeyValuePair<string, string>("idUsuarioInclusao", idUsuarioInclusao.ToString())
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(URL, param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public static bool UpdateMarca(Marca marca, int idUsuarioAlteracao)
        {
            var URL = EnderecoBase + "/marca/salvar";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("id", marca.id.ToString()),
                new KeyValuePair<string, string>("nome", marca.nome),
                new KeyValuePair<string, string>("codigo", marca.codigo.ToString()),
                new KeyValuePair<string, string>("idUsuarioInclusao", idUsuarioAlteracao.ToString())
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(URL, param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public static bool DeleteMarca(Marca marca)
        {
            var URL = EnderecoBase + "/marca/excluir/" + marca.id;

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(URL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;

        }

        public async static Task<bool> DeleteMarcaAsync(Marca marca)
        {
            var URL = EnderecoBase + "/marca/excluir/" + marca.id;

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = await requisicao.GetAsync(URL);

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        //----------------------------------------------------
        //PRODUTOS
        //----------------------------------------------------
        public static List<Produto> GetProdutoPorId(int id)
        {
            var URL = EnderecoBase + "/produto/obterporid/{0}";
            string NewURL = string.Format(URL, id);

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(NewURL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    List<Produto> produto = JsonConvert.DeserializeObject<List<Produto>>(conteudo);
                    return produto;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static List<Produto> GetProdutos(int idMarca)
        {
            var URL = EnderecoBase + "/produto/obtertodas/{0}";
            string NewURL = string.Format(URL, idMarca);

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(NewURL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    List<Produto> produtos = JsonConvert.DeserializeObject<List<Produto>>(conteudo);
                    return produtos;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static bool InsertProduto(Produto produto, int idMarca)
        {
            var URL = EnderecoBase + "/produto/salvar";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("nome", produto.nome),
                new KeyValuePair<string, string>("codigo", produto.codigo.ToString()),
                new KeyValuePair<string, string>("idMarca", idMarca.ToString())
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(URL, param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public static bool UpdateProduto(Produto produto, int idMarca)
        {
            var URL = EnderecoBase + "/produto/salvar";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("id", produto.id.ToString()),
                new KeyValuePair<string, string>("nome", produto.nome),
                new KeyValuePair<string, string>("codigo", produto.codigo.ToString()),
                new KeyValuePair<string, string>("idMarca", idMarca.ToString())
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(URL, param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public static bool DeleteProduto(Produto produto)
        {
            var URL = EnderecoBase + "/produto/excluir/" + produto.id;

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(URL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        //----------------------------------------------------
        //PEDIDOS
        //----------------------------------------------------
        public static List<Pedido> GetPedidoPorId(int id)
        {
            var URL = EnderecoBase + "/pedido/obterporid/{0}";
            string NewURL = string.Format(URL, id);

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(NewURL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    List<Pedido> pedido = JsonConvert.DeserializeObject<List<Pedido>>(conteudo);
                    return pedido;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static List<Pedido> GetPedidos(string data)
        {
            string dataParaEnvio = "?Data=" + "2018-05-18";

            var URL = EnderecoBase + "/pedido/obtertodas/" + dataParaEnvio;
            

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.GetAsync(URL).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                string conteudo = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (conteudo.Length > 2)
                {
                    List<Pedido> pedidos = JsonConvert.DeserializeObject<List<Pedido>>(conteudo);
                    return pedidos;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public static bool InsertPedido(Pedido pedido)
        {
            var URL = EnderecoBase + "/pedido/salvar";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("idProduto", pedido.idProduto.ToString()),
                new KeyValuePair<string, string>("perda", pedido.perda.ToString()),
                new KeyValuePair<string, string>("troca", pedido.troca.ToString()),
                new KeyValuePair<string, string>("quantidade", pedido.quantidade.ToString()),
                new KeyValuePair<string, string>("obs", pedido.obs),
                //new KeyValuePair<string, string>("dataInclusao", DateTime.Now),
                //new KeyValuePair<string, string>("idUsuarioInclusao", pedido.idUsuarioInclusao.ToString())
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(URL, param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public static bool UpdatePedido(Pedido pedido, int idUsuarioAlteracao)
        {
            var URL = EnderecoBase + "/pedido/salvar";

            FormUrlEncodedContent param = new FormUrlEncodedContent(new[]
            {
                //new KeyValuePair<string, string>("id", pedido.id.ToString()),
                new KeyValuePair<string, string>("idProduto", pedido.idProduto.ToString()),
                new KeyValuePair<string, string>("perda", pedido.perda.ToString()),
                new KeyValuePair<string, string>("troca", pedido.troca.ToString()),
                new KeyValuePair<string, string>("quantidade", pedido.quantidade.ToString()),
                new KeyValuePair<string, string>("obs", pedido.obs)
                //new KeyValuePair<string, string>("idUsuarioAlteracao", idUsuarioAlteracao.ToString())
            });

            HttpClient requisicao = new HttpClient();
            HttpResponseMessage resposta = requisicao.PostAsync(URL, param).GetAwaiter().GetResult();

            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }
    }
}
