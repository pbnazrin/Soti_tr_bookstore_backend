using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pjt_BookStore.Models
{
    internal interface IUserRepository
    {
        List<Users> GetAllUsers();
        Users GetUsersById(int id);

        Users AddUser(Users users);
        void DeleteUsers(int id);
        void UpdateUsers ( Users users );

        void AddToWishList(int uid, int bik);
        List<WishList> ViewWishList(int uid);
        

    }
}
