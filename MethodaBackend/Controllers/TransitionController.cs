using DALContracts;
using Microsoft.AspNetCore.Mvc;
using ProjectContracts;
using ProjectDTO;

namespace MethodaBackend.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class TransitionController : ControllerBase
    {

        private ITransition m_TransitionService;

        public TransitionController(ITransition i_TransitionService, IDAL i_DAL)
        {
            m_TransitionService = i_TransitionService;
            m_TransitionService.DALServices = i_DAL;
        }

        [HttpPost]
        public bool AddNewTransition([FromBody] TransitionDTO i_TransitionDetails)
        {
            bool isStatusAddedSuccessfully = false;
            if (!m_TransitionService.IsTransitionExist(i_TransitionDetails))
            {
                isStatusAddedSuccessfully = m_TransitionService.AddNewTransition(i_TransitionDetails);
            }
            return isStatusAddedSuccessfully;
        }

        [HttpPost]
        public bool RemoveTransition([FromBody] TransitionDTO i_TransitionDetails)
        {
            bool isStatusAddedSuccessfully = false;
            if (m_TransitionService.IsTransitionExist(i_TransitionDetails))
            {
                isStatusAddedSuccessfully = m_TransitionService.DeleteExistTransition(i_TransitionDetails);
            }
            return isStatusAddedSuccessfully;
        }
    }
}
