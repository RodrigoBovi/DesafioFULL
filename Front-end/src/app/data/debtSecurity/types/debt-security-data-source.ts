export interface DebtSecurityDataSource {
    debtSecurityId: number,
    debtorName: string,
    numberInstallments: number,
    originalValue: number,
    daysOverdue: number,
    updatedAmount: number
}
