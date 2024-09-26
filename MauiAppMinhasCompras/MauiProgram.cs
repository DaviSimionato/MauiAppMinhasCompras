using Microsoft.Extensions.Logging;
    // Importa o namespace Microsoft.Extensions.Logging, que fornece funcionalidades para registro de logs (logging) no aplicativo.

namespace MauiAppMinhasCompras
{
    // Define o namespace "MauiAppMinhasCompras", agrupando todas as classes relacionadas ao aplicativo "Minhas Compras" em um contexto lógico.

    public static class MauiProgram
    {
        // Define uma classe estática chamada "MauiProgram". Ela é responsável por configurar e criar o aplicativo MAUI.

        public static MauiApp CreateMauiApp()
        {
            // Define um método estático que retorna uma instância do tipo "MauiApp". 
            // Este método cria e configura o aplicativo MAUI, que é a base para o funcionamento do aplicativo.

            var builder = MauiApp.CreateBuilder();
            // Cria uma instância de "MauiAppBuilder" chamada "builder". Este objeto será utilizado para configurar o aplicativo MAUI.

            builder
                .UseMauiApp<App>()
                // Associa a classe "App" como a principal aplicação que será executada.

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
                // Configura as fontes que serão utilizadas no aplicativo. 
                // Adiciona as fontes "OpenSans-Regular.ttf" e "OpenSans-Semibold.ttf" ao projeto, 
                // associando-as aos nomes "OpenSansRegular" e "OpenSansSemibold", respectivamente.

            #if DEBUG
                        builder.Logging.AddDebug();
            #endif
            // Se a aplicação estiver sendo executada em modo de depuração (DEBUG), o log será configurado para permitir a saída de logs de depuração.
            // Isso permite que informações úteis sobre o aplicativo sejam registradas durante o desenvolvimento.

            return builder.Build();
            // Constrói a aplicação MAUI com base nas configurações feitas no "builder" e retorna a instância do aplicativo configurado.
        }
    }
}
