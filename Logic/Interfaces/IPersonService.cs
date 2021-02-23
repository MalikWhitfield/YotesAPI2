using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IPersonService
    {
        Task<YoteDTO> CreateYote(CreateYoteDTO createYoteDTO);
        Task<YoteDTO> GetYote(Guid id);
        Task<List<YoteDTO>> GetYotes();
        Task<YoteDTO> DeleteYote(Guid id);
        Task<YoteDTO> UpdateYote(YoteDTO yoteDTO);
    }
}
