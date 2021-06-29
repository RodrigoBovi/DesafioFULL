import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { map } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { User } from '../data/user/types/user';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(
    private http: HttpClient,
    private router: Router
  ) { }

  getSession(): any {
    return JSON.parse(localStorage.getItem('user'));
  }

  login(user: User) {
    return this.http.post(`${environment.baseUrlApi}User/Authenticate`, user).pipe(
      map(user => {
        this.setSession(user);
        return user;
      })
    );
  }

  logout() {
    this.clearSession();
    this.router.navigate(['/login']);
  }

  private clearSession() {
    localStorage.removeItem('user');
  }

  private setSession(user: any) {
    localStorage.setItem('user', JSON.stringify(user));
  }
}
