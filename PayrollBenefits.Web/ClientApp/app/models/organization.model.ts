export class Organization {
    name: string;
    paychecksPerYear: number;
    employeeBenefitsCost: number;
    dependentBenefitsCost: number;
    constructor() {
        this.name = '';
        this.paychecksPerYear = 0;
        this.employeeBenefitsCost = 0;
        this.dependentBenefitsCost = 0;
    }
}