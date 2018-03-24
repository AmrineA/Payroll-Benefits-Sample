import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Employee } from '../models/employee.model';
import { Dependent } from '../models/dependent.model';
import { PaySummaryItem } from '../models/paySummary.model';

@Injectable()
export class EmployeeService {

    constructor(private client: HttpClient) { }

    getAll(): Observable<Employee[]> {
        return this.client.get<Employee[]>('api/Employees');
    }

    get(id: number): Observable<Employee> {
        return this.client.get<Employee>(`api/Employees/${id}`);
    }

    getPaySummary(id: number): Observable<PaySummaryItem[]> {
        return this.client.get<PaySummaryItem[]>(`api/Employees/${id}/PaySummary`);
    }

    delete(id: number) {
        return this.client.delete(`api/Employees/${id}`);
    }

    create(employee: Employee): Observable<Employee> {
        return this.client.post<Employee>('api/Employees', employee);
    }

    update(id: number, employee: Employee) {
        return this.client.put(`api/Employees/${id}`, employee);
    }

    getAllDependents(employeeId: number): Observable<Dependent[]> {
        return this.client.get<Dependent[]>(`api/Employees/${employeeId}/Dependents`);
    }

    getDependent(employeeId: number, id: number): Observable<Dependent> {
        return this.client.get<Dependent>(`api/Employees/${employeeId}/Dependents/${id}`);
    }

    deleteDependent(employeeId: number, id: number) {
        return this.client.delete(`api/Employees/${employeeId}/Dependents/${id}`);
    }

    createDependent(employeeId: number, dependent: Dependent): Observable<Dependent> {
        return this.client.post<Dependent>(`api/Employees/${employeeId}/Dependents`, dependent);
    }

    updateDependent(employeeId: number, id: number, dependent: Dependent) {
        return this.client.put(`api/Employees/${employeeId}/Dependents/${id}`, dependent);
    }
}
