﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using EFCore.Cassandra.Benchmarks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Cassandra.Storage;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Cassandra.Benchmarks
{
    public class FakeDbContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCassandra("Contact Points=127.0.0.1;", opt =>
            {
                opt.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "cv");
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var timeUuidConverter = new TimeUuidToGuidConverter();
            modelBuilder.ForCassandraAddKeyspace("cv", new KeyspaceReplicationSimpleStrategyClass(2));
            modelBuilder.Entity<Applicant>()
                .ToTable("applicants", "cv")
                .HasKey(p => new { p.Id, p.Order });
            modelBuilder.Entity<Applicant>()
                .ForCassandraSetClusterColumns(_ => _.Order)
                .ForCassandraSetClusteringOrderBy(new[] { new CassandraClusteringOrderByOption("Order", CassandraClusteringOrderByOptions.ASC) });
            modelBuilder.Entity<Applicant>()
               .Property(p => p.TimeUuid)
               .HasConversion(new TimeUuidToGuidConverter());
            modelBuilder.Entity<Applicant>()
                .Property(p => p.Id)
                .HasColumnName("id");
            modelBuilder.Entity<ApplicantAddress>()
                .ToUserDefinedType("applicant_addr", "cv")
                .HasNoKey();
        }
    }
}