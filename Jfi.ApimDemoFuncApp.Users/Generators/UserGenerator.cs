namespace Jfi.ApimDemoFuncApp.Users.Generators;

using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Models;

public static class UserGenerator
{
    private static readonly Faker<User> UserFaker = new Faker<User>()
        .StrictMode(true)
        .RuleFor(x => x.Id, f => f.IndexFaker)
        .RuleFor(x => x.FirstName, f => f.Name.FirstName())
        .RuleFor(x => x.LastName, f => f.Name.LastName())
        .RuleFor(x => x.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName));

    public static List<User> CreateUsers()
    {
        return Enumerable.Range(0, Random.Shared.Next(20, 60))
            .Select(_ => UserFaker.Generate())
            .ToList();
    }

    public static User CreateUser()
    {
        return UserFaker.Generate();
    }
}
