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
    public class SkillManager : ISkillServices
    {
        ISkillDAL _skillDAL;

        public SkillManager(ISkillDAL skillDAL)
        {
            _skillDAL = skillDAL;
        }

        public void TAdd(Skill t)
        {
            _skillDAL.Insert(t);
        }

        public void TDelete(Skill t)
        {
            _skillDAL.Delete(t);
        }

        public List<Skill> TGetByFilterList()
        {
            throw new NotImplementedException();
        }

        public List<Skill> TGetByFilterList(Expression<Func<Skill, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Skill TGetByID(int id)
        {
            return _skillDAL.GetByID(id);
        }

        public List<Skill> TGetList()
        {
            return _skillDAL.GetList();
        }

        public void TUpdate(Skill t)
        {
            _skillDAL.Update(t);
        }
    }
}
