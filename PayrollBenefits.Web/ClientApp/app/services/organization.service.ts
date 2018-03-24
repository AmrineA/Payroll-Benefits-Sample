import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Organization } from '../models/organization.model';

@Injectable()
export class OrganizationService {

    constructor(private client: HttpClient) { }

    get(): Observable<Organization> {
        return this.client.get<Organization>('api/Organization');
    }

    update(organization: Organization) {
        return this.client.put('api/Organization', organization);
    }
}
