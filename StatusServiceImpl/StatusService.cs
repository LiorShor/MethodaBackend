using DALContracts;
using ProjectContracts;
using ProjectDTO;
using System;

namespace StatusServiceImpl
{
    public class StatusService : IStatus
    {
        public IDAL DALServices { get; set; }
        public bool AddNewStatus(string i_StatusName)
        {
            bool isStatusAddedSuccessfully;
            IParameter paramStatusName = DALServices.CreateParameter("statusName", i_StatusName);
            try
            {
                DALServices.ExecuteNonQuery("AddNewStatus", paramStatusName);
                isStatusAddedSuccessfully = true;
            }
            catch (Exception)
            {
                isStatusAddedSuccessfully = false;
            }
            return isStatusAddedSuccessfully;
        }

        public bool DeleteExistStatus(string i_StatusName)
        {
            bool isStatusDeletedSuccessfully = false;
            IParameter paramStatusName = DALServices.CreateParameter("statusName", i_StatusName);
            if (IsStatusExist(i_StatusName))
            {
                try
                {
                    DALServices.ExecuteNonQuery("DeleteStatus", paramStatusName);
                    isStatusDeletedSuccessfully = true;
                }
                catch (Exception)
                {
                    isStatusDeletedSuccessfully = false;
                }
            }
            return isStatusDeletedSuccessfully;
        }

        public StatusDTO[] GetAllStatuses()
        {
            var dataset = DALServices.ExecuteQuery("GetAllStatuses");
            StatusDTO[] retval = new StatusDTO[dataset.Tables[0].Rows.Count];
            for (var i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                retval[i] = new StatusDTO();
                retval[i].statusName = (string)dataset.Tables[0].Rows[i]["statusName"];
            }
            return retval;
        }

        public bool IsStatusExist(string i_StatusName)
        {
            bool isStatusExistInDatabase = false;
            var paramStatusName = DALServices.CreateParameter("statusName", i_StatusName);
            var dataset = DALServices.ExecuteQuery("IsStatusExist", paramStatusName);
            if (dataset.Tables[0].Rows.Count != 0)
            {
                isStatusExistInDatabase = true;
            }
            return isStatusExistInDatabase;
        }
    }
}
