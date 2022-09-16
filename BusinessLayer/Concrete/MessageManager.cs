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
    public class MessageManager : IGenericServices<Message>
    {
        IMessageDAL _messageDAL;
        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public void TAdd(Message t)
        {
            _messageDAL.Insert(t);
        }

        public void TDelete(Message t)
        {
            _messageDAL.Delete(t);

        }

        public List<Message> TGetByFilterList()
        {
            throw new NotImplementedException();
        }

        public List<Message> TGetByFilterList(Expression<Func<Message, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Message TGetByID(int id)
        {
            return _messageDAL.GetByID(id);
        }

        public List<Message> TGetList()
        {
            return _messageDAL.GetList();
        }

        public void TUpdate(Message t)
        {
            _messageDAL.Update(t);
        }
    }
}
