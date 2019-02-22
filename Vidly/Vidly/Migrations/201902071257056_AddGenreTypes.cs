namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO Genres (Name) Values('Comedy')");
            Sql("Insert INTO Genres (Name) Values('Action')");
            Sql("Insert INTO Genres (Name) Values('Family')");
            Sql("Insert INTO Genres (Name) Values('Romance')");
            Sql("Insert INTO Genres (Name) Values('Classic')");
            Sql("Insert INTO Genres (Name) Values('Drama')");
            Sql("Insert INTO Genres (Name) Values('Biskop')");


        }
        
        public override void Down()
        {
        }
    }
}
