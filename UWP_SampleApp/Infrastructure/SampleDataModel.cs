namespace Infrastructure
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using BusinessObjects;

    public partial class SampleDataModel : DbContext
    {
        public SampleDataModel()
            : base("name=SampleDataModel")
        {
        }

        public IDbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
