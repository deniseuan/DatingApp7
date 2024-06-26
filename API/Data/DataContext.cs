﻿using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : IdentityDbContext<AppUser, 
AppRole, int, IdentityUserClaim<int>, AppUserRole, 
IdentityUserLogin<int>, IdentityRoleClaim<int>,
IdentityUserToken<int>>
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<UserLike> Likes { get; set; }
    public DbSet<Message> Messages { get; set; }

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<ProductPhoto> ProductPhotos { get; set; }
    
    public DbSet<Group> Groups { get; set; }
    public DbSet<Connection> Connections { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUser>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();

        builder.Entity<AppRole>()
            .HasMany(ur => ur.UserRoles)
            .WithOne(u => u.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();

        builder.Entity<UserLike>()
            .HasKey(k => new { k.SourceUserId, k.TargetUserId });

        builder.Entity<UserLike>()
            .HasOne(s => s.SourceUser)
            .WithMany(l => l.LikedUsers)
            .HasForeignKey(s => s.SourceUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<UserLike>()
            .HasOne(s => s.TargetUser)
            .WithMany(l => l.LikedByUsers)
            .HasForeignKey(s => s.TargetUserId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.Entity<Message>()
            .HasOne(u => u.Recipient)
            .WithMany(m => m.MessagesReceived)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Message>()
            .HasOne(u => u.Sender)
            .WithMany(m => m.MessagesSent)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<ProductPhoto>()
            .HasKey(x => new { x.ProductId, x.PhotoId });

        builder.Entity<ProductPhoto>()
            .HasOne(p => p.Product)
            .WithMany(p => p.ProductPhotos)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ProductPhoto>()
            .HasOne(p => p.Photo)
            .WithOne(p => p.ProductPhoto)
            .HasForeignKey<ProductPhoto>(p => p.PhotoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ProductBrand>()
            .HasKey(x => new { x.ProductId, x.BrandId });

        builder.Entity<Product>()
            .HasMany(p => p.ProductPhotos)
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Brand>()
            .HasMany(b => b.ProductBrands)
            .WithOne(p => p.Brand)
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Photo>()
            .HasOne(x => x.ProductPhoto)
            .WithOne(x => x.Photo)
            .HasForeignKey<ProductPhoto>(x => x.PhotoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
