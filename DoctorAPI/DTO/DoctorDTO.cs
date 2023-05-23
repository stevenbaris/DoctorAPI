namespace DoctorAPI.DTO
{
    public class DoctorDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }

        public DoctorDTO() { }

        public DoctorDTO(string firstName, string lastName, string specialization)
        {
            FirstName = firstName;
            LastName = lastName;
            Specialization = specialization;
        }
    }
}
