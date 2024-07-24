using Siged.Application.TaskEmployees.DTOs;
using Siged.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.ActivitiesCalendar.Interfaces
{
    public interface IActivitiesCalendarService
    {
        Task<List<Event>> GetEvents();
    }
}
