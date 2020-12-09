﻿using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class MembersService : IMembersService
    {
        private IMembersRepository _membersRepo;
        public MembersService(IMembersRepository memberRepo)
        {
            _membersRepo = memberRepo;
        }

        public void AddMember(MemberViewModel m)
        {
            Member newMember = new Member()
            {
                Email = m.Email,
                FirstName = m.FirstName,
                LastName = m.LastName
            };

            _membersRepo.AddMember(newMember);
        }
    }
}
