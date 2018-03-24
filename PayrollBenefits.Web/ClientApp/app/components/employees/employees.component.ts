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
        this.employeeService.getAll().subscribe(e => this.employees = e);
    }
}
