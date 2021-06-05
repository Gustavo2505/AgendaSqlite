﻿// <auto-generated />
using Mabinfo.Banco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Mabinfo.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20210331171939_TesteMigration")]
    partial class TesteMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Mabinfo.Modelos.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Data");

                    b.Property<bool>("Finalizado");

                    b.Property<TimeSpan?>("HorarioFinal");

                    b.Property<TimeSpan?>("HorarioInicial");

                    b.Property<string>("Nome");

                    b.Property<string>("Nota");

                    b.HasKey("Id");

                    b.ToTable("Tarefas");
                });
#pragma warning restore 612, 618
        }
    }
}
