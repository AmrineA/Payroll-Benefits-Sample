import { Component, Inject, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee.model';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Dependent } from '../../models/dependent.model';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'dependent',
    templateUrl: './dependent.component.html',
    providers: [EmployeeService]
})
export class DependentComponent implements OnInit {
    dependent: Dependent;
    employeeId: number;
    id: number;
    depForm: FormGroup;

    constructor(private employeeService: EmployeeService, private route: ActivatedRoute,
        private fb: FormBuilder, private router: Router, private toastr: ToastrService) {
    }

    ngOnInit() {
        this.route.params.subscribe(p => {
            this.employeeId = +p['employeeId'];
            this.id = +p['id'];
            if (this.id > 0) {
                this.employeeService.getDependent(this.employeeId, this.id).subscribe(d => {
                    this.dependent = d;
                    this.depForm = this.fb.group({
                        'firstName': [this.dependent.firstName, Validators.required],
                        'lastName': [this.dependent.lastName, Validators.required],
                        'age': [this.dependent.age, Validators.required]
                    });
                });
            } else {
                this.dependent = new Dependent(this.employeeId);
                this.depForm = this.fb.group({
                    'firstName': [this.dependent.firstName, Validators.required],
                    'lastName': [this.dependent.lastName, Validators.required],
                    'age': [this.dependent.age, Validators.required]
                });
            }
        });
    }

    save() {
        this.dependent.firstName = this.depForm.value.firstName;
        this.dependent.lastName = this.depForm.value.lastName;
        this.dependent.age = this.depForm.value.age;
        if (this.id == 0) {
            this.employeeService.createDependent(this.employeeId, this.dependent).subscribe(() => {
                this.toastr.success('Success', 'Dependent created successfully');
                this.router.navigate(['/employees', this.employeeId]);
            });
        } else {
            this.employeeService.updateDependent(this.employeeId, this.id, this.dependent).subscribe(() => {
                this.toastr.success('Success', 'Dependent saved successfully');
                this.router.navigate(['/employees', this.employeeId]);
            });
        }
    }
}
