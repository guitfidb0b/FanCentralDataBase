using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FanCentral2.Models;

namespace FanCentral2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDBContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any Customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var customers = new Customer[]
            {
                new Customer { FirstName = "Carson",   LastName = "Alexander",
                    Email = "carson.alexander@somewhere.com", Password = "Password" },
                new Customer { FirstName = "Meredith", LastName = "Alonso",
                    Email = "meredith.alonso@nowhere.com", Password = "Password" }
            };

            foreach (Customer s in customers)
            {
                context.Customers.Add(s);
            }
            context.SaveChanges();

            var addresses = new Address[]
            {
                new Address { StreetAddress = "123 Main St",    City = "Somewhere",    State = "Someplace",
                    ZipCode = 12345 },
                new Address { StreetAddress = "456 Main St",    City = "Somewhere",    State = "Someplace",
                    ZipCode = 12345 },
            };

            foreach (Address i in addresses)
            {
                context.Addresses.Add(i);
            }
            context.SaveChanges();

            var payments = new Payment[]
            {
                new Payment { CardNumber = 12345678912345,     Expiration = DateTime.Parse("2019-09-10"),
                    NameOnCard = "Alexander Carson", Code = 123},
                new Payment { CardNumber = 12345678912345,     Expiration = DateTime.Parse("2019-10-10"),
                    NameOnCard = "Meridith Alonso", Code = 123}
            };

            foreach (Payment d in payments)
            {
                context.Payments.Add(d);
            }
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order { OrderDate = DateTime.Parse("2019-09-10"), CustomerID = 1 },
                new Order { OrderDate = DateTime.Parse("2019-09-10"), CustomerID = 1 }
            };

            foreach (Order c in orders)
            {
                context.Orders.Add(c);
            }
            context.SaveChanges();

            var orderedProducts = new OrderedProduct[]
            {
                new OrderedProduct { OrderID = 1, ProductID = 1 },
                new OrderedProduct { OrderID = 1, ProductID = 2 },
                new OrderedProduct { OrderID = 1, ProductID = 3 },
                new OrderedProduct { OrderID = 2, ProductID = 4 },
                new OrderedProduct { OrderID = 2, ProductID = 5 },
                new OrderedProduct { OrderID = 2, ProductID = 6 }
            };

            foreach (OrderedProduct o in orderedProducts)
            {
                context.OrderedProducts.Add(o);
            }
            context.SaveChanges();

            /*var courseInstructors = new CourseAssignment[]
            {
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Kapoor").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Fakhouri").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                    },
                new CourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Literature" ).CourseID,
                    InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                    },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    Grade = Grade.A
                },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                    Grade = Grade.C
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Anand").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Anand").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                    Grade = Grade.B
                    },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Li").ID,
                    CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                    Grade = Grade.B
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Justice").ID,
                    CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                    Grade = Grade.B
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }*/
            context.SaveChanges();
        }
    }
}