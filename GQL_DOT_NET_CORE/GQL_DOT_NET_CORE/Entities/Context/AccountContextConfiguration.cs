﻿using GQL_DOT_NET_CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GraphQLDotNetCore.Entities.Context
{
    public class AccountContextConfiguration : IEntityTypeConfiguration<Account>
    {
        private Guid[] _ids;

        public AccountContextConfiguration(Guid[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasData(
                new Account
                {
                    Id = Guid.NewGuid(),
                    Type = AccountType.Cash,
                    Description = "Cash account for our users",
                    OwnerId = _ids[0]
                },
                new Account
                {
                    Id = Guid.NewGuid(),
                    Type = AccountType.Savings,
                    Description = "Savings account for our users",
                    OwnerId = _ids[1]
                },
                new Account
                {
                    Id = Guid.NewGuid(),
                    Type = AccountType.Income,
                    Description = "Income account for our users",
                    OwnerId = _ids[1]
                }
           );
        }
    }
}
