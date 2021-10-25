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
        public void AddNewTransition([FromBody] TransitionDTO i_TransitionDetails)
        {
            if (!m_TransitionService.IsTransitionExist(i_TransitionDetails))
            {
                m_TransitionService.AddNewTransition(i_TransitionDetails);
            }
        }

        [HttpPost]
        public void RemoveTransition([FromBody] TransitionDTO i_TransitionDetails)
        {
            m_TransitionService.DeleteExistTransition(i_TransitionDetails);
        }

        [HttpPost]
        public TransitionDTO[] GetAllTransitions()
        {
            return m_TransitionService.GetAllTransitions();
        }
    }
}
