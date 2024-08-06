using Siged.Application.Attendances.DTOs;
using Siged.Application.Attendances.Exceptions;
using Siged.Application.Attendances.Interfaces;
using Siged.Domain.Interfaces;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Siged.Domain;
using Microsoft.AspNetCore.Identity;

namespace Siged.Application.Attendances
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IGenericRepository<Attendance> _attendanceRepository;
        private readonly IMapper _mapper;

        public AttendanceService(IGenericRepository<Attendance> genericRepository, IMapper mapper)
        {
            _attendanceRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<GetAttendance> CheckIn(CreateCheckIn attendance)
        {
            try
            {
                DateTime currentDate = DateTime.Now;
                TimeSpan currentTime = new TimeSpan(currentDate.Hour, currentDate.Minute, currentDate.Second);

                var newAttendance = new Attendance
                {
                    UserId = attendance.UserId,
                    AttendanceDate = currentDate,
                    CheckIn = currentTime
                };

                var createdAttendance = await _attendanceRepository.CreateAsync(newAttendance);

                var query = await _attendanceRepository.VerifyDataExistenceAsync(c => c.AttendanceId == createdAttendance.AttendanceId);
                createdAttendance = query
                    .Include(att => att.User)
                    .First();

                return _mapper.Map<GetAttendance>(createdAttendance);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<GetAttendance> GetAttendanceByIdAsync(int id)
        {
            var attendance = await _attendanceRepository.GetEverythingAsync(a => a.AttendanceId == id);
            return _mapper.Map<GetAttendance>(attendance);
        }

        public async Task<CheckOut> CheckOut(GetAttendance attendance)
        {
            try
            {
                //attendance = _attendanceRepository.GetEverythingAsync(a => a.)

                attendance.CheckOut = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                var checkOut = await _attendanceRepository.UpdateAsync(_mapper.Map<Attendance>(attendance));

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
                var attendances = await _attendanceRepository.VerifyDataExistenceAsync();
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
