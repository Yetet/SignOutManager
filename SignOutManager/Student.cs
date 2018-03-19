using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignOutManager
{
    /// <summary>
    /// Student class that contains the Student's Name and Reason for signing out.
    /// </summary>
    public class Student
    {
        public string Name { get; set; } = string.Empty;   // The Student's Name.
        public string Reason { get; set; } = string.Empty; // The Reason why the Student signed out.

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Student() { }

        /// <summary>
        /// Constructor override.
        /// </summary>
        /// <param name="name">This Student's Name property.</param>
        public Student(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Constructor override.
        /// </summary>
        /// <param name="name">This Student's Name property.</param>
        /// <param name="reason">This Student's Reason property.</param>
        public Student(string name, string reason)
        {
            Name = name;
            Reason = reason;
        }
    }
}
