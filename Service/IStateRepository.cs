﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sina_CSC_Project.Data;

namespace Sina_CSC_Project.Service
{
    public interface IStateRepository:IRepositoryBase<State>
    {
        ICollection<State> LoadStates(int CountryId);
    }
}
