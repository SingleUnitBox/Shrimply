﻿using Microsoft.EntityFrameworkCore;
using Shrimply.Data;
using Shrimply.Models.Domain;

namespace Shrimply.Repositories
{
    public class ShrimpRepository : IShrimpRepository
    {
        private readonly ShrimplyDbContext _shrimplyDbContext;
        public ShrimpRepository(ShrimplyDbContext shrimplyDbContext)
        {
            _shrimplyDbContext = shrimplyDbContext;
        }
        public async Task AddAsync(Shrimp shrimp)
        {
            await _shrimplyDbContext.Shrimps.AddAsync(shrimp);
            await _shrimplyDbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var shrimp = await _shrimplyDbContext.Shrimps.FindAsync(id);
            if (shrimp != null)
            {
                _shrimplyDbContext.Shrimps.Remove(shrimp);
                await _shrimplyDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Shrimp>> GetAllAsync()
        {
            var shrimps = await _shrimplyDbContext.Shrimps.ToListAsync();
            return shrimps;
        }

        public async Task<Shrimp> GetAsync(Guid id)
        {
            var shrimp = await _shrimplyDbContext.Shrimps.FirstOrDefaultAsync(x => x.Id == id);
            return shrimp;
        }

        public async Task<Shrimp> UpdateAsync(Shrimp shrimp)
        {
            var existingShrimp = await _shrimplyDbContext.Shrimps.FirstOrDefaultAsync(x => x.Id == shrimp.Id);
            if (existingShrimp != null)
            {
                existingShrimp.Name = shrimp.Name;
                existingShrimp.Description = shrimp.Description;
                existingShrimp.Color = shrimp.Color;
                existingShrimp.Family = shrimp.Family;
                existingShrimp.FeaturedImageUrl = shrimp.FeaturedImageUrl;
                existingShrimp.UrlHandle = shrimp.UrlHandle;
                existingShrimp.PublishedDate = shrimp.PublishedDate;
                existingShrimp.Author = shrimp.Author;
                existingShrimp.IsVisible = shrimp.IsVisible;
            }

            await _shrimplyDbContext.SaveChangesAsync();
            return existingShrimp;
        }
    }
}
