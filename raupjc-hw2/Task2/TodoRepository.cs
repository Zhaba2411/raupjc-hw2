using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Task2
{
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;
        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y => if x is not null , expression returns x. Else it will
            // return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.FirstOrDefault(x => x.Id == todoId);
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                throw new DuplicateNameException("duplicate id: " + todoItem.Id); //napraviti vlastitu iznimku
            }
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public bool Remove(Guid todoId)
        {
            return _inMemoryTodoDatabase.Remove(_inMemoryTodoDatabase.FirstOrDefault(x => x.Id == todoId));
        }

        public TodoItem Update(TodoItem todoItem)
        {
            if (!_inMemoryTodoDatabase.Contains(todoItem))
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
            else
            {
                _inMemoryTodoDatabase.First(x => x.Id == todoItem.Id).DateCompleted = todoItem.DateCompleted;
                _inMemoryTodoDatabase.First(x => x.Id == todoItem.Id).DateCreated = todoItem.DateCreated;
                _inMemoryTodoDatabase.First(x => x.Id == todoItem.Id).Text = todoItem.Text;
                return _inMemoryTodoDatabase.First(x => x.Id == todoItem.Id);
            }
        }

        public bool MarkAsCompleted(Guid todoId)
        {

            TodoItem td = _inMemoryTodoDatabase.FirstOrDefault(x => x.Id == todoId);

            if (td == null || td.IsCompleted)
            {
                return false;
            }
            else
            {
                td.DateCompleted = DateTime.Now;
                return true;
            }
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(x => !x.IsCompleted).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(x => x.IsCompleted).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(filterFunction).ToList();
        }
    }
}