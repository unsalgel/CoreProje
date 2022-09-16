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
	public class WriterUserManager : IWriterUserServices
	{
		IWriterUserDAL _writerUserDAL;

		public WriterUserManager(IWriterUserDAL writerUserDAL)
		{
			_writerUserDAL=writerUserDAL;
		}

		public void TAdd(WriterUser t)
		{
			throw new NotImplementedException();
		}

		public void TDelete(WriterUser t)
		{
			throw new NotImplementedException();
		}

		public List<WriterUser> TGetByFilterList(Expression<Func<WriterUser, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public WriterUser TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<WriterUser> TGetList()
		{
			return _writerUserDAL.GetList();	
		}

		public void TUpdate(WriterUser t)
		{
			throw new NotImplementedException();
		}
	}
}
