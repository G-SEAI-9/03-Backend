var employees = new List<Employee>
{
    new Employee
    {
        Id = 1,
        Name = "Aisha",
        Department = "Engineering",
    },
    new Employee
    {
        Id = 2,
        Name = "Jonas",
        Department = "Design",
    },
    new Employee
    {
        Id = 3,
        Name = "Priya",
        Department = "Engineering",
    },
    new Employee
    {
        Id = 4,
        Name = "Luca",
        Department = "Marketing",
    },
};

var assignments = new List<ProjectAssignment>
{
    new ProjectAssignment { EmployeeId = 1, Project = "Website Redesign" },
    new ProjectAssignment { EmployeeId = 1, Project = "Payment Gateway" },
    new ProjectAssignment { EmployeeId = 2, Project = "Website Redesign" },
    new ProjectAssignment { EmployeeId = 3, Project = "Data Migration" },
    new ProjectAssignment { EmployeeId = 4, Project = "Social Media Campaign" },
};
