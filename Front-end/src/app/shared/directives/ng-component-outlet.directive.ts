import { ComponentFactoryResolver, ComponentRef, Directive, Input, NgModuleRef, OnChanges, OnDestroy, SimpleChanges, Type, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[appNgComponentOutlet]', exportAs: 'ngComponentOutlet'
})
export class NgComponentOutletDirective<TComponent> implements OnChanges, OnDestroy {

  @Input() appNgComponentOutlet: Type<any>;

  private _componentRef: ComponentRef<TComponent> = null;
  private _moduleRef: NgModuleRef<any> = null;

  constructor(private _viewContainerRef: ViewContainerRef) { }

  public get component(): TComponent {
    if (!this._componentRef) {
      return null;
    }

    return this._componentRef.instance;
  }

  ngOnChanges(changes: SimpleChanges) {
    if (this._componentRef) {
      this._viewContainerRef.remove(this._viewContainerRef.indexOf(this._componentRef.hostView));
    }
    this._viewContainerRef.clear();
    this._componentRef = null;

    if (this.appNgComponentOutlet) {
      let injector = this._viewContainerRef.parentInjector;

      if (this._moduleRef) {
        injector = this._moduleRef.injector;
      }

      let componentFactory =
          injector.get(ComponentFactoryResolver).resolveComponentFactory(this.appNgComponentOutlet);

      this._componentRef = this._viewContainerRef.createComponent(
          componentFactory, this._viewContainerRef.length, injector, null);
    }
  }

  ngOnDestroy() {
    if (this._moduleRef) this._moduleRef.destroy();
  }
}
