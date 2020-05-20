﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using Cassandra;
using EFCore.Cassandra.Samples;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore.Cassandra.Samples.Migrations
{
    [DbContext(typeof(FakeDbContext))]
    [Migration("20200520135456_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Cassandra:Keyspacecv", "{\"ReplicationFactor\":2,\"ReplicationClass\":0}")
                .HasAnnotation("ProductVersion", "3.1.4");

            modelBuilder.Entity("EFCore.Cassandra.Samples.Models.Applicant", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<BigInteger>("BigInteger")
                        .HasColumnType("varint");

                    b.Property<byte[]>("Blob")
                        .HasColumnType("blob");

                    b.Property<bool>("Bool")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("DateTimeOffset")
                        .HasColumnType("timestamp");

                    b.Property<decimal>("Decimal")
                        .HasColumnType("decimal");

                    b.Property<IDictionary<string, string>>("Dic")
                        .HasColumnType("map<text,text>");

                    b.Property<double>("Double")
                        .HasColumnType("double");

                    b.Property<float>("Float")
                        .HasColumnType("float");

                    b.Property<int>("Integer")
                        .HasColumnType("int");

                    b.Property<IPAddress>("Ip")
                        .HasColumnType("inet");

                    b.Property<LocalDate>("LocalDate")
                        .HasColumnType("date");

                    b.Property<LocalTime>("LocalTime")
                        .HasColumnType("time");

                    b.Property<long>("Long")
                        .HasColumnType("bigint");

                    b.Property<IList<string>>("Lst")
                        .HasColumnType("list<text>");

                    b.Property<IList<int>>("LstInt")
                        .HasColumnType("list<int>");

                    b.Property<sbyte>("Sbyte")
                        .HasColumnType("tinyint");

                    b.Property<short>("SmallInt")
                        .HasColumnType("smallint");

                    b.Property<Guid>("TimeUuid")
                        .HasColumnType("uuid");

                    b.HasKey("Id", "LastName");

                    b.ToTable("applicants","cv");

                    b.HasAnnotation("Cassandra:ClusterColumns", new[] { "LastName" });
                });

            modelBuilder.Entity("EFCore.Cassandra.Samples.Models.CV", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("cvs","cv");
                });
#pragma warning restore 612, 618
        }
    }
}