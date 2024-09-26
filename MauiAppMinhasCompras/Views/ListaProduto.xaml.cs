using MauiAppMinhasCompras.Models;
using System.Collections.ObjectModel;
    // Importa o namespace "MauiAppMinhasCompras.Models" que contém o modelo "Produto" e "System.Collections.ObjectModel", que fornece a coleção observável "ObservableCollection".

namespace MauiAppMinhasCompras.Views;
{
    // Define o namespace "MauiAppMinhasCompras.Views", que contém as páginas do aplicativo.

    public partial class ListaProduto : ContentPage
    {
        // Define a classe parcial "ListaProduto" que herda de "ContentPage". 
        // Esta classe representa a página que lista os produtos cadastrados.

        ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
        // Declara uma coleção observável "lista" que contém objetos do tipo "Produto". 
        // Essa coleção será usada como a fonte de dados para a interface de listagem de produtos.
        // Qualquer mudança na coleção será automaticamente refletida na UI.

        public ListaProduto()
        {
            InitializeComponent();
            // Construtor da classe. Inicializa os componentes da página.

            lst_produtos.ItemsSource = lista;
            // Define a propriedade "ItemsSource" da lista de produtos (lst_produtos) como a coleção observável "lista", 
            // o que faz com que os itens na coleção sejam exibidos na interface de usuário.
        }

        protected async override void OnAppearing()
        {
            // Sobrescreve o método "OnAppearing", que é executado quando a página aparece na tela.

            try
            {
                lista.Clear();
                // Limpa a lista de produtos antes de carregar novos dados.

                List<Produto> tmp = await App.Db.GetAll();
                // Chama o método "GetAll" do banco de dados para obter todos os produtos.

                tmp.ForEach(i => lista.Add(i));
                // Adiciona os produtos obtidos da lista temporária "tmp" à coleção "lista", 
                // para que sejam exibidos na interface de usuário.
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
                // Se ocorrer algum erro, exibe uma mensagem de alerta com a descrição da exceção capturada.
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            // Método chamado quando o usuário clica no item de toolbar (botão) para adicionar um novo produto.

            try
            {
                Navigation.PushAsync(new Views.NovoProduto());
                // Navega para a página de cadastro de um novo produto ("NovoProduto").
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
                // Em caso de erro, exibe uma mensagem de alerta.
            }
        }

        private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Método chamado quando o texto no campo de busca (txt_search) é alterado.

            try
            {
                string q = e.NewTextValue;
                // Obtém o novo valor do texto digitado pelo usuário.

                lista.Clear();
                // Limpa a lista de produtos antes de exibir os resultados da busca.

                List<Produto> tmp = await App.Db.Search(q);
                // Faz uma busca no banco de dados com o texto de busca "q" e retorna a lista de produtos correspondentes.

                tmp.ForEach(i => lista.Add(i));
                // Adiciona os resultados da busca à lista observável "lista".
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
                // Em caso de erro, exibe uma mensagem de alerta com a descrição da exceção.
            }
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            // Método chamado quando o usuário clica no item de toolbar para calcular o total dos produtos.

            double soma = lista.Sum(i => i.Total);
            // Calcula a soma total dos valores (quantidade * preço) de todos os produtos na lista.

            string msg = $"O total é {soma:C}";
            // Cria uma mensagem formatada com o total, usando a formatação de moeda (C).

            DisplayAlert("Total dos Produtos", msg, "OK");
            // Exibe uma mensagem com o total dos produtos.
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            // Método chamado quando o usuário seleciona a opção de remover um produto.

            try
            {
                MenuItem selecinado = sender as MenuItem;
                // Obtém o item de menu clicado e o converte para "MenuItem".

                Produto p = selecinado.BindingContext as Produto;
                // Obtém o produto associado ao item de menu (BindingContext) e o converte para "Produto".

                bool confirm = await DisplayAlert(
                    "Tem Certeza?", $"Remover {p.Descricao}?", "Sim", "Não");
                // Pergunta ao usuário se ele tem certeza de que deseja remover o produto com base em sua descrição.

                if (confirm)
                {
                    await App.Db.Delete(p.Id);
                    // Se o usuário confirmar, remove o produto do banco de dados pelo seu ID.

                    lista.Remove(p);
                    // Também remove o produto da lista observável para atualizar a interface de usuário.
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
                // Em caso de erro, exibe uma mensagem de alerta com a descrição da exceção capturada.
            }
        }

        private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Método chamado quando o usuário seleciona um item da lista de produtos.

            try
            {
                Produto p = e.SelectedItem as Produto;
                // Obtém o produto selecionado e o converte para "Produto".

                Navigation.PushAsync(new Views.EditarProduto
                {
                    BindingContext = p,
                });
                // Navega para a página de edição do produto ("EditarProduto") 
                // e vincula o produto selecionado ao contexto de dados (BindingContext) da página.
            }
            catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
                // Em caso de erro, exibe uma mensagem de alerta.
            }
        }
    }
}
