import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupOfFormComponent } from './group-of-form.component';

describe('GroupOfFormComponent', () => {
  let component: GroupOfFormComponent;
  let fixture: ComponentFixture<GroupOfFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GroupOfFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GroupOfFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
