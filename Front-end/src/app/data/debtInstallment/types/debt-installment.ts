export class DebtInstallment {
    dueDate: Date;
    installmentAmount: string;

    constructor(init?: Required<DebtInstallment>) {
        Object.assign(this, init);
    }
}
