using System;
using System.Collections.Generic;

namespace PotatoWebAPI.Models;

public partial class PasswordResetRequest
{
    public string Id { get; set; } = null!;

    public string? Email { get; set; }

    public string? Token { get; set; }

    public DateTime? CreatedAt { get; set; }
}
