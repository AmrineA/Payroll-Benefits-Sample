import { Component, Inject, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee.model';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Dependent } from '../../models/dependent.model';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'employee',
    templateUrl: './employee.component.html',
    providers: [EmployeeService]
})
export class EmployeeComponent implements OnInit {
    employee: Employee;
    dependents: Dependent[];
    id: number;
    empForm: FormGroup;

    constructor(private employeeService: EmployeeService, private route: ActivatedRoute,
        private fb: FormBuilder, private router: Router, private toastr: ToastrService) {
    }

    ngOnInit() {
        this.route.params.subscribe(p => {
            this.id = +p['id'];
            if (this.id > 0) {
                this.employeeService.get(this.id).subscribe(e => {
                    this.employee = e;
                    this.empForm = this.fb.group({
                        'firstName': [this.employee.firstName, Validators.required],
                        'lastName': [this.employee.lastName, Validators.required],
                        'age': [this.employee.age, Validators.required],
                        'grossPay': [this.employee.grossPay, Validators.required]
                    });
                });
                this.loadDependents();
            } else {
                this.employee = new Employee();
                this.empForm = this.fb.group({
                    'firstName': [this.employee.firstName, Validators.required],
                    'lastName': [this.employee.lastName, Validators.required],
                    'age': [this.employee.age, Validators.required],
                    'grossPay': [this.employee.grossPay, Validators.required]
                });
            }
        });
    }

    save() {
        this.employee.firstName = this.empForm.value.firstName;
        this.employee.lastName = this.empForm.value.lastName;
        this.employee.age = this.empForm.value.age;
        this.employee.grossPay = this.empForm.value.grossPay;
        if (this.id == 0) {
            this.employeeService.create(this.employee).subscribe(() => {
                this.toastr.success('Success', 'Employee created successfully');
                this.router.navigate(['/employees']);
            });
        } else {
            this.employeeService.update(this.id, this.employee).subscribe(() => {
                this.toastr.success('Success', 'Employee saved successfully');
                this.router.navigate(['/employees']);
            });
        }
    }

    deleteDependent(dependentId: number) {
        if (confirm(`Are you sure you want to delete dependent with ID ${dependentId}?`))
            this.employeeService.deleteDependent(this.id, dependentId).subscribe(() => {
                this.toastr.success('Success', 'Dependent deleted successfully');
                this.loadDependents();
            });
    }

    loadDependents() {
        this.employeeService.getAllDependents(this.id).subscribe(d => this.dependents = d);
    }
}
