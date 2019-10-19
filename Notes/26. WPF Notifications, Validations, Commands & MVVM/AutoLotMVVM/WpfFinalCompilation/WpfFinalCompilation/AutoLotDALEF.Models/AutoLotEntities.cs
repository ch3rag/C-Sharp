namespace AutoLotDALEF.Models {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Infrastructure.Interception;
    using System.Data.Entity.Core.Objects;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using AutoLotDALEF.Interception;
    using AutoLotDALEF.Models.Base;

    public partial class AutoLotEntities : DbContext {
        static readonly DatabaseLogger logger = new DatabaseLogger("sqllog.txt", true);
        public AutoLotEntities()
            : base("name=AutoLotConnection") {
                // Command Interceptor
                // DbInterception.Add(new ConsoleWriterInterceptor());

                // DatabaseLogger
                // logger.StartLogging();
                // DbInterception.Add(logger);

                ObjectContext context = (this as IObjectContextAdapter).ObjectContext;

                context.ObjectMaterialized += OnObjectMaterialized;
                context.SavingChanges += OnSavingChanges;
            
        }

        void OnSavingChanges(object sender, EventArgs e) {
            ObjectContext context = sender as ObjectContext;
            if (context == null) return;
            foreach (ObjectStateEntry entry in context.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified)) {
                if ((entry.Entity as Inventory) != null) {
                    Inventory entity = entry.Entity as Inventory;
                    if (entity.Color == "Red") {
                        Console.WriteLine("Red cars are not allowed!");
                        entry.RejectPropertyChanges("Color");
                    }
                }
            }
        }

        void OnObjectMaterialized(object sender, ObjectMaterializedEventArgs e) {
            EntityBase model = e.Entity as EntityBase;
            if (model != null) model.IsChanged = false;
        }

        public virtual DbSet<CreditRisk> CreditRisks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Cars { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Inventory)
                .HasForeignKey(e => e.CardId) 
                .WillCascadeOnDelete(false);
        }

        protected override void Dispose(bool disposing) {
            logger.StartLogging();
            DbInterception.Remove(logger);
            base.Dispose(disposing);
        }
    }
    
}
