namespace MVCCodeChallenges.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Challenge",
                c => new
                    {
                        ChallengeId = c.Int(nullable: false, identity: true),
                        ClassPath = c.String(),
                        Sequence = c.Int(nullable: false),
                        Name = c.String(),
                        UriTitle = c.String(),
                        Description = c.String(),
                        ImageFilenameNoExtension = c.String(),
                    })
                .PrimaryKey(t => t.ChallengeId);
            
            CreateTable(
                "dbo.ChallengeInput",
                c => new
                    {
                        ChallengeInputId = c.Int(nullable: false, identity: true),
                        InputElement = c.String(),
                        InputNameAttr = c.String(),
                        InputTypeAttr = c.String(),
                        ChallengeId = c.Int(nullable: false),
                        ValidationId = c.Int(nullable: true),
                        ValidationErrorMsg = c.String(),
                        Sequence = c.Int(nullable: false),
                        InstructionText = c.String(),
                    })
                .PrimaryKey(t => t.ChallengeInputId)
                .ForeignKey("dbo.Challenge", t => t.ChallengeId, cascadeDelete: true)
                .ForeignKey("dbo.Validation", t => t.ValidationId, cascadeDelete: true)
                .Index(t => t.ChallengeId)
                .Index(t => t.ValidationId);
            
            CreateTable(
                "dbo.Validation",
                c => new
                    {
                        ValidationId = c.Int(nullable: false, identity: true),
                        ValidationFunctionName = c.String(),
                    })
                .PrimaryKey(t => t.ValidationId);
            
            CreateTable(
                "dbo.InputLookupValue",
                c => new
                    {
                        InputLookupValueId = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.InputLookupValueId);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ContactId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        Comment = c.String(nullable: false, maxLength: 2000),
                    })
                .PrimaryKey(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ChallengeInput", new[] { "ValidationId" });
            DropIndex("dbo.ChallengeInput", new[] { "ChallengeId" });
            DropForeignKey("dbo.ChallengeInput", "ValidationId", "dbo.Validation");
            DropForeignKey("dbo.ChallengeInput", "ChallengeId", "dbo.Challenge");
            DropTable("dbo.Contact");
            DropTable("dbo.InputLookupValue");
            DropTable("dbo.Validation");
            DropTable("dbo.ChallengeInput");
            DropTable("dbo.Challenge");
        }
    }
}
