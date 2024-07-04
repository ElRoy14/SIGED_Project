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

        public async Task<CreateCheckIn> CheckIn(GetAttendance attendance)
        {
            try
            {
                attendance.CheckIn = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                var checkIn = await _attendanceRepository.CreateAsync(_mapper.Map<Attendance>(attendance));

                var query = await _attendanceRepository.VerifyDataExistenceAsync(c => c.AttendanceId == checkIn.AttendanceId);
                checkIn = query
                    .Include(attendance => attendance.User).First();

                return _mapper.Map<CreateCheckIn>(checkIn);
            }
            catch
            {
                throw new CheckInFailedException();
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
