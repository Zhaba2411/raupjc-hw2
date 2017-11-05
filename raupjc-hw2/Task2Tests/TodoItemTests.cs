using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{
    [TestClass()]
    public class TodoItemTests
    {
        [TestMethod()]
        public void TodoItemTest()
        {
            TodoItem tdItem = new TodoItem("TODOITEM");

            Assert.AreEqual(tdItem.IsCompleted, false);
            tdItem.DateCompleted = DateTime.Now;
            Assert.AreEqual(tdItem.IsCompleted, true);

        }
    }
}