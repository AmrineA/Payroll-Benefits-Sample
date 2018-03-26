import { Component, Inject, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee.model';

@Component({
    selector: 'employees',
    templateUrl: './employees.component.html',
    providers: [EmployeeService]
})
export class EmployeesComponent implements OnInit {
    employees: Employee[];

    constructor(private employeeService: EmployeeService) {
    }

    ngOnInit() {
        this.loadEmployees();
    }

    delete(id: number) {
        if (confirm(`Are you sure you want to delete employee with ID ${id}?`))
            this.employeeService.delete(id).subscribe(() => {
                this.loadEmployees();
            });
    }

    loadEmployees() {
        this.employeeService.getAll().subscribe(e => this.employees = e);
    }
}
