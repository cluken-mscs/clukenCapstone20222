using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneProject.Models;

namespace CapstoneProject.Data
{
    public class DbInitializer
    {
        public static void Initialize(ProductContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var boots = new Product[]
            {
            new Product{TypeId=2,Brand="DC",Description="Judge",Size="Large"},
            new Product{TypeId=2,Brand="DC",Description="Control",Size="Large"},
            new Product{TypeId=2,Brand="thirtytwo",Description="JonesMTB",Size="Large"},
            new Product{TypeId=2,Brand="thirtytwo",Description="TM-3XD",Size="Large"},
            new Product{TypeId=2,Brand="Ride",Description="Trident",Size="Large"},
            new Product{TypeId=2,Brand="Ride",Description="Insano",Size="Large"},
            new Product{TypeId=2,Brand="Ride",Description="Anchor",Size="Large"},
            new Product{TypeId=2,Brand="Adidas",Description="Samba",Size="Large"},
            new Product{TypeId=2,Brand="Adidas",Description="Lexicon",Size="Large"},
            };
            foreach (Product b in boots)
            {
                context.Products.Add(b);
            }
            context.SaveChanges();
        }
    }
}

//            var courses = new Course[]
//            {
//            new Course{CourseID=1050,Title="Chemistry",Credits=3},
//            new Course{CourseID=4022,Title="Microeconomics",Credits=3},
//            new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
//            new Course{CourseID=1045,Title="Calculus",Credits=4},
//            new Course{CourseID=3141,Title="Trigonometry",Credits=4},
//            new Course{CourseID=2021,Title="Composition",Credits=3},
//            new Course{CourseID=2042,Title="Literature",Credits=4}
//            };
//            foreach (Course c in courses)
//            {
//                context.Courses.Add(c);
//            }
//            context.SaveChanges();

//            var enrollments = new Enrollment[]
//            {
//            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
//            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
//            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
//            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
//            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
//            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
//            new Enrollment{StudentID=3,CourseID=1050},
//            new Enrollment{StudentID=4,CourseID=1050},
//            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
//            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
//            new Enrollment{StudentID=6,CourseID=1045},
//            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
//            };
//            foreach (Enrollment e in enrollments)
//            {
//                context.Enrollments.Add(e);
//            }
//            context.SaveChanges();
//        }
//    }
//}
