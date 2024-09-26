using MauiAppMinhasCompras.Models;
    // Importa o namespace "MauiAppMinhasCompras.Models", que contém a classe "Produto" usada para manipular dados de produtos.

namespace MauiAppMinhasCompras.Views;
{
    // Define o namespace "MauiAppMinhasCompras.Views", que contém as views (páginas) do aplicativo.

    public partial class EditarProduto : ContentPage
    {
        // Define uma classe parcial chamada "EditarProduto" que herda de "ContentPage". 
        // Esta classe representa a página de edição de produtos no aplicativo.

        public EditarProduto()
        {
            InitializeComponent();
            // Construtor da classe. Chama o método "InitializeComponent" que inicializa todos os componentes visuais e recursos da página.
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            // Define um método privado assíncrono que será chamado quando o usuário clicar em um item da barra de ferramentas.
            // O evento é assíncrono para permitir chamadas não bloqueantes, como atualizações no banco de dados e navegação.

            try
            {
                Produto produto_anexado = BindingContext as Produto;
                // Recupera o contexto de dados da página (BindingContext) e o converte para um objeto "Produto".
                // O BindingContext normalmente representa o produto que está sendo editado.

                Produto p = new Produto
                {
                    Id = produto_anexado.Id,
                    Descricao = txt_descricao.Text,
                    Quantidade = Convert.ToDouble(txt_quantidade.Text),
                    Preco = Convert.ToDouble(txt_preco.Text)
                };
                // Cria um novo objeto "Produto" com os valores fornecidos nos campos de entrada da interface do usuário (txt_descricao, txt_quantidade e txt_preco).
                // O Id é atribuído a partir do produto anexado (BindingContext), enquanto os outros valores são convertidos a partir dos campos de texto.

                await App.Db.Update(p);
                // Chama o método "Update" do banco de dados para atualizar o produto no banco. 
                // O uso de "await" permite que essa operação seja realizada de forma assíncrona.

                await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
                // Exibe uma mensagem de sucesso ao usuário informando que o produto foi atualizado com sucesso.

                await Navigation.PopAsync();
                // Retorna o usuário à página anterior da pilha de navegação, após a conclusão da atualização.
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
                // Em caso de erro, exibe uma mensagem de alerta com a descrição da exceção capturada.
            }
        }
    }
}
