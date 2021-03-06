﻿using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using Rhythm.Domain.Repository.Interfaces;
using Rhythm.Domain.Context;
using Rhythm.Domain.Entities;
using Rhythm.Domain.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Rhythm.Domain.Repository
{
    public class UserRepository : IUserRepository
    {
        DogCodingContext _db;

        public UserRepository(DogCodingContext db)
        {
            _db = db;
        }

        public async Task CreateUserAsync(ChiefUser chiefUser)
        {
            _db.ChiefUsers.Add(chiefUser);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(ChiefUser chiefUser)
        {
            _db.ChiefUsers.Remove(chiefUser);
            await _db.SaveChangesAsync();
        }

        public async Task EditUser(ChiefUser chiefUser)
        {
            _db.Entry(chiefUser).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ChiefUser>> GetChiefUsersAsync()
        {
            return await _db.ChiefUsers.ToListAsync();
        }

        public async Task<ChiefUser> GetUserAsync(int chiefUser)
        {
            return await _db.ChiefUsers.FindAsync(chiefUser);
        }

        public DogUserManager GetUserManagerAsync()
        {
            return new DogUserManager(new UserStore<User>(_db));
        }
    }
}
