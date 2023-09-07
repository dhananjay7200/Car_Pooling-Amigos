using Car_pooling.Interfaces;
using Car_pooling.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Text;

namespace Car_pooling.Repository
{
    public class UserDetailsRepo : IUserDetails
    {
        private CarPoolingContext _context;
        private readonly IConfiguration iconfiguration;

        public UserDetailsRepo(CarPoolingContext context, IConfiguration iconfiguration)
        {
            this._context = context;
            this.iconfiguration = iconfiguration;
        }

        public IEnumerable<UserDetail> GetAllUsersDetails()
        {
            throw new NotImplementedException();
        }

        public UserDetail GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UserLogin(LoginDetails user1)
        {
            UserDetail user = new UserDetail();
            var token = string.Empty;
            try
            {
                user = await  _context.UserDetails.Where(x => x.UserEmail == user1.UserEmail && x.UserPassword == user1.UserPassword).FirstOrDefaultAsync();
                if (user != null)
                {
                    token = GenerateToken(user);
                }
            }
            catch (Exception e)
            {
                throw new Exception("In UserLogin " + e.Message);
            }
            if (user == null)
            {
                token = "not found";
            }


            return token;
        }

        public async Task<UserDetail> UserRegister(UserDetail user)
        {
            if(user == null)
            {
                return null;
            }
            try
            {
               String u= UserPresent(user);
                if (u =="not present")
                {
                    await _context.UserDetails.AddAsync(user);
                    _context.SaveChangesAsync();
                }
                else
                {
                    return null;
                }

            }catch(DbUpdateException ex) {
                throw new DbUpdateException("error in reg"+ex.Message);
            }
            return user;
        }

        private string UserPresent(UserDetail user)
        {

           UserDetail u= (UserDetail)_context.UserDetails.Where(x => x.UserEmail == user.UserEmail).FirstOrDefault();
            if (u == null)
            {
                return "not present";
            }
            return "User present";

        }

        private string GenerateToken(UserDetail user)
        {
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));
            var credentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                  new Claim("email",user.UserEmail),
                  new Claim("role", user.UserRole),
                   new Claim("id", user.UserIdPk.ToString()),
                   new Claim("name",user.UserName),
              };
            var token = new JwtSecurityToken(iconfiguration["Jwt:Issuer"],
                iconfiguration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }


    }
}
