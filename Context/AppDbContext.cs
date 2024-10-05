﻿using CrudApiPrueba.Entities;
using Microsoft.EntityFrameworkCore;


namespace CrudApiPrueba.Context
{
    public class AppDbContext:DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {
        
        }      
        public DbSet<Employees> Employees { get; set; }

    }
}
