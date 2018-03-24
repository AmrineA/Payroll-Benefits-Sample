import { Component, ViewChild } from '@angular/core';
import { OrganizationService } from '../../services/organization.service';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { Organization } from '../../models/organization.model';
import { NgForm, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'organization',
    templateUrl: './organization.component.html',
    providers: [OrganizationService]
})
export class OrganizationComponent implements OnInit {
    orgForm: FormGroup;
    organization: Organization;
    constructor(private orgService: OrganizationService, private fb: FormBuilder,
    private router: Router) {
    }

    ngOnInit() {
        this.orgService.get().subscribe(org => {
            this.organization = org;
            this.orgForm = this.fb.group({
                'name': [org.name, Validators.required],
                'paychecksPerYear': [org.paychecksPerYear, Validators.required],
                'employeeBenefitsCost': [org.employeeBenefitsCost, Validators.required],
                'dependentBenefitsCost': [org.dependentBenefitsCost, Validators.required]
            });
        });
    }

    save() {
        alert(1);
        this.organization.name = this.orgForm.value.name;
        this.organization.paychecksPerYear = this.orgForm.value.paychecksPerYear;
        this.organization.employeeBenefitsCost = this.orgForm.value.employeeBenefitsCost;
        this.organization.dependentBenefitsCost = this.orgForm.value.dependentBenefitsCost;
        this.orgService.update(this.organization).subscribe(() => this.router.navigate(['/home']));
    }
}
