using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections;

namespace ChatAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private string _connectionString;
        public ChatController(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
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

        [HttpGet("LoadMessagesIntoArray")]
        public IActionResult LoadMessagesIntoArray()
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            for (int i = 1; i <= MessagesCount("Messages"); i++)
            {
                SqlCommand command = new SqlCommand($"SELECT Message FROM Messages where id = {i}", sc);
                string message = command.ExecuteScalar().ToString();
                arrayList.Add(message);
            }
            sc.Close();
            return Ok(arrayList);
        }
        
        [HttpGet("LoadAccountNameIntoArray")]
        public IActionResult LoadAccountNameIntoArray()
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            for (int i = 1; i <= MessagesCount("Messages"); i++)
            {
                SqlCommand command = new SqlCommand($"SELECT username FROM accounts where id = {i}", sc);
                string message = command.ExecuteScalar().ToString();
                arrayList.Add(message);
            }
            sc.Close();
            return Ok(arrayList);
        }
        
        [HttpGet("LoadPasswordIntoArray")]
        public IActionResult LoadPasswordIntoArray()
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            for (int i = 1; i <= MessagesCount("Messages"); i++)
            {
                SqlCommand command = new SqlCommand($"SELECT password FROM accounts where id = {i}", sc);
                string message = command.ExecuteScalar().ToString();
                arrayList.Add(message);
            }
            sc.Close();
            return Ok(arrayList);
        }

        [HttpGet("LoadUserNamesIntoArray")]
        public IActionResult LoadUserNamesIntoArray()
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            if (arrayList.Count > 0)
            {
                arrayList.Clear();
            }
            if (MessagesCount("Messages") > 0)
            {
                for (int i = 1; i <= MessagesCount("Messages"); i++)
                {
                    SqlCommand command = new SqlCommand($"SELECT userName FROM Messages where id = {i}", sc);
                    string user = command.ExecuteScalar().ToString();
                    arrayList.Add(user);
                }
            }
            sc.Close();
            return Ok(arrayList);
        }

        [HttpGet("LoadMessageGroupIntoArray")]
        public IActionResult LoadMessageGroupIntoArray()
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            if (arrayList.Count > 0)
            {
                arrayList.Clear();
            }
            for (int i = 1; i <= MessagesCount("Messages"); i++)
            {
                SqlCommand command = new SqlCommand($"SELECT chatName FROM Messages where id = {i}", sc);
                string user = command.ExecuteScalar().ToString();
                arrayList.Add(user);
            }
            sc.Close();
            return Ok(arrayList);
        }

        [HttpGet("LoadNameOfChatGroupIntoArray")]
        public IActionResult LoadNameOfChatGroupIntoArray()
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            if (arrayList.Count > 0)
            {
                arrayList.Clear();
            }
            for (int i = 1; i <= MessagesCount("ChatGroups"); i++)
            {
                SqlCommand command = new SqlCommand($"SELECT chatGroupName FROM ChatGroups where id = {i}", sc);
                string user = command.ExecuteScalar().ToString();
                arrayList.Add(user);
            }
            sc.Close();
            return Ok(arrayList);
        }
        
        [HttpGet("isPvIntoArray")]
        public IActionResult isPvIntoArray()
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            if (arrayList.Count > 0)
            {
                arrayList.Clear();
            }
            for (int i = 1; i <= MessagesCount("ChatGroups"); i++)
            {
                SqlCommand command = new SqlCommand($"SELECT isPv FROM ChatGroups where id = {i}", sc);
                string user = command.ExecuteScalar().ToString();
                arrayList.Add(user);
            }
            sc.Close();
            return Ok(arrayList);
        }
        
        [HttpGet("isGroupIntoArray")]
        public IActionResult isGroupIntoArray()
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            if (arrayList.Count > 0)
            {
                arrayList.Clear();
            }
            for (int i = 1; i <= MessagesCount("ChatGroups"); i++)
            {
                SqlCommand command = new SqlCommand($"SELECT isGroup FROM ChatGroups where id = {i}", sc);
                string user = command.ExecuteScalar().ToString();
                arrayList.Add(user);
            }
            sc.Close();
            return Ok(arrayList);
        }
        
        [HttpGet("isChannelIntoArray")]
        public IActionResult isChannelIntoArray()
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            if (arrayList.Count > 0)
            {
                arrayList.Clear();
            }
            for (int i = 1; i <= MessagesCount("ChatGroups"); i++)
            {
                SqlCommand command = new SqlCommand($"SELECT isChannel FROM ChatGroups where id = {i}", sc);
                string user = command.ExecuteScalar().ToString();
                arrayList.Add(user);
            }
            sc.Close();
            return Ok(arrayList);
        }
         
        [HttpGet("LoadMembersIntoArray")]
        public IActionResult LoadMembersIntoArray()
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            if (arrayList.Count > 0)
            {
                arrayList.Clear();
            }
            for (int i = 1; i <= MessagesCount("Members"); i++)
            {
                SqlCommand command = new SqlCommand($"SELECT Member FROM Members where id = {i}", sc);
                string user = command.ExecuteScalar().ToString();
                arrayList.Add(user);
            }
            sc.Close();
            return Ok(arrayList);
        }
         
        [HttpGet("LoadMembersOfGroupIntoArray")]
        public IActionResult LoadMembersOfGroupIntoArray()
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            if (arrayList.Count > 0)
            {
                arrayList.Clear();
            }
            for (int i = 1; i <= MessagesCount("Members"); i++)
            {
                SqlCommand command = new SqlCommand($"SELECT GroupName FROM Members where id = {i}", sc);
                string user = command.ExecuteScalar().ToString();
                arrayList.Add(user);
            }
            sc.Close();
            return Ok(arrayList);
        }
         
        [HttpGet("LoadPvNameIntoArray")]
        public IActionResult LoadPvNameIntoArray()
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            if (arrayList.Count > 0)
            {
                arrayList.Clear();
            }
            for (int i = 1; i <= MessagesCount("PvChats"); i++)
            {
                SqlCommand command = new SqlCommand($"SELECT PvName FROM PvChats where id = {i}", sc);
                string user = command.ExecuteScalar().ToString();
                arrayList.Add(user);
            }
            sc.Close();
            return Ok(arrayList);
        }
         
        [HttpGet("LoadPerson1PvIntoArray")]
        public IActionResult LoadPerson1PvIntoArray()
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            if (arrayList.Count > 0)
            {
                arrayList.Clear();
            }
            for (int i = 1; i <= MessagesCount("PvChats"); i++)
            {
                SqlCommand command = new SqlCommand($"SELECT FistPerson FROM PvChats where id = {i}", sc);
                string user = command.ExecuteScalar().ToString();
                arrayList.Add(user);
            }
            sc.Close();
            return Ok(arrayList);
        }
         
        [HttpGet("LoadPerson2PvIntoArray")]
        public IActionResult LoadPerson2PvIntoArray()
        {
            ArrayList arrayList = new ArrayList();
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            if (arrayList.Count > 0)
            {
                arrayList.Clear();
            }
            for (int i = 1; i <= MessagesCount("PvChats"); i++)
            {
                SqlCommand command = new SqlCommand($"SELECT SecondPerson FROM PvChats where id = {i}", sc);
                string user = command.ExecuteScalar().ToString();
                arrayList.Add(user);
            }
            sc.Close();
            return Ok(arrayList);
        }
         
        [HttpPost("CreateChatGroup")]
        public IActionResult CreateChatGroup(string name, string[] members)
        {
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            SqlCommand insertGroup = new SqlCommand($"insert into ChatGroups values({MessagesCount("ChatGroups") + 1},N'{name}','false','true','false')", sc);
            SqlCommand insertMembers;
            for (int i = 0; i < members.Length; i++)
            {
                insertMembers = new SqlCommand($"insert into Members values({MessagesCount("ChatGroups") + 1},'{members[i]}',N'{name}')", sc);
                insertMembers.ExecuteNonQuery();
            }
            insertGroup.ExecuteNonQuery();
            sc.Close();
            return Ok("Chat group created.");
        }

        [HttpPost("CreatePvChat")]
        public IActionResult CreatePvChat(string member1, string[] member2)
        {
            string name = member1 + " " + member2;
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            SqlCommand insertGroup = new SqlCommand($"insert into ChatGroups values({MessagesCount("ChatGroups") + 1},N'{name}','true','false','false')", sc);
            insertGroup.ExecuteNonQuery();
            SqlCommand insertPv = new SqlCommand($"insert into PvChats values({MessagesCount("PvChats") + 1},'{member1}','{member2}','{name}')", sc);
            insertPv.ExecuteNonQuery();
            SqlCommand insertMember1 = new SqlCommand($"insert into Members values({MessagesCount("Members") + 1},'{member1}',N'{name}')", sc);
            insertMember1.ExecuteNonQuery();
            SqlCommand insertMember2 = new SqlCommand($"insert into Members values({MessagesCount("Members") + 1},'{member2}',N'{name}')", sc);
            insertMember2.ExecuteNonQuery();
            sc.Close();
            return Ok("Private Chat created.");
        }

        [HttpPost("CreateChannel")]
        public IActionResult CreateChannel(string name, string[] members)
        {
            SqlConnection sc = new SqlConnection(_connectionString);
            sc.Open();
            SqlCommand insertGroup = new SqlCommand($"insert into ChatGroups values({MessagesCount("ChatGroups") + 1},N'{name}','false','false','true')", sc);
            SqlCommand insertMembers;
            for (int i = 0; i < members.Length; i++)
            {
                insertMembers = new SqlCommand($"insert into Members values({MessagesCount("ChatGroups") + 1},'{members[i]}',N'{name}')", sc);
                insertMembers.ExecuteNonQuery();
            }
            insertGroup.ExecuteNonQuery();
            sc.Close();
            return Ok("Channel created.");
        }

        [HttpPost("SignUser")]
        public IActionResult SignUser(string username, string password)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand($"insert into accounts values({MessagesCount("accounts") + 1},N'{username}',N'{password}')", connection);
            command.ExecuteNonQuery();
            connection.Close();
            return Ok("User Created.");
        }
    }
}
