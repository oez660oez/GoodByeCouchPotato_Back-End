using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<ActionResult<RegisterDTO>> PostPlayer([FromForm] RegisterDTO player)  //註冊
        {
            bool checkaccount = _context.Players.Any(s => s.Account.Equals(player.Account));
            if (!checkaccount)
            {

            if (player.Password == player.CheckPassword)
            {

            string PasswordBCrypt = BCrypt.Net.BCrypt.HashPassword(player.Password);  //將密碼加密
            player.Password = PasswordBCrypt;  //直接換成加密後的密碼

                //發送驗證信
                player.Token = Guid.NewGuid().ToString();  //生成驗證token
                    var newplayer = new Player
                    {
                        Account = player.Account,
                        Email = player.Email,
                        Password = player.Password,
                        Playerstatus = player.Playerstatus,
                        Token = player.Token
                    };
                    _context.Players.Add(newplayer);
                    ////生成驗證連結
                int result= await _context.SaveChangesAsync();
                    string baseUrl = _configuration["AppSettings:BaseUrl"];
                string verificationlink = $"{baseUrl}/api/IndexPlayers/verify?account={player.Account}&token={player.Token}";
                string subject = "Potato帳號驗證信";
                    string message = $@"
    <p>親愛的用戶您好，</p>
    <p >感謝您註冊「再見！沙發potato」的遊戲帳號。</p>
    <p>請您點擊以下連結，進行帳號開通：</p>
<p>返回首頁即開通成功，可立即使用註冊帳號進行登入</p>
    <p><a href='{verificationlink}'>點擊此處開通您的帳號</a></p>";
                        if (result > 0)
                        {

                await _senewEmail.SendEmailAsync(player.Email, subject, message);
                            return Ok(new { Message = "註冊成功" });
                        }
                        else
                        {
                            return Ok(new { Message = "註冊失敗，請重新嘗試" });
                        }
                
            }

            return Ok(new { Message = "密碼及確認密碼不相同" });
            }
                return Ok(new { Message = "此帳號已被註冊" });
        }

        [HttpPost("Login")]
        public  IActionResult Login(LoginPlayDTO loginPlayDTO)  //登入
        {
            var member = _context.Players.Where(s => s.Account == loginPlayDTO.Account).FirstOrDefault();
            if (member != null)
            {
                try
                {

                    bool passwordIsCorrect = BCrypt.Net.BCrypt.Verify(loginPlayDTO.password, member.Password); //比對兩者，如果資料庫裡面的資料不是加密規格就會bug

                if (passwordIsCorrect)
                { 
                            if (member.Playerstatus)
                            {   
                                    bool havecharacter= _context.Characters.Any(s => s.Account == loginPlayDTO.Account && s.LivingStatus == "居住");
                                    if(havecharacter) {  //有角色照理說要同時建立角色現有配件，所以他們會同時存在
                                        var Character=_context.Characters.Where(s=>s.Account == loginPlayDTO.Account&&s.LivingStatus=="居住").FirstOrDefault();
                                        var characterbody = _context.CharacterAccessories.Where(s => s.CId == Character.CId).FirstOrDefault();       
                            if (Character.Environment > 0)
                                        {
                                            return Ok(new { Message = "success",PlayerCharacter = Character, CharacterAccessorie = characterbody });

                                        }
                                        else
                                        {
                                            Character.LivingStatus = "搬離";
                                            Character.MoveOutDate = DateTime.Now;
                                             _context.SaveChangesAsync();
                                           return Ok(new { Message = "因環境值歸0，角色已搬離，請重新創建角色", respond = "gameover", PlayerCharacter = Character, CharacterAccessorie = characterbody });
                                        }
                                    
                            }
                                        return Ok(new { Message = "目前無居住中的角色，需創建角色",respond = "newcharacter",Player=loginPlayDTO.Account});
                            }
                            else
                            {
                                 return Ok(new { Message = "帳號尚未開通",respond = "Nopermission" });
                            }
                }
                                return Ok(new { Message = "帳號或密碼錯誤",respond = "Nopermission"  });
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return Ok(new { Message = "此帳號尚未註冊",
                respond
            ="Noaccount"});
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
                _cache.Set(CacheKey, CacheValue, TimeSpan.FromMinutes(5)); //儲存數據到快取，設定為5分鐘內
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
                var player = await _context.Players.FirstOrDefaultAsync(s => s.Account == forgetNEWPassword.account);
                if (player != null)
                {

                string PasswordBCrypt = BCrypt.Net.BCrypt.HashPassword(forgetNEWPassword.password);  //將密碼加密
                player.Password = PasswordBCrypt;
                await _context.SaveChangesAsync();
                return Ok(new { Message = "更新成功" });
                }
                return Ok(new { Message = "查無此帳號" });

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
            return Ok(new { Message = "帳號錯誤或驗證碼已過期，請重新嘗試"});

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


        [HttpPost("ChangePassword")]
        public async Task<ActionResult<ChangePasswordDTO>> ChangePassword([FromForm] ChangePasswordDTO changePassword)
        {
            if (!string.IsNullOrEmpty(changePassword.NewPassword) && !string.IsNullOrEmpty(changePassword.OldPassword) && !string.IsNullOrEmpty(changePassword.Account))
            {
                var player = _context.Players.Where(s => s.Account == changePassword.Account).FirstOrDefault();
                if (player != null)
                {
                    bool isrightoldpassword= BCrypt.Net.BCrypt.Verify(changePassword.OldPassword,player.Password);
                    if (isrightoldpassword)
                    {
                        string bcryptnewpassword=BCrypt.Net.BCrypt.HashPassword(changePassword.NewPassword);
                        player.Password =bcryptnewpassword;
                        await _context.SaveChangesAsync();
                        return Ok(new { Message = "密碼變更成功"});
                    }
                    return Ok(new { Message = "原密碼錯誤"});
                }
                return Ok(new { Message = "查無此帳號" });
            }
            return Ok(new { Message = "有資料未填寫" });
        }

        //[HttpPost("Gameover")]
        //public async Task<ActionResult<GameOveryDTO>> GameOvery([FromForm] GameOveryDTO Gameoveraccount)
        //{
        //    var member = _context.Players.Where(s => s.Account == Gameoveraccount.Account).FirstOrDefault();
        //    if (member != null)
        //    {
        //        bool havecharacter = _context.Characters.Any(s => s.Account == Gameoveraccount.Account && s.LivingStatus == "居住" && s.Environment <= 0);
        //        if (havecharacter)
        //        {  //有角色照理說要同時建立角色現有配件，所以他們會同時存在
        //            var Character = _context.Characters.Where(s => s.Account == Gameoveraccount.Account && s.LivingStatus == "居住" && s.Environment <= 0).FirstOrDefault();

        //            Character.LivingStatus = "搬離";
        //            Character.MoveOutDate = DateTime.Now;
        //            _context.SaveChangesAsync();
        //            return Ok(new { Message = "修改狀態完成" });
        //        }
        //            return Ok(new { Message = "查無此角色" });
        //    }
        //    return Ok(new { Message = "查無此帳號" });
        //}

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
