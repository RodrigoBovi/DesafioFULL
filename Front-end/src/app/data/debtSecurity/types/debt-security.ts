import { DebtInstallment } from '../../debtInstallment/types/debt-installment';

export class DebtSecurity {   
    debtorName: string;
    debtorCPF: string;
    interestPercent: number;
    penaltyPercent: number;
    debtInstallments: DebtInstallment[];
    userId: number;

    constructor(init?: Required<DebtSecurity>) {
        Object.assign(this, init);
    }
}
