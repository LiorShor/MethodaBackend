using ProjectDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectContracts
{
    public interface ITransition
    {
        public bool AddNewTransition(TransitionDTO i_TransitionDetails);
        public bool DeleteExistTransition(TransitionDTO i_TransitionDetails);
        public bool IsTransitionExist(TransitionDTO i_TransitionDetails);
    }
}
