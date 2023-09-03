namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingOtherEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShippingAddress = c.String(),
                        BillingAddress = c.String(),
                        PaymentMethod = c.Int(nullable: false),
                        PaymentStatus = c.Int(nullable: false),
                        ShippingMethod = c.Int(nullable: false),
                        ShippingCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ExpectedDeliveryDate = c.DateTime(nullable: false),
                        TrackingNumber = c.String(),
                        PromoCode = c.String(),
                        TaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderPriority = c.Int(nullable: false),
                        Discounts = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.ProductionPlans",
                c => new
                    {
                        PlanID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        ProductionStartDate = c.DateTime(nullable: false),
                        ProductionEndDate = c.DateTime(nullable: false),
                        QuantityToProduce = c.Int(nullable: false),
                        OutputProduct = c.String(),
                    })
                .PrimaryKey(t => t.PlanID)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        WorkstationID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        TaskDescription = c.String(),
                        EstimatedTime = c.Time(nullable: false, precision: 7),
                        TaskStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .ForeignKey("dbo.Workstations", t => t.WorkstationID, cascadeDelete: true)
                .Index(t => t.WorkstationID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Workstations",
                c => new
                    {
                        WorkstationID = c.Int(nullable: false, identity: true),
                        WorkstationName = c.String(),
                        WorkstationType = c.Int(nullable: false),
                        Supervisor = c.String(),
                        Shifts = c.Int(nullable: false),
                        DefectRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductionVolume = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.WorkstationID)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "WorkstationID", "dbo.Workstations");
            DropForeignKey("dbo.Workstations", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Tasks", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.ProductionPlans", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Workstations", new[] { "Employee_Id" });
            DropIndex("dbo.Tasks", new[] { "EmployeeID" });
            DropIndex("dbo.Tasks", new[] { "WorkstationID" });
            DropIndex("dbo.ProductionPlans", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropTable("dbo.Workstations");
            DropTable("dbo.Tasks");
            DropTable("dbo.ProductionPlans");
            DropTable("dbo.Orders");
        }
    }
}
