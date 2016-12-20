namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        CriadoPor = c.String(maxLength: 100),
                        ModificadoPor = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                        Versao = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Biblioteca",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Endereco = c.String(nullable: false, maxLength: 100),
                        CriadoPor = c.String(maxLength: 100),
                        ModificadoPor = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                        Versao = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Livro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Tipo = c.String(nullable: false, maxLength: 100),
                        BibliotecaId = c.Int(nullable: false),
                        AutorId = c.Int(nullable: false),
                        SecaoId = c.Int(nullable: false),
                        CriadoPor = c.String(maxLength: 100),
                        ModificadoPor = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                        Versao = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autor", t => t.AutorId)
                .ForeignKey("dbo.Biblioteca", t => t.BibliotecaId)
                .ForeignKey("dbo.Secao", t => t.SecaoId)
                .Index(t => t.BibliotecaId)
                .Index(t => t.AutorId)
                .Index(t => t.SecaoId);
            
            CreateTable(
                "dbo.Secao",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Local = c.String(nullable: false, maxLength: 100),
                        BibliotecaId = c.Int(nullable: false),
                        CriadoPor = c.String(maxLength: 100),
                        ModificadoPor = c.String(maxLength: 100),
                        Name = c.String(maxLength: 100),
                        Versao = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        DataCriacao = c.DateTime(nullable: false),
                        DataModificacao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Biblioteca", t => t.BibliotecaId)
                .Index(t => t.BibliotecaId);
            
            CreateTable(
                "dbo.AutoresBibliotecas",
                c => new
                    {
                        Autor_Id = c.Int(nullable: false),
                        Biblioteca_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Autor_Id, t.Biblioteca_Id })
                .ForeignKey("dbo.Autor", t => t.Autor_Id)
                .ForeignKey("dbo.Biblioteca", t => t.Biblioteca_Id)
                .Index(t => t.Autor_Id)
                .Index(t => t.Biblioteca_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AutoresBibliotecas", "Biblioteca_Id", "dbo.Biblioteca");
            DropForeignKey("dbo.AutoresBibliotecas", "Autor_Id", "dbo.Autor");
            DropForeignKey("dbo.Livro", "SecaoId", "dbo.Secao");
            DropForeignKey("dbo.Secao", "BibliotecaId", "dbo.Biblioteca");
            DropForeignKey("dbo.Livro", "BibliotecaId", "dbo.Biblioteca");
            DropForeignKey("dbo.Livro", "AutorId", "dbo.Autor");
            DropIndex("dbo.AutoresBibliotecas", new[] { "Biblioteca_Id" });
            DropIndex("dbo.AutoresBibliotecas", new[] { "Autor_Id" });
            DropIndex("dbo.Secao", new[] { "BibliotecaId" });
            DropIndex("dbo.Livro", new[] { "SecaoId" });
            DropIndex("dbo.Livro", new[] { "AutorId" });
            DropIndex("dbo.Livro", new[] { "BibliotecaId" });
            DropTable("dbo.AutoresBibliotecas");
            DropTable("dbo.Secao");
            DropTable("dbo.Livro");
            DropTable("dbo.Biblioteca");
            DropTable("dbo.Autor");
        }
    }
}
