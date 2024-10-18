using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;
using NuGet.Common;
using PotatoWebAPI.DTO;
using PotatoWebAPI.Models;

namespace PotatoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexPlayersController : ControllerBase
    {
        private readonly GoodbyepotatoContext _context;
        private readonly SendEmail _senewEmail;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;

        public IndexPlayersController(GoodbyepotatoContext context, SendEmail sendemai, IConfiguration configuration, IMemoryCache cache)
        {
            _context = context;
            _senewEmail = sendemai;
            _configuration = configuration;
            _cache = cache;
        }


        // GET: api/IndexPlayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        // GET: api/IndexPlayers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(string id)
        {
            var player = await _context.Players.FindAsync(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // PUT: api/IndexPlayers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPlayer(string id, Player player)
        //{
        //    if (id != player.Account)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(player).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PlayerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/IndexPlayers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer([FromForm] Player player)  //註冊
        {

            string PasswordBCrypt = BCrypt.Net.BCrypt.HashPassword(player.Password);  //將密碼加密
            player.Password = PasswordBCrypt;  //直接換成加密後的密碼
            _context.Players.Add(player);
            try
            {
                //發送驗證信
                player.Token = Guid.NewGuid().ToString();  //生成驗證token
                ////生成驗證連結
                string baseUrl = _configuration["AppSettings:BaseUrl"];
                string verificationlink = $"{baseUrl}/api/IndexPlayers/verify?account={player.Account}&token={player.Token}";
                string subject = "Potato帳號驗證信";
                string message = $"親愛的用戶您好，感謝您註冊再見！沙發potato的遊戲帳號，請您點擊以下連結，進行帳號開通{verificationlink}";
                await _senewEmail.SendEmailAsync(player.Email, subject, message);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                if (PlayerExists(player.Account))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPlayer", new { id = player.Account }, player);
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginPlayDTO loginPlayDTO)
        {
            var member = _context.Players.Where(s => s.Account == loginPlayDTO.Account).FirstOrDefault();
            if (member != null)
            {
                var passwordIsCorrect = BCrypt.Net.BCrypt.Verify(loginPlayDTO.password, member.Password); //比對兩者，如果資料庫裡面的資料不是加密規格就會bug
                if (passwordIsCorrect)
                {
                    return Ok(new { Message = "登入成功" });
                }
                else
                {
                    return Ok(new { Message = "帳號或密碼錯誤" });
                }
            }
            return Ok(new { Message = "此帳號尚未註冊" });
        }

        //驗證信結果
        [HttpGet("verify")]
        public async Task<IActionResult> verifyEmail(string account, string token)
        {
            var user = await _context.Players.FirstOrDefaultAsync(s => s.Account == account && s.Token == token);
            if (user != null)
            {
                user.Playerstatus = true;
                user.Token = null; //清除token
                await _context.SaveChangesAsync();

                return Redirect("http://localhost:5173/");

            }
            return BadRequest("無效的驗證連結");
        }

        [HttpPost("ForgetPasswordEmail")]   //寄送驗證碼到email
        public async Task<ActionResult<GetForgetPasswordEmailDTO>> GetForgetPassword([FromForm] GetForgetPasswordEmailDTO ForgetPassword)
        {

            string CacheKey = ForgetPassword.forgetEmail;
            int CacheValue;
            var havePlays = _context.Players.Any(s => s.Email.Equals(ForgetPassword.forgetEmail));
            if (havePlays)
            {
                Random random = new Random();
                //生成驗證碼
                string baseUrl = _configuration["AppSettings:BaseUrl"];
                int verificationnumber = random.Next(100000, 999999);
                CacheValue = verificationnumber;
                _cache.Set(CacheKey, CacheValue, TimeSpan.FromMinutes(10)); //儲存數據到快取，設定為5分鐘內
                string subject = "Potato忘記密碼驗證碼";
                string message = $"親愛的用戶您好，您的驗證碼為{verificationnumber}，請勿將驗證碼透露給陌生人，並請於5分鐘內進行驗證";
                await _senewEmail.SendEmailAsync(ForgetPassword.forgetEmail, subject, message);
                return Ok(new { Message = "寄送成功" });
            }
            else
            {
                return Ok(new { Message = "Noaccount" });
            }
        }

        [HttpPost("NewPassword")]
        public async Task<ActionResult<ForgetNEWPasswordDTO>> GetNewPassword([FromForm] ForgetNEWPasswordDTO forgetNEWPassword)
        {
            if (CheckVerificationnumber(forgetNEWPassword))
            {
                var player = await _context.Players.SingleOrDefaultAsync(s => s.Account == forgetNEWPassword.account);

                string PasswordBCrypt = BCrypt.Net.BCrypt.HashPassword(forgetNEWPassword.password);  //將密碼加密
                player.Password = PasswordBCrypt;
                await _context.SaveChangesAsync();
                return Ok(new { Message = "更新成功" });

                ////用來確認快取有成功存取，並且有抓到
                //if (cachedValue != null)
                //{
                //    return Ok(new { Message = $"Cache hit for {forgetNEWPassword.email}: {cachedValue}" });
                //}
                //else
                //{
                //    return Ok(new { Message = $"Cache hit for {forgetNEWPassword.email}" });
                //}
                //}
                //}
                //return Ok(new { Message = "密碼重設成功，請使用新密碼登入" });

            }
            return Ok(new { Message = "帳號錯誤或驗證碼已過期，請重新嘗試" });

            //下面這個是用來驗證資料是否有進來，結果抓到password的資料前端有抓到，後端沒進來，因為前端的password的name跟後端的password不一致，要注意送form的時候name要跟類別/模型一樣
            //return Ok(new { Message = $"{forgetNEWPassword.email},{forgetNEWPassword.password}, {forgetNEWPassword.Verificationnumber}, {forgetNEWPassword.account}" });
        }

        private bool CheckVerificationnumber([FromForm] ForgetNEWPasswordDTO forgetNEWPassword)  //忘記密碼的資料與驗證碼驗證
        {
            if (!string.IsNullOrEmpty(forgetNEWPassword.email) &&
            !string.IsNullOrEmpty(forgetNEWPassword.account) &&
            !string.IsNullOrEmpty(forgetNEWPassword.password)&&forgetNEWPassword.Verificationnumber>0)
            {
                int Verification = Convert.ToInt32(_cache.Get(forgetNEWPassword.email));
                int UserVerification = Convert.ToInt32(forgetNEWPassword.Verificationnumber);
                if (UserVerification > 0)
                {

                bool playerexist = _context.Players.Any(s => s.Email == forgetNEWPassword.email && s.Account == forgetNEWPassword.account);
                bool isvernumber = Verification== UserVerification;
                if (playerexist && isvernumber)
                {
                    return true;
                }
                }
            }
            return false;
        }




        // DELETE: api/IndexPlayers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePlayer(string id)
        //{
        //    var player = await _context.Players.FindAsync(id);
        //    if (player == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Players.Remove(player);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool PlayerExists(string id)
        {
            return _context.Players.Any(e => e.Account == id);
        }
    }
}
