using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ToDoListManager : IToDoListServices
    {
        IToDoListDAL _toDoListDAL;

        public ToDoListManager()
        {
        }

        public ToDoListManager(IToDoListDAL toDoListDAL)
        {
            _toDoListDAL = toDoListDAL;
        }

        public void TAdd(ToDoList t)
        {
            _toDoListDAL.Insert(t);
        }

        public void TDelete(ToDoList t)
        {
            _toDoListDAL.Delete(t);
        }

        public List<ToDoList> TGetByFilterList()
        {
            throw new NotImplementedException();
        }

        public List<ToDoList> TGetByFilterList(Expression<Func<ToDoList, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public ToDoList TGetByID(int id)
        {
            return _toDoListDAL.GetByID(id);
        }

        public List<ToDoList> TGetList()
        {
            return _toDoListDAL.GetList();
        }

        public void TUpdate(ToDoList t)
        {
            _toDoListDAL.Update(t);
        }
    }
}
