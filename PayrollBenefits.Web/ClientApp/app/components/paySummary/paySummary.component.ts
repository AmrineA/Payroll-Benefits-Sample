import { Component, Inject, OnInit } from '@angular/core';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee.model';
import { PaySummaryItem } from '../../models/paySummary.model';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'pay-summary',
    templateUrl: './paySummary.component.html',
    providers: [EmployeeService]
})
export class PaySummaryComponent implements OnInit {
    paySummary: PaySummaryItem[];
    employee: Employee;

    constructor(private employeeService: EmployeeService, private route: ActivatedRoute) {
    }

    ngOnInit() {
        this.route.params.subscribe(p => {
            this.employeeService.get(+p['id']).subscribe(e => this.employee = e);
            this.employeeService.getPaySummary(+p['id']).subscribe(ps => this.paySummary = ps);
        });
        
    }
}
