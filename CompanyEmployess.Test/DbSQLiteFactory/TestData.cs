using CompanyEmployess.DAL;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployess.Test.DbSQLiteFactory
{
    public static class TestData
    {
        public static void RepositorySeed(RepositoryContext context)
        {
            context.Companies.AddRange(AddCompanes());
            context.Employees.AddRange(AddEmployees());

            context.SaveChanges();
        }

        public static void ExternalClientSeed(ExternalClientContext context)
        {
            context.Clients.AddRange(AddClients());

            context.SaveChanges();
        }

        private static List<Company> AddCompanes()
        {
            return new List<Company>
            {
                new Company() 
                { 
                    Id = new Guid("C9D4C053-49B6-410C-BC78-2D54A9991870"), 
                    Name = "IT_Solutions Ltd", 
                    Address = "583 Wall Dr. Gwynn Oak, MD 21207", 
                    Country ="USA" 
                },
                new Company() 
                { 
                    Id = new Guid("3D490A70-94CE-4D15-9494-5248280C2CE3"), 
                    Name = "Admin_Solutions Ltd", 
                    Address = "312 Forest Avenue, BF 923", 
                    Country = "USA" 
                }
            };
        }

        private static List<Employee> AddEmployees()
        {
            return new List<Employee>
            {
                new Employee() 
                { 
                    Id = new Guid("80ABBCA8-664D-4B20-B5DE-024705497D4A"), 
                    Name = "Sam Raiden", 
                    Age = 26, 
                    Position = "Software developer", 
                    CompanyId = new Guid("C9D4C053-49B6-410C-BC78-2D54A9991870") 
                },
                new Employee() 
                { 
                    Id = new Guid("021CA3C1-0DEB-4AFD-AE94-2159A8479811"), 
                    Name = "Kane Miller", 
                    Age = 35, 
                    Position = "Administrator", 
                    CompanyId = new Guid("3D490A70-94CE-4D15-9494-5248280C2CE3") 
                },
                new Employee() 
                { 
                    Id = new Guid("86DBA8C0-D178-41E7-938C-ED49778FB52A"), 
                    Name = "Jana McLeaf", 
                    Age = 30, 
                    Position = "Software developer", 
                    CompanyId = new Guid("C9D4C053-49B6-410C-BC78-2D54A9991870") 
                }
            };
        }

        private static List<Client> AddClients()
        {
            return new List<Client>
            {
                new Client() 
                { 
                    Id = new Guid("C1F33503-BB38-4FA1-98A0-6CFAF9986797"), 
                    Name = "External Client's Test Name" 
                }
            };
        }
    }
}
