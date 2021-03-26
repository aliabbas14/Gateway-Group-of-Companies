using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreAssignment.DAL
{
    public class EmployeeContext:DbContext
    {

        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {

        }

        public DbSet<Employees> Employees { get; set; }
    }
}
