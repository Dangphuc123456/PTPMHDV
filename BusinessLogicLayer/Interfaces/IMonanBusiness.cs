﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public partial interface IMonanBusiness
    {
        MonanModel GetDatabyID(string Mamonan);
        bool Create(MonanModel monan);
        bool Update(MonanModel model);
        bool Delete(MonanModel model);
    }
}
