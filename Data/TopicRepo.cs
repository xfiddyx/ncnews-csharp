using System;
using System.Collections.Generic;
using System.Linq;
using NcNews.Models;

namespace NcNews.Data
{
    public class TopicRepository : ITopicRepo
    {
        private readonly NcNewsContext _context;

        public TopicRepository(NcNewsContext context)
        {
            _context = context;
        }

        public IEnumerable<Topics> GetAllTopics()
        {
            return _context.Topic.ToList();
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
