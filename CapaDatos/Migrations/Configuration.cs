using System.Data.Entity.Migrations;

namespace CapaDatos.Migrations
{
    
    internal sealed class Configuration : DbMigrationsConfiguration<CapaDatos.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            this.SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(CapaDatos.Contexto context)
        {
            
        }
    }
}
