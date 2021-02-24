using Data.Models;
using Logic.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IYoteService
    {
        Task<YoteDTO> CreateYote(CreateYoteDTO createYoteDTO);
        Task<YoteDTO> GetYote(Guid id);
        Task<List<YoteDTO>> GetYotes();
        Task<YoteDTO> DeleteYote(Guid id);
        Task<YoteDTO> DeactivateYote(Guid id);
        Task<YoteDTO> UpdateYote(Guid id, UpdateYoteDTO yoteDTO);
    }
}
