using Microsoft.AspNetCore.Mvc;
using MVCApp.Domain.Entities;

namespace MVCApp.Repository{

    public static class UserRepository {

        private static List<User> _users = new List<User>{
            new User{Id = 1, Username = "omaradriano", Email = "oadrian38@gmail.com", Career = "Ingenieria en sistemas computacionales"},
            new User{Id = 2, Username = "mayraval", Email = "mayraval@gmail.com", Career = "Ingenieria industrial"},
            new User{Id = 3, Username = "renart", Email = "renartgaming@gmail.com", Career = "Psicologia"},
            new User{Id = 4, Username = "tmxmike", Email = "tmxmike@gmail.com", Career = "Ingenieria en mantenimiento industrial"}
        }; 

        public static void AddUser(User user){
            if(user != null){
                user.Id = _users.Max(x => x.Id + 1);
                _users.Add(user);
            }
        }

        public static void DeleteUser(int id){
            var userExists = _users.FirstOrDefault(x => x.Id == id);
            if(userExists != null){
                _users.Remove(userExists);
            }
        }

        public static int CountUsers() => _users.Count();
        public static List<User> GetUsers() => _users;

        public static User GetUserByID(int id){
            if(id <= 0 || id > _users.Max(x => x.Id)) System.Console.WriteLine("No existe el usuario");
            return _users.FirstOrDefault(x => id == x.Id);
        }

        public static void EditUser(User user){
            if(user != null){
                var userOnDB = _users.FirstOrDefault(x => x.Id == user.Id);
                userOnDB = user;
            }
        }

    }

}