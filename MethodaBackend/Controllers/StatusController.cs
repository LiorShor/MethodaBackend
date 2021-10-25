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
        public bool AddNewStatus([FromBody] StatusDTO i_StatusDetails)
        {
            bool isStatusAddedSuccessfully = false;
            if(!m_StatusService.IsStatusExist(i_StatusDetails.statusName))
            {
                isStatusAddedSuccessfully = m_StatusService.AddNewStatus(i_StatusDetails.statusName);
            }
            return isStatusAddedSuccessfully;
        }

        [HttpPost]
        public void RemoveStatus([FromBody] StatusDTO i_StatusDetails)
        {
            if (m_StatusService.IsStatusExist(i_StatusDetails.statusName))
            {
                m_StatusService.DeleteExistStatus(i_StatusDetails.statusName);
            }
        }
        [HttpPost]
        public StatusDTO[] GetAllStatuses()
        {
            return m_StatusService.GetAllStatuses();
        }
    }
}
