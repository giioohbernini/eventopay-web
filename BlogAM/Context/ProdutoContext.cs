namespace BlogAM.Context
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProdutoContext : DbContext
    {
        // Your context has been configured to use a 'ProdutosContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BlogAM.Context.ProdutosContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProdutosContext' 
        // connection string in the application configuration file.
        public ProdutoContext()
           // : base("name=ProdutosContext")
           : base("name=DefaultConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Produto> Produto { get; set; }
    }
    
}