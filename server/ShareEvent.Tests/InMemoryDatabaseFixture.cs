﻿using System;
using System.Collections.Generic;
using System.Text;
using ShareEvent.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace iReception.Test
{
    public class InMemoryDatabaseFixture : IDisposable
    {
        private bool disposed = false;
        protected readonly DbContextOptions<ShareEventDbContext> DbOptions;

        public InMemoryDatabaseFixture()
        {
            // guid is used to create new in-memory database for each repository to avoid conflicts between tests
            DbOptions = new DbContextOptionsBuilder<ShareEventDbContext>()
                .UseInMemoryDatabase("SampleDb" + Guid.NewGuid().ToString())
                .Options;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                using (var sampleDbContext = new ShareEventDbContext(DbOptions))
                {
                    sampleDbContext.Database.EnsureDeleted();
                }
            }

            disposed = true;
        }

        ~InMemoryDatabaseFixture()
        {
            Dispose(false);
        }
    }
}