using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contribution.Classes
{
    internal class Member
    {
        private string _name;
        private DateTime _birthDate;
        private DateTime _joinDate;
        private bool _isPlaying;

        public string Name
        {
            get { return _name; }
            protected set { _name = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            protected set { _birthDate = value; }
        }

        public DateTime JoinDate
        {
            get { return _joinDate; }
            protected set { _joinDate = value; }
        }

        public bool IsPlaying
        {
            get { return _isPlaying; }
            protected set { _isPlaying = value; }
        }

        public Member(string name, DateTime birthDate, DateTime joinDate, bool isPlaying)
        {
            Name = name;
            BirthDate = birthDate.Date;
            JoinDate = joinDate.Date;
            IsPlaying = isPlaying;
        }
    }
}
