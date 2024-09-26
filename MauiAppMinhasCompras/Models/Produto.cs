using SQLite;
    // Importa a biblioteca "SQLite", que fornece atributos e funcionalidades para trabalhar com bancos de dados SQLite, como as anotações de chave primária e autoincremento.

namespace MauiAppMinhasCompras.Models
{
    // Define o namespace "MauiAppMinhasCompras.Models", que organiza as classes de modelo de dados do aplicativo.

    public class Produto
    {
        // Define uma classe pública chamada "Produto", que representa o modelo de dados de um produto no banco de dados.

        string _descricao;
        // Declara uma variável privada chamada "_descricao", que será usada internamente pela propriedade "Descricao" para armazenar a descrição do produto.

        [PrimaryKey, AutoIncrement]
        // Anota a propriedade "Id" como a chave primária da tabela "Produto" no banco de dados SQLite, 
        // e define que o valor dessa chave será gerado automaticamente (auto incremento).
        public int Id { get; set; }

        public string Descricao
        {
            // Define a propriedade "Descricao" que usa a variável privada "_descricao" para armazenar seu valor.
            // Inclui lógica para validar a entrada da descrição.

            get => _descricao;
            // Define o getter da propriedade "Descricao", que retorna o valor armazenado em "_descricao".

            set
            {
                // Define o setter da propriedade "Descricao".
                // Antes de definir o valor, ele verifica se o valor é nulo.

                if (value == null)
                {
                    throw new Exception("Por favor, preencha a descrição");
                    // Se o valor for nulo, lança uma exceção informando que a descrição deve ser preenchida.
                }

                _descricao = value;
                // Se o valor for válido, armazena o valor na variável privada "_descricao".
            }
        }

        public double Quantidade { get; set; }
        // Define uma propriedade pública "Quantidade" do tipo "double", que armazena a quantidade de produtos.

        public double Preco { get; set; }
        // Define uma propriedade pública "Preco" do tipo "double", que armazena o preço unitário do produto.

        public double Total
        {
            get => Quantidade * Preco;
        }
        // Define uma propriedade pública somente leitura chamada "Total". 
        // Ela calcula o valor total do produto multiplicando a "Quantidade" pelo "Preco". 
        // Sempre que for acessada, esta propriedade retornará o valor calculado.
    }
}
