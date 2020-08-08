namespace Labo4ka7
{
    using System;
    using System.Data.SQLite.EF6;
    using System.Data.Entity;
    using SQLite.CodeFirst;
    using System.Linq;

    public class Model1 : DbContext
    {
        // Контекст настроен для использования строки подключения "Model1" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "Labo4ka7.Model1" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Model1" 
        // в файле конфигурации приложения.
        public Model1()
            : base("name=Model1")
        {
        }
        public DbSet<person> person { get; set; }
        public DbSet<Machine> Machine  { get; set; }
        public DbSet<MachineReferenceBook> MachineReferenceBooks { get; set; }
        public DbSet<Repairs> Repairs { get; set; }
        public DbSet<RepairsReferenceBook> RepairsReferenceBook { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<Model1>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}