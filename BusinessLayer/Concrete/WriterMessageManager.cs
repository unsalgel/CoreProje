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

    public class WriterMessageManager : IWriterMessageServices
    {
        IWriterMessageDAL _writerMessageDAL;

        public WriterMessageManager(IWriterMessageDAL writerMessageDAL)
        {
            _writerMessageDAL = writerMessageDAL;
        }

        public List<WriterMessage> GetListReceiverMessage(string p)
        {
            return _writerMessageDAL.GetByFilterList(a => a.Receiver == p);
        }

        public List<WriterMessage> GetListSenderMessage(string p)
        {
            return _writerMessageDAL.GetByFilterList(a => a.Sender == p);
        }

        public void TAdd(WriterMessage t)
        {
            _writerMessageDAL.Insert(t);
        }

        public void TDelete(WriterMessage t)
        {
           _writerMessageDAL.Delete(t);
        }

     

        public List<WriterMessage> TGetByFilterList()
        {
            throw new NotImplementedException();
        }

        public List<WriterMessage> TGetByFilterList(Expression<Func<WriterMessage, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public WriterMessage TGetByID(int id)
        {
            return _writerMessageDAL.GetByID(id);
        }

        public List<WriterMessage> TGetList()
        {
            return _writerMessageDAL.GetList();
        }

        public void TUpdate(WriterMessage t)
        {
            _writerMessageDAL.Update(t);
            
        }
    }
}
