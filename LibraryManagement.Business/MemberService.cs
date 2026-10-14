using LibraryManagement.Data;
using LibraryManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement.Business
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _member;
        public MemberService(IMemberRepository member)
        {
            _member=member;
        }

        public List<Members> GetMembers()
        {
            return _member.GetMembers();
        }
    }
}
