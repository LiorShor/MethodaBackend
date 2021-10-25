using DALContracts;
using ProjectDTO;

namespace ProjectContracts
{
    public interface ITransition
    {
        public bool AddNewTransition(TransitionDTO i_TransitionDetails);
        public bool DeleteExistTransition(TransitionDTO i_TransitionDetails);
        public bool IsTransitionExist(TransitionDTO i_TransitionDetails);

        public TransitionDTO[] GetAllTransitions();
        public IDAL DALServices { get; set; }
    }
}
