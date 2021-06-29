export class DebtInstallment {
    dueDate: Date;
    installmentAmount: number;

    constructor(init?: Required<DebtInstallment>) {
        Object.assign(this, init);
    }
}
