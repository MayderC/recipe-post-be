﻿namespace Recipes.Application.Entities;

public class User
{
    public string Id { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public IEnumerable<string> Roles{ get; set; }
    
}