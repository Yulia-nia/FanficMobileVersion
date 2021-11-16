using FanficMobileVersion.Models;
using FanficMobileVersion.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FanficMobileVersion.Services
{
    public class FanficService
    {
        public FanficRepository _fanfic;

        public async Task<Fanfic> FanficById(int id)
        {
            return await _fanfic.GetFanfic(id);
        }

        public async Task<IEnumerable<Chapter>> AllChaptersInFanfic(int id)
        {
            return await _fanfic.GetAllChaptersInFanfic(id);
        }

        public async Task<List<Comment>> AllCommentsInFanfic(int id)
        {
            return await _fanfic.GetAllCommentsInFanfic(id);
        }

        public async Task<IEnumerable<Tag>> TegsInFanfic(int id)
        {
            return await _fanfic.GetTegs(id);
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _fanfic.GetCategory(id);
        }

        public async Task<int> UserFanficById(int id)
        {
            return await _fanfic.GetUserId(id);
        }

        public async Task<User> UserFanfic(int id)
        {
            return await _fanfic.GetUserFanfic(id);
        }
    }
}
