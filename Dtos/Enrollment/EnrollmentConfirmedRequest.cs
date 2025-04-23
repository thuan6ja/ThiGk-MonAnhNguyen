namespace NhuThuan_K2023_THIGK.Dtos.Enrollment
{
    public class EnrollmentConfirmedRequest
    {
        public Guid Id { get; set; }
        public bool Confirmed { get; set; } = false;
    }
}
