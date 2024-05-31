using Persistence.DTOs.Asistencia;
using Persistence.Queries.Asistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Asistencia
{
    public class AsistenciaService
    {
        private AsistenciaQueries _asistenciaQueries = null;

        public AsistenciaService()
        {
            AsistenciaQueries asistenciaQueries = new AsistenciaQueries();
            _asistenciaQueries = asistenciaQueries;
        }

        public List<BaseAsistenciaDTO> ObtenerAsistencias()
        {
            try
            {

                return _asistenciaQueries.Get();

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public BaseAsistenciaDTO ObtenerAsistenciaPorId(int id)
        {
            try
            {
                return _asistenciaQueries.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public List<BaseAsistenciaDTO> ObtenerAsistenciaPorFecha(DateTime fecha)
        {
            try
            {
                return _asistenciaQueries.GetByDate(fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int RegistrarLlegada(BaseAsistenciaDTO dto)
        {
            try
            {
                dto.Fecha = DateTime.Now;
                dto.HoraEntrada = DateTime.Now;

                return _asistenciaQueries.RegistrarEntrada(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int RegistrarSalida(BaseAsistenciaDTO dto)
        {
            try
            {
                dto.Fecha = DateTime.Now;
                dto.HoraSalida = DateTime.Now;

                return _asistenciaQueries.RegistrarEntrada(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
