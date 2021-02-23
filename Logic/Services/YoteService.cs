using AutoMapper;
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
            return null;
        }
        public async Task<List<YoteDTO>> GetYotes()
        {
            return null;
        }
        public async Task<YoteDTO> DeleteYote(Guid id)
        {
            return null;
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
        }
    }
}
