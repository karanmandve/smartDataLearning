import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LifecycleHooksComponent } from './lifecycle-hooks.component';

describe('LifecycleHooksComponent', () => {
  let component: LifecycleHooksComponent;
  let fixture: ComponentFixture<LifecycleHooksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LifecycleHooksComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LifecycleHooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
