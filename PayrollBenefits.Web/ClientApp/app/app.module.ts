import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { OrganizationComponent } from './components/organization/organization.component';
import { EmployeesComponent } from './components/employees/employees.component';
import { BrowserModule } from '@angular/platform-browser';
import { EmployeeComponent } from './components/employee/employee.component';
import { DependentComponent } from './components/dependent/dependent.component';
import { PaySummaryComponent } from './components/paySummary/paySummary.component';

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        NavMenuComponent,
        EmployeesComponent,
        EmployeeComponent,
        PaySummaryComponent,
        DependentComponent,
        OrganizationComponent,
        HomeComponent
    ],
    imports: [
        BrowserModule,
        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'organization', component: OrganizationComponent },
            { path: 'employees', component: EmployeesComponent },
            { path: 'employees/:id', component: EmployeeComponent },
            { path: 'employees/:id/paysummary', component: PaySummaryComponent },
            { path: 'employees/:employeeId/dependents/:id', component: DependentComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        HttpClient,
        { provide: 'BASE_URL', useFactory: getBaseUrl }
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}