using ImdbData.Models;
using ImdbData.Repositories;
using ImdbData.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImdbService.Services
{
    public class CastRoleService 
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public int CastRoleGenerateCastRoleId(string castRoleType)
        {   
            CastRole _castRole = new CastRole();
            _castRole.castRoleName = castRoleType;
            //var castRoleRepository = new CastRoleRepository();
            //castRoleRepository.Insert(_castRole);

            unitOfWork.CastRoleRepository.Insert(_castRole);
            unitOfWork.Save();
            return _castRole.castRoleId;
        }
        public CastRole FindCastRole(string role)
        {
            //var castRepository = new CastRoleRepository();
            CastRole selectedMovie = new CastRole();
            //selectedMovie = castRepository.FindWithRole(x => x.castRoleName == role);
            selectedMovie = unitOfWork.CastRoleRepository.FindWithRole(x => x.castRoleName == role);
            return selectedMovie;
        }
    }
}
