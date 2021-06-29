import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from '../../../../environments/environment';
import { DebtSecurity } from '../types/debt-security';
import { DebtSecurityDataSource } from '../types/debt-security-data-source';

@Injectable({
  providedIn: 'root'
})
export class DebtSecurityService {

  constructor(
    private http: HttpClient
  ) { }

  getUserDebtSecurities(userId: number): Observable<DebtSecurityDataSource[]> {
    return this.http.get(`${environment.baseUrlApi}DebtSecurity/GetUserDebtSecurities?userId=${userId}`).pipe(
      map((data:DebtSecurityDataSource[]) => {
        return data;
      }
    ));
  }

  createDebtSecurity(debtSecurity: DebtSecurity): Observable<DebtSecurityDataSource[]> {
    return this.http.post(`${environment.baseUrlApi}DebtSecurity/CreateDebtSecurity`, debtSecurity).pipe(
      map((data:DebtSecurityDataSource[]) => {
        return data;
      }
    ));
  }
}
