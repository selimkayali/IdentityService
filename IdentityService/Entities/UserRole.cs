using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using MongoDbGenericRepository.Attributes;

namespace IdentityService.Entities;

[CollectionName("roles")]
public class UserRole : MongoIdentityRole<Guid>
{
    
}