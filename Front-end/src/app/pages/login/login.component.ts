import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/data/user/types/user';

import { AuthenticationService } from '../../_helpers/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  isLoading = false;
  loginForm: FormGroup;

  constructor(
    private authService: AuthenticationService,
    private formBuilder: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.createForm();
  }

  getControl(field: string): AbstractControl {
    return this.loginForm.get(field);
  }

  isFieldInvalid(field: string): boolean {
    return (
      (!this.getControl(field).valid && this.getControl(field).touched) ||
      (this.getControl(field).untouched)
    );
  }

  onSubmit() {
    if (!this.isValidForm()) {
      return;
    }

    this.authenticate();
  }

  private authenticate() {
    this.setLoading(true);
    this.authService.login(new User(this.loginForm.value)).subscribe(
      data => {
        this.setLoading(false);
        this.router.navigate(['/titles']);
      },
      error => {
        this.setLoading(false);
      }
    );
  }

  private createForm() {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  private isValidForm(): boolean {
    let isValid = true;

    if (this.loginForm.invalid) {
      isValid = false;
    }

    return isValid;
  }

  private setLoading(loading: boolean) {
    this.isLoading = loading;
  }
}
