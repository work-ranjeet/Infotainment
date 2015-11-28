using System;
using Infotainment.Data.Crypto;

namespace Infotainment.Data.Controls
{
    using Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserBL : IDisposable
    {
        private Lazy<UsersDB> UserDataAccess
        {
            get
            {
                return new Lazy<UsersDB>(() => new UsersDB());
            }
        }

        public async Task<IUsers> SelectUser(string Email)
        {
            var user = await UserDataAccess.Value.Select(Email);
            user.Password = RSACrypto.Instance.Decrypt(user.Password);
            return user;
        }

        public async Task<IEnumerable<UserGroup>> SelectGroup(Int64 UserID)
        {
            return await Task.Run(() =>
            {
                return UserDataAccess.Value.SelectUserGroup(UserID);
            });
        }

        public async Task<bool> IsValidUser(IUsers userDetail, string EmailPwd, string Password)
        {
            return await Task.Run(() =>
            {
                bool valid = false;

                if (userDetail != null && userDetail.Password.Trim() == Password.Trim())
                    valid = true;

                return valid;
            });
        }

        #region Memory
        private bool disposed = false;
        ~UserBL()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {

                }


                disposed = true;
            }
        }
        #endregion

    }
}
