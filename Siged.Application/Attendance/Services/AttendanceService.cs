using Siged.Application.Attendance.DTOs;
using Siged.Application.Attendance.Exceptions;
using Siged.Application.Attendance.Interfaces;
using Siged.Domain.Interfaces;
using Siged.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Siged.Domain.Interfaces.Attendance;

namespace Siged.Application.Attendance.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository<GetAttendance> _attendanceRepository;
        private readonly IMapper _mapper;

        public AttendanceService(IAttendanceRepository<GetAttendance> attendanceRepository, IMapper mapper)
        {
            _attendanceRepository = attendanceRepository;
            _mapper = mapper;
        }

        public async Task<CheckIn> CheckIn(GetAttendance attendance)
        {
            try
            {
                var checkIn = await _attendanceRepository.CheckIn(attendance);
                return _mapper.Map<CheckIn>(checkIn);
            }
            catch
            {
                throw new CheckInFailedException();
            }
        }

        public async Task<CheckOut> CheckOut(GetAttendance attendance)
        {
            try
            {
                var checkOut = await _attendanceRepository.CheckOut(attendance);
                return _mapper.Map<CheckOut>(checkOut);
            }
            catch
            {
                throw new CheckOutFailedException();
            }
        }

        public async Task<List<GetAttendance>> GetAllAttendanceAsync()
        {
            try
            {
                var attendances = await _attendanceRepository.GetAllAttendanceAsync();
                var attendance = attendances.
                                 Include(user => user.UserId).ToList();
                return _mapper.Map<List<GetAttendance>>(attendance);
            }
            catch
            {
                throw new GetAttendanceException();
            }
        }
    }
}
