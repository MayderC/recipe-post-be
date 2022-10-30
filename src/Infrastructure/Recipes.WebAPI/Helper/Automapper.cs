using AutoMapper;
using Recipes.Application.Entities;
using Recipes.WebAPI.DTOs;

namespace Recipes.WebAPI.Helper;

public class Automapper : Profile
{

    public void UserMapper()
    {
        CreateMap<UserRegisterRequest, User>();
        CreateMap<User, UserLoginResponse>();
        // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
    }

}