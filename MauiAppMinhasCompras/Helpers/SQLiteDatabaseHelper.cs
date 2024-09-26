using MauiAppMinhasCompras.Models;
    // Importa o namespace "MauiAppMinhasCompras.Models", que provavelmente contém o modelo de dados "Produto", utilizado para representar os produtos no banco de dados.

using SQLite;
    // Importa a biblioteca "SQLite", que fornece funcionalidades para trabalhar com o banco de dados SQLite.

namespace MauiAppMinhasCompras.Helpers
{
    // Define o namespace "MauiAppMinhasCompras.Helpers", que agrupa classes auxiliares, incluindo o helper de banco de dados SQLite.

    public class SQLiteDatabaseHelper
    {
        // Define a classe "SQLiteDatabaseHelper", que gerencia as operações com o banco de dados SQLite de forma assíncrona.

        readonly SQLiteAsyncConnection _conn;
        // Declara uma variável privada somente leitura (readonly) chamada "_conn" do tipo "SQLiteAsyncConnection". 
        // Esta variável representa a conexão assíncrona com o banco de dados SQLite.

        public SQLiteDatabaseHelper(string path) 
        { 
            _conn = new SQLiteAsyncConnection(path);
            // Construtor da classe. Recebe o caminho do banco de dados como argumento e inicializa a conexão com o banco SQLite.

            _conn.CreateTableAsync<Produto>().Wait();
            // Cria uma tabela chamada "Produto" no banco de dados, se ainda não existir. 
            // O método "Wait()" é chamado para garantir que a criação da tabela seja concluída antes de continuar.
        }

        public Task<int> Insert(Produto p) 
        {
            // Define um método público que insere um objeto "Produto" no banco de dados.
            // Ele retorna um "Task<int>", onde o valor inteiro indica o número de linhas inseridas (normalmente 1, se a inserção for bem-sucedida).
            
            return _conn.InsertAsync(p);
            // Executa a inserção do produto no banco de dados de forma assíncrona.
        }

        public Task<List<Produto>> Update(Produto p) 
        {
            // Define um método público que atualiza um produto no banco de dados.
            // Ele retorna uma lista de produtos atualizados, encapsulada em uma "Task".

            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";
            // Define a consulta SQL para atualizar os campos "Descricao", "Quantidade" e "Preco" do produto, onde o "Id" corresponde ao produto a ser atualizado.

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
            );
            // Executa a consulta SQL com os parâmetros passados e retorna o resultado da operação.
        }

        public Task<int> Delete(int id) 
        {
            // Define um método público que exclui um produto do banco de dados, dado o seu "Id".
            // Ele retorna um "Task<int>", onde o número de linhas afetadas é retornado (geralmente 1, se o produto foi excluído).

            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
            // Executa a exclusão assíncrona do produto com o "Id" fornecido.
        }

        public Task<List<Produto>> GetAll() 
        {
            // Define um método público que retorna todos os produtos armazenados no banco de dados.
            // Ele retorna uma lista de produtos, encapsulada em uma "Task".

            return _conn.Table<Produto>().ToListAsync();
            // Converte a tabela "Produto" em uma lista assíncrona e a retorna.
        }

        public Task<List<Produto>> Search(string q) 
        {
            // Define um método público que pesquisa produtos no banco de dados com base em uma string de consulta.
            // Ele retorna uma lista de produtos que correspondem à pesquisa, encapsulada em uma "Task".

            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + q + "%'";
            // Define a consulta SQL para pesquisar produtos onde a descrição contém a string "q".

            return _conn.QueryAsync<Produto>(sql);
            // Executa a consulta SQL assíncrona e retorna os resultados.
        }
    }
}
