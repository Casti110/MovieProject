using System;
using Microsoft.AspNetCore.Identity;

namespace MovieProjectWebAPI.Models;

public class User : IdentityUser
{
    public string? FavoriteMovieCharacter { get; set; }

}
