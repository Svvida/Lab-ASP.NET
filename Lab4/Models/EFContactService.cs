using Data;

namespace Lab4.Models
{
    public class EFContactService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EFContactService(AppDbContext employeeService)
        {
            _context = employeeService;
        }

        public void AddEmployee(EmployeeModel employee)
        {
            _context.Contacts.Add(ContactMapper.toEntity(employee));
            _context.SaveChanges();
        }

        public void DeleteEmployee(int employeeid)
        {
            var entity = _context.Contacts.Find(id);
            if(entity != null)
            {
                _context.Contacts.Remove(entity);
                _context.SaveChanges();
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            return (IEnumerable<EmployeeModel>)_context.Contacts.Select(e => ContactMapper.FromEntity(e)).ToList();
        }

        public EmployeeModel? GetEmployeeById(int employeeid)
        {
            var entity = _context.Contacts.Find(employeeid);
            if(entity != null)
            {
                return (EmployeeModel?)ContactMapper.FromEntity(_context.Contacts.Find(employeeid));
            } else return null;
                
        }

        public void UpdateEmployee(int id, EmployeeModel employee)
        {
            _context.Contacts.Update(ContactMapper.toEntity(employee));
            _context.SaveChanges();
        }

        public List<EmployeeModel> FindAll()
        {
            return _context.Contacts.Select(e => ContactMapper.FromEntity(e)).ToList();
        }
    }
}
