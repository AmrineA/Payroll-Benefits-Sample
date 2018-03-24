export class Employee {
    id: number;
    firstName: string;
    lastName: string;
    age: number;
    grossPay: number;
    constructor() {
        this.firstName = '';
        this.lastName = '';
        this.age = null;
        this.grossPay = null;
        this.id = 0;
    }
}