namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intitbd4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GmsBudgets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BudgetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        SalaryPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductionPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherExpensesPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RemainingAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalaryAllocation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductionAllocation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherExpensesAllocation = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RemainingBudget = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GmsBudgets");
        }
    }
}
