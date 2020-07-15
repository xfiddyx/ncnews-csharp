using System;
using System.Collections.Generic;
using NcNews.Models;

namespace NcNews.Data
{
    public interface ITopicRepo
    {
        IEnumerable<Topics> GetAllTopics();
        void Save();

    }
}
