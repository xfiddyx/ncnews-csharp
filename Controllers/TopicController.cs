using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NcNews.Data;
using NcNews.Dtos;
using NcNews.Models;

namespace NcNews.Controllers
{
    [Route("api/topics")]
    [ApiController]
    public class TopicController : Controller
    {
        private readonly ITopicRepo _topicRepository;
        private readonly IMapper _mapper;

        public TopicController(ITopicRepo topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;

        }
        [HttpGet]
        public ActionResult<IEnumerable<Topics>> GetAllTopics()
        {

            var result = _topicRepository.GetAllTopics();
            return Ok(_mapper.Map<IEnumerable<ReadTopicDto>>(result));
        }

    }

}

