using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using System.Collections;
namespace ChatAPI
{
    public class ChatHub : Hub
    {
        private string _connectionString = "";
        public ChatHub(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task SendMessage(string _username, string _message, string _group)
        {
            await Clients.All.SendAsync("ReciveMessage", _username, _message, _group);
        }
        private int MessagesCount(string tableName)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM {tableName}", connection);
            int a = (int)(command.ExecuteScalar());
            connection.Close();
            return a;
        }
        private void SaveMessage(string _username, string _message, string _group)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand($"insert into Messages values({MessagesCount("Messages") + 1},N'{_username}',N'{_message}',N'{_group}')", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
