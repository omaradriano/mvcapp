using System.Text.Json;
using MVCApp.Domain.Entities;

namespace MVCApp.Repository
{
    public static class UsersJSONRepository
    {
        private static string _FileName = "users.json";
        private static string _FilePath = Path.Combine(Directory.GetCurrentDirectory(), "Infrastructure", "Persistence", _FileName);
        private static string _DirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Infrastructure", "Persistence");
        private static List<User> _data = new List<User>();

        public static void AddUser(User user)
        {
            try
            {
                if (!File.Exists(_FilePath))
                {
                    _data.Add(user);
                    var data = JsonSerializer.Serialize(_data);
                    File.WriteAllText(_FilePath, data);
                }
                else
                {
                    int maxId;
                    string json = File.ReadAllText(_FilePath);
                    _data = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
                    _ = _data.Count == 0 ? maxId = 0 : maxId = _data.Max(x => x.Id + 1);
                    user.Id = maxId;
                    _data.Add(user);

                    string updatedJson = JsonSerializer.Serialize(_data);
                    // _data = [];
                    File.WriteAllText(_FilePath, updatedJson);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        public static void DeleteUser(int id)
        {
            string json = File.ReadAllText(_FilePath);
            _data = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            var userExists = _data.FirstOrDefault(x => x.Id == id);
            if (userExists != null)
            {
                _data.Remove(userExists);
                string updatedJson = JsonSerializer.Serialize(_data);
                // _data = [];
                File.WriteAllText(_FilePath, updatedJson);
            }

        }

        // public static int CountUsers() => _users.Count();
        public static List<User> GetUsers()
        {
            string json = File.ReadAllText(_FilePath);
            _data = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            if (_data.Count < 0)
            {
                return _data;
            }
            return _data;
        }

        public static User GetUserByID(int id)
        {
            string json = File.ReadAllText(_FilePath);
            _data = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            if (id <= 0 || id > _data.Max(x => x.Id)) System.Console.WriteLine("No existe el usuario");
            return _data.FirstOrDefault(x => id == x.Id);
        }

        public static void EditUser(User user)
        {
            if (user != null)
            {
                var userOnDB = _data.FirstOrDefault(x => x.Id == user.Id);
                userOnDB = user;
            }
        }

    }

}