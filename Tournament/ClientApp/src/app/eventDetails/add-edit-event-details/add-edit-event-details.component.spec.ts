import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditEventDetailsComponent } from './add-edit-event-details.component';

describe('AddEditEventDetailsComponent', () => {
  let component: AddEditEventDetailsComponent;
  let fixture: ComponentFixture<AddEditEventDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditEventDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditEventDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
