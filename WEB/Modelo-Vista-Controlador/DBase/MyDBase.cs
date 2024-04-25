using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Modelo_Vista_Controlador.Models;
using System.Collections.Generic;

namespace Modelo_Vista_Controlador.DBase
{
    public class MyDBase : DbContext
    {
        public MyDBase(DbContextOptions<MyDBase> options) : base(options)
        {
        }

        public DbSet<Contact> Contact
        {
            get; set;
        }
    }
}