using I3B_Dapper_Svatoš.Data;
using I3B_Dapper_Svatoš.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I3B_Dapper_Svatoš.Services
{
    internal class MediaTypeService
    {
        private MediaTypeRepository _mediaTypeRepository;
        public MediaTypeService(MediaTypeRepository mediaTypeRepository)
        {
            _mediaTypeRepository = mediaTypeRepository;
        }
        public List<MediaType> GetAll()
        {
            return _mediaTypeRepository.GetAll();
        }

    }
}
