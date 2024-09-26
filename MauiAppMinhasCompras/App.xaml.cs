using MauiAppMinhasCompras.Helpers;
    // Importa o namespace "MauiAppMinhasCompras.Helpers", que provavelmente contém a classe "SQLiteDatabaseHelper", usada para interagir com o banco de dados SQLite.

namespace MauiAppMinhasCompras
{
    // Define o namespace "MauiAppMinhasCompras", que organiza classes relacionadas ao aplicativo "Minhas Compras".

    public partial class App : Application
    {
        // Define a classe "App" que herda de "Application". Esta é a classe principal que controla o ciclo de vida do aplicativo e define a página inicial.

        static SQLiteDatabaseHelper _db;
        // Declara uma variável estática privada chamada "_db" do tipo "SQLiteDatabaseHelper". 
        // Esta variável armazenará uma instância da classe que gerencia o banco de dados SQLite.

        public static SQLiteDatabaseHelper Db
        {
            get
            {
                // Define uma propriedade estática pública chamada "Db" que retorna uma instância de "SQLiteDatabaseHelper".
                // Ela permite o acesso ao banco de dados em todo o aplicativo.

                if (_db == null)
                {
                    // Verifica se "_db" está nulo, ou seja, se o banco de dados ainda não foi inicializado.

                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");
                    // Se não foi inicializado, constrói o caminho completo para o arquivo do banco de dados SQLite.
                    // O banco de dados será armazenado na pasta de dados local da aplicação com o nome "banco_sqlite_compras.db3".

                    _db = new SQLiteDatabaseHelper(path);
                    // Inicializa a instância de "_db" criando um novo objeto "SQLiteDatabaseHelper" e passando o caminho do banco de dados como argumento.
                }

                return _db;
                // Retorna a instância de "_db". Se já foi criada anteriormente, essa instância será reutilizada.
            }
        }

        public App()
        {
            InitializeComponent();
            // Construtor da classe "App". Chama o método "InitializeComponent", que inicializa todos os componentes visuais e os recursos definidos no aplicativo.

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto());
            // Define a propriedade "MainPage" para a página inicial do aplicativo.
            // A linha comentada teria definido a "AppShell" como a página principal, mas aqui a linha ativa usa uma página de navegação que abre "ListaProduto".
            // "NavigationPage" permite navegação entre diferentes páginas do aplicativo, e "ListaProduto" é a página inicial exibida ao usuário.
        }
    }
}
