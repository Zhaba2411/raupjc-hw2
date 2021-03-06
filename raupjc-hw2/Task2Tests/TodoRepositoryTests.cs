﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {
        [TestMethod()]
        public void GetTest()
        {
            TodoItem tdItem1 = new TodoItem("td1");
            TodoItem tdItem2 = new TodoItem("td2");
            TodoItem tdItem3 = new TodoItem("td3");
            TodoItem tdItem4 = new TodoItem("td4");

            TodoRepository tdr = new TodoRepository(new GenericList<TodoItem>
            {
                tdItem1,
                tdItem2,
                tdItem3,
                tdItem4
            });

            Guid id = tdr.GetAll()[0].Id;

            Assert.AreEqual(tdItem1, tdr.Get(id));

        }

        [TestMethod()]
        public void AddTest()
        {
            TodoItem tdItem1 = new TodoItem("td1");
            TodoItem tdItem2 = new TodoItem("td2");
            TodoItem tdItem3 = new TodoItem("td3");
            TodoItem tdItem4 = new TodoItem("td4");

            TodoRepository tdr = new TodoRepository(new GenericList<TodoItem>
            {
                tdItem1,
                tdItem2,
                tdItem3,
                tdItem4
            });

            int sizeBefore = tdr.GetAll().Count;

            tdr.Add(new TodoItem("td5"));
            
            Assert.AreEqual(sizeBefore + 1, tdr.GetAll().Count); 
        }

        [TestMethod()]
        public void RemoveTest()
        {
            TodoItem tdItem1 = new TodoItem("td1");
            TodoItem tdItem2 = new TodoItem("td2");
            TodoItem tdItem3 = new TodoItem("td3");
            TodoItem tdItem4 = new TodoItem("td4");

            TodoRepository tdr = new TodoRepository(new GenericList<TodoItem>
            {
                tdItem1,
                tdItem2,
                tdItem3,
                tdItem4
            });

            int sizeBefore = tdr.GetAll().Count;

            tdr.Remove(tdr.GetAll()[0].Id);

            Assert.AreEqual(sizeBefore - 1, tdr.GetAll().Count);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            TodoItem tdItem = new TodoItem("TodoItem");
            
            TodoRepository tdr = new TodoRepository(new GenericList<TodoItem>
            {
                tdItem
            });

            TodoItem td = new TodoItem("TodoItemUpdated");
            td.Id = tdItem.Id;

            string before = tdr.GetAll()[0].Text;
            Assert.AreNotEqual(before, tdr.Update(td));
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            TodoItem tdItem = new TodoItem("TodoItem");

            TodoRepository tdr = new TodoRepository(new GenericList<TodoItem>
            {
                tdItem
            });

            bool before = tdItem.IsCompleted;
            bool after = tdr.MarkAsCompleted(tdItem.Id);
            Assert.AreNotEqual(before, after);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            TodoItem tdItem1 = new TodoItem("td1");
            TodoItem tdItem2 = new TodoItem("td2");
            TodoItem tdItem3 = new TodoItem("td3");
            TodoItem tdItem4 = new TodoItem("td4");

            GenericList < TodoItem > todoItemList = new GenericList<TodoItem>
            {
                tdItem1,
                tdItem2,
                tdItem3,
                tdItem4
            };

            TodoRepository tdr = new TodoRepository(todoItemList);

            CollectionAssert.AreEqual(todoItemList.ToList(), tdr.GetAll());

        }

        [TestMethod()]
        public void GetActiveTest()
        {
            TodoItem tdItem1 = new TodoItem("td1");
            TodoItem tdItem2 = new TodoItem("td2");
            TodoItem tdItem3 = new TodoItem("td3");
            TodoItem tdItem4 = new TodoItem("td4");

            TodoRepository tdr = new TodoRepository(new GenericList<TodoItem>
            {
                tdItem1,
                tdItem2,
                tdItem3,
                tdItem4
            });

            int before = tdr.GetAll().Count;

            tdr.MarkAsCompleted(tdr.GetAll()[0].Id);

            Assert.AreEqual(before - 1, tdr.GetActive().Count) ;

        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            TodoItem tdItem1 = new TodoItem("td1");
            TodoItem tdItem2 = new TodoItem("td2");
            TodoItem tdItem3 = new TodoItem("td3");
            TodoItem tdItem4 = new TodoItem("td4");

            TodoRepository tdr = new TodoRepository(new GenericList<TodoItem>
            {
                tdItem1,
                tdItem2,
                tdItem3,
                tdItem4
            });

            int before = tdr.GetAll().Count;

            tdr.MarkAsCompleted(tdr.GetAll()[0].Id);
            tdr.MarkAsCompleted(tdr.GetAll()[1].Id);

            Assert.AreEqual(2, tdr.GetCompleted().Count);
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            TodoItem tdItem1 = new TodoItem("td");
            TodoItem tdItem2 = new TodoItem("td");
            TodoItem tdItem3 = new TodoItem("tdi");
            TodoItem tdItem4 = new TodoItem("tdi");

            TodoRepository tdr = new TodoRepository(new GenericList<TodoItem>
            {
                tdItem1,
                tdItem2,
                tdItem3,
                tdItem4
            });

            List<TodoItem> before = new List<TodoItem>();
            before.Add(tdItem1);
            before.Add(tdItem2);

            var todoItems = tdr.GetFiltered(stud => stud.Text.Equals("td"));

            CollectionAssert.AreEqual(before, todoItems);
        }
    }
}