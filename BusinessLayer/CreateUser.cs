using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    class CreateUser
    {
        private static CreateUser instance = new CreateUser();
        private int id = 0;
        private CreateUser() { }

        public static CreateUser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CreateUser();
                }
                return instance;
            }
        }

        public User AddUser(int tel_num)
        {
            id++;
            User user = new User(id, tel_num);
            return user;
        }
    }
}
