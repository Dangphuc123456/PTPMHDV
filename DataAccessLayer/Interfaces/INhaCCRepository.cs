﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public partial interface INhaccRepository
    {
        NhaCCModel GetDatabyID(string NhaCCID);
        bool Create(NhaCCModel model);
        bool Update(NhaCCModel model);
        public List<NhaCCModel> Search(int pageIndex, int pageSize, out long total, string TenNCC, string DiachiNCC);
    }
}