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
        public async Task<YoteDTO> CreateYote(CreateYoteDTO createYoteDTO)
        {
            //return await;
            return null;
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
}
