export class Dependent {
    id: number;
    firstName: string;
    lastName: string;
    age: number;
    employeeId: number;
    constructor(employeeId: number) {
        this.firstName = '';
        this.lastName = '';
        this.age = null;
        this.employeeId = employeeId;
        this.id = 0;
    }
}