﻿using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;

namespace JourneyJoy.DAL.Repositories.EFRepositories
{
    public class EFAccountRepository(AppDbContext context) : GenericRepository<Account>(context), IAccountDAL
    {
    }
}
