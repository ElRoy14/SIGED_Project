using AutoMapper;
using Siged.Application.ActivitiesCalendar.Exceptions;
using Siged.Application.ActivitiesCalendar.Interfaces;
using Siged.Application.TaskEmployees.DTOs;
using Siged.Domain;
using Siged.Domain.Entities;
using Siged.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.ActivitiesCalendar.Services
{
    public class ActivitiesCalendarService : IActivitiesCalendarService
    {
        private readonly IGenericRepository<GetTask> _taskRepository;
        private readonly IMapper _mapper;

        public ActivitiesCalendarService(IGenericRepository<GetTask> taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<Event>> GetEvents()
        {
            try
            {
                var evento = await _taskRepository
                    .VerifyDataExistenceAsync(task => task.TaskStatusId == 1);

                return _mapper.Map<List<Event>>(evento.ToList());
            }
            catch
            {
                throw new GetEventFailedException(); 
            }
        }
    }
}
