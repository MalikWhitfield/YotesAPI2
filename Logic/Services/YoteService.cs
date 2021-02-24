using AutoMapper;
using Common.Exceptions;
using Data.Interfaces;
using Data.Models;
using Logic.DTOs;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class YoteService : IYoteService
    {
        private readonly IYoteRepository _yoteRepository;
        //private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public YoteService(IYoteRepository yoteRepository, IMapper mapper)
        {
            _yoteRepository = yoteRepository;
            //_userService = userService;
            _mapper = mapper;
        }

        public async Task<YoteDTO> CreateYote(CreateYoteDTO createYoteDTO)
        {
            var yote = _mapper.Map<Yote>(createYoteDTO);
            yote = await _yoteRepository.Create(yote);
            return _mapper.Map<YoteDTO>(yote);
        }
        public async Task<YoteDTO> GetYote(Guid id)
        {
            return _mapper.Map<YoteDTO>(await _yoteRepository.GetById(id));
        }
        public async Task<List<YoteDTO>> GetYotes()
        {
            var yotes = await _yoteRepository.GetAll();
            var yoteDTOs = new List<YoteDTO>();

            foreach (Yote yote in yotes.Results)
            {
                yoteDTOs.Add(_mapper.Map<YoteDTO>(yote));
            }
            return yoteDTOs;
        }
        public async Task<YoteDTO> DeleteYote(Guid id)
        {
            var yote = await _yoteRepository.GetById(id);
            if(yote == null)
            {
                throw new ResourceValidationException($"Yote with ID {id} not found.");
            }
            yote.IsDeleted = true;

            await _yoteRepository.Update(yote);
            return _mapper.Map<YoteDTO>(yote);
        }

        public async Task<YoteDTO> DeactivateYote(Guid id)
        {
            var yote = await _yoteRepository.GetById(id);
            if (yote == null)
            {
                throw new ResourceValidationException($"Yote with ID {id} not found.");
            }
            yote.IsActive = false;

            await _yoteRepository.Update(yote);
            return _mapper.Map<YoteDTO>(yote);
        }

        public async Task<YoteDTO> UpdateYote(YoteDTO yoteDTO)
        {
            return null;
        }
    }

    public class YoteMappingProfile : Profile
    {
        public YoteMappingProfile()
        {
            CreateMap<CreateYoteDTO, Yote>();
            CreateMap<YoteDTO, Yote>().ReverseMap();
            CreateMap<ListResults<YoteDTO>, ListResults<Yote>>().ReverseMap();
            CreateMap<ListResults<Yote>, ListResults<YoteDTO>>().ReverseMap();
            CreateMap<List<Yote>, List<YoteDTO>>().ReverseMap();
            CreateMap<List<YoteDTO>, List<Yote>>().ReverseMap();
        }
    }
}
