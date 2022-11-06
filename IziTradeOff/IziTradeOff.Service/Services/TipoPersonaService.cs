using AutoMapper;
using IziTradeOff.Application.Dtos;
using IziTradeOff.Application.Interfaces.Services;
using IziTradeOff.Application.Interfaces;
using IziTradeOff.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IziTradeOff.Persistence.Connection;
using System.Linq;

namespace IziTradeOff.Service.Services
{
    public class TipoPersonaService : ITipoPersonaService
    {
        private IMapper mapper;
        /// <summary>
        /// Constructor vacio
        /// </summary>
        public TipoPersonaService()
        {

        }
        /// <summary>
        /// Constructor del servicio
        /// </summary>
        /// <param name="mapper">Automapper Injectable</param>
        public TipoPersonaService(IMapper _mapper)
        {
            mapper = _mapper;
        }
        /// <summary>
        /// Agrega un nuevo tipo persona
        /// </summary>
        /// <param name="tipoPersona">TipoPersona</param>
        /// <returns>tipo persona</returns>
        /// Francisco Rios
        public async Task<TipoPersonaDto> AddTipoPersonaAsync(TipoPersonaDto tipoPersona)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _unitOfWork.Repository<TipoPersona>();
                TipoPersona newTipoPersona = new TipoPersona();
                mapper.Map(tipoPersona, newTipoPersona);
                newTipoPersona.Estado = true;
                repository.AddEntity(newTipoPersona);
                await _unitOfWork.Complete();
                return tipoPersona;
            }
        }
        /// <summary>
        /// Actualiza el tipo de persona
        /// </summary>
        /// <param name="tipoPersona">Objeto Tipo Persona/param>
        /// <returns></returns>
        /// Francisco Rios
        public async Task<TipoPersonaDto> UpdateTipoPersonaAsync(TipoPersonaDto tipoPersona)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var repository = _unitOfWork.Repository<TipoPersona>();
                TipoPersona newTipoPersona = new TipoPersona();
                mapper.Map(tipoPersona, newTipoPersona);
                repository.UpdateEntity(newTipoPersona);
                await _unitOfWork.Complete();
                return tipoPersona;
            }
        }
        /// <summary>
        /// Obtiene todas las persona
        /// </summary>
        /// <returns>Obtiene todas las persona</returns>
        /// Francisco Rios
        public async Task<IReadOnlyList<TipoPersonaDto>> GetAllTipoPersonaAsync()
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var listPersona = await _unitOfWork.Repository<TipoPersona>().GetAllAsync();
                return mapper.Map<List<TipoPersona>, List<TipoPersonaDto>>(listPersona.ToList());
            }
        }
        
        /// <summary>
        /// Obtiene el tipo de persona por Id
        /// </summary>
        /// <param name="IdTipoPersona">Id Tipo Persona/param>
        /// <returns>Retorna la tipo de persona por Id</returns>
        /// Francisco Rios
        public async Task<TipoPersonaDto> GetTipoPersonaPorIdAsync(int IdTipoPersona)
        {
            using (var _unitOfWork = new Contextos().GetUnitOfWork())
            {
                var query = new Persistence.Base.BaseSpecification<TipoPersona>(x => x.Id == IdTipoPersona);
                var tipoPersona = await _unitOfWork.Repository<TipoPersona>().GetByIdWithSpec(query);
                return mapper.Map<TipoPersona, TipoPersonaDto>(tipoPersona);
            }
        }
    }
}

