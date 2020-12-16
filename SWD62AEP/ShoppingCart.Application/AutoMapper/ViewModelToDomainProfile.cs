﻿using AutoMapper;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.AutoMapper
{
    public class ViewModelToDomainProfile:Profile
    {
        public ViewModelToDomainProfile()
        {
            //ProductViewModel >>> Product
            CreateMap<ProductViewModel, Product>()
                .ForMember(x=>x.Category, opt => opt.Ignore());
            
            //CategoryViewModel >> Category
            CreateMap<CategoryViewModel, Category>();
            
            CreateMap<MemberViewModel, Member>();
        }
    }
}
