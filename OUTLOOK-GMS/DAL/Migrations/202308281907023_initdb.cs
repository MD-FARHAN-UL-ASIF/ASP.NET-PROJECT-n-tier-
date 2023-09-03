namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ClockInTime = c.DateTime(),
                        ClockOutTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        NID = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Gender = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Image = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UserType = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        Salary = c.Double(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Leaves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        LeaveType = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Reason = c.String(),
                        TotalAnnualLeaveEntitlement = c.Int(nullable: false),
                        RemainingLeave = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Notices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenKey = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        ExpiredAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            DropTable("dbo.GmsBudgets");
            DropTable("dbo.Products");
            DropTable("dbo.Salaries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bonus = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Allowance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                        Net = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        perprice = c.Int(nullable: false),
                        totalprice = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            DropForeignKey("dbo.Tokens", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Leaves", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Attendances", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Tokens", new[] { "EmployeeId" });
            DropIndex("dbo.Leaves", new[] { "EmployeeId" });
            DropIndex("dbo.Attendances", new[] { "EmployeeId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Notices");
            DropTable("dbo.Leaves");
            DropTable("dbo.Employees");
            DropTable("dbo.Attendances");
        }
    }
}
