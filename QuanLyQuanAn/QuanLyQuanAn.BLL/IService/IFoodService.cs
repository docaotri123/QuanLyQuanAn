﻿using QuanLyQuanAn.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn.BLL.IService
{
    public interface IFoodService
    {
        IEnumerable<Food> GetFoodByCategory(int? idCategory);
    }
}