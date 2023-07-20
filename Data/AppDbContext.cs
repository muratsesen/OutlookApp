using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

public class OutlookContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Token> Tokens { get; set; }
    public DbSet<Email> Emails { get; set; }
    public DbSet<Folder> Folders { get; set; }

    public string DbPath { get; }

    public OutlookContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "outlook2.db");
        Console.WriteLine($"Outlook DB Path {path}");
    }
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Token>(eb=>{
    //         eb.HasNoKey();
    //     });
    // }
    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}


