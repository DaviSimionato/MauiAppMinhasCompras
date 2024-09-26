using MauiAppMinhasCompras.Models;
    // Importa o namespace que contém o modelo "Produto".

namespace MauiAppMinhasCompras.Views;
{
    // Define o namespace "MauiAppMinhasCompras.Views", que contém as views (páginas) da aplicação.

    public partial class NovoProduto : ContentPage
    {
        // Define a classe parcial "NovoProduto", que herda de "ContentPage". 
        // Esta classe representa a página para a criação de novos produtos.

        public NovoProduto()
        {
            InitializeComponent();
            // Construtor da classe. Inicializa os componentes da página.
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            // Método chamado quando o usuário clica no item de toolbar (botão) para adicionar um novo produto.

            try
            {
                Produto p = new Produto
                {
                    Descricao = txt_descricao.Text,
                    Quantidade = Convert.ToDouble(txt_quantidade.Text),
                    Preco = Convert.ToDouble(txt_preco.Text)
                };
                // Cria um novo objeto "Produto" e atribui os valores da interface de usuário 
                // (campos de texto) para as propriedades "Descricao", "Quantidade" e "Preco".

                await App.Db.Insert(p);
                // Insere o novo produto no banco de dados, usando o método "Insert" da classe "SQLiteDatabaseHelper".

                await DisplayAlert("Sucesso!", "Registro Inserido", "OK");
                // Exibe uma mensagem de sucesso informando que o produto foi inserido no banco de dados.
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
                // Se ocorrer algum erro, exibe uma mensagem de alerta com a descrição da exceção capturada.
            }
        }
    }
}
