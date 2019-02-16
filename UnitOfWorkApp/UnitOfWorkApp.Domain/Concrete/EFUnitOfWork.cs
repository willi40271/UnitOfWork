using System;
using System.Data.Entity;
using UnitOfWorkApp.Domain.Abstract;
using UnitOfWorkApp.Domain.Entities;

namespace UnitOfWorkApp.Domain.Concrete
{
    public class EFUnitOfWork : IEFUnitOfWork, IDisposable
    {
        public EFUnitOfWork()
        {
            this.Context = new EFDbContext();
        }

        public EFUnitOfWork(string connectionString)
        {
            this.Context = new EFDbContext();
            this.Context.Database.Connection.ConnectionString = connectionString;
            this.Context.Database.Connection.Open();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.Context != null)
                {
                    this.Context.Dispose();
                    this.Context = null;
                }
            }
        }

        public EFDbContext Context { get; private set; }
        public Database Database => Context.Database;

        //Define your Generic Repositories
        private EFRepository<Category> categoryRepository;
        public EFRepository<Category> CategoryRepository => this.categoryRepository ?? (this.categoryRepository = new EFRepository<Category>(Context));

        private EFRepository<Customer> customerRepository;
        public EFRepository<Customer> CustomerRepository => this.customerRepository ?? (this.customerRepository = new EFRepository<Customer>(Context));

        private EFRepository<Employee> employeeRepository;
        public EFRepository<Employee> EmployeeRepository => this.employeeRepository ?? (this.employeeRepository = new EFRepository<Employee>(Context));

        private EFRepository<EmployeeTerritory> employeeTerritoryRepository;
        public EFRepository<EmployeeTerritory> EmployeeTerritoryRepository => this.employeeTerritoryRepository ?? (this.employeeTerritoryRepository = new EFRepository<EmployeeTerritory>(Context));

        private EFRepository<OrderDetail> orderDetailRepository;
        public EFRepository<OrderDetail> OrderDetailRepository => this.orderDetailRepository ?? (this.orderDetailRepository = new EFRepository<OrderDetail>(Context));

        private EFRepository<Order> orderRepository;
        public EFRepository<Order> OrderRepository => this.orderRepository ?? (this.orderRepository = new EFRepository<Order>(Context));

        private EFRepository<Product> productRepository;
        public EFRepository<Product> ProductRepository => this.productRepository ?? (this.productRepository = new EFRepository<Product>(Context));

        private EFRepository<Region> regionRepository;
        public EFRepository<Region> RegionRepository => this.regionRepository ?? (this.regionRepository = new EFRepository<Region>(Context));

        private EFRepository<Shipper> shipperRepository;
        public EFRepository<Shipper> ShipperRepository => this.shipperRepository ?? (this.shipperRepository = new EFRepository<Shipper>(Context));

        private EFRepository<Supplier> supplierRepository;
        public EFRepository<Supplier> SupplierRepository => this.supplierRepository ?? (this.supplierRepository = new EFRepository<Supplier>(Context));

        private EFRepository<Territory> territoryRepository;
        public EFRepository<Territory> TerritoryRepository => this.territoryRepository ?? (this.territoryRepository = new EFRepository<Territory>(Context));
    }
}