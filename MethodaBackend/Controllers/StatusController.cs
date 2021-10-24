using DALContracts;
using Microsoft.AspNetCore.Mvc;
using ProjectContracts;
using ProjectDTO;

namespace MethodaBackend.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private IStatus m_StatusService;

        public StatusController (IStatus i_StatusService, IDAL i_DAL)
        {
            m_StatusService = i_StatusService;
            m_StatusService.DALServices = i_DAL;
        }

        [HttpPost]
        public bool AddNewStatus([FromBody] string i_StatusDetails)
        {
            bool isStatusAddedSuccessfully = false;
            if(!m_StatusService.IsStatusExist(i_StatusDetails))
            {
                isStatusAddedSuccessfully = m_StatusService.AddNewStatus(i_StatusDetails);
            }
            return isStatusAddedSuccessfully;
        }

        [HttpPost]
        public bool RemoveStatus([FromBody] string i_StatusDetails)
        {
            bool isStatusAddedSuccessfully = false;
            if (!m_StatusService.IsStatusExist(i_StatusDetails))
            {
                isStatusAddedSuccessfully = m_StatusService.DeleteExistStatus(i_StatusDetails);
            }
            return isStatusAddedSuccessfully;
        }
        [HttpGet]
        public StatusDTO[] GetAllStatuses()
        {
            return m_StatusService.GetAllStatuses();
        }
    }
}
