﻿using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.BlogInterfaces;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _carBookContext;

        public BlogRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

		public List<Blog> GetAllBlogWithAuthor()
		{
			var values=_carBookContext.Blogs.Include(x=> x.Author).ToList();
            return values;
		}

        public List<Blog> GetBlogByAuthorId(int id)
        {
            var values=_carBookContext.Blogs.Include(x=>x.Author).Where(y=>y.BlogID==id).ToList();
            return values;
        }

        public List<Blog> GetLast3BlogsWithAuthors()
        {
            var values = _carBookContext.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).ToList();
            return values;
        }
    }
}
