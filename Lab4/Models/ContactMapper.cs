using Data.Entities;

namespace Lab4.Models
{
    public class ContactMapper
    {

        public static ContactEntity toEntity(EmployeeModel model)
        {
            return new ContactEntity()
            {
                ContactId = model.Id,
                Name = model.FirstName,
                Birth = model.HireDate,
                Email = model.LastName,
                Phone = model.Department
            };
        }

        public static EmployeeModel FromEntity(EmployeeModel entity)
        {
            return new EmployeeModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PESEL = entity.PESEL,
            };
        }
    }
}
