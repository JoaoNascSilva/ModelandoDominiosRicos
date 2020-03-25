using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            for (int i = 0; i <= 10; i++)
            {
                _students.Add(new Student(new Domain.ValueObjects.Name("Aluno", i.ToString()), new Document("1111111111" + i.ToString(), EDocumentType.CPF), new Email(i.ToString() + "@balta.io")));
            }
        }

        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var expression = StudentQueries.GetStudenInfo("123456789011");
            var student = _students.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreEqual(null, student);
        }

        public void ShouldReturnStudentWhenDocumentExists()
        {
            var expression = StudentQueries.GetStudenInfo("1111111111");
            var student = _students.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreNotEqual(null, student);
        }

    }
}