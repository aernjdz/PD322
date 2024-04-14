using Exam_DAL.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_DAL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryModel, Configuration>());

            using (var context = new LibraryModel())
            {
                context.Database.Initialize(force: true);
            }
        }
    }
}
