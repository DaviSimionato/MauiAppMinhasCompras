namespace MauiAppMinhasCompras
{
    // Define o namespace "MauiAppMinhasCompras", que agrupa classes relacionadas ao projeto "Minhas Compras" no aplicativo MAUI.

    public partial class MainPage : ContentPage
    {
        // Define a classe "MainPage", que herda de "ContentPage". 
        // Esta página contém o conteúdo visual e a lógica para a página principal do aplicativo.

        int count = 0;
        // Declara uma variável inteira chamada "count", inicializada com 0. 
        // Esta variável será usada para contar quantas vezes um botão foi clicado.

        public MainPage()
        {
            InitializeComponent();
            // Construtor da classe "MainPage". Aqui, é chamado o método "InitializeComponent", que inicializa os componentes visuais da página.
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            // Define um método privado chamado "OnCounterClicked" que será executado quando o botão for clicado.
            // "sender" refere-se ao objeto que disparou o evento, e "EventArgs" contém dados sobre o evento.

            count++;
            // Incrementa o valor da variável "count" em 1 toda vez que o botão é clicado.

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";
            // Verifica se "count" é igual a 1. Se for, o texto do botão "CounterBtn" é atualizado para "Clicked 1 time". 
            // Caso contrário, é exibido "Clicked X times", onde X é o valor da variável "count".

            SemanticScreenReader.Announce(CounterBtn.Text);
            // Chama o método "Announce" do "SemanticScreenReader", que lê em voz alta o novo valor do texto do botão, 
            // proporcionando acessibilidade para usuários com deficiências visuais.
        }
    }
}
