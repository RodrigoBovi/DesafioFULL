import { Component, Input, OnInit } from '@angular/core';

import { ngxLoadingAnimationTypes } from 'ngx-loading';

@Component({
  selector: 'app-custom-loading',
  templateUrl: './custom-loading.component.html',
  styleUrls: ['./custom-loading.component.css']
})
export class CustomLoadingComponent implements OnInit {

  @Input() isLoading = false;
  @Input() isSubmited = false;

  config: any;

  constructor() { }

  ngOnInit(): void {
    this.initConfig();
  }

  private initConfig() {
    this.config = {
      animationType: ngxLoadingAnimationTypes.none,
      primaryColour: '#fff',
      secondaryColour: '#ccc',
      tertiaryColour: '#fff',
      backdropBorderRadius: '3px'
    };
  }
}
