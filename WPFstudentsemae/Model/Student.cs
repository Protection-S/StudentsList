    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace WPFstudentsemae.Model
    {
        public class Student
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Patronymic { get; set; }
            public GenderType Gender { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string Group { get; set; }
        }

        public enum GenderType
        {
            Male,
            Female
        }
    }
