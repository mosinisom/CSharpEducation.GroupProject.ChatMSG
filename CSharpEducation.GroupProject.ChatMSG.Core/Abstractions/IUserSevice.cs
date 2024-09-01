using CSharpEducation.GroupProject.ChatMSG.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEducation.GroupProject.ChatMSG.Core.Abstractions
{
  internal interface IUserSevice
  {
    Task Add(string username, string password);
    Task Remove(int id);
    Task<User> Get(int id);
    Task Update(string username, string password);
    Task<ICollection<User>> GetUsers();
  }
}
