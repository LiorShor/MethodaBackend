﻿using System;

namespace ProjectContracts
{
    public interface IStatus
    {
        public bool AddNewStatus(string i_StatusName);
        public bool IsStatusExist(string i_StatusName);
        public bool DeleteExistStatus(string i_StatusName);
    }
}
