using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contribution.Classes
{
    internal class Contract
    {
        private Member _member;

        public Member Member
        { 
            get { return _member; } 
            protected set { _member = value; }
        }

        public double Contribution()
        {
            double total = 0;

            total += (MemberAge() < 18 ? Club.JuniorFee : Club.SeniorFee);
            total += (Member.IsPlaying ? Club.PlayingFee : 0);
            total -= (MembershipDuration() < Club.YearsDiscount ? 0 : (total * Club.PercentDiscount) / 100);

            return total;
        }
        public float MembershipDuration()
        {
            var duration = 0;
            var today = DateTime.Today;
            duration = today.Year - Member.JoinDate.Year;
            if (Member.JoinDate > today.AddYears(-duration)) { duration--; }
            return duration;
        }

        public int MemberAge()
        {
            var age = 0;
            var today = DateTime.Today;
            age = today.Year - Member.BirthDate.Year;
            if(Member.BirthDate > today.AddYears(-age)) { age--; }
            return age;
        }

        public Contract(Member member)
        {
            Member = member;
            //Club.AddContract(this);
        }
    }
}
