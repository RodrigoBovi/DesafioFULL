import { Component, OnInit } from '@angular/core';

import { AuthenticationService } from '../../_helpers/authentication.service';

@Component({
  selector: 'app-toolbar',
  templateUrl: './toolbar.component.html',
  styleUrls: ['./toolbar.component.css']
})
export class ToolbarComponent implements OnInit {

  constructor(
    private authService: AuthenticationService
  ) { }

  ngOnInit(): void {
  }

  onLogout() {
    this.authService.logout();
  }
}
