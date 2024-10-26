using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using MongoDbGenericRepository.Attributes;

namespace IdentityService.Entities;

[CollectionName("users")]
public class User : MongoIdentityUser<Guid>
{
}

public class UserEntity : IdentityUser
{
}