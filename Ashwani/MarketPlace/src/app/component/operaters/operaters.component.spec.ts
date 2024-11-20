import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OperatersComponent } from './operaters.component';

describe('OperatersComponent', () => {
  let component: OperatersComponent;
  let fixture: ComponentFixture<OperatersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OperatersComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OperatersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
