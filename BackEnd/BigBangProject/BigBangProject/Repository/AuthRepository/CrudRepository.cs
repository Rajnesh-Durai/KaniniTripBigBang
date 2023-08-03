using BigBangProject.Model.DTO;
using BigBangProject.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using BigBangProject.DataContext;
using BigBangProject.GlobalException;

namespace BigBangProject.Repository.AuthRepository
{
    public class CrudRepository:ICrudRepo<User, UserDTO>
    {
        private readonly DBContext _context;


        public CrudRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<User?> Add(User user)
        {
            try
            {
                var users = _context.Users;
                var myUser = await users.SingleOrDefaultAsync(u => u.Username == user.Username);
                if (myUser == null)
                {
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
                return null;
            }
            catch (Exception se) { throw new Exception(CustomException.ExceptionMessages["CantEmpty"]); }
        }

        public async Task<User?> Delete(UserDTO userDTO)
        {
            try
            {
                var users = _context.Users;
                var myUser = users.SingleOrDefault(u => u.Username == userDTO.Username);
                if (myUser != null)
                {
                    _context.Users.Remove(myUser);
                    await _context.SaveChangesAsync();
                    return myUser;
                }
                return null;
            }
            catch (Exception se) { throw new Exception(CustomException.ExceptionMessages["CantEmpty"]); }
        }

        public async Task<User?> GetValue(UserDTO userDTO)
        {
            try
            {
                var users = await GetAll();
                if (users != null)
                {
                    var user = users.FirstOrDefault(u => u.Username == userDTO.Username);
                    if (user != null)
                    {
                        return user;
                    }
                }
                return null;
            }
            catch (Exception se) { throw new Exception(CustomException.ExceptionMessages["CantEmpty"]); }
        }

        public async Task<List<User>?> GetAll()
        {
            try
            {
                var Users = await _context.Users.ToListAsync();
                if (Users != null)
                {
                    return Users;
                }
                return null;
            }
            catch (Exception se) { throw new Exception(CustomException.ExceptionMessages["CantEmpty"]); }
        }

        public async Task<User?> Update(User user)
        {
            try
            {
                var users = await GetAll();
                if (users != null)
                {
                    var Newuser = users.FirstOrDefault(u => u.Username == user.Username);
                    if (Newuser != null)
                    {
                        _context.Users.Update(Newuser);
                        await _context.SaveChangesAsync();
                        return Newuser;
                    }
                    /* else
                         return null;*/
                }
                return null;


            }
            catch (Exception se) { throw new Exception(CustomException.ExceptionMessages["CantEmpty"]); }

        }
    }
}
