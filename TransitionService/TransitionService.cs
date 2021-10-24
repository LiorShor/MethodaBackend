using DALContracts;
using ProjectContracts;
using ProjectDTO;
using System;

namespace TransitionService
{
    public class TransitionService : ITransition
    {
        public IDAL DALServices { get; set; }
        public bool AddNewTransition(TransitionDTO i_TransitionDetails)
        {
            bool isStatusAddedSuccessfully;
            IParameter paramID = DALServices.CreateParameter("id", i_TransitionDetails.TransitionID);
            IParameter paramFrom = DALServices.CreateParameter("from", i_TransitionDetails.From);
            IParameter paramTo = DALServices.CreateParameter("to", i_TransitionDetails.To);
            try
            {
                DALServices.ExecuteNonQuery("AddNewTransition", paramID, paramFrom, paramTo);
                isStatusAddedSuccessfully = true;
            }
            catch (Exception)
            {
                isStatusAddedSuccessfully = false;
            }
            return isStatusAddedSuccessfully;
        }

        public bool DeleteExistTransition(TransitionDTO i_TransitionDetails)
        {
            bool isStatusDeletedSuccessfully = false;
            IParameter paramID = DALServices.CreateParameter("id", i_TransitionDetails.TransitionID);
            IParameter paramFrom = DALServices.CreateParameter("from", i_TransitionDetails.From);
            IParameter paramTo = DALServices.CreateParameter("to", i_TransitionDetails.To);
            if (IsTransitionExist(i_TransitionDetails))
            {
                try
                {
                    DALServices.ExecuteNonQuery("DeleteTransition", paramID, paramFrom, paramTo);
                    isStatusDeletedSuccessfully = true;
                }
                catch (Exception)
                {
                    isStatusDeletedSuccessfully = false;
                }
            }
            return isStatusDeletedSuccessfully;
        }

        public bool IsTransitionExist(TransitionDTO i_TransitionDetails)
        {
            bool isStatusExistInDatabase = false;
            var paramFrom = DALServices.CreateParameter("id", i_TransitionDetails.From);
            var paramTo = DALServices.CreateParameter("id", i_TransitionDetails.To);
            var dataset = DALServices.ExecuteQuery("IsTransitionExist", paramFrom, paramTo);
            if (dataset.Tables[0].Rows.Count != 0)
            {
                isStatusExistInDatabase = true;
            }
            return isStatusExistInDatabase;
        }
    }
}
