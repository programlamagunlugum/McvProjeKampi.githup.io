﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
           _contentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList(string p)
        {
            return _contentDal.List(x=>x.ContentValue.Contains(p));
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }

        public List<Content> GetListHeadingByID(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);
        }
    }
}
